﻿namespace AsteroidsGame
{
    partial class AsteroidsForm
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
            this.mouseXposer = new System.Windows.Forms.Label();
            this.Asteroid = new System.Windows.Forms.PictureBox();
            this.AsteroidPositionTimer = new System.Windows.Forms.Timer(this.components);
            this.ExplodingAsteroid = new System.Windows.Forms.PictureBox();
            this.NukeCloud = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Asteroid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplodingAsteroid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NukeCloud)).BeginInit();
            this.SuspendLayout();
            // 
            // mouseXposer
            // 
            this.mouseXposer.Location = new System.Drawing.Point(12, 9);
            this.mouseXposer.Name = "mouseXposer";
            this.mouseXposer.Size = new System.Drawing.Size(100, 23);
            this.mouseXposer.TabIndex = 0;
            this.mouseXposer.Text = "label1";
            // 
            // Asteroid
            // 
            this.Asteroid.BackColor = System.Drawing.Color.Transparent;
            this.Asteroid.Image = global::AsteroidsGame.Properties.Resources.Bomb1;
            this.Asteroid.Location = new System.Drawing.Point(316, 0);
            this.Asteroid.Name = "Asteroid";
            this.Asteroid.Size = new System.Drawing.Size(50, 50);
            this.Asteroid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Asteroid.TabIndex = 1;
            this.Asteroid.TabStop = false;
            this.Asteroid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Asteroid_MouseClick);
            // 
            // AsteroidPositionTimer
            // 
            this.AsteroidPositionTimer.Enabled = true;
            this.AsteroidPositionTimer.Interval = 1;
            this.AsteroidPositionTimer.Tick += new System.EventHandler(this.AsteroidPositionTimer_Tick);
            // 
            // ExplodingAsteroid
            // 
            this.ExplodingAsteroid.BackColor = System.Drawing.Color.Transparent;
            this.ExplodingAsteroid.Image = global::AsteroidsGame.Properties.Resources.ExplodingAsteroid;
            this.ExplodingAsteroid.Location = new System.Drawing.Point(246, 0);
            this.ExplodingAsteroid.MaximumSize = new System.Drawing.Size(75, 75);
            this.ExplodingAsteroid.Name = "ExplodingAsteroid";
            this.ExplodingAsteroid.Size = new System.Drawing.Size(75, 75);
            this.ExplodingAsteroid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExplodingAsteroid.TabIndex = 2;
            this.ExplodingAsteroid.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(426, 516);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "Score = 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(426, 469);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Missing Shots = 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(428, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Shots = 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-23, -46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // NukeCloud
            // 
            this.NukeCloud.BackColor = System.Drawing.Color.Transparent;
            this.NukeCloud.Image = global::AsteroidsGame.Properties.Resources.nukecloud;
            this.NukeCloud.Location = new System.Drawing.Point(291, 450);
            this.NukeCloud.MaximumSize = new System.Drawing.Size(75, 75);
            this.NukeCloud.Name = "NukeCloud";
            this.NukeCloud.Size = new System.Drawing.Size(75, 75);
            this.NukeCloud.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NukeCloud.TabIndex = 3;
            this.NukeCloud.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // AsteroidsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AsteroidsGame.Properties.Resources.Back;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NukeCloud);
            this.Controls.Add(this.ExplodingAsteroid);
            this.Controls.Add(this.Asteroid);
            this.Controls.Add(this.mouseXposer);
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "AsteroidsForm";
            this.Text = "wwww";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AsteroidsForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AsteroidsForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.Asteroid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplodingAsteroid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NukeCloud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label mouseXposer;
        private System.Windows.Forms.PictureBox Asteroid;
        private System.Windows.Forms.Timer AsteroidPositionTimer;
        private System.Windows.Forms.PictureBox ExplodingAsteroid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox NukeCloud;
    }
}

