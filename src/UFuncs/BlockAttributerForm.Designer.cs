﻿using NXOpen;
using NXOpen.UF;
using NXOpen.UserDefinedObjects;
using System;
using TSG_Library.Utilities;
using static TSG_Library.Extensions.Extensions;

namespace TSG_Library.UFuncs
{
    partial class BlockAttributerForm
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
            this.comboBoxAddx = new System.Windows.Forms.ComboBox();
            this.comboBoxAddy = new System.Windows.Forms.ComboBox();
            this.comboBoxAddz = new System.Windows.Forms.ComboBox();
            this.labelBlockX = new System.Windows.Forms.Label();
            this.labelBlockY = new System.Windows.Forms.Label();
            this.labelBlockZ = new System.Windows.Forms.Label();
            this.groupBoxAddStock = new System.Windows.Forms.GroupBox();
            this.groupBoxBurnSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxGrind = new System.Windows.Forms.CheckBox();
            this.checkBoxBurnout = new System.Windows.Forms.CheckBox();
            this.checkBoxBurnDirZ = new System.Windows.Forms.CheckBox();
            this.checkBoxBurnDirY = new System.Windows.Forms.CheckBox();
            this.comboBoxTolerance = new System.Windows.Forms.ComboBox();
            this.checkBoxBurnDirX = new System.Windows.Forms.CheckBox();
            this.buttonSelectBlockComp = new System.Windows.Forms.Button();
            this.groupBoxAttributes = new System.Windows.Forms.GroupBox();
            this.comboBoxWeldment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxDieset = new System.Windows.Forms.ComboBox();
            this.comboBoxWireDev = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxWireTaper = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonSetAutoUpdateOn = new System.Windows.Forms.Button();
            this.groupBoxCustom = new System.Windows.Forms.GroupBox();
            this.buttonSelectMultiple = new System.Windows.Forms.Button();
            this.groupBoxMaterial = new System.Windows.Forms.GroupBox();
            this.comboBoxCustomMaterials = new System.Windows.Forms.ComboBox();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.comboBoxPurMaterials = new System.Windows.Forms.ComboBox();
            this.buttonSelectCustom = new System.Windows.Forms.Button();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.comboBoxDescription = new System.Windows.Forms.ComboBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonSelectDiesetOn = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxBlockExpressions = new System.Windows.Forms.GroupBox();
            this.buttonSelectWeldmentOff = new System.Windows.Forms.Button();
            this.buttonSelectWeldmentOn = new System.Windows.Forms.Button();
            this.buttonSelectDiesetOff = new System.Windows.Forms.Button();
            this.buttonMeasure = new System.Windows.Forms.Button();
            this.groupBoxAddStock.SuspendLayout();
            this.groupBoxBurnSettings.SuspendLayout();
            this.groupBoxAttributes.SuspendLayout();
            this.groupBoxCustom.SuspendLayout();
            this.groupBoxMaterial.SuspendLayout();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxBlockExpressions.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxAddx
            // 
            this.comboBoxAddx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxAddx.FormattingEnabled = true;
            this.comboBoxAddx.Location = new System.Drawing.Point(8, 35);
            this.comboBoxAddx.Name = "comboBoxAddx";
            this.comboBoxAddx.Size = new System.Drawing.Size(67, 21);
            this.comboBoxAddx.TabIndex = 0;
            this.comboBoxAddx.SelectedIndexChanged += new System.EventHandler(this.comboBoxAddx_SelectedIndexChanged);
            // 
            // comboBoxAddy
            // 
            this.comboBoxAddy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxAddy.FormattingEnabled = true;
            this.comboBoxAddy.Location = new System.Drawing.Point(81, 35);
            this.comboBoxAddy.Name = "comboBoxAddy";
            this.comboBoxAddy.Size = new System.Drawing.Size(67, 21);
            this.comboBoxAddy.TabIndex = 1;
            this.comboBoxAddy.SelectedIndexChanged += new System.EventHandler(this.comboBoxAddy_SelectedIndexChanged);
            // 
            // comboBoxAddz
            // 
            this.comboBoxAddz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddz.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxAddz.FormattingEnabled = true;
            this.comboBoxAddz.Location = new System.Drawing.Point(154, 35);
            this.comboBoxAddz.Name = "comboBoxAddz";
            this.comboBoxAddz.Size = new System.Drawing.Size(67, 21);
            this.comboBoxAddz.TabIndex = 2;
            this.comboBoxAddz.SelectedIndexChanged += new System.EventHandler(this.comboBoxAddz_SelectedIndexChanged);
            // 
            // labelBlockX
            // 
            this.labelBlockX.AutoSize = true;
            this.labelBlockX.Location = new System.Drawing.Point(17, 17);
            this.labelBlockX.Name = "labelBlockX";
            this.labelBlockX.Size = new System.Drawing.Size(42, 13);
            this.labelBlockX.TabIndex = 4;
            this.labelBlockX.Text = "X - Axis";
            // 
            // labelBlockY
            // 
            this.labelBlockY.AutoSize = true;
            this.labelBlockY.Location = new System.Drawing.Point(90, 17);
            this.labelBlockY.Name = "labelBlockY";
            this.labelBlockY.Size = new System.Drawing.Size(42, 13);
            this.labelBlockY.TabIndex = 5;
            this.labelBlockY.Text = "Y - Axis";
            // 
            // labelBlockZ
            // 
            this.labelBlockZ.AutoSize = true;
            this.labelBlockZ.Location = new System.Drawing.Point(163, 17);
            this.labelBlockZ.Name = "labelBlockZ";
            this.labelBlockZ.Size = new System.Drawing.Size(42, 13);
            this.labelBlockZ.TabIndex = 6;
            this.labelBlockZ.Text = "Z - Axis";
            // 
            // groupBoxAddStock
            // 
            this.groupBoxAddStock.Controls.Add(this.labelBlockX);
            this.groupBoxAddStock.Controls.Add(this.comboBoxAddx);
            this.groupBoxAddStock.Controls.Add(this.labelBlockZ);
            this.groupBoxAddStock.Controls.Add(this.comboBoxAddy);
            this.groupBoxAddStock.Controls.Add(this.labelBlockY);
            this.groupBoxAddStock.Controls.Add(this.comboBoxAddz);
            this.groupBoxAddStock.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxAddStock.Location = new System.Drawing.Point(6, 46);
            this.groupBoxAddStock.Name = "groupBoxAddStock";
            this.groupBoxAddStock.Size = new System.Drawing.Size(229, 65);
            this.groupBoxAddStock.TabIndex = 2;
            this.groupBoxAddStock.TabStop = false;
            this.groupBoxAddStock.Text = "Add Stock";
            // 
            // groupBoxBurnSettings
            // 
            this.groupBoxBurnSettings.Controls.Add(this.checkBoxGrind);
            this.groupBoxBurnSettings.Controls.Add(this.checkBoxBurnout);
            this.groupBoxBurnSettings.Controls.Add(this.checkBoxBurnDirZ);
            this.groupBoxBurnSettings.Controls.Add(this.checkBoxBurnDirY);
            this.groupBoxBurnSettings.Controls.Add(this.comboBoxTolerance);
            this.groupBoxBurnSettings.Controls.Add(this.checkBoxBurnDirX);
            this.groupBoxBurnSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxBurnSettings.Location = new System.Drawing.Point(6, 117);
            this.groupBoxBurnSettings.Name = "groupBoxBurnSettings";
            this.groupBoxBurnSettings.Size = new System.Drawing.Size(229, 105);
            this.groupBoxBurnSettings.TabIndex = 3;
            this.groupBoxBurnSettings.TabStop = false;
            this.groupBoxBurnSettings.Text = "Burn Settings";
            // 
            // checkBoxGrind
            // 
            this.checkBoxGrind.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxGrind.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxGrind.Location = new System.Drawing.Point(117, 19);
            this.checkBoxGrind.Name = "checkBoxGrind";
            this.checkBoxGrind.Size = new System.Drawing.Size(104, 20);
            this.checkBoxGrind.TabIndex = 1;
            this.checkBoxGrind.Text = "Grind";
            this.checkBoxGrind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxGrind.UseVisualStyleBackColor = true;
            this.checkBoxGrind.CheckedChanged += new System.EventHandler(this.checkBoxGrind_CheckedChanged);
            // 
            // checkBoxBurnout
            // 
            this.checkBoxBurnout.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxBurnout.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxBurnout.Location = new System.Drawing.Point(8, 19);
            this.checkBoxBurnout.Name = "checkBoxBurnout";
            this.checkBoxBurnout.Size = new System.Drawing.Size(103, 20);
            this.checkBoxBurnout.TabIndex = 0;
            this.checkBoxBurnout.Text = "Burnout";
            this.checkBoxBurnout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxBurnout.UseVisualStyleBackColor = true;
            this.checkBoxBurnout.CheckedChanged += new System.EventHandler(this.checkBoxBurnout_CheckedChanged);
            // 
            // checkBoxBurnDirZ
            // 
            this.checkBoxBurnDirZ.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxBurnDirZ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxBurnDirZ.Location = new System.Drawing.Point(154, 45);
            this.checkBoxBurnDirZ.Name = "checkBoxBurnDirZ";
            this.checkBoxBurnDirZ.Size = new System.Drawing.Size(67, 20);
            this.checkBoxBurnDirZ.TabIndex = 4;
            this.checkBoxBurnDirZ.Text = "Z";
            this.checkBoxBurnDirZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxBurnDirZ.UseVisualStyleBackColor = true;
            this.checkBoxBurnDirZ.CheckedChanged += new System.EventHandler(this.checkBoxBurnDirZ_CheckedChanged);
            // 
            // checkBoxBurnDirY
            // 
            this.checkBoxBurnDirY.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxBurnDirY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxBurnDirY.Location = new System.Drawing.Point(81, 45);
            this.checkBoxBurnDirY.Name = "checkBoxBurnDirY";
            this.checkBoxBurnDirY.Size = new System.Drawing.Size(67, 20);
            this.checkBoxBurnDirY.TabIndex = 3;
            this.checkBoxBurnDirY.Text = "Y";
            this.checkBoxBurnDirY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxBurnDirY.UseVisualStyleBackColor = true;
            this.checkBoxBurnDirY.CheckedChanged += new System.EventHandler(this.checkBoxBurnDirY_CheckedChanged);
            // 
            // comboBoxTolerance
            // 
            this.comboBoxTolerance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTolerance.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxTolerance.FormattingEnabled = true;
            this.comboBoxTolerance.Location = new System.Drawing.Point(8, 71);
            this.comboBoxTolerance.Name = "comboBoxTolerance";
            this.comboBoxTolerance.Size = new System.Drawing.Size(213, 21);
            this.comboBoxTolerance.TabIndex = 5;
            // 
            // checkBoxBurnDirX
            // 
            this.checkBoxBurnDirX.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxBurnDirX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxBurnDirX.Location = new System.Drawing.Point(8, 45);
            this.checkBoxBurnDirX.Name = "checkBoxBurnDirX";
            this.checkBoxBurnDirX.Size = new System.Drawing.Size(67, 20);
            this.checkBoxBurnDirX.TabIndex = 2;
            this.checkBoxBurnDirX.Text = "X";
            this.checkBoxBurnDirX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxBurnDirX.UseVisualStyleBackColor = true;
            this.checkBoxBurnDirX.CheckedChanged += new System.EventHandler(this.checkBoxBurnDirX_CheckedChanged);
            // 
            // buttonSelectBlockComp
            // 
            this.buttonSelectBlockComp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectBlockComp.Location = new System.Drawing.Point(12, 19);
            this.buttonSelectBlockComp.Name = "buttonSelectBlockComp";
            this.buttonSelectBlockComp.Size = new System.Drawing.Size(105, 21);
            this.buttonSelectBlockComp.TabIndex = 0;
            this.buttonSelectBlockComp.Text = "Select Block";
            this.buttonSelectBlockComp.UseVisualStyleBackColor = true;
            this.buttonSelectBlockComp.Click += new System.EventHandler(this.buttonSelectBlockComp_Click);
            // 
            // groupBoxAttributes
            // 
            this.groupBoxAttributes.Controls.Add(this.comboBoxWeldment);
            this.groupBoxAttributes.Controls.Add(this.label1);
            this.groupBoxAttributes.Controls.Add(this.label8);
            this.groupBoxAttributes.Controls.Add(this.comboBoxMaterial);
            this.groupBoxAttributes.Controls.Add(this.label9);
            this.groupBoxAttributes.Controls.Add(this.comboBoxName);
            this.groupBoxAttributes.Controls.Add(this.label10);
            this.groupBoxAttributes.Controls.Add(this.comboBoxDieset);
            this.groupBoxAttributes.Controls.Add(this.comboBoxWireDev);
            this.groupBoxAttributes.Controls.Add(this.label11);
            this.groupBoxAttributes.Controls.Add(this.comboBoxWireTaper);
            this.groupBoxAttributes.Controls.Add(this.label12);
            this.groupBoxAttributes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxAttributes.Location = new System.Drawing.Point(7, 536);
            this.groupBoxAttributes.Name = "groupBoxAttributes";
            this.groupBoxAttributes.Size = new System.Drawing.Size(240, 185);
            this.groupBoxAttributes.TabIndex = 2;
            this.groupBoxAttributes.TabStop = false;
            this.groupBoxAttributes.Text = "Default Attributes";
            // 
            // comboBoxWeldment
            // 
            this.comboBoxWeldment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeldment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxWeldment.FormattingEnabled = true;
            this.comboBoxWeldment.Location = new System.Drawing.Point(95, 154);
            this.comboBoxWeldment.Name = "comboBoxWeldment";
            this.comboBoxWeldment.Size = new System.Drawing.Size(133, 21);
            this.comboBoxWeldment.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Weldment";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(45, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Material";
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Location = new System.Drawing.Point(95, 19);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(133, 21);
            this.comboBoxMaterial.Sorted = true;
            this.comboBoxMaterial.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(54, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Name";
            // 
            // comboBoxName
            // 
            this.comboBoxName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(95, 46);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(133, 21);
            this.comboBoxName.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(52, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Dieset";
            // 
            // comboBoxDieset
            // 
            this.comboBoxDieset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDieset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxDieset.FormattingEnabled = true;
            this.comboBoxDieset.Location = new System.Drawing.Point(95, 127);
            this.comboBoxDieset.Name = "comboBoxDieset";
            this.comboBoxDieset.Size = new System.Drawing.Size(133, 21);
            this.comboBoxDieset.TabIndex = 4;
            // 
            // comboBoxWireDev
            // 
            this.comboBoxWireDev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWireDev.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxWireDev.FormattingEnabled = true;
            this.comboBoxWireDev.Location = new System.Drawing.Point(95, 73);
            this.comboBoxWireDev.Name = "comboBoxWireDev";
            this.comboBoxWireDev.Size = new System.Drawing.Size(133, 21);
            this.comboBoxWireDev.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(34, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Wire Dev.";
            // 
            // comboBoxWireTaper
            // 
            this.comboBoxWireTaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWireTaper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxWireTaper.FormattingEnabled = true;
            this.comboBoxWireTaper.Location = new System.Drawing.Point(95, 100);
            this.comboBoxWireTaper.Name = "comboBoxWireTaper";
            this.comboBoxWireTaper.Size = new System.Drawing.Size(133, 21);
            this.comboBoxWireTaper.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Wire Taper";
            // 
            // buttonSetAutoUpdateOn
            // 
            this.buttonSetAutoUpdateOn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSetAutoUpdateOn.Location = new System.Drawing.Point(21, 727);
            this.buttonSetAutoUpdateOn.Name = "buttonSetAutoUpdateOn";
            this.buttonSetAutoUpdateOn.Size = new System.Drawing.Size(104, 21);
            this.buttonSetAutoUpdateOn.TabIndex = 3;
            this.buttonSetAutoUpdateOn.Text = "Auto Update = ON";
            this.buttonSetAutoUpdateOn.UseVisualStyleBackColor = true;
            this.buttonSetAutoUpdateOn.Click += new System.EventHandler(this.buttonSetAutoUpdateOn_Click);
            // 
            // groupBoxCustom
            // 
            this.groupBoxCustom.Controls.Add(this.buttonSelectMultiple);
            this.groupBoxCustom.Controls.Add(this.groupBoxMaterial);
            this.groupBoxCustom.Controls.Add(this.buttonSelectCustom);
            this.groupBoxCustom.Controls.Add(this.groupBoxDescription);
            this.groupBoxCustom.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxCustom.Location = new System.Drawing.Point(7, 305);
            this.groupBoxCustom.Name = "groupBoxCustom";
            this.groupBoxCustom.Size = new System.Drawing.Size(240, 225);
            this.groupBoxCustom.TabIndex = 1;
            this.groupBoxCustom.TabStop = false;
            this.groupBoxCustom.Text = " Custom Description";
            // 
            // buttonSelectMultiple
            // 
            this.buttonSelectMultiple.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectMultiple.Location = new System.Drawing.Point(125, 19);
            this.buttonSelectMultiple.Name = "buttonSelectMultiple";
            this.buttonSelectMultiple.Size = new System.Drawing.Size(102, 21);
            this.buttonSelectMultiple.TabIndex = 1;
            this.buttonSelectMultiple.Text = "Select Multiple";
            this.buttonSelectMultiple.UseVisualStyleBackColor = true;
            this.buttonSelectMultiple.Click += new System.EventHandler(this.buttonSelectMultiple_Click);
            // 
            // groupBoxMaterial
            // 
            this.groupBoxMaterial.Controls.Add(this.comboBoxCustomMaterials);
            this.groupBoxMaterial.Controls.Add(this.textBoxMaterial);
            this.groupBoxMaterial.Controls.Add(this.comboBoxPurMaterials);
            this.groupBoxMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxMaterial.Location = new System.Drawing.Point(5, 132);
            this.groupBoxMaterial.Name = "groupBoxMaterial";
            this.groupBoxMaterial.Size = new System.Drawing.Size(229, 80);
            this.groupBoxMaterial.TabIndex = 3;
            this.groupBoxMaterial.TabStop = false;
            this.groupBoxMaterial.Text = "Materials";
            // 
            // comboBoxCustomMaterials
            // 
            this.comboBoxCustomMaterials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomMaterials.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxCustomMaterials.FormattingEnabled = true;
            this.comboBoxCustomMaterials.Location = new System.Drawing.Point(118, 45);
            this.comboBoxCustomMaterials.Name = "comboBoxCustomMaterials";
            this.comboBoxCustomMaterials.Size = new System.Drawing.Size(104, 21);
            this.comboBoxCustomMaterials.Sorted = true;
            this.comboBoxCustomMaterials.TabIndex = 2;
            this.comboBoxCustomMaterials.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomMaterials_SelectedIndexChanged);
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(6, 19);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.Size = new System.Drawing.Size(216, 20);
            this.textBoxMaterial.TabIndex = 0;
            this.textBoxMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMaterial.Click += new System.EventHandler(this.textBoxMaterial_Click);
            this.textBoxMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMaterial_KeyDown);
            // 
            // comboBoxPurMaterials
            // 
            this.comboBoxPurMaterials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPurMaterials.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxPurMaterials.FormattingEnabled = true;
            this.comboBoxPurMaterials.Location = new System.Drawing.Point(6, 45);
            this.comboBoxPurMaterials.Name = "comboBoxPurMaterials";
            this.comboBoxPurMaterials.Size = new System.Drawing.Size(103, 21);
            this.comboBoxPurMaterials.Sorted = true;
            this.comboBoxPurMaterials.TabIndex = 1;
            this.comboBoxPurMaterials.SelectedIndexChanged += new System.EventHandler(this.comboBoxPurMaterials_SelectedIndexChanged);
            // 
            // buttonSelectCustom
            // 
            this.buttonSelectCustom.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectCustom.Location = new System.Drawing.Point(12, 19);
            this.buttonSelectCustom.Name = "buttonSelectCustom";
            this.buttonSelectCustom.Size = new System.Drawing.Size(102, 21);
            this.buttonSelectCustom.TabIndex = 0;
            this.buttonSelectCustom.Text = "Select Custom";
            this.buttonSelectCustom.UseVisualStyleBackColor = true;
            this.buttonSelectCustom.Click += new System.EventHandler(this.buttonSelectCustom_Click);
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.comboBoxDescription);
            this.groupBoxDescription.Controls.Add(this.textBoxDescription);
            this.groupBoxDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxDescription.Location = new System.Drawing.Point(6, 46);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(229, 80);
            this.groupBoxDescription.TabIndex = 2;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Description";
            // 
            // comboBoxDescription
            // 
            this.comboBoxDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxDescription.FormattingEnabled = true;
            this.comboBoxDescription.Location = new System.Drawing.Point(6, 45);
            this.comboBoxDescription.Name = "comboBoxDescription";
            this.comboBoxDescription.Size = new System.Drawing.Size(216, 21);
            this.comboBoxDescription.Sorted = true;
            this.comboBoxDescription.TabIndex = 1;
            this.comboBoxDescription.SelectedIndexChanged += new System.EventHandler(this.comboBoxDescription_SelectedIndexChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(6, 19);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(216, 20);
            this.textBoxDescription.TabIndex = 0;
            this.textBoxDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            this.textBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDescription_KeyDown);
            // 
            // buttonSelectDiesetOn
            // 
            this.buttonSelectDiesetOn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectDiesetOn.Location = new System.Drawing.Point(12, 228);
            this.buttonSelectDiesetOn.Name = "buttonSelectDiesetOn";
            this.buttonSelectDiesetOn.Size = new System.Drawing.Size(102, 21);
            this.buttonSelectDiesetOn.TabIndex = 4;
            this.buttonSelectDiesetOn.Text = "Dieset = On";
            this.buttonSelectDiesetOn.UseVisualStyleBackColor = true;
            this.buttonSelectDiesetOn.Click += new System.EventHandler(this.buttonSelectDiesetOn_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonExit.Location = new System.Drawing.Point(19, 781);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(216, 21);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonApply.Location = new System.Drawing.Point(132, 727);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(103, 48);
            this.buttonApply.TabIndex = 5;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonReset.Location = new System.Drawing.Point(21, 754);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(104, 21);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBoxBlockExpressions
            // 
            this.groupBoxBlockExpressions.Controls.Add(this.buttonSelectWeldmentOff);
            this.groupBoxBlockExpressions.Controls.Add(this.buttonSelectWeldmentOn);
            this.groupBoxBlockExpressions.Controls.Add(this.buttonSelectDiesetOff);
            this.groupBoxBlockExpressions.Controls.Add(this.buttonSelectDiesetOn);
            this.groupBoxBlockExpressions.Controls.Add(this.buttonMeasure);
            this.groupBoxBlockExpressions.Controls.Add(this.buttonSelectBlockComp);
            this.groupBoxBlockExpressions.Controls.Add(this.groupBoxAddStock);
            this.groupBoxBlockExpressions.Controls.Add(this.groupBoxBurnSettings);
            this.groupBoxBlockExpressions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxBlockExpressions.Location = new System.Drawing.Point(7, 12);
            this.groupBoxBlockExpressions.Name = "groupBoxBlockExpressions";
            this.groupBoxBlockExpressions.Size = new System.Drawing.Size(240, 287);
            this.groupBoxBlockExpressions.TabIndex = 0;
            this.groupBoxBlockExpressions.TabStop = false;
            this.groupBoxBlockExpressions.Text = "Block Expressions";
            // 
            // buttonSelectWeldmentOff
            // 
            this.buttonSelectWeldmentOff.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectWeldmentOff.Location = new System.Drawing.Point(123, 255);
            this.buttonSelectWeldmentOff.Name = "buttonSelectWeldmentOff";
            this.buttonSelectWeldmentOff.Size = new System.Drawing.Size(104, 21);
            this.buttonSelectWeldmentOff.TabIndex = 7;
            this.buttonSelectWeldmentOff.Text = "Weldment = Off";
            this.buttonSelectWeldmentOff.UseVisualStyleBackColor = true;
            this.buttonSelectWeldmentOff.Click += new System.EventHandler(this.buttonSelectWeldmentOff_Click);
            // 
            // buttonSelectWeldmentOn
            // 
            this.buttonSelectWeldmentOn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectWeldmentOn.Location = new System.Drawing.Point(11, 255);
            this.buttonSelectWeldmentOn.Name = "buttonSelectWeldmentOn";
            this.buttonSelectWeldmentOn.Size = new System.Drawing.Size(102, 21);
            this.buttonSelectWeldmentOn.TabIndex = 6;
            this.buttonSelectWeldmentOn.Text = "Weldment = On";
            this.buttonSelectWeldmentOn.UseVisualStyleBackColor = true;
            this.buttonSelectWeldmentOn.Click += new System.EventHandler(this.buttonSelectWeldmentOn_Click);
            // 
            // buttonSelectDiesetOff
            // 
            this.buttonSelectDiesetOff.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectDiesetOff.Location = new System.Drawing.Point(123, 228);
            this.buttonSelectDiesetOff.Name = "buttonSelectDiesetOff";
            this.buttonSelectDiesetOff.Size = new System.Drawing.Size(104, 21);
            this.buttonSelectDiesetOff.TabIndex = 5;
            this.buttonSelectDiesetOff.Text = "Dieset = Off";
            this.buttonSelectDiesetOff.UseVisualStyleBackColor = true;
            this.buttonSelectDiesetOff.Click += new System.EventHandler(this.buttonSelectDiesetOff_Click);
            // 
            // buttonMeasure
            // 
            this.buttonMeasure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonMeasure.Location = new System.Drawing.Point(123, 19);
            this.buttonMeasure.Name = "buttonMeasure";
            this.buttonMeasure.Size = new System.Drawing.Size(104, 21);
            this.buttonMeasure.TabIndex = 1;
            this.buttonMeasure.Text = "Measure";
            this.buttonMeasure.UseVisualStyleBackColor = true;
            this.buttonMeasure.Click += new System.EventHandler(this.buttonMeasure_Click);
            // 
            // BlockAttributerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 811);
            this.Controls.Add(this.groupBoxBlockExpressions);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBoxAttributes);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.groupBoxCustom);
            this.Controls.Add(this.buttonSetAutoUpdateOn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(30, 130);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlockAttributerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "1919";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
#pragma warning disable CS0618 // Type or member is obsolete
            this.Load += new System.EventHandler(this.MainForm_Load);
#pragma warning restore CS0618 // Type or member is obsolete
            this.groupBoxAddStock.ResumeLayout(false);
            this.groupBoxAddStock.PerformLayout();
            this.groupBoxBurnSettings.ResumeLayout(false);
            this.groupBoxAttributes.ResumeLayout(false);
            this.groupBoxAttributes.PerformLayout();
            this.groupBoxCustom.ResumeLayout(false);
            this.groupBoxMaterial.ResumeLayout(false);
            this.groupBoxMaterial.PerformLayout();
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.groupBoxBlockExpressions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBlockX;
        private System.Windows.Forms.ComboBox comboBoxAddz;
        private System.Windows.Forms.ComboBox comboBoxAddy;
        private System.Windows.Forms.ComboBox comboBoxAddx;
        private System.Windows.Forms.GroupBox groupBoxAddStock;
        private System.Windows.Forms.Label labelBlockZ;
        private System.Windows.Forms.Label labelBlockY;
        private System.Windows.Forms.GroupBox groupBoxBurnSettings;
        private System.Windows.Forms.Button buttonSelectBlockComp;
        private System.Windows.Forms.GroupBox groupBoxAttributes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxDieset;
        private System.Windows.Forms.ComboBox comboBoxWireDev;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxWireTaper;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSetAutoUpdateOn;
        private System.Windows.Forms.GroupBox groupBoxCustom;
        private System.Windows.Forms.GroupBox groupBoxMaterial;
        private System.Windows.Forms.TextBox textBoxMaterial;
        private System.Windows.Forms.Button buttonSelectCustom;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.ComboBox comboBoxPurMaterials;
        private System.Windows.Forms.CheckBox checkBoxGrind;
        private System.Windows.Forms.CheckBox checkBoxBurnout;
        private System.Windows.Forms.CheckBox checkBoxBurnDirZ;
        private System.Windows.Forms.CheckBox checkBoxBurnDirY;
        private System.Windows.Forms.ComboBox comboBoxTolerance;
        private System.Windows.Forms.CheckBox checkBoxBurnDirX;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBoxBlockExpressions;
        private System.Windows.Forms.ComboBox comboBoxCustomMaterials;
        private System.Windows.Forms.Button buttonMeasure;
        private System.Windows.Forms.Button buttonSelectDiesetOn;
        private System.Windows.Forms.Button buttonSelectDiesetOff;
        private System.Windows.Forms.Button buttonSelectMultiple;
        private System.Windows.Forms.ComboBox comboBoxWeldment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectWeldmentOff;
        private System.Windows.Forms.Button buttonSelectWeldmentOn;




        //////////////////////////////////////////////////////////////////////////////


        private void UpdateBoundingBox()
        {
            if (!_allowBoundingBox)
                return;

            __display_part_.Views.Refresh();

            // get named expressions
            bool isNamedExpression = false;

            Expression AddX = null,
                AddY = null,
                AddZ = null;

            double xValue = 0,
                yValue = 0,
                zValue = 0;

            NewMethod114(ref isNamedExpression, ref AddX, ref AddY, ref AddZ, ref xValue, ref yValue, ref zValue);

            if (!isNamedExpression)
                return;

            _workPart.Expressions.Edit(AddX, comboBoxAddx.Text);
            xValue = AddX.Value;
            _workPart.Expressions.Edit(AddY, comboBoxAddy.Text);
            yValue = AddY.Value;
            _workPart.Expressions.Edit(AddZ, comboBoxAddz.Text);
            zValue = AddZ.Value;
            // get bounding box info
            double[] distances = NewMethod33(xValue, yValue, zValue);
            CreateTempBlockLines(__display_part_.WCS.Origin, distances[0], distances[1], distances[2]);
        }

        private void CreateTempBlockLines(Point3d wcsOrigin, double lineLength, double lineWidth, double lineHeight)
        {
            Tag prevWork = NXOpen.Tag.Null;
#pragma warning disable CS0618 // Type or member is obsolete
            ufsession_.Assem.SetWorkPartQuietly(__display_part_.Tag, out prevWork);
#pragma warning restore CS0618 // Type or member is obsolete

            Point3d mappedStartPoint1 = MapAbsoluteToWcs(wcsOrigin);
            UFObj.DispProps dispProps = new UFObj.DispProps { color = 7 };
            UFCurve.Line lineData1 = new UFCurve.Line();
            Point3d endPointX1 = mappedStartPoint1.__AddX(lineLength);
            Point3d mappedEndPointX1 = MapWcsToAbsolute(endPointX1);
            lineData1 = DisplayUFLine(wcsOrigin, dispProps, mappedEndPointX1);
            ShowTemporarySizeText(lineLength, wcsOrigin, mappedEndPointX1);
            Point3d endPointY1 = mappedStartPoint1.__AddY(lineWidth);
            Point3d mappedEndPointY1 = MapWcsToAbsolute(endPointY1);
            _ = DisplayUFLine(wcsOrigin, dispProps, mappedEndPointY1);
            ShowTemporarySizeText(lineWidth, wcsOrigin, mappedEndPointY1);
            Point3d mappedEndPointZ1 = MapWcsToAbsolute(mappedStartPoint1.__AddZ(lineHeight));
            lineData1 = DisplayUFLine(wcsOrigin, dispProps, mappedEndPointZ1);
            ShowTemporarySizeText(lineHeight, wcsOrigin, mappedEndPointZ1);
            Point3d endPointX2 = MapAbsoluteToWcs(mappedEndPointY1).__AddX(lineLength);
            Point3d mappedEndPointX2 = MapWcsToAbsolute(endPointX2);
            lineData1 = DisplayUFLine(mappedEndPointY1, dispProps, mappedEndPointX2);
            lineData1 = DisplayUFLine(mappedEndPointX1, dispProps, mappedEndPointX2);
            Point3d mappedStartPoint3 = MapAbsoluteToWcs(mappedEndPointZ1);
            Point3d endPointX1Ceiling = mappedStartPoint3.__AddX(lineLength);
            Point3d mappedEndPointX1Ceiling = MapWcsToAbsolute(endPointX1Ceiling);
            lineData1 = DisplayUFLine(mappedEndPointZ1, dispProps, mappedEndPointX1Ceiling);
            Point3d endPointY1Ceiling = mappedStartPoint3.__AddY(lineWidth);
            Point3d mappedEndPointY1Ceiling = MapWcsToAbsolute(endPointY1Ceiling);
            lineData1 = CreateUFLine(mappedEndPointZ1, mappedEndPointY1Ceiling);
            dispProps = DisplayTemporaryLine(dispProps, lineData1);
            Point3d mappedStartPoint4 = MapAbsoluteToWcs(mappedEndPointY1Ceiling);
            Point3d endPointX2Ceiling = mappedStartPoint4.__AddX(lineLength);
            Point3d mappedEndPointX2Ceiling = MapWcsToAbsolute(endPointX2Ceiling);
            lineData1 = DisplayUFLine(mappedEndPointY1Ceiling, dispProps, mappedEndPointX2Ceiling);
            lineData1 = DisplayUFLine(mappedEndPointX1Ceiling, dispProps, mappedEndPointX2Ceiling);
            lineData1 = DisplayUFLine(mappedEndPointX1, dispProps, mappedEndPointX1Ceiling);
            lineData1 = DisplayUFLine(mappedEndPointY1, dispProps, mappedEndPointY1Ceiling);
            lineData1 = DisplayUFLine(mappedEndPointX2, dispProps, mappedEndPointX2Ceiling);

            if (_selComp != null)
            {
                __work_component_ = _selComp;
                return;
            }

            __work_part_ = prevWork.__To<Part>();
            _workPart = session_.Parts.Work;
            __display_part_ = session_.Parts.Display;

            //==================================================================================================================
        }

        private void ShowTemporarySizeText(double length, Point3d start, Point3d end)
        {
            Tag view = __display_part_.Views.WorkView.Tag;
            UFDisp.ViewType viewType = UFDisp.ViewType.UseWorkView;

            string dim = __display_part_.PartUnits == BasePart.Units.Inches
                ? string.Format("{0:0.000}", System.Math.Round(length, 3))
                : string.Format("{0:0.000}", System.Math.Round(length, 3) / 25.4);

            double[] midPoint = new double[3];
            UFObj.DispProps dispProps = new UFObj.DispProps { color = 31 };
            double charSize;
            int font = 1;
            charSize = __display_part_.PartUnits == BasePart.Units.Inches ? .125 : 3.175;
            midPoint[0] = (start.X + end.X) / 2;
            midPoint[1] = (start.Y + end.Y) / 2;
            midPoint[2] = (start.Z + end.Z) / 2;
            ufsession_.Disp.DisplayTemporaryText(view, viewType, dim, midPoint, UFDisp.TextRef.Middlecenter, ref dispProps, charSize, font);
        }

        private static UFObj.DispProps DisplayTemporaryLine(UFObj.DispProps dispProps, UFCurve.Line lineData1)
        {
            ufsession_.Disp.DisplayTemporaryLine(
                            __display_part_.Views.WorkView.Tag,
                            UFDisp.ViewType.UseWorkView,
                            lineData1.start_point,
                            lineData1.end_point,
                            ref dispProps);
            return dispProps;
        }

        private static string NewMethod73(string description)
        {
            if (__work_part_.__HasAttribute("DESCRIPTION"))
                description = __work_part_.__GetStringAttribute("DESCRIPTION");
            else
                __work_part_.__SetAttribute("DESCRIPTION", "NO DESCRIPTION");
            return description;
        }

        private static void NewMethod73()
        {
            using (session_.__UsingSuppressDisplay())
            using (session_.__UsingDisplayPartReset())
                foreach (var weldmentComp in _selectedComponents)
                {
                    __display_part_ = weldmentComp.__Prototype();
                    _workPart = session_.Parts.Work;
                    __display_part_ = session_.Parts.Display;
                    Expression noteExp = null;
                    bool isExpression = false;
                    NewMethod51(ref noteExp, ref isExpression);
                    string description = string.Empty;

                    description = NewMethod72(description);

                    NewMethod36(noteExp, isExpression, description);
                }
        }

        private static string NewMethod72(string description)
        {
            if (_workPart.__HasAttribute("DESCRIPTION"))
                description = _workPart.__GetStringAttribute("DESCRIPTION");
            else
                _workPart.__SetAttribute("DESCRIPTION", "NO DESCRIPTION");
            return description;
        }


        private static void NewMethod76()
        {
            using (session_.__UsingSuppressDisplay())
            using (session_.__UsingDisplayPartReset())
                foreach (var diesetComp in _selectedComponents)
                {
                    __display_part_ = diesetComp.__Prototype();
                    Expression noteExp = null;
                    bool isExpression = false;
                    NewMethod35(ref noteExp, ref isExpression);
                    string description = _workPart.__GetStringAttribute("DESCRIPTION");
                    NewMethod34(noteExp, isExpression, description);
                }
        }

        private static void NewMethod74()
        {
            using (session_.__UsingDisplayPartReset())
            using (session_.__UsingSuppressDisplay())
                foreach (var weldmentComp in _selectedComponents)
                {
                    __display_part_ = weldmentComp.__Prototype();
                    Expression noteExp = null;
                    bool isExpression = false;
                    NewMethod2(ref noteExp, ref isExpression);
                    string description = _workPart.__GetStringAttribute("DESCRIPTION");
                    NewMethod37(noteExp, isExpression, description);
                }
        }

        private static void NewMethod59(UserDefinedObject[] currentUdo)
        {
            UserDefinedObject myUDO = currentUdo[0];
            int[] updateFlag = myUDO.GetIntegers();
            int[] updateOn = { 1 };
            myUDO.SetIntegers(updateOn);
            _workPart.__SetAttribute("AUTO UPDATE", "ON");
        }

        private static void NewMethod58(UserDefinedObject[] currentUdo)
        {
            UserDefinedObject myUDO = currentUdo[0];
            int[] updateFlag = myUDO.GetIntegers();
            int[] updateOn = { 1 };
            myUDO.SetIntegers(updateOn);
            _workPart.__SetAttribute("AUTO UPDATE", "ON");
        }


        private void NewMethod55()
        {
            Unit unit1 = _workPart.UnitCollection.FindObject("MilliMeter");

            if (comboBoxAddx.SelectedIndex > 0)
                _ = _workPart.Expressions.CreateWithUnits($"AddX={comboBoxAddx.Text}", unit1);
            else
                _ = _workPart.Expressions.CreateWithUnits("AddX=.000", unit1);

            if (comboBoxAddy.SelectedIndex > 0)
                _ = _workPart.Expressions.CreateWithUnits($"AddY={comboBoxAddy.Text}", unit1);
            else
                _ = _workPart.Expressions.CreateWithUnits("AddY=.000", unit1);

            if (comboBoxAddz.SelectedIndex > 0)
                _ = _workPart.Expressions.CreateWithUnits(NewMethod60(), unit1);
            else
                _ = _workPart.Expressions.CreateWithUnits("AddZ=.000", unit1);
        }

        private void NewMethod54()
        {
            Unit unit1 = _workPart.UnitCollection.FindObject("Inch");

            if (comboBoxAddx.SelectedIndex > 0)
                _ = _workPart.Expressions.CreateWithUnits($"AddX={comboBoxAddx.Text}", unit1);
            else
                _ = _workPart.Expressions.CreateWithUnits("AddX=.000", unit1);

            if (comboBoxAddy.SelectedIndex > 0)
                _ = _workPart.Expressions.CreateWithUnits($"AddY={comboBoxAddy.Text}", unit1);
            else
                _ = _workPart.Expressions.CreateWithUnits("AddY=.000", unit1);

            if (comboBoxAddz.SelectedIndex > 0)
                _ = _workPart.Expressions.CreateWithUnits($"AddZ={comboBoxAddz.Text}", unit1);
            else
                _ = _workPart.Expressions.CreateWithUnits("AddZ=.000", unit1);
        }

        private static void NewMethod77(string diesetValue)
        {
            if (diesetValue == "yes")
            {
                string description = _workPart.__GetStringAttribute("DESCRIPTION");

                if (!description.ToLower().Contains("dieset"))
                {
                    description += " DIESET";
                    _workPart.__SetAttribute("DESCRIPTION", description);
                }
            }
        }

        private static void NewMethod75(string diesetValue)
        {
            if (diesetValue == "yes")
            {
                string description = _workPart.__GetStringAttribute("DESCRIPTION");

                if (!description.ToLower().Contains("dieset"))
                {
                    description += " DIESET";
                    _workPart.__SetAttribute("DESCRIPTION", description);
                }
            }
        }

        private static void NewMethod41(string burnDirValue, string grindTolValue, double xGrindDist, double yGrindDist, double zGrindDist)
        {
            if (burnDirValue.ToLower() == "x")
                _workPart.__SetAttribute("DESCRIPTION", NewMethod61(grindTolValue, xGrindDist));

            if (burnDirValue.ToLower() == "y")
                _workPart.__SetAttribute("DESCRIPTION", NewMethod62(grindTolValue, yGrindDist));

            if (burnDirValue.ToLower() == "z")
                _workPart.__SetAttribute("DESCRIPTION", NewMethod63(grindTolValue, zGrindDist));
        }
        private static void NewMethod40(string grindTolValue, double[] distances, double[] grindDistances, double zGrindDist)
        {
            if (zGrindDist == grindDistances[0])
                _workPart.__SetAttribute("DESCRIPTION", NewMethod64(grindTolValue, distances, grindDistances));

            if (zGrindDist == grindDistances[1])
                _workPart.__SetAttribute("DESCRIPTION",
                    NewMethod65(grindTolValue, distances, grindDistances));

            if (zGrindDist == grindDistances[2])
                _workPart.__SetAttribute("DESCRIPTION",
                    NewMethod66(grindTolValue, distances, grindDistances));
        }

        private static void NewMethod39(string grindTolValue, double[] distances, double[] grindDistances, double yGrindDist)
        {
            if (yGrindDist == grindDistances[0])
                _workPart.__SetAttribute("DESCRIPTION",
                    NewMethod78(grindTolValue, distances, grindDistances));

            if (yGrindDist == grindDistances[1])
                _workPart.__SetAttribute("DESCRIPTION",
                    NewMethod79(grindTolValue, distances, grindDistances));
            if (yGrindDist == grindDistances[2])
                _workPart.__SetAttribute("DESCRIPTION",
                    NewMethod80(grindTolValue, distances, grindDistances));
        }

        private static void NewMethod38(string grindTolValue, double[] distances, double[] grindDistances, double xGrindDist)
        {
            if (xGrindDist == grindDistances[0])
                _workPart.__SetAttribute("DESCRIPTION",
                    NewMethod92(grindTolValue, distances, grindDistances));
            if (xGrindDist == grindDistances[1])
                _workPart.__SetAttribute("DESCRIPTION",
                    NewMethod105(grindTolValue, distances, grindDistances));
            if (xGrindDist == grindDistances[2])
                NewMethod106(grindTolValue, distances, grindDistances);
        }

        private static void NewMethod69(string grindTolValue, double[] distances, double[] grindDistances, double zGrindDist, double tolerance)
        {
            if (System.Math.Abs(zGrindDist - grindDistances[0]) < tolerance)
                _workPart.SetUserAttribute("DESCRIPTION", -1,
                    $"{grindDistances[0]:f3} {grindTolValue} X {distances[1]:f2} X {distances[2]:f2}",
                    NXOpen.Update.Option.Now);
            if (System.Math.Abs(zGrindDist - grindDistances[1]) < tolerance)
                _workPart.SetUserAttribute("DESCRIPTION", -1,
                    $"{distances[0]:f2} X {grindDistances[1]:f3} {grindTolValue} X {distances[2]:f2}",
                    NXOpen.Update.Option.Now);
            if (System.Math.Abs(zGrindDist - grindDistances[2]) < tolerance)
                _workPart.SetUserAttribute("DESCRIPTION", -1,
                    $"{distances[0]:f2} X {distances[1]:f2} X {grindDistances[2]:f3} {grindTolValue}",
                    NXOpen.Update.Option.Now);
        }

        private static void NewMethod68(string grindTolValue, double[] distances, double[] grindDistances, double yGrindDist, double tolerance)
        {
            if (System.Math.Abs(yGrindDist - grindDistances[0]) < tolerance)
                _workPart.SetUserAttribute("DESCRIPTION", -1,
                    $"{grindDistances[0]:f3} {grindTolValue} X {distances[1]:f2} X {distances[2]:f2}",
                    NXOpen.Update.Option.Now);
            if (System.Math.Abs(yGrindDist - grindDistances[1]) < tolerance)
                _workPart.SetUserAttribute("DESCRIPTION", -1,
                    $"{distances[0]:f2} X {grindDistances[1]:f3} {grindTolValue} X {distances[2]:f2}",
                    NXOpen.Update.Option.Now);
            if (System.Math.Abs(yGrindDist - grindDistances[2]) < tolerance)
                _workPart.SetUserAttribute("DESCRIPTION", -1,
                    $"{distances[0]:f2} X {distances[1]:f2} X {grindDistances[2]:f3} {grindTolValue}",
                    NXOpen.Update.Option.Now);
        }

        private static void NewMethod67(string grindTolValue, double[] distances, double[] grindDistances, double xGrindDist, double tolerance)
        {
            if (System.Math.Abs(xGrindDist - grindDistances[0]) < tolerance)
                _workPart.SetUserAttribute("DESCRIPTION", -1,
                    $"{grindDistances[0]:f3} {grindTolValue} X {distances[1]:f2} X {distances[2]:f2}",
                    NXOpen.Update.Option.Now);
            if (System.Math.Abs(xGrindDist - grindDistances[1]) < tolerance)
                _workPart.SetUserAttribute("DESCRIPTION", -1,
                    $"{distances[0]:f2} X {grindDistances[1]:f3} {grindTolValue} X {distances[2]:f2}",
                    NXOpen.Update.Option.Now);
            if (System.Math.Abs(xGrindDist - grindDistances[2]) < tolerance)
                _workPart.SetUserAttribute("DESCRIPTION", -1,
                    $"{distances[0]:f2} X {distances[1]:f2} X {grindDistances[2]:f3} {grindTolValue}",
                    NXOpen.Update.Option.Now);
        }

        private static void NewMethod42(string burnDirValue, double yDist, double zDist)
        {
            if (burnDirValue.ToLower() == "x")
                _workPart.__SetAttribute("DESCRIPTION", $"BURN {"{xDist:f2}"}");

            if (burnDirValue.ToLower() == "y")
                _workPart.__SetAttribute("DESCRIPTION", $"BURN {string.Format("{0:f2}", yDist)}");

            if (burnDirValue.ToLower() == "z")
                _workPart.__SetAttribute("DESCRIPTION", $"BURN {string.Format("{0:f2}", zDist)}");
        }





        private static string NewMethod57(double[] distances)
        {
            return string.Format("{0:f2}", distances[0]) + " X " + string.Format("{0:f2}", distances[1]) +
                                        " X " +
                                        string.Format("{0:f2}", distances[2]);
        }

        private static string NewMethod56(double[] distances)
        {
            return $"{distances[0]:f2} X {$"{distances[1]:f2}"} X {distances[2]:f2}";
        }




        private static string NewMethod63(string grindTolValue, double zGrindDist)
        {
            return $"BURN {$"{zGrindDist:f3}"} {grindTolValue}";
        }

        private static string NewMethod62(string grindTolValue, double yGrindDist)
        {
            return $"BURN {$"{yGrindDist:f3}"} {grindTolValue}";
        }

        private static string NewMethod61(string grindTolValue, double xGrindDist)
        {
            return $"BURN {$"{xGrindDist:f3}"} {grindTolValue}";
        }



        private static string NewMethod66(string grindTolValue, double[] distances, double[] grindDistances)
        {
            return $"{distances[0]:f2}" + " X " +
                                $"{distances[1]:f2}" + " X " +
                                $"{grindDistances[2]:f3}" + " " + grindTolValue;
        }

        private static string NewMethod65(string grindTolValue, double[] distances, double[] grindDistances)
        {
            return $"{distances[0]:f2}" + " X " +
                                $"{grindDistances[1]:f3}" + " " + grindTolValue +
                                " X " +
                                $"{distances[2]:f2}";
        }

        private static string NewMethod64(string grindTolValue, double[] distances, double[] grindDistances)
        {
            return $"{grindDistances[0]:f3} {grindTolValue} X {$"{distances[1]:f2}"} X {$"{distances[2]:f2}"}";
        }



        private static string NewMethod80(string grindTolValue, double[] distances, double[] grindDistances)
        {
            return $"{string.Format("{0:f2}", distances[0])} X {string.Format("{0:f2}", distances[1])} X {string.Format("{0:f3}", grindDistances[2])} {grindTolValue}";
        }

        private static string NewMethod79(string grindTolValue, double[] distances, double[] grindDistances)
        {
            return $"{$"{distances[0]:f2}"} X " +
                                $"{$"{grindDistances[1]:f3}"} {grindTolValue} X {string.Format("{0:f2}", distances[2])}";
        }

        private static string NewMethod78(string grindTolValue, double[] distances, double[] grindDistances)
        {
            return $"{$"{grindDistances[0]:f3}"} {grindTolValue} X {$"{distances[1]:f2}"} X {string.Format("{0:f2}", distances[2])}";
        }


        private static void NewMethod106(string grindTolValue, double[] distances, double[] grindDistances)
        {
            _workPart.__SetAttribute("DESCRIPTION",
                                string.Format("{0:f2}", distances[0]) + " X " +
                                string.Format("{0:f2}", distances[1]) + " X " +
                                string.Format("{0:f3}", grindDistances[2]) + " " + grindTolValue);
        }

        private static string NewMethod105(string grindTolValue, double[] distances, double[] grindDistances)
        {
            return $"{distances[0]:f2} X {$"{grindDistances[1]:f3}"} {grindTolValue} X {string.Format("{0:f2}", distances[2])}";
        }

        private static string NewMethod92(string grindTolValue, double[] distances, double[] grindDistances)
        {
            return $"{grindDistances[0]:f3} {grindTolValue} X {$"{distances[1]:f2}"} X {string.Format("{0:f2}", distances[2])}";
        }


        private static void NewMethod36(Expression noteExp, bool isExpression, string description)
        {
            if (description == "" && isExpression)
            {
                noteExp.RightHandSide = "\"yes\"";
                _workPart.Expressions.CreateExpression("String", "WeldmentNote=\"yes\"");
                return;
            }

            if (!description.ToLower().Contains("weldment"))
            {
                description += " WELDMENT";
                _workPart.__SetAttribute("DESCRIPTION", description);
            }

            if (isExpression)
                noteExp.RightHandSide = "\"yes\"";

            _workPart.Expressions.CreateExpression("String", "WeldmentNote=\"yes\"");
        }



        private static void NewMethod37(Expression noteExp, bool isExpression, string description)
        {
            if (description != "")
            {
                description = description.Replace(" WELDMENT", "");
                _workPart.__SetAttribute("DESCRIPTION", description);

                if (isExpression)
                {
                    noteExp.RightHandSide = "\"no\"";
                }
                else
                {
                    Expression weldmentExp =
                        _workPart.Expressions.CreateExpression("String", "WeldmentNote=\"no\"");
                }
            }
            else
            {
                if (isExpression)
                {
                    noteExp.RightHandSide = "\"no\"";
                }
                else
                {
                    Expression weldmentExp =
                        _workPart.Expressions.CreateExpression("String", "WeldmentNote=\"no\"");
                }
            }
        }

        private static void NewMethod34(Expression noteExp, bool isExpression, string description)
        {
            if (description != "")
            {
                description = description.Replace(" DIESET", "");
                _workPart.__SetAttribute("DESCRIPTION", description);

                if (isExpression)
                {
                    noteExp.RightHandSide = "\"no\"";
                }
                else
                {
                    Expression diesetExp =
                        _workPart.Expressions.CreateExpression("String", "DiesetNote=\"no\"");
                }
            }
            else
            {
                if (isExpression)
                {
                    noteExp.RightHandSide = "\"no\"";
                }
                else
                {
                    Expression diesetExp =
                        _workPart.Expressions.CreateExpression("String", "DiesetNote=\"no\"");
                }
            }
        }


        private static void NewMethod1(Expression noteExp, bool isExpression)
        {
            if (isExpression)
            {
                noteExp.RightHandSide = "\"yes\"";
            }
            else
            {
                Expression diesetExp =
                    _workPart.Expressions.CreateExpression("String", "DiesetNote=\"yes\"");
            }
        }

        private static void NewMethod(Expression noteExp, bool isExpression)
        {
            if (isExpression)
            {
                noteExp.RightHandSide = "\"yes\"";
            }
            else
            {
                Expression diesetExp =
                    _workPart.Expressions.CreateExpression("String", "DiesetNote=\"yes\"");
            }
        }





        private static void NewMethod26(ref Expression noteExp, ref bool isExpression)
        {
            foreach (Expression exp in _workPart.Expressions)
                if (exp.Name == "DiesetNote")
                {
                    isExpression = true;
                    noteExp = exp;
                }
        }




        private static void NewMethod35(ref Expression noteExp, ref bool isExpression)
        {
            foreach (Expression exp in _workPart.Expressions)
                if (exp.Name == "DiesetNote")
                {
                    isExpression = true;
                    noteExp = exp;
                }
        }




        private static void NewMethod51(ref Expression noteExp, ref bool isExpression)
        {
            foreach (Expression exp in _workPart.Expressions)
                if (exp.Name == "WeldmentNote")
                {
                    isExpression = true;
                    noteExp = exp;
                }
        }


        private static void NewMethod2(ref Expression noteExp, ref bool isExpression)
        {
            foreach (Expression exp in _workPart.Expressions)
                if (exp.Name == "WeldmentNote")
                {
                    isExpression = true;
                    noteExp = exp;
                }
        }



        private void NewMethod12(Expression AddZ)
        {
            foreach (CtsAttributes addZ in comboBoxAddz.Items)
            {
                if (AddZ.RightHandSide == addZ.AttrValue)
                {
                    comboBoxAddz.SelectedItem = addZ;

                    break;
                }

                comboBoxAddz.SelectedIndex = 0;
            }
        }

        private void NewMethod11(Expression AddY)
        {
            foreach (CtsAttributes addY in comboBoxAddy.Items)
            {
                if (AddY.RightHandSide == addY.AttrValue)
                {
                    comboBoxAddy.SelectedItem = addY;

                    break;
                }

                comboBoxAddy.SelectedIndex = 0;
            }
        }

        private void NewMethod10(Expression AddX)
        {
            foreach (CtsAttributes addX in comboBoxAddx.Items)
            {
                if (AddX.RightHandSide == addX.AttrValue)
                {
                    comboBoxAddx.SelectedItem = addX;

                    break;
                }

                comboBoxAddx.SelectedIndex = 0;
            }
        }

        private void NewMethod18(Expression AddZ)
        {
            foreach (CtsAttributes addZ in comboBoxAddz.Items)
            {
                if (AddZ.RightHandSide == addZ.AttrValue)
                {
                    comboBoxAddz.SelectedItem = addZ;

                    break;
                }

                comboBoxAddz.SelectedIndex = 0;
            }
        }

        private void NewMethod17(Expression AddY)
        {
            foreach (CtsAttributes addY in comboBoxAddy.Items)
            {
                if (AddY.RightHandSide == addY.AttrValue)
                {
                    comboBoxAddy.SelectedItem = addY;

                    break;
                }

                comboBoxAddy.SelectedIndex = 0;
            }
        }

        private void NewMethod16(Expression AddX)
        {
            foreach (CtsAttributes addX in comboBoxAddx.Items)
            {
                if (AddX.RightHandSide == addX.AttrValue)
                {
                    comboBoxAddx.SelectedItem = addX;

                    break;
                }

                comboBoxAddx.SelectedIndex = 0;
            }
        }


        private void NewMethod28(Expression AddX, Expression AddY, Expression AddZ)
        {
            foreach (CtsAttributes addX in comboBoxAddx.Items)
                try
                {
                    if (AddX.RightHandSide == addX.AttrValue)
                    {
                        comboBoxAddx.SelectedItem = addX;

                        break;
                    }

                    comboBoxAddx.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    UI.GetUI().NXMessageBox.Show("DJ", NXMessageBox.DialogType.Error, ex.Message);
                }

            foreach (CtsAttributes addY in comboBoxAddy.Items)
            {
                if (AddY.RightHandSide == addY.AttrValue)
                {
                    comboBoxAddy.SelectedItem = addY;

                    break;
                }

                comboBoxAddy.SelectedIndex = 0;
            }

            foreach (CtsAttributes addZ in comboBoxAddz.Items)
            {
                if (AddZ.RightHandSide == addZ.AttrValue)
                {
                    comboBoxAddz.SelectedItem = addZ;

                    break;
                }

                comboBoxAddz.SelectedIndex = 0;
            }
        }



        private void NewMethod7(Expression AddZ)
        {
            foreach (CtsAttributes addZ in comboBoxAddz.Items)
            {
                if (AddZ.RightHandSide == addZ.AttrValue)
                {
                    comboBoxAddz.SelectedItem = addZ;

                    break;
                }

                comboBoxAddz.SelectedIndex = 0;
            }
        }

        private void NewMethod6(Expression AddY)
        {
            foreach (CtsAttributes addY in comboBoxAddy.Items)
            {
                if (AddY.RightHandSide == addY.AttrValue)
                {
                    comboBoxAddy.SelectedItem = addY;

                    break;
                }

                comboBoxAddy.SelectedIndex = 0;
            }
        }

        private void NewMethod5(Expression AddX)
        {
            foreach (CtsAttributes addX in comboBoxAddx.Items)
            {
                if (AddX.RightHandSide == addX.AttrValue)
                {
                    comboBoxAddx.SelectedItem = addX;

                    break;
                }

                comboBoxAddx.SelectedIndex = 0;
            }
        }




        private void NewMethod13(string burnDirValue, string burnoutValue, string grindValue)
        {
            if (burnoutValue.ToLower() == "yes")
                checkBoxBurnout.Checked = true;
            else
                checkBoxBurnout.Checked = false;
            if (grindValue.ToLower() == "yes")
                checkBoxGrind.Checked = true;
            else
                checkBoxGrind.Checked = false;
            if (burnDirValue.ToLower() == "x")
                checkBoxBurnDirX.Checked = true;
            if (burnDirValue.ToLower() == "y")
                checkBoxBurnDirY.Checked = true;
            if (burnDirValue.ToLower() == "z")
                checkBoxBurnDirZ.Checked = true;
        }

        private void NewMethod112(string burnDirValue, string burnoutValue, string grindValue)
        {
            if (burnoutValue.ToLower() == "yes")
                checkBoxBurnout.Checked = true;
            else
                checkBoxBurnout.Checked = false;
            if (grindValue.ToLower() == "yes")
                checkBoxGrind.Checked = true;
            else
                checkBoxGrind.Checked = false;
            if (burnDirValue.ToLower() == "x")
                checkBoxBurnDirX.Checked = true;
            if (burnDirValue.ToLower() == "y")
                checkBoxBurnDirY.Checked = true;
            if (burnDirValue.ToLower() == "z")
                checkBoxBurnDirZ.Checked = true;
        }
        private void NewMethod113(string burnDirValue, string burnoutValue, string grindValue)
        {
            if (burnoutValue.ToLower() == "yes")
                checkBoxBurnout.Checked = true;
            else
                checkBoxBurnout.Checked = false;
            if (grindValue.ToLower() == "yes")
                checkBoxGrind.Checked = true;
            else
                checkBoxGrind.Checked = false;
            if (burnDirValue.ToLower() == "x")
                checkBoxBurnDirX.Checked = true;
            if (burnDirValue.ToLower() == "y")
                checkBoxBurnDirY.Checked = true;
            if (burnDirValue.ToLower() == "z")
                checkBoxBurnDirZ.Checked = true;
        }
        private void NewMethod115(string burnDirValue, string burnoutValue, string grindValue)
        {
            if (burnoutValue.ToLower() == "yes")
                checkBoxBurnout.Checked = true;
            else
                checkBoxBurnout.Checked = false;
            if (grindValue.ToLower() == "yes")
                checkBoxGrind.Checked = true;
            else
                checkBoxGrind.Checked = false;
            if (burnDirValue.ToLower() == "x")
                checkBoxBurnDirX.Checked = true;
            if (burnDirValue.ToLower() == "y")
                checkBoxBurnDirY.Checked = true;
            if (burnDirValue.ToLower() == "z")
                checkBoxBurnDirZ.Checked = true;
        }

        private void NewMethod8(double xValue, double yValue, double zValue)
        {
            // get bounding box info
            double[] distances = NewMethod148();
            // add stock values
            distances[0] += xValue;
            distances[1] += yValue;
            distances[2] += zValue;
            NewMethod147(distances);
            NewMethod146(distances);
        }

        private static double[] NewMethod148()
        {
            double[] minCorner = new double[3];
            double[,] directions = new double[3, 3];
            double[] distances = new double[3];

            ufsession_.Modl.AskBoundingBoxExact(_sizeBody.Tag,
                __display_part_.WCS.CoordinateSystem.Tag, minCorner, directions, distances);
            return distances;
        }

        private static void NewMethod147(double[] distances)
        {
            NewMethod81(distances);
            distances.__RoundTo_125();
        }

        private static void NewMethod81(double[] distances)
        {
            if (_workPart.PartUnits == BasePart.Units.Millimeters)
                for (int i = 0; i < distances.Length; i++)
                    distances[i] /= 25.4d;
        }

        private void NewMethod146(double[] distances)
        {
            CreateTempBlockLines(__display_part_.WCS.Origin, distances[0], distances[1],
                            distances[2]);
            _allowBoundingBox = true;
        }

        private static double[] NewMethod3(double xValue, double yValue, double zValue)
        {
            // get bounding box info

            double[] distances = NewMethod145();

            // add stock values

            distances[0] += xValue;
            distances[1] += yValue;
            distances[2] += zValue;
            NewMethod144(distances);

            return distances;
        }

        private static double[] NewMethod145()
        {
            double[] minCorner = new double[3];
            double[,] directions = new double[3, 3];
            double[] distances = new double[3];

            ufsession_.Modl.AskBoundingBoxExact(_sizeBody.Tag,
                __display_part_.WCS.CoordinateSystem.Tag, minCorner, directions, distances);
            return distances;
        }

        private static void NewMethod144(double[] distances)
        {
            NewMethod82(distances);
            distances.__RoundTo_125();
        }

        private static void NewMethod82(double[] distances)
        {
            if (_workPart.PartUnits == BasePart.Units.Millimeters)
                for (int i = 0; i < distances.Length; i++)
                    distances[i] /= 25.4d;
        }

        private void NewMethod20(double xValue, double yValue, double zValue)
        {
            // get bounding box info

            double[] distances = NewMethod143();

            // add stock values

            distances[0] += xValue;
            distances[1] += yValue;
            distances[2] += zValue;
            NewMethod142(distances);
            NewMethod141(distances);
        }

        private static double[] NewMethod143()
        {
            double[] minCorner = new double[3];
            double[,] directions = new double[3, 3];
            double[] distances = new double[3];

            ufsession_.Modl.AskBoundingBoxExact(_sizeBody.Tag,
                __display_part_.WCS.CoordinateSystem.Tag, minCorner, directions, distances);
            return distances;
        }

        private static void NewMethod142(double[] distances)
        {
            NewMethod83(distances);
            distances.__RoundTo_125();
        }

        private static void NewMethod83(double[] distances)
        {
            if (_workPart.PartUnits == BasePart.Units.Millimeters)
                for (int i = 0; i < distances.Length; i++)
                    distances[i] /= 25.4d;
        }

        private void NewMethod141(double[] distances)
        {
            CreateTempBlockLines(__display_part_.WCS.Origin, distances[0], distances[1],
                            distances[2]);
            _allowBoundingBox = true;
        }

        private void NewMethod14(double xValue, double yValue, double zValue)
        {
            // get bounding box info
            double[] distances = NewMethod139();
            // add stock values
            distances[0] += xValue;
            distances[1] += yValue;
            distances[2] += zValue;
            NewMethod138(distances);
            NewMethod140(distances);
        }

        private void NewMethod140(double[] distances)
        {
            CreateTempBlockLines(__display_part_.WCS.Origin, distances[0], distances[1],
                            distances[2]);
            _allowBoundingBox = true;
        }

        private static double[] NewMethod139()
        {
            double[] minCorner = new double[3];
            double[,] directions = new double[3, 3];
            double[] distances = new double[3];

            ufsession_.Modl.AskBoundingBoxExact(_sizeBody.Tag,
                __display_part_.WCS.CoordinateSystem.Tag, minCorner, directions, distances);
            return distances;
        }

        private static void NewMethod138(double[] distances)
        {
            NewMethod84(distances);
         distances.__RoundTo_125();
        }

        private static void NewMethod84(double[] distances)
        {
            if (_workPart.PartUnits == BasePart.Units.Millimeters)
                for (int i = 0; i < distances.Length; i++)
                    distances[i] /= 25.4d;
        }

        private static double[] NewMethod24(CartesianCoordinateSystem tempCsys, bool isMetric)
        {
            // get bounding box of solid body
            double[] distances = NewMethod137(tempCsys);
            NewMethod136(isMetric, distances);
            return distances;
        }

        private static double[] NewMethod137(CartesianCoordinateSystem tempCsys)
        {
            double[] minCorner = new double[3];
            double[,] directions = new double[3, 3];
            double[] distances = new double[3];

            ufsession_.Modl.AskBoundingBoxExact(_sizeBody.Tag, tempCsys.Tag, minCorner, directions, distances);
            return distances;
        }

        private static void NewMethod136(bool isMetric, double[] distances)
        {
            NewMethod85(isMetric, distances);
            distances.__RoundTo_125();
        }

        private static void NewMethod85(bool isMetric, double[] distances)
        {
            if (isMetric)
                for (int i = 0; i < distances.Length; i++)
                    distances[i] /= 25.4d;
        }

        private static double[] NewMethod32(bool isMetric, Body[] sizeBody, Tag tempCsys)
        {
            double[] distances = NewMethod135(sizeBody, tempCsys);
            NewMethod134(isMetric, distances);

            return distances;
        }

        private static double[] NewMethod135(Body[] sizeBody, Tag tempCsys)
        {
            double[] minCorner = new double[3];
            double[,] directions = new double[3, 3];
            double[] distances = new double[3];

            ufsession_.Modl.AskBoundingBoxExact(sizeBody[0].Tag, tempCsys, minCorner, directions,
                distances);
            return distances;
        }

        private static void NewMethod134(bool isMetric, double[] distances)
        {
            NewMethod86(isMetric, distances);
            distances.__RoundTo_125();
        }

        private static void NewMethod86(bool isMetric, double[] distances)
        {
            if (isMetric)
                for (int i = 0; i < distances.Length; i++)
                    distances[i] /= 25.4d;
        }

        private static void NewMethod31(bool isMetric, string burnoutValue, double[] distances)
        {
            NewMethod133(isMetric, distances);

            if (burnoutValue.ToLower() == "no")
                distances.__RoundTo_125();
        }

        private static void NewMethod133(bool isMetric, double[] distances)
        {
            if (isMetric)
                for (int i = 0; i < distances.Length; i++)
                    distances[i] /= 25.4d;
        }

        private double AskSteelSize(double distance, BasePart part)
        {
            //            if (part.Leaf.Contains("200"))
            //                Debugger.Launch();
            double roundValue, truncateValue, fractionValue;
            NewMethod132(distance, out roundValue, out truncateValue, out fractionValue);

            // If it doesn't seem to be working you might have any issue with metric vs english,
            // or you can revert the code back to the orignal line before you changed to float-point comparison.
            if (System.Math.Abs(fractionValue) <= .001)
                return roundValue;

            for (double ii = .125; ii <= 1; ii += .125)
                if (fractionValue <= ii)
                {
                    double finalValue = truncateValue + ii;
                    return finalValue;
                }

            throw new Exception($"Ask Steel Size, Part: {part.Leaf}. {nameof(distance)}: {distance}");
        }

        private static void NewMethod132(double distance, out double roundValue, out double truncateValue, out double fractionValue)
        {
            roundValue = System.Math.Round(distance, 3);
            truncateValue = System.Math.Truncate(roundValue);
            fractionValue = roundValue - truncateValue;
        }

        private static double[] NewMethod33(double xValue, double yValue, double zValue)
        {
            double[] distances = NewMethod23();

            // add stock values

            distances[0] += xValue;
            distances[1] += yValue;
            distances[2] += zValue;
            NewMethod131(distances);

            return distances;
        }

        private static void NewMethod131(double[] distances)
        {
            NewMethod87(distances);
            distances.__RoundTo_125();
        }

        private static void NewMethod87(double[] distances)
        {
            if (_workPart.PartUnits == BasePart.Units.Millimeters)
                for (int i = 0; i < distances.Length; i++)
                    distances[i] /= 25.4d;
        }

        private static double[] NewMethod23()
        {
            double[] minCorner = new double[3];
            double[,] directions = new double[3, 3];
            double[] distances = new double[3];

            ufsession_.Modl.AskBoundingBoxExact(_sizeBody.Tag, __display_part_.WCS.CoordinateSystem.Tag,
                minCorner, directions, distances);
            return distances;
        }

        private static void NewMethod114(ref bool isNamedExpression, ref Expression AddX, ref Expression AddY, ref Expression AddZ, ref double xValue, ref double yValue, ref double zValue)
        {
            foreach (Expression exp in _workPart.Expressions.ToArray())
            {
                if (exp.Name == "AddX")
                {
                    isNamedExpression = true;
                    AddX = exp;
                    xValue = exp.Value;
                }

                if (exp.Name == "AddY")
                {
                    isNamedExpression = true;
                    AddY = exp;
                    yValue = exp.Value;
                }

                if (exp.Name == "AddZ")
                {
                    isNamedExpression = true;
                    AddZ = exp;
                    zValue = exp.Value;
                }
            }
        }


        private static void NewMethod27(ref bool isNamedExpression, ref Expression AddX, ref Expression AddY, ref Expression AddZ, ref Expression BurnDir, ref Expression Burnout, ref Expression Grind, ref Expression GrindTolerance, ref double xValue, ref double yValue, ref double zValue, ref string burnDirValue, ref string burnoutValue, ref string grindValue, ref string grindTolValue)
        {
            foreach (Expression exp in _workPart.Expressions.ToArray())
            {
                if (exp.Name == "AddX")
                {
                    isNamedExpression = true;
                    AddX = exp;
                    xValue = exp.Value;
                }

                if (exp.Name == "AddY")
                {
                    isNamedExpression = true;
                    AddY = exp;
                    yValue = exp.Value;
                }

                if (exp.Name == "AddZ")
                {
                    isNamedExpression = true;
                    AddZ = exp;
                    zValue = exp.Value;
                }

                if (exp.Name == "BurnDir")
                {
                    isNamedExpression = true;
                    BurnDir = exp;
                    burnDirValue = exp.RightHandSide;
                }

                if (exp.Name == "Burnout")
                {
                    isNamedExpression = true;
                    Burnout = exp;
                    burnoutValue = exp.RightHandSide;
                }

                if (exp.Name == "Grind")
                {
                    isNamedExpression = true;
                    Grind = exp;
                    grindValue = exp.RightHandSide;
                }

                if (exp.Name == "GrindTolerance")
                {
                    isNamedExpression = true;
                    GrindTolerance = exp;
                    grindTolValue = exp.RightHandSide;
                }
            }
        }





        private static void NewMethod4(ref bool isNamedExpression, ref Expression AddX, ref Expression AddY, ref Expression AddZ, ref Expression BurnDir, ref Expression Burnout, ref Expression Grind, ref Expression GrindTolerance, ref double xValue, ref double yValue, ref double zValue, ref string burnDirValue, ref string burnoutValue, ref string grindValue, ref string grindTolValue)
        {
            foreach (Expression exp in _workPart.Expressions.ToArray())
            {
                if (exp.Name == "AddX")
                {
                    isNamedExpression = true;
                    AddX = exp;
                    xValue = exp.Value;
                }

                if (exp.Name == "AddY")
                {
                    isNamedExpression = true;
                    AddY = exp;
                    yValue = exp.Value;
                }

                if (exp.Name == "AddZ")
                {
                    isNamedExpression = true;
                    AddZ = exp;
                    zValue = exp.Value;
                }

                if (exp.Name == "BurnDir")
                {
                    isNamedExpression = true;
                    BurnDir = exp;
                    burnDirValue = exp.RightHandSide;
                }

                if (exp.Name == "Burnout")
                {
                    isNamedExpression = true;
                    Burnout = exp;
                    burnoutValue = exp.RightHandSide;
                }

                if (exp.Name == "Grind")
                {
                    isNamedExpression = true;
                    Grind = exp;
                    grindValue = exp.RightHandSide;
                }

                if (exp.Name == "GrindTolerance")
                {
                    isNamedExpression = true;
                    GrindTolerance = exp;
                    grindTolValue = exp.RightHandSide;
                }
            }
        }

        private static void NewMethod15(ref bool isNamedExpression, ref Expression AddX, ref Expression AddY, ref Expression AddZ, ref Expression BurnDir, ref Expression Burnout, ref Expression Grind, ref Expression GrindTolerance, ref double xValue, ref double yValue, ref double zValue, ref string burnDirValue, ref string burnoutValue, ref string grindValue, ref string grindTolValue)
        {
            foreach (Expression exp in _workPart.Expressions.ToArray())
            {
                if (exp.Name == "AddX")
                {
                    isNamedExpression = true;
                    AddX = exp;
                    xValue = exp.Value;
                }

                if (exp.Name == "AddY")
                {
                    isNamedExpression = true;
                    AddY = exp;
                    yValue = exp.Value;
                }

                if (exp.Name == "AddZ")
                {
                    isNamedExpression = true;
                    AddZ = exp;
                    zValue = exp.Value;
                }

                if (exp.Name == "BurnDir")
                {
                    isNamedExpression = true;
                    BurnDir = exp;
                    burnDirValue = exp.RightHandSide;
                }

                if (exp.Name == "Burnout")
                {
                    isNamedExpression = true;
                    Burnout = exp;
                    burnoutValue = exp.RightHandSide;
                }

                if (exp.Name == "Grind")
                {
                    isNamedExpression = true;
                    Grind = exp;
                    grindValue = exp.RightHandSide;
                }

                if (exp.Name == "GrindTolerance")
                {
                    isNamedExpression = true;
                    GrindTolerance = exp;
                    grindTolValue = exp.RightHandSide;
                }
            }
        }




        private static void NewMethod9(ref bool isNamedExpression, ref Expression AddX, ref Expression AddY, ref Expression AddZ, ref Expression BurnDir, ref Expression Burnout, ref Expression Grind, ref Expression GrindTolerance, ref double xValue, ref double yValue, ref double zValue, ref string burnDirValue, ref string burnoutValue, ref string grindValue, ref string grindTolValue)
        {
            foreach (Expression exp in _workPart.Expressions.ToArray())
            {
                if (exp.Name == "AddX")
                {
                    isNamedExpression = true;
                    AddX = exp;
                    xValue = exp.Value;
                }

                if (exp.Name == "AddY")
                {
                    isNamedExpression = true;
                    AddY = exp;
                    yValue = exp.Value;
                }

                if (exp.Name == "AddZ")
                {
                    isNamedExpression = true;
                    AddZ = exp;
                    zValue = exp.Value;
                }

                if (exp.Name == "BurnDir")
                {
                    isNamedExpression = true;
                    BurnDir = exp;
                    burnDirValue = exp.RightHandSide;
                }

                if (exp.Name == "Burnout")
                {
                    isNamedExpression = true;
                    Burnout = exp;
                    burnoutValue = exp.RightHandSide;
                }

                if (exp.Name == "Grind")
                {
                    isNamedExpression = true;
                    Grind = exp;
                    grindValue = exp.RightHandSide;
                }

                if (exp.Name == "GrindTolerance")
                {
                    isNamedExpression = true;
                    GrindTolerance = exp;
                    grindTolValue = exp.RightHandSide;
                }
            }
        }




        private static void NewMethod21(ref bool isNamedExpression, ref Expression AddX, ref Expression AddY, ref Expression AddZ, ref Expression BurnDir, ref Expression Burnout, ref Expression Grind, ref Expression GrindTolerance, ref double xValue, ref double yValue, ref double zValue, ref string burnDirValue, ref string burnoutValue, ref string grindValue, ref string grindTolValue)
        {
            foreach (Expression exp in _workPart.Expressions.ToArray())
            {
                if (exp.Name == "AddX")
                {
                    isNamedExpression = true;
                    AddX = exp;
                    xValue = exp.Value;
                }

                if (exp.Name == "AddY")
                {
                    isNamedExpression = true;
                    AddY = exp;
                    yValue = exp.Value;
                }

                if (exp.Name == "AddZ")
                {
                    isNamedExpression = true;
                    AddZ = exp;
                    zValue = exp.Value;
                }

                if (exp.Name == "BurnDir")
                {
                    isNamedExpression = true;
                    BurnDir = exp;
                    burnDirValue = exp.RightHandSide;
                }

                if (exp.Name == "Burnout")
                {
                    isNamedExpression = true;
                    Burnout = exp;
                    burnoutValue = exp.RightHandSide;
                }

                if (exp.Name == "Grind")
                {
                    isNamedExpression = true;
                    Grind = exp;
                    grindValue = exp.RightHandSide;
                }

                if (exp.Name == "GrindTolerance")
                {
                    isNamedExpression = true;
                    GrindTolerance = exp;
                    grindTolValue = exp.RightHandSide;
                }
            }
        }


        private static void NewMethod22(ref bool isNamedExpression, ref Expression AddX, ref Expression AddY, ref Expression AddZ, ref Expression BurnDir, ref Expression Burnout, ref Expression Grind, ref Expression GrindTolerance, ref Expression Dieset, ref double xValue, ref double yValue, ref double zValue, ref string burnDirValue, ref string burnoutValue, ref string grindValue, ref string grindTolValue, ref string diesetValue)
        {
            foreach (Expression exp in _workPart.Expressions.ToArray())
            {
                if (exp.Name == "AddX")
                {
                    isNamedExpression = true;
                    AddX = exp;
                    xValue = exp.Value;
                }

                if (exp.Name == "AddY")
                {
                    isNamedExpression = true;
                    AddY = exp;
                    yValue = exp.Value;
                }

                if (exp.Name == "AddZ")
                {
                    isNamedExpression = true;
                    AddZ = exp;
                    zValue = exp.Value;
                }

                if (exp.Name == "BurnDir")
                {
                    isNamedExpression = true;
                    BurnDir = exp;
                    burnDirValue = exp.RightHandSide;
                }

                if (exp.Name == "Burnout")
                {
                    isNamedExpression = true;
                    Burnout = exp;
                    burnoutValue = exp.RightHandSide;
                }

                if (exp.Name == "Grind")
                {
                    isNamedExpression = true;
                    Grind = exp;
                    grindValue = exp.RightHandSide;
                }

                if (exp.Name == "GrindTolerance")
                {
                    isNamedExpression = true;
                    GrindTolerance = exp;
                    grindTolValue = exp.RightHandSide;
                }

                if (exp.Name == "DiesetNote")
                {
                    Dieset = exp;
                    diesetValue = exp.RightHandSide;
                }
            }
        }



        private static void NewMethod25(ref bool isNamedExpression, ref double xValue, ref double yValue, ref double zValue, ref string burnDirValue, ref string burnoutValue, ref string grindValue, ref string grindTolValue, ref string diesetValue)
        {
            foreach (Expression exp in _workPart.Expressions.ToArray())
            {
                if (exp.Name == "AddX")
                {
                    isNamedExpression = true;
                    xValue = exp.Value;
                }

                if (exp.Name == "AddY")
                {
                    isNamedExpression = true;
                    yValue = exp.Value;
                }

                if (exp.Name == "AddZ")
                {
                    isNamedExpression = true;
                    zValue = exp.Value;
                }

                if (exp.Name == "BurnDir")
                {
                    isNamedExpression = true;
                    burnDirValue = exp.RightHandSide;
                }

                if (exp.Name == "Burnout")
                {
                    isNamedExpression = true;
                    burnoutValue = exp.RightHandSide;
                }

                if (exp.Name == "Grind")
                {
                    isNamedExpression = true;
                    grindValue = exp.RightHandSide;
                }

                if (exp.Name == "GrindTolerance")
                {
                    isNamedExpression = true;
                    grindTolValue = exp.RightHandSide;
                }

                if (exp.Name == "DiesetNote") diesetValue = exp.RightHandSide;
            }
        }











        private void NewMethod116()
        {
            textBoxDescription.Clear();
            textBoxMaterial.Clear();
            buttonReset.PerformClick();
            buttonSelectCustom.Enabled = false;
            comboBoxMaterial.Enabled = false;
            groupBoxDescription.Enabled = true;
            groupBoxMaterial.Enabled = true;
            groupBoxAttributes.Enabled = true;
            groupBoxBlockExpressions.Enabled = false;
            _isCustom = true;
            _isMeasureBody = false;
            _isSelectMultiple = true;
            _allSelectedComponents = SelectMultipleComponents();
        }

        private void NewMethod117()
        {
            textBoxDescription.Clear();
            textBoxMaterial.Clear();
            comboBoxDescription.SelectedIndex = -1;
            comboBoxMaterial.SelectedIndex = -1;
            _isCustom = false;
            _isMeasureBody = false;
            _isSelectMultiple = false;
            _selectedComponents = SelectMultipleComponents();
        }


        private void NewMethod118()
        {
            textBoxDescription.Clear();
            textBoxMaterial.Clear();
            comboBoxDescription.SelectedIndex = -1;
            comboBoxMaterial.SelectedIndex = -1;
            _workPart = session_.Parts.Work;
            __display_part_ = session_.Parts.Display;
            _originalWorkPart = _workPart; _originalDisplayPart = __display_part_; ;
            _isCustom = false;
            _isMeasureBody = false;
            _isSelectMultiple = false;
            _selectedComponents = SelectMultipleComponents();
        }

        private void NewMethod119()
        {
            textBoxDescription.Clear();
            textBoxMaterial.Clear();
            comboBoxDescription.SelectedIndex = -1;
            comboBoxMaterial.SelectedIndex = -1;
            _workPart = session_.Parts.Work;
            __display_part_ = session_.Parts.Display;
            _originalWorkPart = _workPart; _originalDisplayPart = __display_part_; ;
            _isCustom = false;
            _isMeasureBody = false;
            _isSelectMultiple = false;
            _selectedComponents = SelectMultipleComponents();
        }

        private void NewMethod120()
        {
            textBoxDescription.Clear();
            textBoxMaterial.Clear();
            comboBoxDescription.SelectedIndex = -1;
            comboBoxMaterial.SelectedIndex = -1;
            _workPart = session_.Parts.Work;
            __display_part_ = session_.Parts.Display;
            _originalWorkPart = _workPart; _originalDisplayPart = __display_part_; ;
            _isCustom = false;
            _isMeasureBody = false;
            _isSelectMultiple = false;
            _selectedComponents = SelectMultipleComponents();
        }


        private void NewMethod124(string grindTolValue)
        {
            foreach (CtsAttributes tolSetting in comboBoxTolerance.Items)
                if (grindTolValue == tolSetting.AttrValue)
                    comboBoxTolerance.SelectedItem = tolSetting;
        }

        private void NewMethod125(string grindTolValue)
        {
            foreach (CtsAttributes tolSetting in comboBoxTolerance.Items)
                if (grindTolValue == tolSetting.AttrValue)
                    comboBoxTolerance.SelectedItem = tolSetting;
        }
        private void NewMethod126(string grindTolValue)
        {
            foreach (CtsAttributes tolSetting in comboBoxTolerance.Items)
                if (grindTolValue == tolSetting.AttrValue)
                    comboBoxTolerance.SelectedItem = tolSetting;
        }

        private void NewMethod127(string grindTolValue)
        {
            foreach (CtsAttributes tolSetting in comboBoxTolerance.Items)
                if (grindTolValue == tolSetting.AttrValue)
                    comboBoxTolerance.SelectedItem = tolSetting;
        }

        private static void NewMethod149(bool isMetric, double[] distances)
        {
            if (isMetric)
                for (int i = 0; i < distances.Length; i++)
                    distances[i] /= 25.4d;
        }
    }
}