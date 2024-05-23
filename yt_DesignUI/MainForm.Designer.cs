using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using yt_DesignUI.Components;
using System;

namespace yt_DesignUI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._fishingToggle = new yt_DesignUI.EgoldsToggleSwitch();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checker = new System.Windows.Forms.Timer(this.components);
            this.checker.Tick += CheckPixelsTick;
            this.clicker = new System.Windows.Forms.Timer(this.components);
            this.clicker.Tick += ClickerTick;
            this.egoldsFormStyle1 = new yt_DesignUI.Components.EgoldsFormStyle(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.captchaSwitch = new yt_DesignUI.EgoldsToggleSwitch();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Рыбалка";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.captchaSwitch);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._fishingToggle);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 197);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(55, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 13);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "100 мс";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 50;
            this.trackBar1.Location = new System.Drawing.Point(9, 119);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(156, 45);
            this.trackBar1.SmallChange = 50;
            this.trackBar1.TabIndex = 21;
            this.trackBar1.TickFrequency = 50;
            this.trackBar1.Value = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(80, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 14);
            this.label5.TabIndex = 19;
            this.label5.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "Цвет:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Частота проверки:";
            // 
            // _fishingToggle
            // 
            this._fishingToggle.BackColor = System.Drawing.Color.White;
            this._fishingToggle.BackColorOFF = System.Drawing.Color.Silver;
            this._fishingToggle.BackColorON = System.Drawing.Color.DodgerBlue;
            this._fishingToggle.Checked = false;
            this._fishingToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this._fishingToggle.Font = new System.Drawing.Font("Verdana", 9F);
            this._fishingToggle.Location = new System.Drawing.Point(9, 40);
            this._fishingToggle.Name = "_fishingToggle";
            this._fishingToggle.Size = new System.Drawing.Size(74, 15);
            this._fishingToggle.TabIndex = 0;
            this._fishingToggle.Text = "OFF";
            this._fishingToggle.TextOnChecked = "ON";
            this._fishingToggle.CheckedChanged += new yt_DesignUI.EgoldsToggleSwitch.OnCheckedChangedHandler(this._fishingToggle_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(85, 240);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 14);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "by BYLEX";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            // 
            // checker
            // 
            this.checker.Enabled = true;
            // 
            // egoldsFormStyle1
            // 
            this.egoldsFormStyle1.AllowUserResize = false;
            this.egoldsFormStyle1.BackColor = System.Drawing.Color.White;
            this.egoldsFormStyle1.ContextMenuForm = null;
            this.egoldsFormStyle1.ControlBoxButtonsWidth = 20;
            this.egoldsFormStyle1.EnableControlBoxIconsLight = false;
            this.egoldsFormStyle1.EnableControlBoxMouseLight = false;
            this.egoldsFormStyle1.Form = this;
            this.egoldsFormStyle1.FormStyle = yt_DesignUI.Components.EgoldsFormStyle.fStyle.TelegramStyle;
            this.egoldsFormStyle1.HeaderColor = System.Drawing.Color.DimGray;
            this.egoldsFormStyle1.HeaderColorAdditional = System.Drawing.Color.White;
            this.egoldsFormStyle1.HeaderColorGradientEnable = false;
            this.egoldsFormStyle1.HeaderColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.egoldsFormStyle1.HeaderHeight = 38;
            this.egoldsFormStyle1.HeaderImage = null;
            this.egoldsFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.egoldsFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 14);
            this.label6.TabIndex = 19;
            this.label6.Text = "Разрешение:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(14, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "0х0";
            // 
            // captchaSwitch
            // 
            this.captchaSwitch.BackColor = System.Drawing.Color.White;
            this.captchaSwitch.BackColorOFF = System.Drawing.Color.Silver;
            this.captchaSwitch.BackColorON = System.Drawing.Color.DodgerBlue;
            this.captchaSwitch.Checked = false;
            this.captchaSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.captchaSwitch.Font = new System.Drawing.Font("Verdana", 9F);
            this.captchaSwitch.Location = new System.Drawing.Point(9, 78);
            this.captchaSwitch.Name = "captchaSwitch";
            this.captchaSwitch.Size = new System.Drawing.Size(74, 15);
            this.captchaSwitch.TabIndex = 24;
            this.captchaSwitch.Text = "OFF";
            this.captchaSwitch.TextOnChecked = "ON";
            this.captchaSwitch.CheckedChanged += new yt_DesignUI.EgoldsToggleSwitch.OnCheckedChangedHandler(this.captchaSwitch_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 14);
            this.label8.TabIndex = 25;
            this.label8.Text = "Авто каптча";
            // 
            // MainForm
            // 
            this.Load += MainForm_Load;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 261);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "FishingHelper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Token: 0x04000062 RID: 98
        private EgoldsFormStyle egoldsFormStyle1;

        // Token: 0x04000063 RID: 99
        private EgoldsToggleSwitch _fishingToggle;

        // Token: 0x04000064 RID: 100
        private Label label1;

        // Token: 0x04000065 RID: 101
        private LinkLabel linkLabel1;

        // Token: 0x04000066 RID: 102
        private GroupBox groupBox1;

        // Token: 0x04000067 RID: 103
        private Label label2;

        // Token: 0x04000068 RID: 104
        private TrackBar trackBar1;

        // Token: 0x04000069 RID: 105
        private Label label3;

        // Token: 0x0400006A RID: 106
        private System.Windows.Forms.Timer checker;

        // Token: 0x0400006B RID: 107
        private Label label5;

        // Token: 0x0400006C RID: 108
        private Label label4;

        // Token: 0x0400006D RID: 109
        private PictureBox pictureBox1;

        // Token: 0x0400006E RID: 110
        private System.Windows.Forms.Timer clicker;

        // Token: 0x0400006F RID: 111
        private Label label7;

        // Token: 0x04000070 RID: 112
        private Label label6;

        #endregion

        private Label label8;
        private EgoldsToggleSwitch captchaSwitch;
    }
}