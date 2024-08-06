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

using System.Collections.Generic;

namespace ThoNohT.NohBoard.Forms.Properties {
    partial class DirectInputDpadPropertiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (this.components != null)) {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnBoundaryDown = new System.Windows.Forms.Button();
			this.btnBoundaryUp = new System.Windows.Forms.Button();
			this.btnRemoveBoundary = new System.Windows.Forms.Button();
			this.btnAddBoundary = new System.Windows.Forms.Button();
			this.CancelButton2 = new System.Windows.Forms.Button();
			this.AcceptButton2 = new System.Windows.Forms.Button();
			this.lblBoundaries = new System.Windows.Forms.Label();
			this.lstBoundaries = new System.Windows.Forms.ListBox();
			this.lblText = new System.Windows.Forms.Label();
			this.txtText = new System.Windows.Forms.TextBox();
			this.lblTextPosition = new System.Windows.Forms.Label();
			this.lblShiftText = new System.Windows.Forms.Label();
			this.txtShiftText = new System.Windows.Forms.TextBox();
			this.chkChangeOnCaps = new System.Windows.Forms.CheckBox();
			this.btnUpdateBoundary = new System.Windows.Forms.Button();
			this.btnCenterText = new System.Windows.Forms.Button();
			this.btnRectangle = new System.Windows.Forms.Button();
			this.txtDeviceId = new System.Windows.Forms.TextBox();
            this.txtBoundaries = new ThoNohT.NohBoard.Controls.VectorTextBox();
            this.txtTextPosition = new ThoNohT.NohBoard.Controls.VectorTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxDevicesList = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbDpad = new System.Windows.Forms.ComboBox();
			this.btnDetectDpad = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdDrawModeDiagonals = new System.Windows.Forms.RadioButton();
			this.rdDrawModeFourWay = new System.Windows.Forms.RadioButton();
			this.rdDrawModeSingle = new System.Windows.Forms.RadioButton();
			groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnBoundaryDown
			// 
			this.btnBoundaryDown.Location = new System.Drawing.Point(5, 268);
			this.btnBoundaryDown.Margin = new System.Windows.Forms.Padding(4);
			this.btnBoundaryDown.Name = "btnBoundaryDown";
			this.btnBoundaryDown.Size = new System.Drawing.Size(88, 26);
			this.btnBoundaryDown.TabIndex = 10;
			this.btnBoundaryDown.Text = "Down";
			this.btnBoundaryDown.UseVisualStyleBackColor = true;
            this.btnBoundaryDown.Click += new System.EventHandler(this.btnBoundaryDown_Click);
			// 
			// btnBoundaryUp
			// 
			this.btnBoundaryUp.Location = new System.Drawing.Point(5, 234);
			this.btnBoundaryUp.Margin = new System.Windows.Forms.Padding(4);
			this.btnBoundaryUp.Name = "btnBoundaryUp";
			this.btnBoundaryUp.Size = new System.Drawing.Size(88, 26);
			this.btnBoundaryUp.TabIndex = 9;
			this.btnBoundaryUp.Text = "Up";
			this.btnBoundaryUp.UseVisualStyleBackColor = true;
            this.btnBoundaryUp.Click += new System.EventHandler(this.btnBoundaryUp_Click);
			// 
			// btnRemoveBoundary
			// 
			this.btnRemoveBoundary.Location = new System.Drawing.Point(5, 201);
			this.btnRemoveBoundary.Margin = new System.Windows.Forms.Padding(4);
			this.btnRemoveBoundary.Name = "btnRemoveBoundary";
			this.btnRemoveBoundary.Size = new System.Drawing.Size(88, 26);
			this.btnRemoveBoundary.TabIndex = 8;
			this.btnRemoveBoundary.Text = "Remove";
			this.btnRemoveBoundary.UseVisualStyleBackColor = true;
            this.btnRemoveBoundary.Click += new System.EventHandler(this.btnRemoveBoundary_Click);
			// 
			// btnAddBoundary
			// 
			this.btnAddBoundary.Location = new System.Drawing.Point(5, 134);
			this.btnAddBoundary.Margin = new System.Windows.Forms.Padding(4);
			this.btnAddBoundary.Name = "btnAddBoundary";
			this.btnAddBoundary.Size = new System.Drawing.Size(88, 26);
			this.btnAddBoundary.TabIndex = 6;
			this.btnAddBoundary.Text = "Add";
			this.btnAddBoundary.UseVisualStyleBackColor = true;
            this.btnAddBoundary.Click += new System.EventHandler(this.btnAddBoundary_Click);
			// 
			// CancelButton2
			// 
			this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton2.Location = new System.Drawing.Point(383, 301);
			this.CancelButton2.Margin = new System.Windows.Forms.Padding(4);
			this.CancelButton2.Name = "CancelButton2";
			this.CancelButton2.Size = new System.Drawing.Size(88, 26);
			this.CancelButton2.TabIndex = 18;
			this.CancelButton2.Text = "Cancel";
			this.CancelButton2.UseVisualStyleBackColor = true;
            this.CancelButton2.Click += new System.EventHandler(this.CancelButton2_Click);
			// 
			// AcceptButton2
			// 
			this.AcceptButton2.Location = new System.Drawing.Point(472, 301);
			this.AcceptButton2.Margin = new System.Windows.Forms.Padding(4);
			this.AcceptButton2.Name = "AcceptButton2";
			this.AcceptButton2.Size = new System.Drawing.Size(88, 26);
			this.AcceptButton2.TabIndex = 19;
			this.AcceptButton2.Text = "Accept";
			this.AcceptButton2.UseVisualStyleBackColor = true;
            this.AcceptButton2.Click += new System.EventHandler(this.AcceptButton2_Click);
			// 
			// lblBoundaries
			// 
			this.lblBoundaries.AutoSize = true;
			this.lblBoundaries.Location = new System.Drawing.Point(9, 107);
			this.lblBoundaries.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblBoundaries.Name = "lblBoundaries";
			this.lblBoundaries.Size = new System.Drawing.Size(69, 15);
			this.lblBoundaries.TabIndex = 36;
			this.lblBoundaries.Text = "Boundaries:";
			// 
			// lstBoundaries
			// 
			this.lstBoundaries.FormattingEnabled = true;
			this.lstBoundaries.ItemHeight = 15;
			this.lstBoundaries.Location = new System.Drawing.Point(99, 134);
			this.lstBoundaries.Margin = new System.Windows.Forms.Padding(4);
			this.lstBoundaries.Name = "lstBoundaries";
			this.lstBoundaries.Size = new System.Drawing.Size(181, 184);
			this.lstBoundaries.TabIndex = 12;
			// 
			// lblText
			// 
			this.lblText.AutoSize = true;
			this.lblText.Location = new System.Drawing.Point(9, 16);
			this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(31, 15);
			this.lblText.TabIndex = 34;
			this.lblText.Text = "Text:";
			// 
			// txtText
			// 
			this.txtText.Location = new System.Drawing.Point(99, 13);
			this.txtText.Margin = new System.Windows.Forms.Padding(4);
			this.txtText.Name = "txtText";
			this.txtText.Size = new System.Drawing.Size(181, 23);
			this.txtText.TabIndex = 0;
			// 
			// lblTextPosition
			// 
			this.lblTextPosition.AutoSize = true;
			this.lblTextPosition.Location = new System.Drawing.Point(9, 77);
			this.lblTextPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTextPosition.Name = "lblTextPosition";
			this.lblTextPosition.Size = new System.Drawing.Size(77, 15);
			this.lblTextPosition.TabIndex = 31;
			this.lblTextPosition.Text = "Text Position:";
			// 
			// lblShiftText
			// 
			this.lblShiftText.AutoSize = true;
			this.lblShiftText.Location = new System.Drawing.Point(9, 46);
			this.lblShiftText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblShiftText.Name = "lblShiftText";
			this.lblShiftText.Size = new System.Drawing.Size(58, 15);
			this.lblShiftText.TabIndex = 45;
			this.lblShiftText.Text = "Shift Text:";
			// 
			// txtShiftText
			// 
			this.txtShiftText.Location = new System.Drawing.Point(99, 43);
			this.txtShiftText.Margin = new System.Windows.Forms.Padding(4);
			this.txtShiftText.Name = "txtShiftText";
			this.txtShiftText.Size = new System.Drawing.Size(181, 23);
			this.txtShiftText.TabIndex = 2;
			// 
			// chkChangeOnCaps
			// 
			this.chkChangeOnCaps.AutoSize = true;
			this.chkChangeOnCaps.Location = new System.Drawing.Point(292, 10);
			this.chkChangeOnCaps.Margin = new System.Windows.Forms.Padding(4);
			this.chkChangeOnCaps.Name = "chkChangeOnCaps";
			this.chkChangeOnCaps.Size = new System.Drawing.Size(235, 19);
			this.chkChangeOnCaps.TabIndex = 1;
			this.chkChangeOnCaps.Text = "Change capitalization on Caps Lock key";
			this.chkChangeOnCaps.UseVisualStyleBackColor = true;
			// 
			// btnUpdateBoundary
			// 
			this.btnUpdateBoundary.Location = new System.Drawing.Point(5, 167);
			this.btnUpdateBoundary.Margin = new System.Windows.Forms.Padding(4);
			this.btnUpdateBoundary.Name = "btnUpdateBoundary";
			this.btnUpdateBoundary.Size = new System.Drawing.Size(88, 26);
			this.btnUpdateBoundary.TabIndex = 7;
			this.btnUpdateBoundary.Text = "Update";
			this.btnUpdateBoundary.UseVisualStyleBackColor = true;
            this.btnUpdateBoundary.Click += new System.EventHandler(this.btnUpdateBoundary_Click);
			// 
			// btnCenterText
			// 
			this.btnCenterText.Location = new System.Drawing.Point(196, 71);
			this.btnCenterText.Margin = new System.Windows.Forms.Padding(4);
			this.btnCenterText.Name = "btnCenterText";
			this.btnCenterText.Size = new System.Drawing.Size(85, 26);
			this.btnCenterText.TabIndex = 4;
			this.btnCenterText.Text = "Center";
			this.btnCenterText.UseVisualStyleBackColor = true;
            this.btnCenterText.Click += new System.EventHandler(this.btnCenterText_Click);
			// 
			// btnRectangle
			// 
			this.btnRectangle.Location = new System.Drawing.Point(5, 301);
			this.btnRectangle.Margin = new System.Windows.Forms.Padding(4);
			this.btnRectangle.Name = "btnRectangle";
			this.btnRectangle.Size = new System.Drawing.Size(88, 26);
			this.btnRectangle.TabIndex = 11;
			this.btnRectangle.Text = "Rectangle";
			this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
			// 
			// txtDeviceId
			// 
			this.txtDeviceId.Location = new System.Drawing.Point(0, 0);
			this.txtDeviceId.Name = "txtDeviceId";
			this.txtDeviceId.Size = new System.Drawing.Size(100, 23);
			this.txtDeviceId.TabIndex = 0;
			// 
			// txtBoundaries
			// 
			this.txtBoundaries.Location = new System.Drawing.Point(99, 104);
			this.txtBoundaries.Margin = new System.Windows.Forms.Padding(4);
			this.txtBoundaries.MaxVal = int.MaxValue;
			this.txtBoundaries.Name = "txtBoundaries";
			this.txtBoundaries.Separator = ';';
			this.txtBoundaries.Size = new System.Drawing.Size(181, 23);
			this.txtBoundaries.SpacesAroundSeparator = true;
			this.txtBoundaries.TabIndex = 5;
			this.txtBoundaries.Text = "0 ; 0";
			this.txtBoundaries.X = 0;
			this.txtBoundaries.Y = 0;
			// 
			// txtTextPosition
			// 
			this.txtTextPosition.Location = new System.Drawing.Point(99, 74);
			this.txtTextPosition.Margin = new System.Windows.Forms.Padding(4);
			this.txtTextPosition.MaxVal = int.MaxValue;
			this.txtTextPosition.Name = "txtTextPosition";
			this.txtTextPosition.Separator = ';';
			this.txtTextPosition.Size = new System.Drawing.Size(181, 23);
			this.txtTextPosition.SpacesAroundSeparator = true;
			this.txtTextPosition.TabIndex = 3;
			this.txtTextPosition.Text = "0 ; 0";
			this.txtTextPosition.X = 0;
			this.txtTextPosition.Y = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(292, 31);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 15);
			this.label1.TabIndex = 54;
			this.label1.Text = "Device";
			// 
			// comboBoxDevicesList
			// 
			this.comboBoxDevicesList.FormattingEnabled = true;
			this.comboBoxDevicesList.Location = new System.Drawing.Point(292, 48);
			this.comboBoxDevicesList.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxDevicesList.Name = "comboBoxDevicesList";
			this.comboBoxDevicesList.Size = new System.Drawing.Size(246, 23);
			this.comboBoxDevicesList.TabIndex = 55;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(292, 83);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 15);
			this.label2.TabIndex = 56;
			this.label2.Text = "DPad";
			// 
			// cmbDpad
			// 
			this.cmbDpad.FormattingEnabled = true;
			this.cmbDpad.Location = new System.Drawing.Point(409, 81);
			this.cmbDpad.Margin = new System.Windows.Forms.Padding(2);
			this.cmbDpad.Name = "cmbDpad";
			this.cmbDpad.Size = new System.Drawing.Size(129, 23);
			this.cmbDpad.TabIndex = 57;
			// 
			// btnDetectDpad
			// 
			this.btnDetectDpad.Location = new System.Drawing.Point(292, 114);
			this.btnDetectDpad.Margin = new System.Windows.Forms.Padding(4);
			this.btnDetectDpad.Name = "btnDetectDpad";
			this.btnDetectDpad.Size = new System.Drawing.Size(119, 26);
			this.btnDetectDpad.TabIndex = 64;
			this.btnDetectDpad.Text = "Detect Dpad";
			this.btnDetectDpad.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(rdDrawModeDiagonals);
			this.groupBox1.Controls.Add(rdDrawModeFourWay);
			this.groupBox1.Controls.Add(rdDrawModeSingle);
			this.groupBox1.Location = new System.Drawing.Point(292, 160);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(246, 134);
			this.groupBox1.TabIndex = 66;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Draw Mode";
			// 
			// rdDrawModeDiagonals
			// 
			this.rdDrawModeDiagonals.AutoSize = true;
			this.rdDrawModeDiagonals.Location = new System.Drawing.Point(16, 73);
			this.rdDrawModeDiagonals.Name = "rdDrawModeDiagonals";
			this.rdDrawModeDiagonals.Size = new System.Drawing.Size(171, 19);
			this.rdDrawModeDiagonals.TabIndex = 2;
			this.rdDrawModeDiagonals.Text = "Eight Directions (Diagonals)";
			this.rdDrawModeDiagonals.UseVisualStyleBackColor = true;
			this.rdDrawModeDiagonals.CheckedChanged += rdDrawModeDiagonals_CheckedChanged;
			// 
			// rdDrawModeFourWay
			// 
			this.rdDrawModeFourWay.AutoSize = true;
			this.rdDrawModeFourWay.Location = new System.Drawing.Point(16, 48);
			this.rdDrawModeFourWay.Name = "rdDrawModeFourWay";
			this.rdDrawModeFourWay.Size = new System.Drawing.Size(105, 19);
			this.rdDrawModeFourWay.TabIndex = 1;
			this.rdDrawModeFourWay.Text = "Four Directions";
			this.rdDrawModeFourWay.UseVisualStyleBackColor = true;
			this.rdDrawModeFourWay.CheckedChanged += rdDrawModeFourWay_CheckedChanged;
			// 
			// rdDrawModeSingle
			// 
			this.rdDrawModeSingle.AutoSize = true;
			this.rdDrawModeSingle.Location = new System.Drawing.Point(16, 22);
			this.rdDrawModeSingle.Name = "rdDrawModeSingle";
			this.rdDrawModeSingle.Size = new System.Drawing.Size(93, 19);
			this.rdDrawModeSingle.TabIndex = 0;
			this.rdDrawModeSingle.Text = "Single Image";
			this.rdDrawModeSingle.UseVisualStyleBackColor = true;
			this.rdDrawModeSingle.CheckedChanged += rdDrawModeSingle_CheckedChanged;
			// 
			// DirectInputDpadPropertiesForm
			// 
			this.AcceptButton = this.AcceptButton2;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelButton2;
			this.ClientSize = new System.Drawing.Size(574, 340);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnDetectDpad);
			this.Controls.Add(this.cmbDpad);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBoxDevicesList);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnUpdateBoundary);
			this.Controls.Add(this.btnCenterText);
			this.Controls.Add(this.btnRectangle);
			this.Controls.Add(this.chkChangeOnCaps);
			this.Controls.Add(this.lblShiftText);
			this.Controls.Add(this.txtShiftText);
			this.Controls.Add(this.btnBoundaryDown);
			this.Controls.Add(this.btnBoundaryUp);
			this.Controls.Add(this.btnRemoveBoundary);
			this.Controls.Add(this.btnAddBoundary);
			this.Controls.Add(this.txtBoundaries);
			this.Controls.Add(this.CancelButton2);
			this.Controls.Add(this.AcceptButton2);
			this.Controls.Add(this.lblBoundaries);
			this.Controls.Add(this.lstBoundaries);
			this.Controls.Add(this.lblText);
			this.Controls.Add(this.txtText);
			this.Controls.Add(this.txtTextPosition);
			this.Controls.Add(this.lblTextPosition);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DirectInputDpadPropertiesForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Keyboard Key Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyboardKeyPropertiesForm_FormClosing);
            this.Load += new System.EventHandler(this.DirectInputDpadPropertiesForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnBoundaryDown;
        private System.Windows.Forms.Button btnBoundaryUp;
        private System.Windows.Forms.Button btnRemoveBoundary;
        private System.Windows.Forms.Button btnAddBoundary;
        private Controls.VectorTextBox txtBoundaries;
        private System.Windows.Forms.Button CancelButton2;
        private System.Windows.Forms.Button AcceptButton2;
        private System.Windows.Forms.Label lblBoundaries;
        private System.Windows.Forms.ListBox lstBoundaries;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtText;
        private Controls.VectorTextBox txtTextPosition;
        private System.Windows.Forms.Label lblTextPosition;
        private System.Windows.Forms.Label lblShiftText;
        private System.Windows.Forms.TextBox txtShiftText;
        private System.Windows.Forms.TextBox txtDeviceId;
        private System.Windows.Forms.CheckBox chkChangeOnCaps;
        private System.Windows.Forms.Button btnUpdateBoundary;
        private System.Windows.Forms.Button btnCenterText;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDevicesList;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDpad;
        private System.Windows.Forms.Button btnDetectDpad;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdDrawModeDiagonals;
		private System.Windows.Forms.RadioButton rdDrawModeFourWay;
		private System.Windows.Forms.RadioButton rdDrawModeSingle;
	}
}
