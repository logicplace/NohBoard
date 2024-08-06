/*
Copyright (C) 2016 by Eric Bataille <e.c.p.bataille@gmail.com>

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

namespace ThoNohT.NohBoard.Forms.Style
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Keyboard.Styles;
    using ThoNohT.NohBoard.Controls;
    using ThoNohT.NohBoard.Extra;

    /// <summary>
    /// The form used to update the style of a key.
    /// </summary>
    public partial class DirectInputDpadStyleForm : Form
    {
        #region Fields

        /// <summary>
        /// A backup style to return to if the user presses cancel.
        /// </summary>
        private readonly DirectInputDpadStyle initialStyle;

        /// <summary>
        /// The style to revert to if the overwrite checkbox is unchecked.
        /// </summary>
        private readonly DirectInputDpadStyle defaultStyle;

        /// <summary>
        /// The currently loaded style.
        /// </summary>
        private readonly DirectInputDpadStyle currentStyle;

        #endregion Fields

        #region Events

        /// <summary>
        /// The event that is invoked when the style has been changed. Only invoked when the style is changed through
        /// the user interface, not when it is changed programmatically.
        /// </summary>
        public new event Action<DirectInputDpadStyle> StyleChanged;

        /// <summary>
        /// The event that is invoked when the style is saved.
        /// </summary>
        public event Action StyleSaved;

        #endregion Events

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyStyleForm" /> class.
        /// </summary>
        /// <param name="initialStyle">The initial style.</param>
        /// <param name="defaultStyle">The default style to revert to when the override checkbox is unchecked.</param>
        public DirectInputDpadStyleForm(DirectInputDpadStyle initialStyle, DirectInputDpadStyle defaultStyle) {
            if (defaultStyle == null) throw new ArgumentNullException(nameof(defaultStyle));
            if (defaultStyle.SubStyle == null) throw new ArgumentNullException(nameof(defaultStyle));

            this.initialStyle = ((DirectInputDpadStyle)initialStyle?.Clone()) ?? new DirectInputDpadStyle {
                SubStyle = null
            };
            this.defaultStyle = (DirectInputDpadStyle)defaultStyle?.Clone();
            this.currentStyle = (DirectInputDpadStyle)this.initialStyle.Clone();

            this.InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the form, setting the controls to the initial style.
        /// </summary>
        private void DirectInputAxisStyleForm_Load(object sender, EventArgs e)
        {
            // Default Direct Input Axis styles.
            this.stylePanel.SubStyle = this.initialStyle?.SubStyle ?? this.defaultStyle.SubStyle;
            this.clrKeyboardBackground.Color = this.initialStyle?.ForegroundColor ?? this.defaultStyle.ForegroundColor;
            this.txtDpadImage.Text = this.initialStyle?.BackgroundNeutralImageFileName ?? this.defaultStyle.BackgroundNeutralImageFileName;
            this.txtTopImage.Text = this.initialStyle?.BackgroundTopImageFileName ?? this.defaultStyle.BackgroundTopImageFileName;
            this.txtBottomImage.Text = this.initialStyle?.BackgroundBottomImageFileName ?? this.defaultStyle.BackgroundBottomImageFileName;
            this.txtLeftImage.Text = this.initialStyle?.BackgroundLeftImageFileName ?? this.defaultStyle.BackgroundLeftImageFileName;
            this.txtRightImage.Text = this.initialStyle?.BackgroundRightImageFileName ?? this.defaultStyle.BackgroundRightImageFileName;
            this.txtBottomLeftImage.Text = this.initialStyle?.BackgroundBottomLeftImageFileName ?? this.defaultStyle.BackgroundBottomLeftImageFileName;
            this.txtBottomRightImage.Text = this.initialStyle?.BackgroundBottomRightImageFileName ?? this.defaultStyle.BackgroundBottomRightImageFileName;
            this.txtTopLeftImage.Text = this.initialStyle?.BackgroundTopLeftImageFileName ?? this.defaultStyle.BackgroundTopLeftImageFileName;
            this.txtTopRightImage.Text = this.initialStyle?.BackgroundTopRightImageFileName ?? this.defaultStyle.BackgroundTopRightImageFileName;
            this.chkDpadBackground.Checked = this.initialStyle?.DrawDpadBackground ?? this.defaultStyle.DrawDpadBackground;
            this.chkOverwriteDefaultStyle.Checked = this.currentStyle != null;

            // Only add the event handlers after the initial style has been set.
            this.stylePanel.StyleChanged += this.style_SubStyleChanged;
            this.clrKeyboardBackground.ColorChanged += this.style_KeyboardBackgroundChanged;
            this.txtDpadImage.TextChanged += this.txtDpadImage_TextChanged;
            this.txtBottomImage.TextChanged += this.txtBottomImage_TextChanged;
            this.txtTopImage.TextChanged += this.txtTopImage_TextChanged;
            this.txtLeftImage.TextChanged += this.txtLeftImage_TextChanged;
            this.txtRightImage.TextChanged += this.txtRightImage_TextChanged;
            this.txtBottomLeftImage.TextChanged += this.txtBottomLeftImage_TextChanged;
            this.txtBottomRightImage.TextChanged += this.txtBottomRightImage_TextChanged;
            this.txtTopLeftImage.TextChanged += this.txtTopLeftImage_TextChanged;
            this.txtTopRightImage.TextChanged += this.txtTopRightImage_TextChanged;
            this.chkOverwriteDefaultStyle.CheckStateChanged += this.chkOverwriteLoose_CheckedChanged;
            this.chkDpadBackground.CheckedChanged += this.chkAxisBackground_CheckedChanged;
        }

        private void style_KeyboardBackgroundChanged(ColorChooser sender, Color color) {
            this.currentStyle.ForegroundColor = color;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        /// <summary>
        /// Accepts the current style.
        /// </summary>
        private void AcceptButton2_Click(object sender, EventArgs e)
        {
            this.StyleSaved?.Invoke();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancels the current style, reverting to the initial style.
        /// </summary>
        private void CancelButton2_Click(object sender, EventArgs e)
        {
            this.StyleChanged?.Invoke(this.initialStyle);
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles change of the pressed style, sets the new style and invokes the changed event.
        /// </summary>
        /// <param name="style">The new style.</param>
        private void style_SubStyleChanged(KeySubStyle style)
        {
            this.currentStyle.SubStyle = style;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        /// <summary>
        /// Toggles the overwriting of the default style for loose keys.
        /// </summary>
        private void chkOverwriteLoose_CheckedChanged(object sender, EventArgs e)
        {
            this.stylePanel.Enabled = this.chkOverwriteDefaultStyle.Checked;

            if (this.chkOverwriteDefaultStyle.Checked)
            {
                this.stylePanel.SubStyle = this.initialStyle.SubStyle ?? this.defaultStyle.SubStyle;
            }
            else
            {
                this.currentStyle.SubStyle = null;
            }

            this.StyleChanged?.Invoke(this.currentStyle);
        }

        #endregion Methods

        private void txtDpadImage_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            this.currentStyle.BackgroundNeutralImageFileName = textBox.Text;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        private void txtLeftImage_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            this.currentStyle.BackgroundLeftImageFileName = textBox.Text;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        private void txtRightImage_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            this.currentStyle.BackgroundRightImageFileName = textBox.Text;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        private void txtTopImage_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            this.currentStyle.BackgroundTopImageFileName = textBox.Text;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        private void txtBottomImage_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            this.currentStyle.BackgroundBottomImageFileName = textBox.Text;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        private void txtBottomLeftImage_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            this.currentStyle.BackgroundBottomLeftImageFileName = textBox.Text;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        private void txtBottomRightImage_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            this.currentStyle.BackgroundBottomRightImageFileName = textBox.Text;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        private void txtTopLeftImage_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            this.currentStyle.BackgroundTopLeftImageFileName = textBox.Text;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        private void txtTopRightImage_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            this.currentStyle.BackgroundTopRightImageFileName = textBox.Text;
            this.StyleChanged?.Invoke(this.currentStyle);
        }

        private void chkAxisBackground_CheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = (CheckBox)sender;
            this.currentStyle.DrawDpadBackground = checkBox.Checked;
            this.StyleChanged?.Invoke(this.currentStyle);
        }
    }
}
