namespace AsteroidsGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsteroidsForm));
            this.mouseXposer = new System.Windows.Forms.Label();
            this.BombPB = new System.Windows.Forms.PictureBox();
            this.AsteroidPositionTimer = new System.Windows.Forms.Timer(this.components);
            this.ExplodingAsteroid = new System.Windows.Forms.PictureBox();
            this.NukeCloud = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RocketPB = new System.Windows.Forms.PictureBox();
            this.LaserPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BombPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplodingAsteroid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NukeCloud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RocketPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaserPB)).BeginInit();
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
            // BombPB
            // 
            this.BombPB.BackColor = System.Drawing.Color.Transparent;
            this.BombPB.Image = global::AsteroidsGame.Properties.Resources.Bomb1;
            this.BombPB.Location = new System.Drawing.Point(316, 0);
            this.BombPB.Name = "BombPB";
            this.BombPB.Size = new System.Drawing.Size(50, 50);
            this.BombPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BombPB.TabIndex = 1;
            this.BombPB.TabStop = false;
            this.BombPB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Asteroid_MouseClick);
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
            // RocketPB
            // 
            this.RocketPB.BackColor = System.Drawing.Color.Transparent;
            this.RocketPB.Image = global::AsteroidsGame.Properties.Resources.Rocket1;
            this.RocketPB.Location = new System.Drawing.Point(261, 243);
            this.RocketPB.Name = "RocketPB";
            this.RocketPB.Size = new System.Drawing.Size(30, 112);
            this.RocketPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.RocketPB.TabIndex = 7;
            this.RocketPB.TabStop = false;
            // 
            // LaserPB
            // 
            this.LaserPB.BackColor = System.Drawing.Color.Transparent;
            this.LaserPB.Image = global::AsteroidsGame.Properties.Resources.LaserLight;
            this.LaserPB.Location = new System.Drawing.Point(281, -12);
            this.LaserPB.Name = "LaserPB";
            this.LaserPB.Size = new System.Drawing.Size(3, 720);
            this.LaserPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LaserPB.TabIndex = 8;
            this.LaserPB.TabStop = false;
            // 
            // AsteroidsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AsteroidsGame.Properties.Resources.Back;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.LaserPB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NukeCloud);
            this.Controls.Add(this.ExplodingAsteroid);
            this.Controls.Add(this.BombPB);
            this.Controls.Add(this.mouseXposer);
            this.Controls.Add(this.RocketPB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "AsteroidsForm";
            this.Text = "NY Bombs - Save your Town";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AsteroidsForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AsteroidsForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.BombPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplodingAsteroid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NukeCloud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RocketPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaserPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mouseXposer;
        private System.Windows.Forms.PictureBox BombPB;
        private System.Windows.Forms.Timer AsteroidPositionTimer;
        private System.Windows.Forms.PictureBox ExplodingAsteroid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox NukeCloud;
        private System.Windows.Forms.PictureBox RocketPB;
        private System.Windows.Forms.PictureBox LaserPB;
    }
}

