namespace game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            bg1 = new PictureBox();
            bg2 = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            player = new PictureBox();
            enemy1 = new PictureBox();
            enemy2 = new PictureBox();
            labelLose = new Label();
            btnRestart = new Button();
            labelPause = new Label();
            labelCoins = new Label();
            labelLives = new Label();
            coin = new PictureBox();
            labelLevel = new Label();
            labelHighScore = new Label();
            ((System.ComponentModel.ISupportInitialize)bg1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bg2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemy1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemy2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coin).BeginInit();
            SuspendLayout();
            // 
            // bg1
            // 
            bg1.Image = (Image)resources.GetObject("bg1.Image");
            bg1.Location = new Point(0, 0);
            bg1.Name = "bg1";
            bg1.Size = new Size(840, 650);
            bg1.TabIndex = 0;
            bg1.TabStop = false;
            // 
            // bg2
            // 
            bg2.Image = (Image)resources.GetObject("bg2.Image");
            bg2.Location = new Point(0, -650);
            bg2.Name = "bg2";
            bg2.Size = new Size(840, 650);
            bg2.TabIndex = 1;
            bg2.TabStop = false;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 15;
            timer.Tick += timer_Tick;
            // 
            // player
            // 
            player.BackColor = Color.FromArgb(64, 64, 64);
            player.Image = (Image)resources.GetObject("player.Image");
            player.Location = new Point(296, 517);
            player.Name = "player";
            player.Size = new Size(128, 128);
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // enemy1
            // 
            enemy1.BackColor = Color.FromArgb(64, 64, 64);
            enemy1.Image = (Image)resources.GetObject("enemy1.Image");
            enemy1.Location = new Point(172, -130);
            enemy1.Name = "enemy1";
            enemy1.Size = new Size(128, 128);
            enemy1.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy1.TabIndex = 3;
            enemy1.TabStop = false;
            // 
            // enemy2
            // 
            enemy2.BackColor = Color.FromArgb(64, 64, 64);
            enemy2.Image = (Image)resources.GetObject("enemy2.Image");
            enemy2.Location = new Point(552, -400);
            enemy2.Name = "enemy2";
            enemy2.Size = new Size(128, 128);
            enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy2.TabIndex = 4;
            enemy2.TabStop = false;
            // 
            // labelLose
            // 
            labelLose.AutoSize = true;
            labelLose.BackColor = Color.Red;
            labelLose.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelLose.ForeColor = Color.White;
            labelLose.Location = new Point(243, 158);
            labelLose.Name = "labelLose";
            labelLose.Size = new Size(360, 54);
            labelLose.TabIndex = 5;
            labelLose.Text = "ВЫ ПРОИГРАЛИ!";
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRestart.Location = new Point(340, 235);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(161, 42);
            btnRestart.TabIndex = 6;
            btnRestart.Text = "Перезапустить";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // labelPause
            // 
            labelPause.AutoSize = true;
            labelPause.BackColor = Color.Red;
            labelPause.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelPause.ForeColor = Color.White;
            labelPause.Location = new Point(24, 601);
            labelPause.Name = "labelPause";
            labelPause.Size = new Size(78, 28);
            labelPause.TabIndex = 7;
            labelPause.Text = "ПАУЗА";
            labelPause.Visible = false;
            // 
            // labelCoins
            // 
            labelCoins.AutoSize = true;
            labelCoins.BackColor = Color.White;
            labelCoins.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelCoins.ForeColor = Color.Black;
            labelCoins.Location = new Point(24, 23);
            labelCoins.Name = "labelCoins";
            labelCoins.Size = new Size(111, 28);
            labelCoins.TabIndex = 8;
            labelCoins.Text = "Монеты: 0";
            // 
            // labelLives
            // 
            labelLives.AutoSize = true;
            labelLives.BackColor = Color.White;
            labelLives.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelLives.ForeColor = Color.Black;
            labelLives.Location = new Point(702, 23);
            labelLives.Name = "labelLives";
            labelLives.Size = new Size(128, 28);
            labelLives.TabIndex = 9;
            labelLives.Text = "Жизни: ♥♥♥";
            // 
            // coin
            // 
            coin.BackColor = Color.FromArgb(64, 64, 64);
            coin.Image = (Image)resources.GetObject("coin.Image");
            coin.Location = new Point(565, -600);
            coin.Name = "coin";
            coin.Size = new Size(32, 32);
            coin.SizeMode = PictureBoxSizeMode.StretchImage;
            coin.TabIndex = 10;
            coin.TabStop = false;
            // 
            // labelLevel
            // 
            labelLevel.AutoSize = true;
            labelLevel.BackColor = Color.White;
            labelLevel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelLevel.ForeColor = Color.Black;
            labelLevel.Location = new Point(702, 75);
            labelLevel.Name = "labelLevel";
            labelLevel.Size = new Size(111, 28);
            labelLevel.TabIndex = 11;
            labelLevel.Text = "Уровень: 1";
            // 
            // labelHighScore
            // 
            labelHighScore.AutoSize = true;
            labelHighScore.BackColor = Color.White;
            labelHighScore.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelHighScore.ForeColor = Color.Black;
            labelHighScore.Location = new Point(702, 601);
            labelHighScore.Name = "labelHighScore";
            labelHighScore.Size = new Size(103, 28);
            labelHighScore.TabIndex = 12;
            labelHighScore.Text = "Рекорд: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(840, 650);
            Controls.Add(labelHighScore);
            Controls.Add(labelLevel);
            Controls.Add(coin);
            Controls.Add(labelLives);
            Controls.Add(labelCoins);
            Controls.Add(labelPause);
            Controls.Add(btnRestart);
            Controls.Add(labelLose);
            Controls.Add(enemy2);
            Controls.Add(enemy1);
            Controls.Add(player);
            Controls.Add(bg1);
            Controls.Add(bg2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyPress += Form1_KeyPress;
            ((System.ComponentModel.ISupportInitialize)bg1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bg2).EndInit();
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemy1).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemy2).EndInit();
            ((System.ComponentModel.ISupportInitialize)coin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox bg1;
        private PictureBox bg2;
        private System.Windows.Forms.Timer timer;
        private PictureBox player;
        private PictureBox enemy1;
        private PictureBox enemy2;
        private Label labelLose;
        private Button btnRestart;
        private Label labelPause;
        private Label labelCoins;
        private Label labelLives;
        private PictureBox coin;
        private Label labelLevel;
        private Label labelHighScore;
    }
}
