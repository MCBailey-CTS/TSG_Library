﻿namespace TSG_Library.UFuncs
{
    partial class BlankDataBuilderForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxCustomText = new System.Windows.Forms.TextBox();
            this.buttonSetAttribute = new System.Windows.Forms.Button();
            this.textBoxRevisionLevel = new System.Windows.Forms.TextBox();
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxJobNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.groupBoxSetRevName = new System.Windows.Forms.GroupBox();
            this.groupBoxName.SuspendLayout();
            this.groupBoxSetRevName.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSelect
            // 
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelect.Location = new System.Drawing.Point(25, 209);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(192, 23);
            this.buttonSelect.TabIndex = 0;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonReset.Location = new System.Drawing.Point(25, 238);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(192, 23);
            this.buttonReset.TabIndex = 18;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // textBoxCustomText
            // 
            this.textBoxCustomText.Location = new System.Drawing.Point(13, 86);
            this.textBoxCustomText.Name = "textBoxCustomText";
            this.textBoxCustomText.Size = new System.Drawing.Size(192, 20);
            this.textBoxCustomText.TabIndex = 21;
            this.textBoxCustomText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSetAttribute
            // 
            this.buttonSetAttribute.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSetAttribute.Location = new System.Drawing.Point(13, 19);
            this.buttonSetAttribute.Name = "buttonSetAttribute";
            this.buttonSetAttribute.Size = new System.Drawing.Size(192, 23);
            this.buttonSetAttribute.TabIndex = 23;
            this.buttonSetAttribute.Text = "Set RevisionText Attribute";
            this.buttonSetAttribute.UseVisualStyleBackColor = true;
            this.buttonSetAttribute.Click += new System.EventHandler(this.ButtonSetAttribute_Click);
            // 
            // textBoxRevisionLevel
            // 
            this.textBoxRevisionLevel.Location = new System.Drawing.Point(13, 48);
            this.textBoxRevisionLevel.Name = "textBoxRevisionLevel";
            this.textBoxRevisionLevel.Size = new System.Drawing.Size(192, 20);
            this.textBoxRevisionLevel.TabIndex = 24;
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.Location = new System.Drawing.Point(79, 35);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(60, 21);
            this.comboBoxOperation.TabIndex = 4;
            this.comboBoxOperation.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOperation_SelectedIndexChanged);
            // 
            // comboBoxVersion
            // 
            this.comboBoxVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxVersion.FormattingEnabled = true;
            this.comboBoxVersion.Location = new System.Drawing.Point(145, 35);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(60, 21);
            this.comboBoxVersion.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Job #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(83, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Operation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(149, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Version #";
            // 
            // textBoxJobNumber
            // 
            this.textBoxJobNumber.Location = new System.Drawing.Point(13, 36);
            this.textBoxJobNumber.Name = "textBoxJobNumber";
            this.textBoxJobNumber.Size = new System.Drawing.Size(60, 20);
            this.textBoxJobNumber.TabIndex = 15;
            this.textBoxJobNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Add Custom Description";
            // 
            // groupBoxName
            // 
            this.groupBoxName.Controls.Add(this.label2);
            this.groupBoxName.Controls.Add(this.textBoxCustomText);
            this.groupBoxName.Controls.Add(this.textBoxJobNumber);
            this.groupBoxName.Controls.Add(this.label4);
            this.groupBoxName.Controls.Add(this.label3);
            this.groupBoxName.Controls.Add(this.label1);
            this.groupBoxName.Controls.Add(this.comboBoxVersion);
            this.groupBoxName.Controls.Add(this.comboBoxOperation);
            this.groupBoxName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxName.Location = new System.Drawing.Point(12, 3);
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.Size = new System.Drawing.Size(217, 116);
            this.groupBoxName.TabIndex = 25;
            this.groupBoxName.TabStop = false;
            this.groupBoxName.Text = "Create Name";
            // 
            // groupBoxSetRevName
            // 
            this.groupBoxSetRevName.Controls.Add(this.textBoxRevisionLevel);
            this.groupBoxSetRevName.Controls.Add(this.buttonSetAttribute);
            this.groupBoxSetRevName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxSetRevName.Location = new System.Drawing.Point(12, 125);
            this.groupBoxSetRevName.Name = "groupBoxSetRevName";
            this.groupBoxSetRevName.Size = new System.Drawing.Size(217, 78);
            this.groupBoxSetRevName.TabIndex = 26;
            this.groupBoxSetRevName.TabStop = false;
            this.groupBoxSetRevName.Text = "Revision Text";
            // 
            // BlankDataBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 271);
            this.Controls.Add(this.groupBoxSetRevName);
            this.Controls.Add(this.groupBoxName);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(30, 130);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlankDataBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "1919";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BlankDataBuilderForm_FormClosed);
            this.Load += new System.EventHandler(this.BlankDataBuilderForm_Load);
            this.groupBoxName.ResumeLayout(false);
            this.groupBoxName.PerformLayout();
            this.groupBoxSetRevName.ResumeLayout(false);
            this.groupBoxSetRevName.PerformLayout();
            this.ResumeLayout(false);

        }










        #endregion

        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxCustomText;
        private System.Windows.Forms.Button buttonSetAttribute;
        private System.Windows.Forms.TextBox textBoxRevisionLevel;
        private System.Windows.Forms.ComboBox comboBoxOperation;
        private System.Windows.Forms.ComboBox comboBoxVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxJobNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.GroupBox groupBoxSetRevName;
    }
}