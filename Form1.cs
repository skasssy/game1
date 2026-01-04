using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        private Point pos;
        private Size startBtnSize;
        private bool dragging, lose = false, pulse = true;
        private int countdownValue = 3;
        private int countCoins = 0;
        private int lives = 3;
        private int level = 1;
        private int highScore = 0;
        private bool isInvulnerable = false;
        private int invulnerabilityTimer = 0;
        private Random rand = new Random();


        public Form1()
        {
            InitializeComponent();

            bg1.MouseDown += MouseClickDown;
            bg1.MouseUp += MouseClickUp;
            bg1.MouseMove += MouseClickMove;

            bg2.MouseDown += MouseClickDown;
            bg2.MouseUp += MouseClickUp;
            bg2.MouseMove += MouseClickMove;

            // Инициализация UI
            labelLose.Visible = false;
            btnRestart.Visible = false;
            KeyPreview = true;

            // Инициализация жизней
            UpdateLivesDisplay();
        }

        enum GameState
        {
            Menu,
            Playing,
            GameOver
        }

        GameState gameState = GameState.Menu;


        private void MouseClickDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            pos.X = e.X;
            pos.Y = e.Y;
        }

        private void MouseClickUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void MouseClickMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currPoint = PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(currPoint.X - pos.X, currPoint.Y - pos.Y + bg1.Top);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
            else if (e.KeyChar == 'p' || e.KeyChar == 'P')
                TogglePause();  // Пауза по клавише P
        }

        private void TogglePause()
        {
            timer.Enabled = !timer.Enabled;
            if (Controls.ContainsKey("labelPause"))
            {
                labelPause.Visible = !timer.Enabled;
            }
        }

        private void ResetCoin()
        {
            coin.Top = -50;
            coin.Left = rand.Next(150, 560);
        }

        private void ResetEnemy(PictureBox enemy, int minLeft, int maxLeft)
        {
            enemy.Top = -rand.Next(100, 400);
            enemy.Left = rand.Next(minLeft, maxLeft);
        }

        private void CheckCollisions()
        {
            // Проверяем столкновение с врагами
            if ((player.Bounds.IntersectsWith(enemy1.Bounds) ||
                 player.Bounds.IntersectsWith(enemy2.Bounds)) && !isInvulnerable)
            {
                HandleCollision();
            }
        }

        private void HandleCollision()
        {
            player.BackColor = Color.Red;

            // Потеря жизни
            lives--;
            UpdateLivesDisplay();

            if (lives <= 0)
            {
                // Конец игры
                GameOver();
            }
            else
            {
                isInvulnerable = true;
                invulnerabilityTimer = 100;
            }
        }

        private void CollectCoin()
        {
            countCoins++;
            labelCoins.Text = "Монеты: " + countCoins.ToString();

            // Обновляем рекорд
            if (countCoins > highScore)
            {
                highScore = countCoins;
                if (Controls.ContainsKey("labelHighScore"))
                {
                    labelHighScore.Text = "Рекорд: " + highScore.ToString();
                }
            }

            // Проверка уровня
            CheckLevelUp();

            ResetCoin();
        }

        private void CheckLevelUp()
        {
            int newLevel = 1 + (countCoins / 3); // Новый уровень каждые 5 монет

            if (newLevel > level)
            {
                level = newLevel;

                // Обновляем отображение уровня
                if (Controls.ContainsKey("labelLevel"))
                {
                    labelLevel.Text = "Уровень: " + level.ToString();
                }

                if (Controls.ContainsKey("labelCoins"))
                {
                    labelCoins.ForeColor = Color.Green;
                }
            }
        }

        private void UpdateLivesDisplay()
        {
            if (Controls.ContainsKey("labelLives"))
            {
                labelLives.Text = "Жизни: " + new string('♥', lives);
                labelLives.ForeColor = lives == 1 ? Color.Red :
                                      lives == 2 ? Color.Orange :
                                      Color.Green;
            }
        }

        private void GameOver()
        {
            timer.Stop();
            labelLose.Visible = true;
            btnRestart.Visible = true;
            lose = true;
        }

        private void ResetGame()
        {
            // Остановка таймера
            timer.Stop();

            // Сброс переменных
            lose = false;
            countCoins = 0;
            lives = 3;
            level = 1;
            isInvulnerable = false;
            invulnerabilityTimer = 0;

            // Сброс скорости таймера
            timer.Interval = 15;

            // Сброс UI элементов
            labelLose.Visible = false;
            btnRestart.Visible = false;

            if (Controls.ContainsKey("labelPause"))
            {
                labelPause.Visible = false;
            }

            // Сброс отображения
            labelCoins.Text = "Монеты: 0";
            labelCoins.ForeColor = SystemColors.ControlText;

            if (Controls.ContainsKey("labelLevel"))
            {
                labelLevel.Text = "Уровень: 1";
            }

            if (Controls.ContainsKey("labelHighScore"))
            {
                labelHighScore.Text = "Рекорд: " + highScore.ToString();
            }

            UpdateLivesDisplay();

            // Сброс позиции игрока
            player.Left = 300;
            player.Top = 500;
            player.BackColor = Color.Transparent;

            // Сброс позиций врагов
            enemy1.Top = -130;
            enemy2.Top = -400;

            // Сброс позиции монеты
            ResetCoin();

            // Включение таймера
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Если игра на паузе или проиграна - выходим
            if (!timer.Enabled || lose) return;

            // Обновляем таймер неуязвимости
            if (isInvulnerable)
            {
                invulnerabilityTimer--;
                if (invulnerabilityTimer <= 0)
                {
                    isInvulnerable = false;
                    player.BackColor = Color.Transparent;
                }
                else
                {
                    // Мигание при неуязвимости
                    player.BackColor = (invulnerabilityTimer / 5) % 2 == 0 ? Color.Transparent : Color.FromArgb(150, Color.Yellow);
                }
            }

            int bgSpeed = 1 + level;  // Скорость фона
            int enemySpeed = 1 + level * 2;  // Скорость врагов

            // Движение фона5
            bg1.Top += bgSpeed;
            bg2.Top += bgSpeed;

            if (bg1.Top >= 650)
            {
                bg1.Top = 0;
                bg2.Top = -650;
            }

            // Движение врагов
            enemy1.Top += enemySpeed;
            enemy2.Top += enemySpeed;

            // Движение монеты
            coin.Top += bgSpeed;


            // Восстановление объектов за пределами экрана
            if (coin.Top >= 650)
            {
                ResetCoin();
            }

            if (enemy1.Top >= 650)
            {
                ResetEnemy(enemy1, 150, 300);
            }

            if (enemy2.Top >= 650)
            {
                ResetEnemy(enemy2, 300, 560);
            }

            // Проверка столкновений с врагами
            CheckCollisions();

            // Проверка сбора монеты
            if (player.Bounds.IntersectsWith(coin.Bounds))
            {
                CollectCoin();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (lose || !timer.Enabled) return;

                int speed = 10;
                bool moved = false;

                // Основное управление
                if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && player.Left > 150)
                {
                    player.Left -= speed;
                    moved = true;
                }
                else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && player.Right < 700)
                {
                    player.Left += speed;
                    moved = true;
                }


                // Вертикальное движение
                if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.W) && player.Top > 0)
                {
                    player.Top -= speed;
                    moved = true;
                }
                else if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.S) && player.Bottom < 650)
                {
                    player.Top += speed;
                    moved = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowMenu();
            timer.Stop();
            startBtnSize = btnStart.Size;
            timerPulse.Start();

            if (Controls.ContainsKey("labelPause"))
            {
                labelPause.Visible = false;
            }

            // Инициализируем отображение рекорда
            if (Controls.ContainsKey("labelHighScore"))
            {
                labelHighScore.Text = "Рекорд: " + highScore.ToString();
            }

            // Инициализируем отображение уровня
            if (Controls.ContainsKey("labelLevel"))
            {
                labelLevel.Text = "Уровень: " + level.ToString();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void ShowMenu()
        {
            panelMenu.Visible = true;
            panelMenu.BringToFront();
            gameState = GameState.Menu;
        }

        private void StartGame()
        {
            panelMenu.Visible = false;
            ResetGame();
            timer.Start();
            gameState = GameState.Playing;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            StartCountdown();
        }

        private void StartCountdown()
        {
            countdownValue = 3;
            labelCountdown.Visible = true;
            labelCountdown.Text = "3";
            timerCountdown.Start();
        }

        private void timerPulse_Tick(object sender, EventArgs e)
        {
            int delta = pulse ? 1 : -1;

            btnStart.Width += delta;
            btnStart.Height += delta;
            btnStart.Left -= delta / 2;
            btnStart.Top -= delta / 2;

            if (btnStart.Width > startBtnSize.Width + 5)
                pulse = false;

            if (btnStart.Width < startBtnSize.Width)
                pulse = true;
        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            countdownValue--;

            if (countdownValue > 0)
            {
                labelCountdown.Text = countdownValue.ToString();

                if (countdownValue == 2) labelCountdown.ForeColor = Color.Yellow;
                if (countdownValue == 1) labelCountdown.ForeColor = Color.Orange;
            }
            else if (countdownValue == 0)
            {
                labelCountdown.Text = "ВПЕРЁД!";
                labelCountdown.ForeColor = Color.Lime;
            }
            else
            {
                // Конец отсчёта
                timerCountdown.Stop();
                labelCountdown.Visible = false;

                StartGame();
            }
        }
    }
}