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
    using Controls;

    partial class DirectInputDpadStyleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			ThoNohT.NohBoard.Keyboard.Styles.KeySubStyle keySubStyle1 = new Keyboard.Styles.KeySubStyle();
			ThoNohT.NohBoard.Extra.SerializableColor serializableColor1 = new Extra.SerializableColor();
			ThoNohT.NohBoard.Extra.SerializableFont serializableFont1 = new Extra.SerializableFont();
			ThoNohT.NohBoard.Extra.SerializableColor serializableColor2 = new Extra.SerializableColor();
			ThoNohT.NohBoard.Extra.SerializableColor serializableColor3 = new Extra.SerializableColor();
			this.AcceptButton2 = new System.Windows.Forms.Button();
			this.CancelButton2 = new System.Windows.Forms.Button();
			this.chkOverwriteDefaultStyle = new System.Windows.Forms.CheckBox();
			this.stylePanel = new KeySubStylePanel();
			this.KeyboardGroup = new System.Windows.Forms.GroupBox();
			this.txtTopRightImage = new System.Windows.Forms.TextBox();
			this.lblTopRightImage = new System.Windows.Forms.Label();
			this.txtTopLeftImage = new System.Windows.Forms.TextBox();
			this.lblTopLeftImage = new System.Windows.Forms.Label();
			this.txtBottomRightImage = new System.Windows.Forms.TextBox();
			this.lblBottomRightImage = new System.Windows.Forms.Label();
			this.txtBottomLeftImage = new System.Windows.Forms.TextBox();
			this.lblBottomLeftImage = new System.Windows.Forms.Label();
			this.txtBottomImage = new System.Windows.Forms.TextBox();
			this.lblBottomImage = new System.Windows.Forms.Label();
			this.txtTopImage = new System.Windows.Forms.TextBox();
			this.lblTopImage = new System.Windows.Forms.Label();
			this.txtRightImage = new System.Windows.Forms.TextBox();
			this.lblRightImage = new System.Windows.Forms.Label();
			this.txtLeftImage = new System.Windows.Forms.TextBox();
			this.lblLeftImage = new System.Windows.Forms.Label();
			this.txtDpadImage = new System.Windows.Forms.TextBox();
			this.lblBackgroundImage = new System.Windows.Forms.Label();
			this.clrKeyboardBackground = new ColorChooser();
			this.chkDpadBackground = new System.Windows.Forms.CheckBox();
			this.KeyboardGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// AcceptButton2
			// 
			this.AcceptButton2.Location = new System.Drawing.Point(531, 387);
			this.AcceptButton2.Margin = new System.Windows.Forms.Padding(4);
			this.AcceptButton2.Name = "AcceptButton2";
			this.AcceptButton2.Size = new System.Drawing.Size(88, 26);
			this.AcceptButton2.TabIndex = 10;
			this.AcceptButton2.Text = "Accept";
			this.AcceptButton2.UseVisualStyleBackColor = true;
			this.AcceptButton2.Click += AcceptButton2_Click;
			// 
			// CancelButton2
			// 
			this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton2.Location = new System.Drawing.Point(436, 387);
			this.CancelButton2.Margin = new System.Windows.Forms.Padding(4);
			this.CancelButton2.Name = "CancelButton2";
			this.CancelButton2.Size = new System.Drawing.Size(88, 26);
			this.CancelButton2.TabIndex = 11;
			this.CancelButton2.Text = "Cancel";
			this.CancelButton2.UseVisualStyleBackColor = true;
			this.CancelButton2.Click += CancelButton2_Click;
			// 
			// chkOverwriteDefaultStyle
			// 
			this.chkOverwriteDefaultStyle.AutoSize = true;
			this.chkOverwriteDefaultStyle.Location = new System.Drawing.Point(16, 396);
			this.chkOverwriteDefaultStyle.Margin = new System.Windows.Forms.Padding(4);
			this.chkOverwriteDefaultStyle.Name = "chkOverwriteDefaultStyle";
			this.chkOverwriteDefaultStyle.Size = new System.Drawing.Size(144, 19);
			this.chkOverwriteDefaultStyle.TabIndex = 18;
			this.chkOverwriteDefaultStyle.Text = "Overwrite default style";
			this.chkOverwriteDefaultStyle.UseVisualStyleBackColor = true;
			// 
			// stylePanel
			// 
			this.stylePanel.Location = new System.Drawing.Point(14, 14);
			this.stylePanel.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.stylePanel.Name = "stylePanel";
			this.stylePanel.Size = new System.Drawing.Size(200, 382);
            serializableColor1.Blue = ((byte)(0));
            serializableColor1.Green = ((byte)(0));
            serializableColor1.Red = ((byte)(0));
			keySubStyle1.Background = serializableColor1;
			keySubStyle1.BackgroundImageFileName = "";
			serializableFont1.AlternateFontFamily = null;
			serializableFont1.DownloadUrl = null;
			serializableFont1.FontFamily = "Courier New";
			serializableFont1.Size = 10F;
			serializableFont1.Style = ThoNohT.NohBoard.Extra.SerializableFontStyle.Regular;
			keySubStyle1.Font = serializableFont1;
			serializableColor2.Blue = ((byte)(0));
			serializableColor2.Green = ((byte)(0));
			serializableColor2.Red = ((byte)(0));
			keySubStyle1.Outline = serializableColor2;
			keySubStyle1.OutlineWidth = 1;
			keySubStyle1.ShowOutline = false;
			serializableColor3.Blue = ((byte)(0));
			serializableColor3.Green = ((byte)(0));
			serializableColor3.Red = ((byte)(0));
			keySubStyle1.Text = serializableColor3;
			this.stylePanel.SubStyle = keySubStyle1;
			this.stylePanel.TabIndex = 12;
			this.stylePanel.Title = "Style";
			// 
			// KeyboardGroup
			// 
			this.KeyboardGroup.Controls.Add(this.txtTopRightImage);
			this.KeyboardGroup.Controls.Add(this.lblTopRightImage);
			this.KeyboardGroup.Controls.Add(this.txtTopLeftImage);
			this.KeyboardGroup.Controls.Add(this.lblTopLeftImage);
			this.KeyboardGroup.Controls.Add(this.txtBottomRightImage);
			this.KeyboardGroup.Controls.Add(this.lblBottomRightImage);
			this.KeyboardGroup.Controls.Add(this.txtBottomLeftImage);
			this.KeyboardGroup.Controls.Add(this.lblBottomLeftImage);
			this.KeyboardGroup.Controls.Add(this.txtBottomImage);
			this.KeyboardGroup.Controls.Add(this.lblBottomImage);
			this.KeyboardGroup.Controls.Add(this.txtTopImage);
			this.KeyboardGroup.Controls.Add(this.lblTopImage);
			this.KeyboardGroup.Controls.Add(this.txtRightImage);
			this.KeyboardGroup.Controls.Add(this.lblRightImage);
			this.KeyboardGroup.Controls.Add(this.txtLeftImage);
			this.KeyboardGroup.Controls.Add(this.lblLeftImage);
			this.KeyboardGroup.Controls.Add(this.txtDpadImage);
			this.KeyboardGroup.Controls.Add(this.lblBackgroundImage);
			this.KeyboardGroup.Controls.Add(this.clrKeyboardBackground);
			this.KeyboardGroup.Location = new System.Drawing.Point(223, 39);
			this.KeyboardGroup.Margin = new System.Windows.Forms.Padding(4);
			this.KeyboardGroup.Name = "KeyboardGroup";
			this.KeyboardGroup.Padding = new System.Windows.Forms.Padding(4);
			this.KeyboardGroup.Size = new System.Drawing.Size(396, 296);
			this.KeyboardGroup.TabIndex = 19;
			this.KeyboardGroup.TabStop = false;
			this.KeyboardGroup.Text = "Axis Circle";
			// 
			// txtTopRightImage
			// 
			this.txtTopRightImage.Location = new System.Drawing.Point(144, 266);
			this.txtTopRightImage.Margin = new System.Windows.Forms.Padding(4);
			this.txtTopRightImage.Name = "txtTopRightImage";
			this.txtTopRightImage.Size = new System.Drawing.Size(240, 23);
			this.txtTopRightImage.TabIndex = 20;
			// 
			// lblTopRightImage
			// 
			this.lblTopRightImage.Location = new System.Drawing.Point(7, 262);
			this.lblTopRightImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTopRightImage.Name = "lblTopRightImage";
			this.lblTopRightImage.Size = new System.Drawing.Size(136, 26);
			this.lblTopRightImage.TabIndex = 19;
			this.lblTopRightImage.Text = "Top Right Image:";
			this.lblTopRightImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTopLeftImage
			// 
			this.txtTopLeftImage.Location = new System.Drawing.Point(144, 240);
			this.txtTopLeftImage.Margin = new System.Windows.Forms.Padding(4);
			this.txtTopLeftImage.Name = "txtTopLeftImage";
			this.txtTopLeftImage.Size = new System.Drawing.Size(240, 23);
			this.txtTopLeftImage.TabIndex = 18;
			// 
			// lblTopLeftImage
			// 
			this.lblTopLeftImage.Location = new System.Drawing.Point(7, 236);
			this.lblTopLeftImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTopLeftImage.Name = "lblTopLeftImage";
			this.lblTopLeftImage.Size = new System.Drawing.Size(136, 26);
			this.lblTopLeftImage.TabIndex = 17;
			this.lblTopLeftImage.Text = "Top Left Image:";
			this.lblTopLeftImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBottomRightImage
			// 
			this.txtBottomRightImage.Location = new System.Drawing.Point(144, 214);
			this.txtBottomRightImage.Margin = new System.Windows.Forms.Padding(4);
			this.txtBottomRightImage.Name = "txtBottomRightImage";
			this.txtBottomRightImage.Size = new System.Drawing.Size(240, 23);
			this.txtBottomRightImage.TabIndex = 16;
			// 
			// lblBottomRightImage
			// 
			this.lblBottomRightImage.Location = new System.Drawing.Point(7, 210);
			this.lblBottomRightImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblBottomRightImage.Name = "lblBottomRightImage";
			this.lblBottomRightImage.Size = new System.Drawing.Size(136, 26);
			this.lblBottomRightImage.TabIndex = 15;
			this.lblBottomRightImage.Text = "Bottom Right Image:";
			this.lblBottomRightImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBottomLeftImage
			// 
			this.txtBottomLeftImage.Location = new System.Drawing.Point(144, 188);
			this.txtBottomLeftImage.Margin = new System.Windows.Forms.Padding(4);
			this.txtBottomLeftImage.Name = "txtBottomLeftImage";
			this.txtBottomLeftImage.Size = new System.Drawing.Size(240, 23);
			this.txtBottomLeftImage.TabIndex = 14;
			// 
			// lblBottomLeftImage
			// 
			this.lblBottomLeftImage.Location = new System.Drawing.Point(7, 184);
			this.lblBottomLeftImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblBottomLeftImage.Name = "lblBottomLeftImage";
			this.lblBottomLeftImage.Size = new System.Drawing.Size(136, 26);
			this.lblBottomLeftImage.TabIndex = 13;
			this.lblBottomLeftImage.Text = "Bottom Left Image:";
			this.lblBottomLeftImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBottomImage
			// 
			this.txtBottomImage.Location = new System.Drawing.Point(144, 163);
			this.txtBottomImage.Margin = new System.Windows.Forms.Padding(4);
			this.txtBottomImage.Name = "txtBottomImage";
			this.txtBottomImage.Size = new System.Drawing.Size(240, 23);
			this.txtBottomImage.TabIndex = 12;
			// 
			// lblBottomImage
			// 
			this.lblBottomImage.Location = new System.Drawing.Point(7, 158);
			this.lblBottomImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblBottomImage.Name = "lblBottomImage";
			this.lblBottomImage.Size = new System.Drawing.Size(136, 26);
			this.lblBottomImage.TabIndex = 11;
			this.lblBottomImage.Text = "Bottom Image:";
			this.lblBottomImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTopImage
			// 
			this.txtTopImage.Location = new System.Drawing.Point(144, 137);
			this.txtTopImage.Margin = new System.Windows.Forms.Padding(4);
			this.txtTopImage.Name = "txtTopImage";
			this.txtTopImage.Size = new System.Drawing.Size(240, 23);
			this.txtTopImage.TabIndex = 10;
			// 
			// lblTopImage
			// 
			this.lblTopImage.Location = new System.Drawing.Point(7, 133);
			this.lblTopImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTopImage.Name = "lblTopImage";
			this.lblTopImage.Size = new System.Drawing.Size(136, 26);
			this.lblTopImage.TabIndex = 9;
			this.lblTopImage.Text = "Top Image:";
			this.lblTopImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRightImage
			// 
			this.txtRightImage.Location = new System.Drawing.Point(144, 111);
			this.txtRightImage.Margin = new System.Windows.Forms.Padding(4);
			this.txtRightImage.Name = "txtRightImage";
			this.txtRightImage.Size = new System.Drawing.Size(240, 23);
			this.txtRightImage.TabIndex = 8;
			// 
			// lblRightImage
			// 
			this.lblRightImage.Location = new System.Drawing.Point(7, 107);
			this.lblRightImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblRightImage.Name = "lblRightImage";
			this.lblRightImage.Size = new System.Drawing.Size(136, 26);
			this.lblRightImage.TabIndex = 7;
			this.lblRightImage.Text = "Right Image:";
			this.lblRightImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLeftImage
			// 
			this.txtLeftImage.Location = new System.Drawing.Point(144, 85);
			this.txtLeftImage.Margin = new System.Windows.Forms.Padding(4);
			this.txtLeftImage.Name = "txtLeftImage";
			this.txtLeftImage.Size = new System.Drawing.Size(240, 23);
			this.txtLeftImage.TabIndex = 6;
			// 
			// lblLeftImage
			// 
			this.lblLeftImage.Location = new System.Drawing.Point(7, 81);
			this.lblLeftImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblLeftImage.Name = "lblLeftImage";
			this.lblLeftImage.Size = new System.Drawing.Size(136, 26);
			this.lblLeftImage.TabIndex = 5;
			this.lblLeftImage.Text = "Left Image:";
			this.lblLeftImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDpadImage
			// 
			this.txtDpadImage.Location = new System.Drawing.Point(144, 59);
			this.txtDpadImage.Margin = new System.Windows.Forms.Padding(4);
			this.txtDpadImage.Name = "txtDpadImage";
			this.txtDpadImage.Size = new System.Drawing.Size(240, 23);
			this.txtDpadImage.TabIndex = 4;
			// 
			// lblBackgroundImage
			// 
			this.lblBackgroundImage.Location = new System.Drawing.Point(7, 55);
			this.lblBackgroundImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblBackgroundImage.Name = "lblBackgroundImage";
			this.lblBackgroundImage.Size = new System.Drawing.Size(136, 26);
			this.lblBackgroundImage.TabIndex = 3;
			this.lblBackgroundImage.Text = "Image:";
			this.lblBackgroundImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// clrKeyboardBackground
			// 
			this.clrKeyboardBackground.BackColor = System.Drawing.SystemColors.Control;
			this.clrKeyboardBackground.Color = System.Drawing.Color.FromArgb(0, 0, 100);
			this.clrKeyboardBackground.LabelText = "Foreground Color";
			this.clrKeyboardBackground.Location = new System.Drawing.Point(9, 25);
			this.clrKeyboardBackground.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.clrKeyboardBackground.Name = "clrKeyboardBackground";
			this.clrKeyboardBackground.PreviewShape = ThoNohT.NohBoard.Controls.ColorChooser.Shape.Square;
			this.clrKeyboardBackground.Size = new System.Drawing.Size(184, 30);
			this.clrKeyboardBackground.TabIndex = 2;
			// 
			// chkDpadBackground
			// 
			this.chkDpadBackground.AutoSize = true;
			this.chkDpadBackground.Location = new System.Drawing.Point(223, 340);
			this.chkDpadBackground.Margin = new System.Windows.Forms.Padding(2);
			this.chkDpadBackground.Name = "chkDpadBackground";
			this.chkDpadBackground.Size = new System.Drawing.Size(151, 19);
			this.chkDpadBackground.TabIndex = 20;
			this.chkDpadBackground.Text = "Draw Dpad Background";
			this.chkDpadBackground.UseVisualStyleBackColor = true;
			// 
			// DirectInputDpadStyleForm
			// 
			this.AcceptButton = this.AcceptButton2;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelButton2;
			this.ClientSize = new System.Drawing.Size(633, 422);
			this.Controls.Add(this.chkDpadBackground);
			this.Controls.Add(this.KeyboardGroup);
			this.Controls.Add(this.chkOverwriteDefaultStyle);
			this.Controls.Add(this.stylePanel);
			this.Controls.Add(this.CancelButton2);
			this.Controls.Add(this.AcceptButton2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DirectInputDpadStyleForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dpad Style";
            this.Load += new System.EventHandler(this.DirectInputAxisStyleForm_Load);
			this.KeyboardGroup.ResumeLayout(false);
			this.KeyboardGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button AcceptButton2;
        private System.Windows.Forms.Button CancelButton2;
        private System.Windows.Forms.CheckBox chkOverwriteDefaultStyle;
        private KeySubStylePanel stylePanel;
        private System.Windows.Forms.GroupBox KeyboardGroup;
        private System.Windows.Forms.TextBox txtAxisImage;
        private System.Windows.Forms.Label lblBackgroundImage;
        private ColorChooser clrKeyboardBackground;
        private System.Windows.Forms.CheckBox chkDpadBackground;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblTopImage;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblRightImage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLeftImage;
        private System.Windows.Forms.Label txtLeftImage2;
        private System.Windows.Forms.TextBox txtLeftImage;
        private System.Windows.Forms.TextBox txtRightImage;
        private System.Windows.Forms.TextBox txtTopImage;
        private System.Windows.Forms.Label lblBottomImage;
        private System.Windows.Forms.TextBox txtBottomImage;
        private System.Windows.Forms.Label lblBottomLeftImage;
        private System.Windows.Forms.TextBox txtBottomLeftImage;
        private System.Windows.Forms.Label lblBottomRightImage;
        private System.Windows.Forms.TextBox txtBottomRightImage;
        private System.Windows.Forms.Label lblTopLeftImage;
        private System.Windows.Forms.TextBox txtTopLeftImage;
        private System.Windows.Forms.Label lblTopRightImage;
        private System.Windows.Forms.TextBox txtTopRightImage;
        private System.Windows.Forms.TextBox txtDpadImage;
        private System.Windows.Forms.CheckBox checkBox1;
	}
}
