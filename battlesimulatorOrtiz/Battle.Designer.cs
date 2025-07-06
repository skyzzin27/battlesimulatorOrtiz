using System;

namespace battlesimulatorOrtiz
{
    partial class Battle
    {
        private System.Windows.Forms.Label lblDamageEffect;
        private System.Windows.Forms.Label lblPlayerDamage;


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
            this.flashTimer = new System.Windows.Forms.Timer(this.components);
            this.lblDamageEffect = new System.Windows.Forms.Label();
            this.lblPlayerDamage = new System.Windows.Forms.Label();
            this.PBPlayer = new System.Windows.Forms.PictureBox();
            this.PBEnemy = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProgBarPlayer = new ColoredProgressBar();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProgBarEnemy = new ColoredProgressBar();
            this.lblEnemyName = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnDefend = new System.Windows.Forms.Button();
            this.BtnAttack2 = new System.Windows.Forms.Button();
            this.TimerEnAtk = new System.Windows.Forms.Timer(this.components);
            this.LblInfo = new System.Windows.Forms.Label();
            this.TimerPlayerHP = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.TimerEnemyHP = new System.Windows.Forms.Timer(this.components);
            this.BtnAttack1 = new System.Windows.Forms.Button();
            this.lblPlayerDamageEffect = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PBPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBEnemy)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flashTimer
            // 
            this.flashTimer.Tick += new System.EventHandler(this.FlashTimer_Tick);
            // 
            // lblDamageEffect
            // 
            this.lblDamageEffect.AutoSize = true;
            this.lblDamageEffect.BackColor = System.Drawing.Color.Transparent;
            this.lblDamageEffect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblDamageEffect.ForeColor = System.Drawing.Color.Red;
            this.lblDamageEffect.Location = new System.Drawing.Point(100, 100);
            this.lblDamageEffect.Name = "lblDamageEffect";
            this.lblDamageEffect.Size = new System.Drawing.Size(0, 26);
            this.lblDamageEffect.TabIndex = 0;
            this.lblDamageEffect.Visible = false;
            // 
            // lblPlayerDamage
            // 
            this.lblPlayerDamage.AutoSize = true;
            this.lblPlayerDamage.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblPlayerDamage.ForeColor = System.Drawing.Color.Red;
            this.lblPlayerDamage.Location = new System.Drawing.Point(100, 300);
            this.lblPlayerDamage.Name = "lblPlayerDamage";
            this.lblPlayerDamage.Size = new System.Drawing.Size(0, 26);
            this.lblPlayerDamage.TabIndex = 1;
            this.lblPlayerDamage.Visible = false;
            // 
            // PBPlayer
            // 
            this.PBPlayer.Image = global::battlesimulatorOrtiz.Properties.Resources.Ortiz;
            this.PBPlayer.Location = new System.Drawing.Point(12, 244);
            this.PBPlayer.Name = "PBPlayer";
            this.PBPlayer.Size = new System.Drawing.Size(200, 200);
            this.PBPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBPlayer.TabIndex = 0;
            this.PBPlayer.TabStop = false;
            this.PBPlayer.Click += new System.EventHandler(this.PBPlayer_Click);
            // 
            // PBEnemy
            // 
            this.PBEnemy.Image = global::battlesimulatorOrtiz.Properties.Resources.Christian;
            this.PBEnemy.Location = new System.Drawing.Point(572, 12);
            this.PBEnemy.Name = "PBEnemy";
            this.PBEnemy.Size = new System.Drawing.Size(200, 200);
            this.PBEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBEnemy.TabIndex = 1;
            this.PBEnemy.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProgBarPlayer);
            this.panel1.Controls.Add(this.lblPlayerName);
            this.panel1.Location = new System.Drawing.Point(218, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 60);
            this.panel1.TabIndex = 4;
            // 
            // ProgBarPlayer
            // 
            this.ProgBarPlayer.Location = new System.Drawing.Point(3, 34);
            this.ProgBarPlayer.Name = "ProgBarPlayer";
            this.ProgBarPlayer.Size = new System.Drawing.Size(220, 23);
            this.ProgBarPlayer.TabIndex = 14;
            this.ProgBarPlayer.Value = 100;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(3, 6);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(62, 25);
            this.lblPlayerName.TabIndex = 5;
            this.lblPlayerName.Text = "Ortiz";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ProgBarEnemy);
            this.panel2.Controls.Add(this.lblEnemyName);
            this.panel2.Location = new System.Drawing.Point(340, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 60);
            this.panel2.TabIndex = 6;
            // 
            // ProgBarEnemy
            // 
            this.ProgBarEnemy.Location = new System.Drawing.Point(3, 34);
            this.ProgBarEnemy.Name = "ProgBarEnemy";
            this.ProgBarEnemy.Size = new System.Drawing.Size(220, 23);
            this.ProgBarEnemy.TabIndex = 15;
            this.ProgBarEnemy.Value = 100;
            // 
            // lblEnemyName
            // 
            this.lblEnemyName.AutoSize = true;
            this.lblEnemyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyName.Location = new System.Drawing.Point(3, 6);
            this.lblEnemyName.Name = "lblEnemyName";
            this.lblEnemyName.Size = new System.Drawing.Size(106, 25);
            this.lblEnemyName.TabIndex = 5;
            this.lblEnemyName.Text = "Christian";
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.Location = new System.Drawing.Point(624, 386);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(139, 58);
            this.BtnExit.TabIndex = 7;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnDefend
            // 
            this.BtnDefend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDefend.Location = new System.Drawing.Point(484, 386);
            this.BtnDefend.Name = "BtnDefend";
            this.BtnDefend.Size = new System.Drawing.Size(139, 58);
            this.BtnDefend.TabIndex = 9;
            this.BtnDefend.Text = "Defend";
            this.BtnDefend.UseVisualStyleBackColor = true;
            this.BtnDefend.Click += new System.EventHandler(this.BtnDefend_Click);
            // 
            // BtnAttack2
            // 
            this.BtnAttack2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAttack2.Location = new System.Drawing.Point(624, 322);
            this.BtnAttack2.Name = "BtnAttack2";
            this.BtnAttack2.Size = new System.Drawing.Size(139, 58);
            this.BtnAttack2.TabIndex = 10;
            this.BtnAttack2.Text = " Attack 2";
            this.BtnAttack2.UseVisualStyleBackColor = true;
            this.BtnAttack2.Click += new System.EventHandler(this.BtnAttack2_Click);
            // 
            // TimerEnAtk
            // 
            this.TimerEnAtk.Interval = 2000;
            this.TimerEnAtk.Tick += new System.EventHandler(this.TimerEnAtk_Tick);
            // 
            // LblInfo
            // 
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.Location = new System.Drawing.Point(520, 232);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(224, 77);
            this.LblInfo.TabIndex = 11;
            this.LblInfo.Text = "\r\n";
            this.LblInfo.Click += new System.EventHandler(this.label1_Click);
            // 
            // TimerPlayerHP
            // 
            this.TimerPlayerHP.Interval = 30;
            this.TimerPlayerHP.Tick += new System.EventHandler(this.TimerPlayerHP_Tick);
            // 
            // TimerEnemyHP
            // 
            this.TimerEnemyHP.Interval = 30;
            this.TimerEnemyHP.Tick += new System.EventHandler(this.TimerEnemyHP_Tick);
            // 
            // BtnAttack1
            // 
            this.BtnAttack1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAttack1.Location = new System.Drawing.Point(484, 322);
            this.BtnAttack1.Name = "BtnAttack1";
            this.BtnAttack1.Size = new System.Drawing.Size(139, 58);
            this.BtnAttack1.TabIndex = 8;
            this.BtnAttack1.Text = "Attack";
            this.BtnAttack1.UseVisualStyleBackColor = true;
            this.BtnAttack1.Click += new System.EventHandler(this.BtnAttack1_Click);
            // 
            // lblPlayerDamageEffect
            // 
            this.lblPlayerDamageEffect.AutoSize = true;
            this.lblPlayerDamageEffect.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerDamageEffect.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerDamageEffect.ForeColor = System.Drawing.Color.Red;
            this.lblPlayerDamageEffect.Location = new System.Drawing.Point(87, 228);
            this.lblPlayerDamageEffect.Name = "lblPlayerDamageEffect";
            this.lblPlayerDamageEffect.Size = new System.Drawing.Size(0, 37);
            this.lblPlayerDamageEffect.TabIndex = 12;
            this.lblPlayerDamageEffect.Visible = false;
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::battlesimulatorOrtiz.Properties.Resources.saddasd;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(775, 456);
            this.Controls.Add(this.lblPlayerDamageEffect);
            this.Controls.Add(this.lblDamageEffect);
            this.Controls.Add(this.lblPlayerDamage);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.BtnAttack2);
            this.Controls.Add(this.BtnDefend);
            this.Controls.Add(this.BtnAttack1);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PBEnemy);
            this.Controls.Add(this.PBPlayer);
            this.Name = "Battle";
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.Battle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBEnemy)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.PictureBox PBPlayer;
        private System.Windows.Forms.PictureBox PBEnemy;
        private System.Windows.Forms.Timer damageTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblEnemyName;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnDefend;
        private System.Windows.Forms.Button BtnAttack2;
        private System.Windows.Forms.Timer TimerEnAtk;
        private System.Windows.Forms.Label LblInfo;
        private ColoredProgressBar ProgBarEnemy;
        private ColoredProgressBar ProgBarPlayer;
        private System.Windows.Forms.Timer TimerPlayerHP;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer TimerEnemyHP;
        private System.Windows.Forms.Button BtnAttack1;
        private System.Windows.Forms.Timer flashTimer;
        private System.Windows.Forms.Label lblPlayerDamageEffect;
    }
}

