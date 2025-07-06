namespace battlesimulatorOrtiz
{
    partial class SelectForm
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
            this.PBBulbasaur = new System.Windows.Forms.PictureBox();
            this.PBOrtiz = new System.Windows.Forms.PictureBox();
            this.PBChristian = new System.Windows.Forms.PictureBox();
            this.lblOrtiz = new System.Windows.Forms.Label();
            this.lblChristian = new System.Windows.Forms.Label();
            this.lblBalbasaur = new System.Windows.Forms.Label();
            this.btnStartBattle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PBBulbasaur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOrtiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBChristian)).BeginInit();
            this.SuspendLayout();
            // 
            // PBBulbasaur
            // 
            this.PBBulbasaur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBBulbasaur.Image = global::battlesimulatorOrtiz.Properties.Resources.Bulbasaur;
            this.PBBulbasaur.Location = new System.Drawing.Point(550, 100);
            this.PBBulbasaur.Name = "PBBulbasaur";
            this.PBBulbasaur.Size = new System.Drawing.Size(200, 200);
            this.PBBulbasaur.TabIndex = 2;
            this.PBBulbasaur.TabStop = false;
            this.PBBulbasaur.Click += new System.EventHandler(this.PBBulbasaur_Click);
            // 
            // PBOrtiz
            // 
            this.PBOrtiz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBOrtiz.Image = global::battlesimulatorOrtiz.Properties.Resources.Ortiz;
            this.PBOrtiz.Location = new System.Drawing.Point(50, 100);
            this.PBOrtiz.Name = "PBOrtiz";
            this.PBOrtiz.Size = new System.Drawing.Size(200, 200);
            this.PBOrtiz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBOrtiz.TabIndex = 1;
            this.PBOrtiz.TabStop = false;
            this.PBOrtiz.Click += new System.EventHandler(this.PBOrtiz_Click);
            // 
            // PBChristian
            // 
            this.PBChristian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBChristian.Image = global::battlesimulatorOrtiz.Properties.Resources.Christian;
            this.PBChristian.Location = new System.Drawing.Point(300, 100);
            this.PBChristian.Name = "PBChristian";
            this.PBChristian.Size = new System.Drawing.Size(200, 200);
            this.PBChristian.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBChristian.TabIndex = 0;
            this.PBChristian.TabStop = false;
            this.PBChristian.Click += new System.EventHandler(this.PBChristian_Click);
            // 
            // lblOrtiz
            // 
            this.lblOrtiz.AutoSize = true;
            this.lblOrtiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrtiz.Location = new System.Drawing.Point(119, 69);
            this.lblOrtiz.Name = "lblOrtiz";
            this.lblOrtiz.Size = new System.Drawing.Size(62, 25);
            this.lblOrtiz.TabIndex = 3;
            this.lblOrtiz.Text = "Ortiz";
            // 
            // lblChristian
            // 
            this.lblChristian.AutoSize = true;
            this.lblChristian.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChristian.Location = new System.Drawing.Point(346, 69);
            this.lblChristian.Name = "lblChristian";
            this.lblChristian.Size = new System.Drawing.Size(106, 25);
            this.lblChristian.TabIndex = 4;
            this.lblChristian.Text = "Christian";
            // 
            // lblBalbasaur
            // 
            this.lblBalbasaur.AutoSize = true;
            this.lblBalbasaur.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalbasaur.Location = new System.Drawing.Point(593, 69);
            this.lblBalbasaur.Name = "lblBalbasaur";
            this.lblBalbasaur.Size = new System.Drawing.Size(118, 25);
            this.lblBalbasaur.TabIndex = 5;
            this.lblBalbasaur.Text = "Bulbasaur";
            // 
            // btnStartBattle
            // 
            this.btnStartBattle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartBattle.Location = new System.Drawing.Point(310, 324);
            this.btnStartBattle.Name = "btnStartBattle";
            this.btnStartBattle.Size = new System.Drawing.Size(190, 64);
            this.btnStartBattle.TabIndex = 6;
            this.btnStartBattle.Text = "StartBattle";
            this.btnStartBattle.UseVisualStyleBackColor = true;
            this.btnStartBattle.Click += new System.EventHandler(this.btnStartBattle_Click);
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnStartBattle);
            this.Controls.Add(this.lblBalbasaur);
            this.Controls.Add(this.lblChristian);
            this.Controls.Add(this.lblOrtiz);
            this.Controls.Add(this.PBBulbasaur);
            this.Controls.Add(this.PBOrtiz);
            this.Controls.Add(this.PBChristian);
            this.Name = "SelectForm";
            this.Text = "SelectForm";
            this.Load += new System.EventHandler(this.SelectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBBulbasaur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOrtiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBChristian)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBChristian;
        private System.Windows.Forms.PictureBox PBOrtiz;
        private System.Windows.Forms.PictureBox PBBulbasaur;
        private System.Windows.Forms.Label lblOrtiz;
        private System.Windows.Forms.Label lblChristian;
        private System.Windows.Forms.Label lblBalbasaur;
        private System.Windows.Forms.Button btnStartBattle;
    }
}