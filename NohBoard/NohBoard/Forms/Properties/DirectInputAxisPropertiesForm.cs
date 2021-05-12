/*
Copyright (C) 2017 by Eric Bataille <e.c.p.bataille@gmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace ThoNohT.NohBoard.Forms.Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Extra;
    using Keyboard.ElementDefinitions;
    using SharpDX.DirectInput;
    using ThoNohT.NohBoard.Hooking.Interop;

    public delegate void DataSetMethodInvokerString(string axis);

    /// <summary>
    /// The form used to update the properties of a keyboard key.
    /// </summary>
    public partial class DirectInputAxisPropertiesForm : Form
    {
        #region Fields

        /// <summary>
        /// A backup definition to return to if the user pressed cancel.
        /// </summary>
        private readonly DirectInputAxisDefinition initialDefinition;

        /// <summary>
        /// The currently loaded definition.
        /// </summary>
        private DirectInputAxisDefinition currentDefinition;

        /// <summary>
        /// Indicates whether we are currently detecting axis one being moved via the <see cref="Hooking.Interop.HookManager"/>.
        /// </summary>
        private bool detectingAxisOne;

        /// <summary>
        /// Indicates whether we are currently detecting axis two being moved via the <see cref="Hooking.Interop.HookManager"/>.
        /// </summary>
        private bool detectingAxisTwo;

        /// <summary>
        /// The joystick currently associated to this control
        /// </summary>
        private Joystick selectedJoystick = null;

        /// <summary>
        /// All of the devices currently connected to the machine
        /// </summary>
        private List<Joystick> devices = null;

        #endregion Fields

        #region Events

        /// <summary>
        /// The event that is invoked when the definition has been changed. Only invoked when the definition is changed
        /// through the user interface, not when it is changed programmatically.
        /// </summary>
        public event Action<DirectInputAxisDefinition> DefinitionChanged;

        /// <summary>
        /// The event that is invoked when the definition is saved.
        /// </summary>
        public event Action DefinitionSaved;

        #endregion Events

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectInputAxisPropertiesForm" /> class.
        /// </summary>
        public DirectInputAxisPropertiesForm(DirectInputAxisDefinition initialDefinition)
        {
            this.initialDefinition = initialDefinition;
            this.currentDefinition = (DirectInputAxisDefinition) initialDefinition.Clone();
            this.InitializeComponent();
        }

        /// <summary>
        /// Loads the form, setting the controls to the initial style.
        /// </summary>
        private void DirectInputAxisPropertiesForm_Load(object sender, EventArgs e)
        {
            this.txtText.Text = this.initialDefinition.Text;
            this.txtShiftText.Text = this.initialDefinition.ShiftText;
            this.txtTextPosition.X = this.initialDefinition.TextPosition.X;
            this.txtTextPosition.Y = this.initialDefinition.TextPosition.Y;
            this.lstBoundaries.Items.AddRange(this.initialDefinition.Boundaries.Cast<object>().ToArray());
            this.chkChangeOnCaps.Checked = this.initialDefinition.ChangeOnCaps;
            this.txtDeviceId.Text = this.initialDefinition.DeviceId.ToString();

            // Retrieves all of the currently available joysticks and lists them here
            this.devices = HookManager.GetCurrentlyActiveJoysticks();
            var data = new List<JoystickComboBoxItem>();
            data.Add(new JoystickComboBoxItem(Guid.Empty.ToString(), "No Device Selected"));

            foreach (var device in this.devices) {
                data.Add(new JoystickComboBoxItem(device.Information.ProductGuid.ToString(), device.Information.ProductName));
            }

            // Sets the other Joystick(s) values
            this.txtStickWidth.Text = this.initialDefinition.StickWidth.ToString();
            this.txtStickHeight.Text = this.initialDefinition.StickHeight.ToString();
            this.txtAxisOneMax.Text = this.initialDefinition.AxisOneMax.ToString();
            this.txtAxisTwoMax.Text = this.initialDefinition.AxisTwoMax.ToString();

            // Sets the Joystick Combobox DataSource
            this.comboBoxDevicesList.ValueMember = "ID";
            this.comboBoxDevicesList.DisplayMember = "Text";
            this.comboBoxDevicesList.DataSource = data;

            // If one of the currently available joysticks matches the ID of the currentDefinition, we take it as the currently selected one
            foreach (var joystick in this.devices) {
                if (joystick.Information.ProductGuid == this.currentDefinition.DeviceId) {
                    this.selectedJoystick = joystick;
                    this.comboBoxDevicesList.SelectedValue = joystick.Information.ProductGuid.ToString();
                    break;
                }
            }

            // Refreshes the Buttons dropdown
            RefreshFormOnJoystickChange();

            // Only add the event handlers after the initial properties have been set.
            this.lstBoundaries.SelectedIndexChanged += this.lstBoundaries_SelectedIndexChanged;
            this.txtText.TextChanged += this.txtText_TextChanged;
            this.txtTextPosition.ValueChanged += this.txtTextPosition_ValueChanged;
            this.txtShiftText.TextChanged += this.txtShiftText_TextChanged;
            this.chkChangeOnCaps.CheckedChanged += this.chkChangeOnCaps_CheckedChanged;
            this.txtDeviceId.TextChanged += this.txtDeviceId_TextChanged;
            this.comboBoxDevicesList.SelectedIndexChanged += this.comboBoxDevicesList_SelectedIndexChanged;
            this.cmbAxisOne.SelectedIndexChanged += this.cmbAxisOne_SelectedIndexChanged;
            this.cmbAxisTwo.SelectedIndexChanged += this.cmbAxisTwo_SelectedIndexChanged;
            this.txtAxisOneMax.TextChanged += this.txtAxisOneMax_TextChanged;
            this.txtAxisTwoMax.TextChanged += this.txtAxisTwoMax_TextChanged;
            this.txtStickWidth.TextChanged += this.txtStickWidth_TextChanged;
            this.txtStickHeight.TextChanged += this.txtStickHeight_TextChanged;
        }

        /// <summary>
        /// Refresh the status of the Buttons Combobox as well as the Detect button
        /// </summary>
        private void RefreshFormOnJoystickChange() {
            this.cmbAxisOne.DataSource = null;

            if (this.selectedJoystick == null) {
                cmbAxisOne.Enabled = false;
                btnDetectAxis1.Enabled = false;

                this.cmbAxisOne.Items.Clear();
                this.cmbAxisOne.Items.Add("Select a device first");
            } else {
                cmbAxisOne.Enabled = true;
                btnDetectAxis1.Enabled = true;

                var data1 = new List<JoystickComboBoxItem>();
                var data2 = new List<JoystickComboBoxItem>();
                for (var counter = 0; counter < 6; counter++) {
                    var enumDisplayStatus = (Hooking.DirectInputAxisNames)counter;
                    string stringValue = enumDisplayStatus.ToString();
                    data1.Add(new JoystickComboBoxItem(stringValue, string.Format("{0} Axis", stringValue)));
                    data2.Add(new JoystickComboBoxItem(stringValue, string.Format("{0} Axis", stringValue)));
                }

                this.cmbAxisOne.ValueMember = "ID";
                this.cmbAxisOne.DisplayMember = "Text";
                this.cmbAxisOne.DataSource = data1;
                this.cmbAxisOne.SelectedValue = this.currentDefinition.AxisOne;

                this.cmbAxisTwo.ValueMember = "ID";
                this.cmbAxisTwo.DisplayMember = "Text";
                this.cmbAxisTwo.DataSource = data2;
                this.cmbAxisTwo.SelectedValue = this.currentDefinition.AxisTwo;
            }
        }

        public void ChangeAxisOne(string axis) {
            this.cmbAxisOne.SelectedValue = axis;
            this.btnDetectAxis1.Text = "Detect Axis One";
            this.detectingAxisOne = false;
        }

        public void ChangeAxisTwo(string axis) {
            this.cmbAxisTwo.SelectedValue = axis;
            this.btnDetectAxis2.Text = "Detect Axis Two";
            this.detectingAxisTwo = false;
        }

        #region Boundaries

        /// <summary>
        /// Handles selecting an item in the boundaries list.
        /// </summary>
        private void lstBoundaries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstBoundaries.SelectedItem == null) return;

            this.txtBoundaries.X = ((TPoint) this.lstBoundaries.SelectedItem).X;
            this.txtBoundaries.Y = ((TPoint) this.lstBoundaries.SelectedItem).Y;
        }

        /// <summary>
        /// Handles adding a boundary, sets the new boundaries and invokes the changed event.
        /// </summary>
        private void btnAddBoundary_Click(object sender, EventArgs e)
        {
            var newBoundary = new TPoint(this.txtBoundaries.X, this.txtBoundaries.Y);
            if (this.lstBoundaries.Items.Cast<TPoint>().Any(p => p.X == newBoundary.X && p.Y == newBoundary.Y)) return;

            var newIndex = Math.Max(0, this.lstBoundaries.SelectedIndex);
            this.lstBoundaries.Items.Insert(newIndex, newBoundary);
            this.lstBoundaries.SelectedIndex = newIndex;

            this.currentDefinition =
                this.currentDefinition.Modify(boundaries: this.lstBoundaries.Items.Cast<TPoint>().ToList());
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles updating a boundary, sets the new boundaries and invokes the changed event.
        /// </summary>
        private void btnUpdateBoundary_Click(object sender, EventArgs e)
        {
            if (this.lstBoundaries.SelectedItem == null) return;

            var updateIndex = this.lstBoundaries.SelectedIndex;
            var newBoundary = new TPoint(this.txtBoundaries.X, this.txtBoundaries.Y);

            if (this.lstBoundaries.Items.Cast<TPoint>().Any(p => p.X == newBoundary.X && p.Y == newBoundary.Y)) return;

            this.lstBoundaries.Items.RemoveAt(updateIndex);
            this.lstBoundaries.Items.Insert(updateIndex, newBoundary);
            this.lstBoundaries.SelectedIndex = updateIndex;

            this.currentDefinition =
                this.currentDefinition.Modify(boundaries: this.lstBoundaries.Items.Cast<TPoint>().ToList());
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles removing a boundary, sets the new boundaries and invokes the changed event.
        /// </summary>
        private void btnRemoveBoundary_Click(object sender, EventArgs e)
        {
            if (this.lstBoundaries.SelectedItem == null) return;
            if (this.lstBoundaries.Items.Count < 4) return;

            var index = this.lstBoundaries.SelectedIndex;
            this.lstBoundaries.Items.Remove(this.lstBoundaries.SelectedItem);
            this.lstBoundaries.SelectedIndex = Math.Min(this.lstBoundaries.Items.Count - 1, index);

            this.currentDefinition =
                this.currentDefinition.Modify(boundaries: this.lstBoundaries.Items.Cast<TPoint>().ToList());
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles moving a boundary up in the list, sets the new boundaries and invokes the changed event.
        /// </summary>
        private void btnBoundaryUp_Click(object sender, EventArgs e)
        {
            var item = this.lstBoundaries.SelectedItem;
            var index = this.lstBoundaries.SelectedIndex;

            if (item == null || index == 0) return;

            this.lstBoundaries.Items.Remove(item);
            this.lstBoundaries.Items.Insert(index - 1, item);
            this.lstBoundaries.SelectedIndex = index - 1;

            this.currentDefinition =
                this.currentDefinition.Modify(boundaries: this.lstBoundaries.Items.Cast<TPoint>().ToList());
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles moving a boundary down in the list, sets the new boundaries and invokes the changed event.
        /// </summary>
        private void btnBoundaryDown_Click(object sender, EventArgs e)
        {
            var item = this.lstBoundaries.SelectedItem;
            var index = this.lstBoundaries.SelectedIndex;

            if (item == null || index == this.lstBoundaries.Items.Count - 1) return;

            this.lstBoundaries.Items.Remove(item);
            this.lstBoundaries.Items.Insert(index + 1, item);
            this.lstBoundaries.SelectedIndex = index + 1;

            this.currentDefinition =
                this.currentDefinition.Modify(boundaries: this.lstBoundaries.Items.Cast<TPoint>().ToList());
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles the click event of the "Rectangle" button, opens the dialog.
        /// </summary>
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            var rectangle = TRectangle.FromPointList(this.lstBoundaries.Items.Cast<TPoint>().ToArray());
            using (var rectangleForm = new RectangleBoundaryForm(rectangle))
            {
                rectangleForm.DimensionsSet += OnRectangleDimensionsSet;
                rectangleForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Called when the user clicks "Apply" in the rectangle dialog. Sets the new boundaries and invokes the changed event.
        /// </summary>
        private void OnRectangleDimensionsSet(TRectangle rectangle)
        {
            this.lstBoundaries.Items.Clear();
            this.lstBoundaries.Items.Add(rectangle.TopLeft);
            this.lstBoundaries.Items.Add(rectangle.TopRight);
            this.lstBoundaries.Items.Add(rectangle.BottomRight);
            this.lstBoundaries.Items.Add(rectangle.BottomLeft);

            this.currentDefinition =
                this.currentDefinition.Modify(boundaries: this.lstBoundaries.Items.Cast<TPoint>().ToList());
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        #endregion Boundaries

        #region KeyCodes

        /// <summary>
        /// Disables key-code detection, in case it was still active.
        /// </summary>
        private void KeyboardKeyPropertiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.btnDetectKeyCode.Text = "Detect";
            //Hooking.Interop.HookManager.KeyboardInsert = null;
        }

        #endregion KeyCodes

        /// <summary>
        /// Handles changing the text, sets the new text and invokes the changed event.
        /// </summary>
        private void txtText_TextChanged(object sender, EventArgs e)
        {
            this.currentDefinition = this.currentDefinition.Modify(text: this.txtText.Text);
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles changing the shift text, sets the new shift text and invokes the changed event.
        /// </summary>
        private void txtShiftText_TextChanged(object sender, EventArgs e)
        {
            this.currentDefinition = this.currentDefinition.Modify(shiftText: this.txtShiftText.Text);
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles changing the text position, sets the new text position and invokes the changed event.
        /// </summary>
        private void txtTextPosition_ValueChanged(Controls.VectorTextBox sender, TPoint newValue)
        {
            this.UpdateTextPosition();
        }

        private void txtDeviceId_TextChanged(object sender, EventArgs e) {
            this.currentDefinition = this.currentDefinition.Modify(deviceId: this.txtDeviceId.Text);
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles clicking of the "Center" button for the text location. Sets the input's value to the center of the button and updates the text.
        /// </summary>
        private void btnCenterText_Click(object sender, EventArgs e)
        {
            var bBox = this.currentDefinition.GetBoundingBox();
            var center = new TPoint((bBox.Left + bBox.Right) / 2, (bBox.Top + bBox.Bottom) / 2);

            this.txtTextPosition.X = center.X;
            this.txtTextPosition.Y = center.Y;

            this.UpdateTextPosition();
        }

        /// <summary>
        /// Takes the current text position input value, updates the current defifinition with it and invokes the change events.
        /// </summary>
        private void UpdateTextPosition()
        {
            var newPos = new TPoint(this.txtTextPosition.X, this.txtTextPosition.Y);

            this.currentDefinition = this.currentDefinition.Modify(textPosition: newPos);
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles changing the change on caps state, sets the new value and invokes the changed event.
        /// </summary>
        private void chkChangeOnCaps_CheckedChanged(object sender, EventArgs e)
        {
            this.currentDefinition = this.currentDefinition.Modify(changeOnCaps: this.chkChangeOnCaps.Checked);
            this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Accepts the current definition.
        /// </summary>
        private void AcceptButton2_Click(object sender, EventArgs e)
        {
            this.DefinitionSaved?.Invoke();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancels the current definition, reverting to the initial definition.
        /// </summary>
        private void CancelButton2_Click(object sender, EventArgs e)
        {
            this.DefinitionChanged?.Invoke(this.initialDefinition);
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Selects a different joystick from the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxDevicesList_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox comboBox = (ComboBox)sender;
            string selectedGuid = comboBox.SelectedValue.ToString();

            this.selectedJoystick = null;
            foreach (var joystick in this.devices) {
                if (joystick.Information.ProductGuid.ToString() == selectedGuid) {
                    this.selectedJoystick = joystick;
                    break;
                }
            }

            // Handles changing the device
            this.currentDefinition = this.currentDefinition.Modify(deviceId: selectedGuid);
            this.DefinitionChanged?.Invoke(this.currentDefinition);

            // Refreshes the Buttons dropdown
            RefreshFormOnJoystickChange();
        }

        /// <summary>
        /// Detects the first Axis being moved
        /// </summary>
        private void btnDetectButton_Click(object sender, EventArgs e) {
            this.detectingAxisOne = !this.detectingAxisOne;

            // If we just hit the Detect Button...
            if (this.detectingAxisOne) {
                // Change the label of the button
                this.btnDetectAxis1.Text = "Detecting...";

                // Wait for a button press
                Hooking.Interop.HookManager.DirectInputAxisInsert = (axis) => {

                    // Changes current definition
                    this.currentDefinition = this.currentDefinition.Modify(axisOne: axis);

                    if (Application.OpenForms["DirectInputAxisPropertiesForm"] != null) {
                        (Application.OpenForms["DirectInputAxisPropertiesForm"] as DirectInputAxisPropertiesForm).Invoke(new DataSetMethodInvokerString(ChangeAxisOne), axis);
                    }

                    return true;
                };
            } else {
                this.btnDetectAxis1.Text = "Detect Axis";
                Hooking.Interop.HookManager.DirectInputAxisInsert = null;
            }
        }

        private void cmbAxisOne_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedItem != null) {
                string axisName = ((JoystickComboBoxItem)comboBox.SelectedItem).ID;

                // Handles changing the button
                this.currentDefinition = this.currentDefinition.Modify(axisOne: axisName);
                this.DefinitionChanged?.Invoke(this.currentDefinition);
            }
        }

        private void btnDetectButton2_Click(object sender, EventArgs e) {
            this.detectingAxisTwo = !this.detectingAxisTwo;

            // If we just hit the Detect Button...
            if (this.detectingAxisTwo) {
                // Change the label of the button
                this.btnDetectAxis2.Text = "Detecting...";

                // Wait for a button press
                Hooking.Interop.HookManager.DirectInputAxisInsert = (axis) => {

                    // Changes current definition
                    this.currentDefinition = this.currentDefinition.Modify(axisTwo: axis);

                    if (Application.OpenForms["DirectInputAxisPropertiesForm"] != null) {
                        (Application.OpenForms["DirectInputAxisPropertiesForm"] as DirectInputAxisPropertiesForm).Invoke(new DataSetMethodInvokerString(ChangeAxisTwo), axis);
                    }

                    return true;
                };
            } else {
                this.btnDetectAxis2.Text = "Detect Axis";
                Hooking.Interop.HookManager.DirectInputAxisInsert = null;
            }

        }

        private void cmbAxisTwo_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedItem != null) {
                string axisName = ((JoystickComboBoxItem)comboBox.SelectedItem).ID;

                // Handles changing the button
                this.currentDefinition = this.currentDefinition.Modify(axisTwo: axisName);
                this.DefinitionChanged?.Invoke(this.currentDefinition);
            }
        }

        private void txtAxisOneMax_TextChanged(object sender, EventArgs e) {
            TextBox txtBox = (TextBox)sender;

            int value;
            bool result = int.TryParse(txtBox.Text, out value);

            if (result) {
                this.currentDefinition = this.currentDefinition.Modify(axisOneMax: value);
                this.DefinitionChanged?.Invoke(this.currentDefinition);
            }
        }

        private void txtAxisTwoMax_TextChanged(object sender, EventArgs e) {
            TextBox txtBox = (TextBox)sender;

            int value;
            bool result = int.TryParse(txtBox.Text, out value);

            if (result) {
                this.currentDefinition = this.currentDefinition.Modify(axisTwoMax: value);
                this.DefinitionChanged?.Invoke(this.currentDefinition);
            }
        }

        private void txtStickWidth_TextChanged(object sender, EventArgs e) {
            TextBox txtBox = (TextBox)sender;

            int value;
            bool result = int.TryParse(txtBox.Text, out value);

            if (result) {
                this.currentDefinition = this.currentDefinition.Modify(stickWidth: value);
                this.DefinitionChanged?.Invoke(this.currentDefinition);
            }
        }

        private void txtStickHeight_TextChanged(object sender, EventArgs e) {
            TextBox txtBox = (TextBox)sender;

            int value;
            bool result = int.TryParse(txtBox.Text, out value);

            if (result) {
                this.currentDefinition = this.currentDefinition.Modify(stickHeight: value);
                this.DefinitionChanged?.Invoke(this.currentDefinition);
            }
        }
    }
}
