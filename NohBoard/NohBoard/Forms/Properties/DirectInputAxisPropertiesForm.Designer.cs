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
    partial class DirectInputAxisPropertiesForm
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
            this.lblKeyCodes = new System.Windows.Forms.Label();
            this.chkChangeOnCaps = new System.Windows.Forms.CheckBox();
            this.btnUpdateBoundary = new System.Windows.Forms.Button();
            this.btnCenterText = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.txtDeviceId = new System.Windows.Forms.TextBox();
            this.cmbAxisOne = new System.Windows.Forms.ComboBox();
            this.btnDetectAxis1 = new System.Windows.Forms.Button();
            this.txtBoundaries = new ThoNohT.NohBoard.Controls.VectorTextBox();
            this.txtTextPosition = new ThoNohT.NohBoard.Controls.VectorTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDevicesList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAxisOneMax = new System.Windows.Forms.TextBox();
            this.txtAxisTwoMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDetectAxis2 = new System.Windows.Forms.Button();
            this.cmbAxisTwo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStickWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStickHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkInvertAxisOne = new System.Windows.Forms.CheckBox();
            this.chkInvertAxisTwo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnBoundaryDown
            // 
            this.btnBoundaryDown.Location = new System.Drawing.Point(7, 446);
            this.btnBoundaryDown.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnBoundaryDown.Name = "btnBoundaryDown";
            this.btnBoundaryDown.Size = new System.Drawing.Size(125, 44);
            this.btnBoundaryDown.TabIndex = 10;
            this.btnBoundaryDown.Text = "Down";
            this.btnBoundaryDown.UseVisualStyleBackColor = true;
            this.btnBoundaryDown.Click += new System.EventHandler(this.btnBoundaryDown_Click);
            // 
            // btnBoundaryUp
            // 
            this.btnBoundaryUp.Location = new System.Drawing.Point(7, 390);
            this.btnBoundaryUp.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnBoundaryUp.Name = "btnBoundaryUp";
            this.btnBoundaryUp.Size = new System.Drawing.Size(125, 44);
            this.btnBoundaryUp.TabIndex = 9;
            this.btnBoundaryUp.Text = "Up";
            this.btnBoundaryUp.UseVisualStyleBackColor = true;
            this.btnBoundaryUp.Click += new System.EventHandler(this.btnBoundaryUp_Click);
            // 
            // btnRemoveBoundary
            // 
            this.btnRemoveBoundary.Location = new System.Drawing.Point(7, 335);
            this.btnRemoveBoundary.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnRemoveBoundary.Name = "btnRemoveBoundary";
            this.btnRemoveBoundary.Size = new System.Drawing.Size(125, 44);
            this.btnRemoveBoundary.TabIndex = 8;
            this.btnRemoveBoundary.Text = "Remove";
            this.btnRemoveBoundary.UseVisualStyleBackColor = true;
            this.btnRemoveBoundary.Click += new System.EventHandler(this.btnRemoveBoundary_Click);
            // 
            // btnAddBoundary
            // 
            this.btnAddBoundary.Location = new System.Drawing.Point(7, 223);
            this.btnAddBoundary.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnAddBoundary.Name = "btnAddBoundary";
            this.btnAddBoundary.Size = new System.Drawing.Size(125, 44);
            this.btnAddBoundary.TabIndex = 6;
            this.btnAddBoundary.Text = "Add";
            this.btnAddBoundary.UseVisualStyleBackColor = true;
            this.btnAddBoundary.Click += new System.EventHandler(this.btnAddBoundary_Click);
            // 
            // CancelButton2
            // 
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(547, 502);
            this.CancelButton2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(125, 44);
            this.CancelButton2.TabIndex = 18;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            this.CancelButton2.Click += new System.EventHandler(this.CancelButton2_Click);
            // 
            // AcceptButton2
            // 
            this.AcceptButton2.Location = new System.Drawing.Point(675, 502);
            this.AcceptButton2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.AcceptButton2.Name = "AcceptButton2";
            this.AcceptButton2.Size = new System.Drawing.Size(125, 44);
            this.AcceptButton2.TabIndex = 19;
            this.AcceptButton2.Text = "Accept";
            this.AcceptButton2.UseVisualStyleBackColor = true;
            this.AcceptButton2.Click += new System.EventHandler(this.AcceptButton2_Click);
            // 
            // lblBoundaries
            // 
            this.lblBoundaries.AutoSize = true;
            this.lblBoundaries.Location = new System.Drawing.Point(13, 179);
            this.lblBoundaries.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBoundaries.Name = "lblBoundaries";
            this.lblBoundaries.Size = new System.Drawing.Size(104, 25);
            this.lblBoundaries.TabIndex = 36;
            this.lblBoundaries.Text = "Boundaries:";
            // 
            // lstBoundaries
            // 
            this.lstBoundaries.FormattingEnabled = true;
            this.lstBoundaries.ItemHeight = 25;
            this.lstBoundaries.Location = new System.Drawing.Point(142, 223);
            this.lstBoundaries.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lstBoundaries.Name = "lstBoundaries";
            this.lstBoundaries.Size = new System.Drawing.Size(257, 304);
            this.lstBoundaries.TabIndex = 12;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(13, 27);
            this.lblText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(46, 25);
            this.lblText.TabIndex = 34;
            this.lblText.Text = "Text:";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(142, 21);
            this.txtText.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(257, 31);
            this.txtText.TabIndex = 0;
            // 
            // lblTextPosition
            // 
            this.lblTextPosition.AutoSize = true;
            this.lblTextPosition.Location = new System.Drawing.Point(13, 129);
            this.lblTextPosition.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTextPosition.Name = "lblTextPosition";
            this.lblTextPosition.Size = new System.Drawing.Size(114, 25);
            this.lblTextPosition.TabIndex = 31;
            this.lblTextPosition.Text = "Text Position:";
            // 
            // lblShiftText
            // 
            this.lblShiftText.AutoSize = true;
            this.lblShiftText.Location = new System.Drawing.Point(13, 77);
            this.lblShiftText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblShiftText.Name = "lblShiftText";
            this.lblShiftText.Size = new System.Drawing.Size(87, 25);
            this.lblShiftText.TabIndex = 45;
            this.lblShiftText.Text = "Shift Text:";
            // 
            // txtShiftText
            // 
            this.txtShiftText.Location = new System.Drawing.Point(142, 71);
            this.txtShiftText.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtShiftText.Name = "txtShiftText";
            this.txtShiftText.Size = new System.Drawing.Size(257, 31);
            this.txtShiftText.TabIndex = 2;
            // 
            // lblKeyCodes
            // 
            this.lblKeyCodes.AutoSize = true;
            this.lblKeyCodes.Location = new System.Drawing.Point(417, 128);
            this.lblKeyCodes.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblKeyCodes.Name = "lblKeyCodes";
            this.lblKeyCodes.Size = new System.Drawing.Size(60, 25);
            this.lblKeyCodes.TabIndex = 51;
            this.lblKeyCodes.Text = "X Axis";
            // 
            // chkChangeOnCaps
            // 
            this.chkChangeOnCaps.AutoSize = true;
            this.chkChangeOnCaps.Location = new System.Drawing.Point(417, 17);
            this.chkChangeOnCaps.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkChangeOnCaps.Name = "chkChangeOnCaps";
            this.chkChangeOnCaps.Size = new System.Drawing.Size(349, 29);
            this.chkChangeOnCaps.TabIndex = 1;
            this.chkChangeOnCaps.Text = "Change capitalization on Caps Lock key";
            this.chkChangeOnCaps.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBoundary
            // 
            this.btnUpdateBoundary.Location = new System.Drawing.Point(7, 279);
            this.btnUpdateBoundary.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnUpdateBoundary.Name = "btnUpdateBoundary";
            this.btnUpdateBoundary.Size = new System.Drawing.Size(125, 44);
            this.btnUpdateBoundary.TabIndex = 7;
            this.btnUpdateBoundary.Text = "Update";
            this.btnUpdateBoundary.UseVisualStyleBackColor = true;
            this.btnUpdateBoundary.Click += new System.EventHandler(this.btnUpdateBoundary_Click);
            // 
            // btnCenterText
            // 
            this.btnCenterText.Location = new System.Drawing.Point(280, 119);
            this.btnCenterText.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCenterText.Name = "btnCenterText";
            this.btnCenterText.Size = new System.Drawing.Size(122, 44);
            this.btnCenterText.TabIndex = 4;
            this.btnCenterText.Text = "Center";
            this.btnCenterText.UseVisualStyleBackColor = true;
            this.btnCenterText.Click += new System.EventHandler(this.btnCenterText_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Location = new System.Drawing.Point(7, 502);
            this.btnRectangle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(125, 44);
            this.btnRectangle.TabIndex = 11;
            this.btnRectangle.Text = "Rectangle";
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // txtDeviceId
            // 
            this.txtDeviceId.Location = new System.Drawing.Point(0, 0);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(100, 31);
            this.txtDeviceId.TabIndex = 0;
            // 
            // cmbAxisOne
            // 
            this.cmbAxisOne.FormattingEnabled = true;
            this.cmbAxisOne.Location = new System.Drawing.Point(487, 125);
            this.cmbAxisOne.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmbAxisOne.Name = "cmbAxisOne";
            this.cmbAxisOne.Size = new System.Drawing.Size(279, 33);
            this.cmbAxisOne.TabIndex = 52;
            // 
            // btnDetectAxis1
            // 
            this.btnDetectAxis1.Location = new System.Drawing.Point(417, 206);
            this.btnDetectAxis1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnDetectAxis1.Name = "btnDetectAxis1";
            this.btnDetectAxis1.Size = new System.Drawing.Size(170, 44);
            this.btnDetectAxis1.TabIndex = 53;
            this.btnDetectAxis1.Text = "Detect Axis One";
            this.btnDetectAxis1.UseVisualStyleBackColor = true;
            this.btnDetectAxis1.Click += new System.EventHandler(this.btnDetectButton_Click);
            // 
            // txtBoundaries
            // 
            this.txtBoundaries.Location = new System.Drawing.Point(142, 173);
            this.txtBoundaries.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtBoundaries.MaxVal = 2147483647;
            this.txtBoundaries.Name = "txtBoundaries";
            this.txtBoundaries.Separator = ';';
            this.txtBoundaries.Size = new System.Drawing.Size(257, 31);
            this.txtBoundaries.SpacesAroundSeparator = true;
            this.txtBoundaries.TabIndex = 5;
            this.txtBoundaries.Text = "0 ; 0";
            this.txtBoundaries.X = 0;
            this.txtBoundaries.Y = 0;
            // 
            // txtTextPosition
            // 
            this.txtTextPosition.Location = new System.Drawing.Point(142, 123);
            this.txtTextPosition.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTextPosition.MaxVal = 2147483647;
            this.txtTextPosition.Name = "txtTextPosition";
            this.txtTextPosition.Separator = ';';
            this.txtTextPosition.Size = new System.Drawing.Size(257, 31);
            this.txtTextPosition.SpacesAroundSeparator = true;
            this.txtTextPosition.TabIndex = 3;
            this.txtTextPosition.Text = "0 ; 0";
            this.txtTextPosition.X = 0;
            this.txtTextPosition.Y = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 54;
            this.label1.Text = "Device";
            // 
            // comboBoxDevicesList
            // 
            this.comboBoxDevicesList.FormattingEnabled = true;
            this.comboBoxDevicesList.Location = new System.Drawing.Point(417, 80);
            this.comboBoxDevicesList.Name = "comboBoxDevicesList";
            this.comboBoxDevicesList.Size = new System.Drawing.Size(349, 33);
            this.comboBoxDevicesList.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 56;
            this.label2.Text = "Axis One Max";
            // 
            // txtAxisOneMax
            // 
            this.txtAxisOneMax.Location = new System.Drawing.Point(569, 342);
            this.txtAxisOneMax.Name = "txtAxisOneMax";
            this.txtAxisOneMax.Size = new System.Drawing.Size(197, 31);
            this.txtAxisOneMax.TabIndex = 57;
            // 
            // txtAxisTwoMax
            // 
            this.txtAxisTwoMax.Location = new System.Drawing.Point(569, 379);
            this.txtAxisTwoMax.Name = "txtAxisTwoMax";
            this.txtAxisTwoMax.Size = new System.Drawing.Size(197, 31);
            this.txtAxisTwoMax.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 25);
            this.label3.TabIndex = 61;
            this.label3.Text = "Axis Two Max";
            // 
            // btnDetectAxis2
            // 
            this.btnDetectAxis2.Location = new System.Drawing.Point(597, 206);
            this.btnDetectAxis2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnDetectAxis2.Name = "btnDetectAxis2";
            this.btnDetectAxis2.Size = new System.Drawing.Size(170, 44);
            this.btnDetectAxis2.TabIndex = 60;
            this.btnDetectAxis2.Text = "Detect Axis Two";
            this.btnDetectAxis2.UseVisualStyleBackColor = true;
            this.btnDetectAxis2.Click += new System.EventHandler(this.btnDetectButton2_Click);
            // 
            // cmbAxisTwo
            // 
            this.cmbAxisTwo.FormattingEnabled = true;
            this.cmbAxisTwo.Location = new System.Drawing.Point(486, 167);
            this.cmbAxisTwo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmbAxisTwo.Name = "cmbAxisTwo";
            this.cmbAxisTwo.Size = new System.Drawing.Size(280, 33);
            this.cmbAxisTwo.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 58;
            this.label4.Text = "Y Axis";
            // 
            // txtStickWidth
            // 
            this.txtStickWidth.Location = new System.Drawing.Point(570, 416);
            this.txtStickWidth.Name = "txtStickWidth";
            this.txtStickWidth.Size = new System.Drawing.Size(197, 31);
            this.txtStickWidth.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(418, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 25);
            this.label5.TabIndex = 63;
            this.label5.Text = "Stick Width";
            // 
            // txtStickHeight
            // 
            this.txtStickHeight.Location = new System.Drawing.Point(570, 453);
            this.txtStickHeight.Name = "txtStickHeight";
            this.txtStickHeight.Size = new System.Drawing.Size(197, 31);
            this.txtStickHeight.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 456);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 25);
            this.label6.TabIndex = 65;
            this.label6.Text = "Stick Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(418, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 25);
            this.label7.TabIndex = 67;
            this.label7.Text = "Invert Axis One";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(418, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 25);
            this.label8.TabIndex = 68;
            this.label8.Text = "Invert Axis Two";
            // 
            // chkInvertAxisOne
            // 
            this.chkInvertAxisOne.AutoSize = true;
            this.chkInvertAxisOne.Location = new System.Drawing.Point(583, 268);
            this.chkInvertAxisOne.Name = "chkInvertAxisOne";
            this.chkInvertAxisOne.Size = new System.Drawing.Size(22, 21);
            this.chkInvertAxisOne.TabIndex = 69;
            this.chkInvertAxisOne.UseVisualStyleBackColor = true;
            // 
            // chkInvertAxisTwo
            // 
            this.chkInvertAxisTwo.AutoSize = true;
            this.chkInvertAxisTwo.Location = new System.Drawing.Point(583, 302);
            this.chkInvertAxisTwo.Name = "chkInvertAxisTwo";
            this.chkInvertAxisTwo.Size = new System.Drawing.Size(22, 21);
            this.chkInvertAxisTwo.TabIndex = 70;
            this.chkInvertAxisTwo.UseVisualStyleBackColor = true;
            // 
            // DirectInputAxisPropertiesForm
            // 
            this.AcceptButton = this.AcceptButton2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton2;
            this.ClientSize = new System.Drawing.Size(820, 759);
            this.Controls.Add(this.chkInvertAxisTwo);
            this.Controls.Add(this.chkInvertAxisOne);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtStickHeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStickWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAxisTwoMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDetectAxis2);
            this.Controls.Add(this.cmbAxisTwo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAxisOneMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDevicesList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetectAxis1);
            this.Controls.Add(this.cmbAxisOne);
            this.Controls.Add(this.btnUpdateBoundary);
            this.Controls.Add(this.btnCenterText);
            this.Controls.Add(this.btnRectangle);
            this.Controls.Add(this.chkChangeOnCaps);
            this.Controls.Add(this.lblKeyCodes);
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
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "DirectInputAxisPropertiesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Keyboard Key Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyboardKeyPropertiesForm_FormClosing);
            this.Load += new System.EventHandler(this.DirectInputAxisPropertiesForm_Load);
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
        private System.Windows.Forms.Label lblKeyCodes;
        private System.Windows.Forms.CheckBox chkChangeOnCaps;
        private System.Windows.Forms.Button btnUpdateBoundary;
        private System.Windows.Forms.Button btnCenterText;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.ComboBox cmbAxisOne;
        private System.Windows.Forms.Button btnDetectAxis1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDevicesList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAxisOneMax;
        private System.Windows.Forms.TextBox txtAxisTwoMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDetectAxis2;
        private System.Windows.Forms.ComboBox cmbAxisTwo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStickHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStickWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkInvertAxisOne;
        private System.Windows.Forms.CheckBox chkInvertAxisTwo;
    }
}