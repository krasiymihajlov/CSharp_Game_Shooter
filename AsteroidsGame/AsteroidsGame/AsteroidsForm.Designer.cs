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
            this.mouseXposer = new System.Windows.Forms.Label();
            this.Asteroid = new System.Windows.Forms.PictureBox();
            this.AsteroidPositionTimer = new System.Windows.Forms.Timer(this.components);
            this.ExplodingAsteroid = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Asteroid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplodingAsteroid)).BeginInit();
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
            this.Asteroid.Image = global::AsteroidsGame.Properties.Resources.Stoun;
            this.Asteroid.Location = new System.Drawing.Point(317, 158);
            this.Asteroid.Name = "Asteroid";
            this.Asteroid.Size = new System.Drawing.Size(81, 65);
            this.Asteroid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Asteroid.TabIndex = 1;
            this.Asteroid.TabStop = false;
            this.Asteroid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Asteroid_MouseClick);
            // 
            // AsteroidPositionTimer
            // 
            this.AsteroidPositionTimer.Enabled = true;
            this.AsteroidPositionTimer.Interval = 800;
            this.AsteroidPositionTimer.Tick += new System.EventHandler(this.AsteroidPositionTimer_Tick);
            // 
            // ExplodingAsteroid
            // 
            this.ExplodingAsteroid.BackColor = System.Drawing.Color.Transparent;
            this.ExplodingAsteroid.Image = global::AsteroidsGame.Properties.Resources.ExplodingAsteroid;
            this.ExplodingAsteroid.Location = new System.Drawing.Point(121, 128);
            this.ExplodingAsteroid.Name = "ExplodingAsteroid";
            this.ExplodingAsteroid.Size = new System.Drawing.Size(147, 147);
            this.ExplodingAsteroid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ExplodingAsteroid.TabIndex = 2;
            this.ExplodingAsteroid.TabStop = false;
            // 
            // AsteroidsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AsteroidsGame.Properties.Resources.Back;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.ExplodingAsteroid);
            this.Controls.Add(this.Asteroid);
            this.Controls.Add(this.mouseXposer);
            this.Name = "AsteroidsForm";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AsteroidsForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AsteroidsForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.Asteroid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplodingAsteroid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mouseXposer;
        private System.Windows.Forms.PictureBox Asteroid;
        private System.Windows.Forms.Timer AsteroidPositionTimer;
        private System.Windows.Forms.PictureBox ExplodingAsteroid;
    }
}

