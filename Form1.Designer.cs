using System.Windows.Forms;

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
            panelMenu = new Panel();
            btnStart = new Button();
            healthItem = new PictureBox();
            boss = new PictureBox();
            HPpanel = new Panel();
            labelCountdown = new Label();
            timerPulse = new System.Windows.Forms.Timer(components);
            timerCountdown = new System.Windows.Forms.Timer(components);
            bossItem = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)bg1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bg2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemy1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemy2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coin).BeginInit();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)healthItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boss).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bossItem).BeginInit();
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
            player.BackColor = Color.Gray;
            player.Image = (Image)resources.GetObject("player.Image");
            player.Location = new Point(380, 517);
            player.Name = "player";
            player.Size = new Size(86, 128);
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // enemy1
            // 
            enemy1.BackColor = Color.Gray;
            enemy1.Image = (Image)resources.GetObject("enemy1.Image");
            enemy1.Location = new Point(171, -129);
            enemy1.Name = "enemy1";
            enemy1.Size = new Size(86, 128);
            enemy1.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy1.TabIndex = 3;
            enemy1.TabStop = false;
            // 
            // enemy2
            // 
            enemy2.BackColor = Color.Gray;
            enemy2.Image = (Image)resources.GetObject("enemy2.Image");
            enemy2.Location = new Point(552, -400);
            enemy2.Name = "enemy2";
            enemy2.Size = new Size(86, 128);
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
            labelLose.Location = new Point(243, 159);
            labelLose.Name = "labelLose";
            labelLose.Size = new Size(360, 54);
            labelLose.TabIndex = 5;
            labelLose.Text = "ВЫ ПРОИГРАЛИ!";
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRestart.Location = new Point(341, 235);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(161, 41);
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
            labelLives.Location = new Point(703, 23);
            labelLives.Name = "labelLives";
            labelLives.Size = new Size(128, 28);
            labelLives.TabIndex = 9;
            labelLives.Text = "Жизни: ♥♥♥";
            // 
            // coin
            // 
            coin.BackColor = Color.Gray;
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
            labelLevel.Location = new Point(703, 75);
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
            labelHighScore.Location = new Point(703, 601);
            labelHighScore.Name = "labelHighScore";
            labelHighScore.Size = new Size(103, 28);
            labelHighScore.TabIndex = 12;
            labelHighScore.Text = "Рекорд: 0";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.Turquoise;
            panelMenu.BackgroundImage = (Image)resources.GetObject("panelMenu.BackgroundImage");
            panelMenu.Controls.Add(btnStart);
            panelMenu.Dock = DockStyle.Fill;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(840, 650);
            panelMenu.TabIndex = 13;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Red;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(362, 350);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(129, 49);
            btnStart.TabIndex = 1;
            btnStart.Text = "СТАРТ";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // healthItem
            // 
            healthItem.BackColor = Color.Gray;
            healthItem.Image = (Image)resources.GetObject("healthItem.Image");
            healthItem.Location = new Point(624, -1000);
            healthItem.Name = "healthItem";
            healthItem.Size = new Size(40, 40);
            healthItem.SizeMode = PictureBoxSizeMode.StretchImage;
            healthItem.TabIndex = 2;
            healthItem.TabStop = false;
            healthItem.Visible = false;
            // 
            // boss
            // 
            boss.BackColor = Color.Gray;
            boss.Image = (Image)resources.GetObject("boss.Image");
            boss.Location = new Point(340, -190);
            boss.Name = "boss";
            boss.Size = new Size(151, 190);
            boss.SizeMode = PictureBoxSizeMode.StretchImage;
            boss.TabIndex = 3;
            boss.TabStop = false;
            boss.Visible = false;
            // 
            // HPpanel
            // 
            HPpanel.BackColor = Color.Firebrick;
            HPpanel.Location = new Point(268, 23);
            HPpanel.Name = "HPpanel";
            HPpanel.Size = new Size(300, 20);
            HPpanel.TabIndex = 2;
            HPpanel.Visible = false;
            // 
            // labelCountdown
            // 
            labelCountdown.AutoSize = true;
            labelCountdown.BackColor = Color.Transparent;
            labelCountdown.Font = new Font("Segoe UI", 64F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelCountdown.ForeColor = Color.Red;
            labelCountdown.Location = new Point(370, 225);
            labelCountdown.Name = "labelCountdown";
            labelCountdown.Size = new Size(122, 142);
            labelCountdown.TabIndex = 3;
            labelCountdown.Text = "3";
            labelCountdown.TextAlign = ContentAlignment.MiddleCenter;
            labelCountdown.Visible = false;
            // 
            // timerPulse
            // 
            timerPulse.Interval = 40;
            timerPulse.Tick += timerPulse_Tick;
            // 
            // timerCountdown
            // 
            timerCountdown.Interval = 1000;
            timerCountdown.Tick += timerCountdown_Tick;
            // 
            // bossItem
            // 
            bossItem.BackColor = Color.Gray;
            bossItem.Image = (Image)resources.GetObject("bossItem.Image");
            bossItem.Location = new Point(243, 442);
            bossItem.Name = "bossItem";
            bossItem.Size = new Size(50, 43);
            bossItem.SizeMode = PictureBoxSizeMode.StretchImage;
            bossItem.TabIndex = 14;
            bossItem.TabStop = false;
            bossItem.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(840, 650);
            Controls.Add(panelMenu);
            Controls.Add(labelLose);
            Controls.Add(btnRestart);
            Controls.Add(HPpanel);
            Controls.Add(enemy2);
            Controls.Add(enemy1);
            Controls.Add(boss);
            Controls.Add(healthItem);
            Controls.Add(bossItem);
            Controls.Add(labelCountdown);
            Controls.Add(player);
            Controls.Add(labelHighScore);
            Controls.Add(labelLevel);
            Controls.Add(coin);
            Controls.Add(labelLives);
            Controls.Add(labelCoins);
            Controls.Add(labelPause);
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
            panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)healthItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)boss).EndInit();
            ((System.ComponentModel.ISupportInitialize)bossItem).EndInit();
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
        private Panel panelMenu;
        private Button btnStart;
        private System.Windows.Forms.Timer timerPulse;
        private Label labelCountdown;
        private System.Windows.Forms.Timer timerCountdown;
        private Panel HPpanel;
        private PictureBox boss;
        private PictureBox bossItem;
        private PictureBox healthItem;
    }
}
