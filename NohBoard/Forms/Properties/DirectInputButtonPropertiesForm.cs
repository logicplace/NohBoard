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

    /// <summary>
    /// The form used to update the properties of a keyboard key.
    /// </summary>
    public partial class DirectInputButtonPropertiesForm : Form
    {
        #region Fields

        /// <summary>
        /// A backup definition to return to if the user pressed cancel.
        /// </summary>
        private readonly DirectInputButtonDefinition initialDefinition;

        /// <summary>
        /// The currently loaded definition.
        /// </summary>
        private DirectInputButtonDefinition currentDefinition;

        /// <summary>
        /// Indicates whether we are currently detecting key pressed via the <see cref="Hooking.Interop.HookManager"/>.
        /// </summary>
        private bool detectingButtonNumber;

        /// <summary>
        /// Datasource for the Buttons Combobox
        /// </summary>
        public List<Item> comboBoxItems = new List<Item>();

        #endregion Fields

        #region Events

        /// <summary>
        /// The event that is invoked when the definition has been changed. Only invoked when the definition is changed
        /// through the user interface, not when it is changed programmatically.
        /// </summary>
        public event Action<DirectInputButtonDefinition> DefinitionChanged;

        /// <summary>
        /// The event that is invoked when the definition is saved.
        /// </summary>
        public event Action DefinitionSaved;

        #endregion Events

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectInputButtonPropertiesForm" /> class.
        /// </summary>
        public DirectInputButtonPropertiesForm(DirectInputButtonDefinition initialDefinition)
        {
            this.initialDefinition = initialDefinition;
            this.currentDefinition = (DirectInputButtonDefinition) initialDefinition.Clone();
            this.InitializeComponent();

            //comboBoxItems.Add(new Item("Button 1", 1));
            //comboBoxItems.Add(new Item("Button 2", 2));
            //comboBoxItems.Add(new Item("Button 3", 3));
            //comboBoxItems.Add(new Item("Button 4", 4));
            //comboBoxItems.Add(new Item("Button 5", 5));
            //comboBoxItems.Add(new Item("Button 6", 6));
            //comboBoxItems.Add(new Item("Button 7", 7));
            //comboBoxItems.Add(new Item("Button 8", 8));
            //comboBoxItems.Add(new Item("Button 9", 9));
            //comboBoxItems.Add(new Item("Button 10", 10));
            //comboBoxItems.Add(new Item("Button 11", 11));
            //comboBoxItems.Add(new Item("Button 12", 12));
            //comboBoxItems.Add(new Item("Button 13", 13));
            //comboBoxItems.Add(new Item("Button 14", 14));
            //comboBoxItems.Add(new Item("Button 15", 15));
            //comboBoxItems.Add(new Item("Button 16", 16));
            //comboBoxItems.Add(new Item("Button 17", 17));
            //comboBoxItems.Add(new Item("Button 18", 18));
            //comboBoxItems.Add(new Item("Button 19", 19));
            //comboBoxItems.Add(new Item("Button 20", 20));
            //comboBoxItems.Add(new Item("Button 21", 21));
            //comboBoxItems.Add(new Item("Button 22", 22));
            //comboBoxItems.Add(new Item("Button 23", 23));
            //comboBoxItems.Add(new Item("Button 24", 24));
            //comboBoxItems.Add(new Item("Button 25", 25));
            //comboBoxItems.Add(new Item("Button 26", 26));
            //comboBoxItems.Add(new Item("Button 27", 27));
            //comboBoxItems.Add(new Item("Button 28", 28));
            //comboBoxItems.Add(new Item("Button 29", 29));
            //comboBoxItems.Add(new Item("Button 30", 30));
            //comboBoxItems.Add(new Item("Button 31", 31));
            //comboBoxItems.Add(new Item("Button 32", 32));

            //this.cmbButtonNumber.DataSource = comboBoxItems;
            //this.cmbButtonNumber.DisplayMember = "Name";
            //this.cmbButtonNumber.ValueMember = "Id";

            this.cmbButtonNumber.Items.Add("Button 1");
            this.cmbButtonNumber.Items.Add("Button 2");
            this.cmbButtonNumber.Items.Add("Button 3");
            this.cmbButtonNumber.Items.Add("Button 4");
            this.cmbButtonNumber.Items.Add("Button 5");
            this.cmbButtonNumber.Items.Add("Button 6");
            this.cmbButtonNumber.Items.Add("Button 7");
            this.cmbButtonNumber.Items.Add("Button 8");
            this.cmbButtonNumber.Items.Add("Button 9");
        }

        /// <summary>
        /// Loads the form, setting the controls to the initial style.
        /// </summary>
        private void DirectInputButtonPropertiesForm_Load(object sender, EventArgs e)
        {
            this.txtText.Text = this.initialDefinition.Text;
            this.txtShiftText.Text = this.initialDefinition.ShiftText;
            this.txtTextPosition.X = this.initialDefinition.TextPosition.X;
            this.txtTextPosition.Y = this.initialDefinition.TextPosition.Y;
            this.lstBoundaries.Items.AddRange(this.initialDefinition.Boundaries.Cast<object>().ToArray());
            this.chkChangeOnCaps.Checked = this.initialDefinition.ChangeOnCaps;
            this.txtDeviceId.Text = this.initialDefinition.DeviceId.ToString();
            this.cmbButtonNumber.SelectedValue = this.initialDefinition.ButtonNumber;

            // Only add the event handlers after the initial properties have been set.
            this.lstBoundaries.SelectedIndexChanged += this.lstBoundaries_SelectedIndexChanged;
            this.txtText.TextChanged += this.txtText_TextChanged;
            this.txtTextPosition.ValueChanged += this.txtTextPosition_ValueChanged;
            this.txtShiftText.TextChanged += this.txtShiftText_TextChanged;
            this.chkChangeOnCaps.CheckedChanged += this.chkChangeOnCaps_CheckedChanged;
            this.txtDeviceId.TextChanged += this.txtDeviceId_TextChanged;
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
        /// Handles selecting an item in the boundaries list.
        /// </summary>
        private void txtButtonNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.lstKeyCodes.SelectedItem != null)
            //    this.udKeyCode.Value = Convert.ToInt32(this.lstKeyCodes.SelectedItem);
        }

        /// <summary>
        /// Handles adding a key code, sets the new key codes and invokes the changed event.
        /// </summary>
        private void btnAddKeyCode_Click(object sender, EventArgs e)
        {
            //var newVal = Convert.ToInt32(this.udKeyCode.Value);
            //if (this.lstKeyCodes.Items.Contains(newVal)) return;

            //this.lstKeyCodes.Items.Add(newVal);
            //this.lstKeyCodes.SelectedIndex = this.lstKeyCodes.Items.Count - 1;

            //this.currentDefinition =
            //    this.currentDefinition.Modify(keyCodes: this.lstKeyCodes.Items.Cast<int>().ToList());
            //this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Handles removing a key code, sets the new key codes and invokes the changed event.
        /// </summary>
        private void btnRemoveKeyCode_Click(object sender, EventArgs e)
        {
            //if (this.lstKeyCodes.SelectedItem == null) return;

            //var index = this.lstKeyCodes.SelectedIndex;
            //this.lstKeyCodes.Items.Remove(this.lstKeyCodes.SelectedItem);

            //this.lstKeyCodes.Items.Remove(this.lstKeyCodes.SelectedItem);
            //this.lstKeyCodes.SelectedIndex = Math.Min(this.lstKeyCodes.Items.Count - 1, index);

            //this.currentDefinition =
            //    this.currentDefinition.Modify(keyCodes: this.lstKeyCodes.Items.Cast<int>().ToList());
            //this.DefinitionChanged?.Invoke(this.currentDefinition);
        }

        /// <summary>
        /// Toggles the key-code detection.
        /// </summary>
        private void btnDetectKeyCode_Click(object sender, EventArgs e)
        {
            //this.detectingKeyCode = !this.detectingKeyCode;

            //if (this.detectingKeyCode)
            //{
            //    this.btnDetectKeyCode.Text = "Detecting...";
            //    Hooking.Interop.HookManager.KeyboardInsert = code =>
            //    {
            //        //this.udKeyCode.Value = code;
            //        return true;
            //    };
            //}
            //else
            //{
            //    this.btnDetectKeyCode.Text = "Detect";
            //    Hooking.Interop.HookManager.KeyboardInsert = null;
            //}
        }

        /// <summary>
        /// Detects the DirectInput button being presed
        /// </summary>
        private void btnDetectButton_Click(object sender, EventArgs e) {
            this.detectingButtonNumber = !this.detectingButtonNumber;

            if (this.detectingButtonNumber) {
                this.btnDetectButton.Text = "Detecting...";
                Hooking.Interop.HookManager.DirectInputButtonInsert = (code) => {
                    this.cmbButtonNumber.Text = code.ToString();
                    return true;
                };
            } else {
                this.btnDetectButton.Text = "Detect Button";
                Hooking.Interop.HookManager.DirectInputButtonInsert = null;
            }
        }

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

    }

    public class Item {
        public string _Name;
        public int _Id;

        public Item(string name, int id) {
            _Name = name;
            _Id = id;
        }

        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }
    }
}
