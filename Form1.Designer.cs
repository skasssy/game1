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
            health = new PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)health).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boss).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bossItem).BeginInit();
            SuspendLayout();
            // 
            // bg1
            // 
            bg1.Image = (Image)resources.GetObject("bg1.Image");
            bg1.Location = new Point(0, 0);
            bg1.Margin = new Padding(4, 4, 4, 4);
            bg1.Name = "bg1";
            bg1.Size = new Size(1050, 812);
            bg1.TabIndex = 0;
            bg1.TabStop = false;
            // 
            // bg2
            // 
            bg2.Image = (Image)resources.GetObject("bg2.Image");
            bg2.Location = new Point(0, -812);
            bg2.Margin = new Padding(4, 4, 4, 4);
            bg2.Name = "bg2";
            bg2.Size = new Size(1050, 812);
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
            player.Location = new Point(475, 646);
            player.Margin = new Padding(4, 4, 4, 4);
            player.Name = "player";
            player.Size = new Size(108, 160);
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // enemy1
            // 
            enemy1.BackColor = Color.Gray;
            enemy1.Image = (Image)resources.GetObject("enemy1.Image");
            enemy1.Location = new Point(231, -161);
            enemy1.Margin = new Padding(4, 4, 4, 4);
            enemy1.Name = "enemy1";
            enemy1.Size = new Size(108, 160);
            enemy1.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy1.TabIndex = 3;
            enemy1.TabStop = false;
            // 
            // enemy2
            // 
            enemy2.BackColor = Color.Gray;
            enemy2.Image = (Image)resources.GetObject("enemy2.Image");
            enemy2.Location = new Point(712, -500);
            enemy2.Margin = new Padding(4, 4, 4, 4);
            enemy2.Name = "enemy2";
            enemy2.Size = new Size(108, 160);
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
            labelLose.Location = new Point(304, 199);
            labelLose.Margin = new Padding(4, 0, 4, 0);
            labelLose.Name = "labelLose";
            labelLose.Size = new Size(431, 65);
            labelLose.TabIndex = 5;
            labelLose.Text = "ВЫ ПРОИГРАЛИ!";
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRestart.Location = new Point(426, 294);
            btnRestart.Margin = new Padding(4, 4, 4, 4);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(201, 51);
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
            labelPause.Location = new Point(30, 751);
            labelPause.Margin = new Padding(4, 0, 4, 0);
            labelPause.Name = "labelPause";
            labelPause.Size = new Size(94, 32);
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
            labelCoins.Location = new Point(30, 29);
            labelCoins.Margin = new Padding(4, 0, 4, 0);
            labelCoins.Name = "labelCoins";
            labelCoins.Size = new Size(131, 32);
            labelCoins.TabIndex = 8;
            labelCoins.Text = "Монеты: 0";
            // 
            // labelLives
            // 
            labelLives.AutoSize = true;
            labelLives.BackColor = Color.White;
            labelLives.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelLives.ForeColor = Color.Black;
            labelLives.Location = new Point(879, 29);
            labelLives.Margin = new Padding(4, 0, 4, 0);
            labelLives.Name = "labelLives";
            labelLives.Size = new Size(150, 32);
            labelLives.TabIndex = 9;
            labelLives.Text = "Жизни: ♥♥♥";
            // 
            // coin
            // 
            coin.BackColor = Color.Gray;
            coin.Image = (Image)resources.GetObject("coin.Image");
            coin.Location = new Point(600, -750);
            coin.Margin = new Padding(4, 4, 4, 4);
            coin.Name = "coin";
            coin.Size = new Size(40, 40);
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
            labelLevel.Location = new Point(879, 94);
            labelLevel.Margin = new Padding(4, 0, 4, 0);
            labelLevel.Name = "labelLevel";
            labelLevel.Size = new Size(131, 32);
            labelLevel.TabIndex = 11;
            labelLevel.Text = "Уровень: 1";
            // 
            // labelHighScore
            // 
            labelHighScore.AutoSize = true;
            labelHighScore.BackColor = Color.White;
            labelHighScore.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelHighScore.ForeColor = Color.Black;
            labelHighScore.Location = new Point(879, 751);
            labelHighScore.Margin = new Padding(4, 0, 4, 0);
            labelHighScore.Name = "labelHighScore";
            labelHighScore.Size = new Size(121, 32);
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
            panelMenu.Margin = new Padding(4, 4, 4, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1050, 812);
            panelMenu.TabIndex = 13;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Red;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(452, 438);
            btnStart.Margin = new Padding(4, 4, 4, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(161, 61);
            btnStart.TabIndex = 1;
            btnStart.Text = "СТАРТ";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // health
            // 
            health.BackColor = Color.Gray;
            health.Image = (Image)resources.GetObject("health.Image");
            health.Location = new Point(780, -1250);
            health.Margin = new Padding(4, 4, 4, 4);
            health.Name = "health";
            health.Size = new Size(40, 40);
            health.SizeMode = PictureBoxSizeMode.StretchImage;
            health.TabIndex = 2;
            health.TabStop = false;
            health.Visible = false;
            // 
            // boss
            // 
            boss.BackColor = Color.Gray;
            boss.Image = (Image)resources.GetObject("boss.Image");
            boss.Location = new Point(425, -238);
            boss.Margin = new Padding(4, 4, 4, 4);
            boss.Name = "boss";
            boss.Size = new Size(189, 238);
            boss.SizeMode = PictureBoxSizeMode.StretchImage;
            boss.TabIndex = 3;
            boss.TabStop = false;
            boss.Visible = false;
            // 
            // HPpanel
            // 
            HPpanel.BackColor = Color.Firebrick;
            HPpanel.Location = new Point(335, 29);
            HPpanel.Margin = new Padding(4, 4, 4, 4);
            HPpanel.Name = "HPpanel";
            HPpanel.Size = new Size(375, 25);
            HPpanel.TabIndex = 2;
            HPpanel.Visible = false;
            // 
            // labelCountdown
            // 
            labelCountdown.AutoSize = true;
            labelCountdown.BackColor = Color.Transparent;
            labelCountdown.Font = new Font("Segoe UI", 64F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelCountdown.ForeColor = Color.Red;
            labelCountdown.Location = new Point(462, 281);
            labelCountdown.Margin = new Padding(4, 0, 4, 0);
            labelCountdown.Name = "labelCountdown";
            labelCountdown.Size = new Size(146, 170);
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
            bossItem.Location = new Point(304, 552);
            bossItem.Margin = new Padding(4, 4, 4, 4);
            bossItem.Name = "bossItem";
            bossItem.Size = new Size(62, 54);
            bossItem.SizeMode = PictureBoxSizeMode.StretchImage;
            bossItem.TabIndex = 14;
            bossItem.TabStop = false;
            bossItem.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1050, 812);
            Controls.Add(panelMenu);
            Controls.Add(labelLose);
            Controls.Add(btnRestart);
            Controls.Add(HPpanel);
            Controls.Add(enemy2);
            Controls.Add(enemy1);
            Controls.Add(boss);
            Controls.Add(health);
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
            Margin = new Padding(4, 4, 4, 4);
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
            ((System.ComponentModel.ISupportInitialize)health).EndInit();
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
        private PictureBox health;
    }
}
