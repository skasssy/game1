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
            btnExit = new Button();
            btnStart = new Button();
            labelTitle = new Label();
            labelCountdown = new Label();
            timerPulse = new System.Windows.Forms.Timer(components);
            timerCountdown = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)bg1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bg2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemy1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemy2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coin).BeginInit();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // bg1
            // 
            bg1.Image = (Image)resources.GetObject("bg1.Image");
            bg1.Location = new Point(0, 0);
            bg1.Margin = new Padding(3, 2, 3, 2);
            bg1.Name = "bg1";
            bg1.Size = new Size(735, 487);
            bg1.TabIndex = 0;
            bg1.TabStop = false;
            // 
            // bg2
            // 
            bg2.Image = (Image)resources.GetObject("bg2.Image");
            bg2.Location = new Point(0, -487);
            bg2.Margin = new Padding(3, 2, 3, 2);
            bg2.Name = "bg2";
            bg2.Size = new Size(735, 487);
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
            player.Location = new Point(259, 388);
            player.Margin = new Padding(3, 2, 3, 2);
            player.Name = "player";
            player.Size = new Size(88, 75);
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // enemy1
            // 
            enemy1.BackColor = Color.FromArgb(64, 64, 64);
            enemy1.Image = (Image)resources.GetObject("enemy1.Image");
            enemy1.Location = new Point(150, -97);
            enemy1.Margin = new Padding(3, 2, 3, 2);
            enemy1.Name = "enemy1";
            enemy1.Size = new Size(88, 75);
            enemy1.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy1.TabIndex = 3;
            enemy1.TabStop = false;
            // 
            // enemy2
            // 
            enemy2.BackColor = Color.FromArgb(64, 64, 64);
            enemy2.Image = (Image)resources.GetObject("enemy2.Image");
            enemy2.Location = new Point(483, -300);
            enemy2.Margin = new Padding(3, 2, 3, 2);
            enemy2.Name = "enemy2";
            enemy2.Size = new Size(88, 75);
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
            labelLose.Location = new Point(213, 119);
            labelLose.Name = "labelLose";
            labelLose.Size = new Size(288, 45);
            labelLose.TabIndex = 5;
            labelLose.Text = "ВЫ ПРОИГРАЛИ!";
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRestart.Location = new Point(298, 176);
            btnRestart.Margin = new Padding(3, 2, 3, 2);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(141, 31);
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
            labelPause.Location = new Point(21, 451);
            labelPause.Name = "labelPause";
            labelPause.Size = new Size(63, 21);
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
            labelCoins.Location = new Point(21, 17);
            labelCoins.Name = "labelCoins";
            labelCoins.Size = new Size(89, 21);
            labelCoins.TabIndex = 8;
            labelCoins.Text = "Монеты: 0";
            // 
            // labelLives
            // 
            labelLives.AutoSize = true;
            labelLives.BackColor = Color.White;
            labelLives.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelLives.ForeColor = Color.Black;
            labelLives.Location = new Point(615, 17);
            labelLives.Name = "labelLives";
            labelLives.Size = new Size(102, 21);
            labelLives.TabIndex = 9;
            labelLives.Text = "Жизни: ♥♥♥";
            // 
            // coin
            // 
            coin.BackColor = Color.FromArgb(64, 64, 64);
            coin.Image = (Image)resources.GetObject("coin.Image");
            coin.Location = new Point(494, -450);
            coin.Margin = new Padding(3, 2, 3, 2);
            coin.Name = "coin";
            coin.Size = new Size(28, 24);
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
            labelLevel.Location = new Point(615, 56);
            labelLevel.Name = "labelLevel";
            labelLevel.Size = new Size(87, 21);
            labelLevel.TabIndex = 11;
            labelLevel.Text = "Уровень: 1";
            // 
            // labelHighScore
            // 
            labelHighScore.AutoSize = true;
            labelHighScore.BackColor = Color.White;
            labelHighScore.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelHighScore.ForeColor = Color.Black;
            labelHighScore.Location = new Point(615, 451);
            labelHighScore.Name = "labelHighScore";
            labelHighScore.Size = new Size(81, 21);
            labelHighScore.TabIndex = 12;
            labelHighScore.Text = "Рекорд: 0";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(180, 0, 0);
            panelMenu.Controls.Add(btnExit);
            panelMenu.Controls.Add(btnStart);
            panelMenu.Controls.Add(labelTitle);
            panelMenu.Dock = DockStyle.Fill;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 2, 3, 2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(735, 487);
            panelMenu.TabIndex = 13;
            panelMenu.Paint += panelMenu_Paint;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(598, 435);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(113, 37);
            btnExit.TabIndex = 2;
            btnExit.Text = "ВЫХОД";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.LimeGreen;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(314, 253);
            btnStart.Margin = new Padding(3, 2, 3, 2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(113, 37);
            btnStart.TabIndex = 1;
            btnStart.Text = "СТАРТ";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(144, 159);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(447, 86);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CAR DODGER";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCountdown
            // 
            labelCountdown.AutoSize = true;
            labelCountdown.BackColor = Color.Red;
            labelCountdown.Font = new Font("Segoe UI", 60F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelCountdown.ForeColor = Color.Black;
            labelCountdown.Location = new Point(329, 169);
            labelCountdown.Name = "labelCountdown";
            labelCountdown.Size = new Size(91, 106);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(735, 487);
            Controls.Add(panelMenu);
            Controls.Add(labelCountdown);
            Controls.Add(player);
            Controls.Add(btnRestart);
            Controls.Add(labelLose);
            Controls.Add(labelHighScore);
            Controls.Add(labelLevel);
            Controls.Add(coin);
            Controls.Add(labelLives);
            Controls.Add(labelCoins);
            Controls.Add(labelPause);
            Controls.Add(enemy2);
            Controls.Add(enemy1);
            Controls.Add(bg1);
            Controls.Add(bg2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
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
            panelMenu.PerformLayout();
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
        private Label labelTitle;
        private Button btnStart;
        private Button btnExit;
        private System.Windows.Forms.Timer timerPulse;
        private Label labelCountdown;
        private System.Windows.Forms.Timer timerCountdown;
    }
}
