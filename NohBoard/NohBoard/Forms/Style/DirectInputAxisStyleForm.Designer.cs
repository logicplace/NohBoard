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

    partial class DirectInputAxisStyleForm
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
            ThoNohT.NohBoard.Keyboard.Styles.KeySubStyle keySubStyle2 = new ThoNohT.NohBoard.Keyboard.Styles.KeySubStyle();
            ThoNohT.NohBoard.Extra.SerializableColor serializableColor4 = new ThoNohT.NohBoard.Extra.SerializableColor();
            ThoNohT.NohBoard.Extra.SerializableFont serializableFont2 = new ThoNohT.NohBoard.Extra.SerializableFont();
            ThoNohT.NohBoard.Extra.SerializableColor serializableColor5 = new ThoNohT.NohBoard.Extra.SerializableColor();
            ThoNohT.NohBoard.Extra.SerializableColor serializableColor6 = new ThoNohT.NohBoard.Extra.SerializableColor();
            this.AcceptButton2 = new System.Windows.Forms.Button();
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.chkOverwriteDefaultStyle = new System.Windows.Forms.CheckBox();
            this.stylePanel = new ThoNohT.NohBoard.Controls.KeySubStylePanel();
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
            this.txtAxisImage = new System.Windows.Forms.TextBox();
            this.lblBackgroundImage = new System.Windows.Forms.Label();
            this.clrKeyboardBackground = new ThoNohT.NohBoard.Controls.ColorChooser();
            this.chkAxisBackground = new System.Windows.Forms.CheckBox();
            this.KeyboardGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcceptButton2
            // 
            this.AcceptButton2.Location = new System.Drawing.Point(758, 645);
            this.AcceptButton2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.AcceptButton2.Name = "AcceptButton2";
            this.AcceptButton2.Size = new System.Drawing.Size(125, 44);
            this.AcceptButton2.TabIndex = 10;
            this.AcceptButton2.Text = "Accept";
            this.AcceptButton2.UseVisualStyleBackColor = true;
            this.AcceptButton2.Click += new System.EventHandler(this.AcceptButton2_Click);
            // 
            // CancelButton2
            // 
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(623, 645);
            this.CancelButton2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(125, 44);
            this.CancelButton2.TabIndex = 11;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            this.CancelButton2.Click += new System.EventHandler(this.CancelButton2_Click);
            // 
            // chkOverwriteDefaultStyle
            // 
            this.chkOverwriteDefaultStyle.AutoSize = true;
            this.chkOverwriteDefaultStyle.Location = new System.Drawing.Point(23, 660);
            this.chkOverwriteDefaultStyle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkOverwriteDefaultStyle.Name = "chkOverwriteDefaultStyle";
            this.chkOverwriteDefaultStyle.Size = new System.Drawing.Size(215, 29);
            this.chkOverwriteDefaultStyle.TabIndex = 18;
            this.chkOverwriteDefaultStyle.Text = "Overwrite default style";
            this.chkOverwriteDefaultStyle.UseVisualStyleBackColor = true;
            this.chkOverwriteDefaultStyle.CheckedChanged += new System.EventHandler(this.chkOverwriteLoose_CheckedChanged);
            // 
            // stylePanel
            // 
            this.stylePanel.Location = new System.Drawing.Point(20, 23);
            this.stylePanel.Margin = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.stylePanel.Name = "stylePanel";
            this.stylePanel.Size = new System.Drawing.Size(285, 637);
            serializableColor4.Blue = ((byte)(0));
            serializableColor4.Green = ((byte)(0));
            serializableColor4.Red = ((byte)(0));
            keySubStyle2.Background = serializableColor4;
            keySubStyle2.BackgroundImageFileName = "";
            serializableFont2.AlternateFontFamily = null;
            serializableFont2.DownloadUrl = null;
            serializableFont2.FontFamily = "Courier New";
            serializableFont2.Size = 10F;
            serializableFont2.Style = ThoNohT.NohBoard.Extra.SerializableFontStyle.Regular;
            keySubStyle2.Font = serializableFont2;
            serializableColor5.Blue = ((byte)(0));
            serializableColor5.Green = ((byte)(0));
            serializableColor5.Red = ((byte)(0));
            keySubStyle2.Outline = serializableColor5;
            keySubStyle2.OutlineWidth = 1;
            keySubStyle2.ShowOutline = false;
            serializableColor6.Blue = ((byte)(0));
            serializableColor6.Green = ((byte)(0));
            serializableColor6.Red = ((byte)(0));
            keySubStyle2.Text = serializableColor6;
            this.stylePanel.SubStyle = keySubStyle2;
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
            this.KeyboardGroup.Controls.Add(this.txtAxisImage);
            this.KeyboardGroup.Controls.Add(this.lblBackgroundImage);
            this.KeyboardGroup.Controls.Add(this.clrKeyboardBackground);
            this.KeyboardGroup.Location = new System.Drawing.Point(318, 65);
            this.KeyboardGroup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.KeyboardGroup.Name = "KeyboardGroup";
            this.KeyboardGroup.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.KeyboardGroup.Size = new System.Drawing.Size(565, 493);
            this.KeyboardGroup.TabIndex = 19;
            this.KeyboardGroup.TabStop = false;
            this.KeyboardGroup.Text = "Axis Circle";
            // 
            // txtTopRightImage
            // 
            this.txtTopRightImage.Location = new System.Drawing.Point(205, 443);
            this.txtTopRightImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTopRightImage.Name = "txtTopRightImage";
            this.txtTopRightImage.Size = new System.Drawing.Size(341, 31);
            this.txtTopRightImage.TabIndex = 20;
            // 
            // lblTopRightImage
            // 
            this.lblTopRightImage.Location = new System.Drawing.Point(10, 436);
            this.lblTopRightImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTopRightImage.Name = "lblTopRightImage";
            this.lblTopRightImage.Size = new System.Drawing.Size(194, 44);
            this.lblTopRightImage.TabIndex = 19;
            this.lblTopRightImage.Text = "Top Right Image:";
            this.lblTopRightImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTopLeftImage
            // 
            this.txtTopLeftImage.Location = new System.Drawing.Point(205, 400);
            this.txtTopLeftImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTopLeftImage.Name = "txtTopLeftImage";
            this.txtTopLeftImage.Size = new System.Drawing.Size(341, 31);
            this.txtTopLeftImage.TabIndex = 18;
            // 
            // lblTopLeftImage
            // 
            this.lblTopLeftImage.Location = new System.Drawing.Point(10, 393);
            this.lblTopLeftImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTopLeftImage.Name = "lblTopLeftImage";
            this.lblTopLeftImage.Size = new System.Drawing.Size(194, 44);
            this.lblTopLeftImage.TabIndex = 17;
            this.lblTopLeftImage.Text = "Top Left Image:";
            this.lblTopLeftImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBottomRightImage
            // 
            this.txtBottomRightImage.Location = new System.Drawing.Point(205, 357);
            this.txtBottomRightImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtBottomRightImage.Name = "txtBottomRightImage";
            this.txtBottomRightImage.Size = new System.Drawing.Size(341, 31);
            this.txtBottomRightImage.TabIndex = 16;
            // 
            // lblBottomRightImage
            // 
            this.lblBottomRightImage.Location = new System.Drawing.Point(10, 350);
            this.lblBottomRightImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBottomRightImage.Name = "lblBottomRightImage";
            this.lblBottomRightImage.Size = new System.Drawing.Size(194, 44);
            this.lblBottomRightImage.TabIndex = 15;
            this.lblBottomRightImage.Text = "Bottom Right Image:";
            this.lblBottomRightImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBottomLeftImage
            // 
            this.txtBottomLeftImage.Location = new System.Drawing.Point(205, 314);
            this.txtBottomLeftImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtBottomLeftImage.Name = "txtBottomLeftImage";
            this.txtBottomLeftImage.Size = new System.Drawing.Size(341, 31);
            this.txtBottomLeftImage.TabIndex = 14;
            // 
            // lblBottomLeftImage
            // 
            this.lblBottomLeftImage.Location = new System.Drawing.Point(10, 307);
            this.lblBottomLeftImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBottomLeftImage.Name = "lblBottomLeftImage";
            this.lblBottomLeftImage.Size = new System.Drawing.Size(194, 44);
            this.lblBottomLeftImage.TabIndex = 13;
            this.lblBottomLeftImage.Text = "Bottom Left Image:";
            this.lblBottomLeftImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBottomImage
            // 
            this.txtBottomImage.Location = new System.Drawing.Point(205, 271);
            this.txtBottomImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtBottomImage.Name = "txtBottomImage";
            this.txtBottomImage.Size = new System.Drawing.Size(341, 31);
            this.txtBottomImage.TabIndex = 12;
            // 
            // lblBottomImage
            // 
            this.lblBottomImage.Location = new System.Drawing.Point(10, 264);
            this.lblBottomImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBottomImage.Name = "lblBottomImage";
            this.lblBottomImage.Size = new System.Drawing.Size(194, 44);
            this.lblBottomImage.TabIndex = 11;
            this.lblBottomImage.Text = "Bottom Image:";
            this.lblBottomImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTopImage
            // 
            this.txtTopImage.Location = new System.Drawing.Point(205, 228);
            this.txtTopImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTopImage.Name = "txtTopImage";
            this.txtTopImage.Size = new System.Drawing.Size(341, 31);
            this.txtTopImage.TabIndex = 10;
            // 
            // lblTopImage
            // 
            this.lblTopImage.Location = new System.Drawing.Point(10, 221);
            this.lblTopImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTopImage.Name = "lblTopImage";
            this.lblTopImage.Size = new System.Drawing.Size(194, 44);
            this.lblTopImage.TabIndex = 9;
            this.lblTopImage.Text = "Top Image:";
            this.lblTopImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRightImage
            // 
            this.txtRightImage.Location = new System.Drawing.Point(205, 185);
            this.txtRightImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtRightImage.Name = "txtRightImage";
            this.txtRightImage.Size = new System.Drawing.Size(341, 31);
            this.txtRightImage.TabIndex = 8;
            // 
            // lblRightImage
            // 
            this.lblRightImage.Location = new System.Drawing.Point(10, 178);
            this.lblRightImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRightImage.Name = "lblRightImage";
            this.lblRightImage.Size = new System.Drawing.Size(194, 44);
            this.lblRightImage.TabIndex = 7;
            this.lblRightImage.Text = "Right Image:";
            this.lblRightImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLeftImage
            // 
            this.txtLeftImage.Location = new System.Drawing.Point(205, 142);
            this.txtLeftImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtLeftImage.Name = "txtLeftImage";
            this.txtLeftImage.Size = new System.Drawing.Size(341, 31);
            this.txtLeftImage.TabIndex = 6;
            // 
            // lblLeftImage
            // 
            this.lblLeftImage.Location = new System.Drawing.Point(10, 135);
            this.lblLeftImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLeftImage.Name = "lblLeftImage";
            this.lblLeftImage.Size = new System.Drawing.Size(194, 44);
            this.lblLeftImage.TabIndex = 5;
            this.lblLeftImage.Text = "Left Image:";
            this.lblLeftImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAxisImage
            // 
            this.txtAxisImage.Location = new System.Drawing.Point(205, 99);
            this.txtAxisImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAxisImage.Name = "txtAxisImage";
            this.txtAxisImage.Size = new System.Drawing.Size(341, 31);
            this.txtAxisImage.TabIndex = 4;
            // 
            // lblBackgroundImage
            // 
            this.lblBackgroundImage.Location = new System.Drawing.Point(10, 92);
            this.lblBackgroundImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBackgroundImage.Name = "lblBackgroundImage";
            this.lblBackgroundImage.Size = new System.Drawing.Size(194, 44);
            this.lblBackgroundImage.TabIndex = 3;
            this.lblBackgroundImage.Text = "Image:";
            this.lblBackgroundImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clrKeyboardBackground
            // 
            this.clrKeyboardBackground.BackColor = System.Drawing.SystemColors.Control;
            this.clrKeyboardBackground.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.clrKeyboardBackground.LabelText = "Foreground Color";
            this.clrKeyboardBackground.Location = new System.Drawing.Point(13, 42);
            this.clrKeyboardBackground.Margin = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.clrKeyboardBackground.Name = "clrKeyboardBackground";
            this.clrKeyboardBackground.PreviewShape = ThoNohT.NohBoard.Controls.ColorChooser.Shape.Square;
            this.clrKeyboardBackground.Size = new System.Drawing.Size(263, 50);
            this.clrKeyboardBackground.TabIndex = 2;
            // 
            // chkAxisBackground
            // 
            this.chkAxisBackground.AutoSize = true;
            this.chkAxisBackground.Location = new System.Drawing.Point(318, 567);
            this.chkAxisBackground.Name = "chkAxisBackground";
            this.chkAxisBackground.Size = new System.Drawing.Size(216, 29);
            this.chkAxisBackground.TabIndex = 20;
            this.chkAxisBackground.Text = "Draw Axis Background";
            this.chkAxisBackground.UseVisualStyleBackColor = true;
            // 
            // DirectInputAxisStyleForm
            // 
            this.AcceptButton = this.AcceptButton2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(904, 703);
            this.Controls.Add(this.chkAxisBackground);
            this.Controls.Add(this.KeyboardGroup);
            this.Controls.Add(this.chkOverwriteDefaultStyle);
            this.Controls.Add(this.stylePanel);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.AcceptButton2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "DirectInputAxisStyleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Key Style";
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
        private System.Windows.Forms.CheckBox chkAxisBackground;
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
    }
}