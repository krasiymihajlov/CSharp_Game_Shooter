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
            this.ScoreCount = new System.Windows.Forms.Label();
            this.Rockets = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RocketPB = new System.Windows.Forms.PictureBox();
            this.LaserPB = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.QuitButton = new System.Windows.Forms.PictureBox();
            this.Restart = new System.Windows.Forms.PictureBox();
            this.RedGift = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Pause = new System.Windows.Forms.PictureBox();
            this.Start = new System.Windows.Forms.PictureBox();
            this.GiftPositionTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.RocketGift = new System.Windows.Forms.PictureBox();
            this.DashboardGiftLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BombPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplodingAsteroid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NukeCloud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RocketPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaserPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Restart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedGift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RocketGift)).BeginInit();
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
            this.AsteroidPositionTimer.Interval = 10;
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
            this.NukeCloud.Location = new System.Drawing.Point(281, 408);
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
            // ScoreCount
            // 
            this.ScoreCount.AutoSize = true;
            this.ScoreCount.BackColor = System.Drawing.SystemColors.Desktop;
            this.ScoreCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.ScoreCount.ForeColor = System.Drawing.Color.Red;
            this.ScoreCount.Location = new System.Drawing.Point(292, 606);
            this.ScoreCount.Name = "ScoreCount";
            this.ScoreCount.Size = new System.Drawing.Size(73, 19);
            this.ScoreCount.TabIndex = 5;
            this.ScoreCount.Text = "Score: 0";
            // 
            // Rockets
            // 
            this.Rockets.AutoSize = true;
            this.Rockets.BackColor = System.Drawing.SystemColors.Desktop;
            this.Rockets.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Rockets.ForeColor = System.Drawing.Color.Red;
            this.Rockets.Location = new System.Drawing.Point(293, 582);
            this.Rockets.Name = "Rockets";
            this.Rockets.Size = new System.Drawing.Size(100, 19);
            this.Rockets.TabIndex = 4;
            this.Rockets.Text = "Rockets: 10";
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
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(-23, -46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.Black;
            this.QuitButton.Image = global::AsteroidsGame.Properties.Resources.quit;
            this.QuitButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("QuitButton.InitialImage")));
            this.QuitButton.Location = new System.Drawing.Point(620, 616);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(66, 53);
            this.QuitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QuitButton.TabIndex = 10;
            this.QuitButton.TabStop = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Restart.Image = global::AsteroidsGame.Properties.Resources.restart;
            this.Restart.Location = new System.Drawing.Point(537, 602);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(46, 47);
            this.Restart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Restart.TabIndex = 11;
            this.Restart.TabStop = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // RedGift
            // 
            this.RedGift.BackColor = System.Drawing.Color.Transparent;
            this.RedGift.Image = ((System.Drawing.Image)(resources.GetObject("RedGift.Image")));
            this.RedGift.Location = new System.Drawing.Point(0, 302);
            this.RedGift.Name = "RedGift";
            this.RedGift.Size = new System.Drawing.Size(77, 99);
            this.RedGift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedGift.TabIndex = 12;
            this.RedGift.TabStop = false;
            this.RedGift.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RedGift_MouseClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(-23, -46);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 50);
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // Pause
            // 
            this.Pause.BackColor = System.Drawing.Color.Black;
            this.Pause.Image = global::AsteroidsGame.Properties.Resources.pause;
            this.Pause.Location = new System.Drawing.Point(103, 602);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(45, 43);
            this.Pause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pause.TabIndex = 14;
            this.Pause.TabStop = false;
            this.Pause.Click += new System.EventHandler(this.PauseGame_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Black;
            this.Start.Image = global::AsteroidsGame.Properties.Resources.start;
            this.Start.Location = new System.Drawing.Point(0, 616);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(66, 53);
            this.Start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Start.TabIndex = 15;
            this.Start.TabStop = false;
            this.Start.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // GiftPositionTimer
            // 
            this.GiftPositionTimer.Interval = 10;
            this.GiftPositionTimer.Tick += new System.EventHandler(this.GiftPositionTimer_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::AsteroidsGame.Properties.Resources.AirForce;
            this.pictureBox3.Location = new System.Drawing.Point(0, 563);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(686, 106);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // RocketGift
            // 
            this.RocketGift.BackColor = System.Drawing.Color.Transparent;
            this.RocketGift.Image = global::AsteroidsGame.Properties.Resources.RocketGift;
            this.RocketGift.Location = new System.Drawing.Point(89, 349);
            this.RocketGift.Name = "RocketGift";
            this.RocketGift.Size = new System.Drawing.Size(23, 52);
            this.RocketGift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.RocketGift.TabIndex = 17;
            this.RocketGift.TabStop = false;
            // 
            // DashboardGiftLabel
            // 
            this.DashboardGiftLabel.AutoSize = true;
            this.DashboardGiftLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.DashboardGiftLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.DashboardGiftLabel.ForeColor = System.Drawing.Color.Orange;
            this.DashboardGiftLabel.Location = new System.Drawing.Point(303, 631);
            this.DashboardGiftLabel.Name = "DashboardGiftLabel";
            this.DashboardGiftLabel.Size = new System.Drawing.Size(77, 16);
            this.DashboardGiftLabel.TabIndex = 18;
            this.DashboardGiftLabel.Text = "+1 Rocket";
            // 
            // AsteroidsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AsteroidsGame.Properties.Resources.Back;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.DashboardGiftLabel);
            this.Controls.Add(this.RocketGift);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.ScoreCount);
            this.Controls.Add(this.Rockets);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.RedGift);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LaserPB);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Restart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedGift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RocketGift)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mouseXposer;
        private System.Windows.Forms.PictureBox BombPB;
        private System.Windows.Forms.Timer AsteroidPositionTimer;
        private System.Windows.Forms.PictureBox ExplodingAsteroid;
        private System.Windows.Forms.Label ScoreCount;
        private System.Windows.Forms.Label Rockets;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox NukeCloud;
        private System.Windows.Forms.PictureBox RocketPB;
        private System.Windows.Forms.PictureBox LaserPB;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox QuitButton;
        private System.Windows.Forms.PictureBox Restart;
        private System.Windows.Forms.PictureBox RedGift;
        private System.Windows.Forms.Timer GiftPositionTimer;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox Pause;
        private System.Windows.Forms.PictureBox Start;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox RocketGift;
        private System.Windows.Forms.Label DashboardGiftLabel;
    }
}

