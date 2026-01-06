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
        private int bossHP = 100;
        private int bossMaxHP = 100;
        private bool bossIntro = false;
        private bool bossFight = false;
        private bool bossActive = false;
        private bool bossCharging = false;
        private bool itemCollected = false;
        private bool itemReturning = false;
        private int bossChargeCooldown = 0;
        private int bossSpeed = 4;
        private Point bossStartPos;
        private int itemSpeed = 8;
        private int itemDropTimer = 0;
        private bool canSpawnItem = true;


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

        enum BossState
        {
            Entering,
            Idle,
            Charging,
            Returning
        }

        BossState bossState;

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
            if (bossIntro || bossFight)
                return;
            coin.Top = -50;
            coin.Left = rand.Next(150, 560);
            coin.Visible = true;
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

            coin.Visible = false;
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

            if (level >= 2 && !bossActive && !bossFight)
            {
                bossIntro = true;
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

            // Сброс переменных
            lose = false;
            countCoins = 0;
            lives = 3;
            level = 1;
            isInvulnerable = false;
            invulnerabilityTimer = 0;

            // Сброс босса
            bossFight = false;
            bossActive = false;
            bossIntro = false;

            bossHP = bossMaxHP;
            boss.Top = -190;

            // Сброс скорости таймера
            timer.Interval = 15;

            // Сброс UI элементов
            labelLose.Visible = false;
            btnRestart.Visible = false;
            healthItem.Visible = false;
            boss.Visible = false;
            HPpanel.Visible = false;

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

            // Движение фона
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

            if (coin.Visible)
            {
                coin.Top += bgSpeed;
            }


            // Восстановление объектов за пределами экрана
            if (!bossIntro && !bossFight)
            {
                if (!coin.Visible || coin.Top >= 650)
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
            }

            // Проверка столкновений с врагами
            CheckCollisions();


            // Проверка сбора монеты
            if (!bossIntro && !bossFight && coin.Visible &&
                player.Bounds.IntersectsWith(coin.Bounds))
            {
                CollectCoin();
            }


            if (!healthItem.Visible && lives < 3)
            {
                SpawnHealth();
            }

            if (healthItem.Visible)
            {
                healthItem.Top += 2;

                // подбор
                if (player.Bounds.IntersectsWith(healthItem.Bounds))
                {
                    lives++;
                    if (lives > 3) lives = 3;

                    UpdateLivesDisplay();
                    healthItem.Visible = false;
                }

                // ушла за экран
                if (healthItem.Top >= 650)
                {
                    healthItem.Visible = false;
                }    
            }

            if (bossIntro &&
                enemy1.Top > 650 &&
                enemy2.Top > 650)
            {
                bossIntro = false;
                StartBossFight();
            }

            if (bossFight && bossActive)
            {
                // Проверка на столкновение с игроком всегда
                if (player.Bounds.IntersectsWith(boss.Bounds) && !isInvulnerable)
                {
                    HandleCollision();
                }

                switch (bossState)
                {
                    case BossState.Entering:
                        boss.Top += bossSpeed;

                        if (boss.Top >= bossStartPos.Y)
                        {
                            boss.Top = bossStartPos.Y;
                            bossState = BossState.Idle;
                            bossChargeCooldown = 0;
                        }
                        break;

                    case BossState.Idle:
                        bossChargeCooldown++;

                        int bossCenter = boss.Left + boss.Width / 2;
                        int playerCenter = player.Left + player.Width / 2;

                        if (playerCenter > bossCenter + 5)
                            boss.Left += 2;
                        else if (playerCenter < bossCenter - 5)
                            boss.Left -= 2;

                        if (bossChargeCooldown > 120)
                        {
                            bossState = BossState.Charging;
                            bossChargeCooldown = 0;
                        }
                        break;

                    case BossState.Charging:
                        boss.Top += bossSpeed * 2;

                        if (boss.Top > 650)
                        {
                            bossState = BossState.Returning;
                        }
                        break;

                    case BossState.Returning:
                        boss.Top -= bossSpeed;

                        if (boss.Top <= bossStartPos.Y)
                        {
                            boss.Top = bossStartPos.Y;
                            bossState = BossState.Idle;
                        }
                        break;
                }
            }

            // Спавн снаряда босса
            if (bossFight && bossActive && bossState == BossState.Idle)
            {
                itemDropTimer++;

                // Спавн только если снаряд не активен
                if (itemDropTimer > 150 && !bossItem.Visible && !itemReturning)
                {
                    DropBossItem();
                    itemDropTimer = 0;
                }
            }

            // Движение снаряда
            if (bossItem.Visible || itemReturning)
            {
                if (!itemCollected)
                {
                    bossItem.Top += 4;

                    // игрок собрал снаряд
                    if (player.Bounds.IntersectsWith(bossItem.Bounds))
                    {
                        itemCollected = true;
                        itemReturning = true;
                    }

                    // снаряд упал за экран — возвращаем к боссу
                    if (bossItem.Top > 650 && !itemCollected)
                    {
                        bossItem.Visible = false;
                        itemReturning = false;
                        itemCollected = false;
                        itemDropTimer = 0;
                    }
                }
                else if (itemReturning)
                {
                    Vector2 itemPos = new Vector2(bossItem.Left, bossItem.Top);
                    Vector2 bossPos = new Vector2(boss.Left + boss.Width / 2 - bossItem.Width / 2, boss.Top + boss.Height / 2);
                    Vector2 direction = bossPos - itemPos;

                    float length = direction.Length();
                    if (length > 0)
                        direction /= length;

                    bossItem.Left += (int)(direction.X * itemSpeed);
                    bossItem.Top += (int)(direction.Y * itemSpeed);

                    // снаряд вернулся к боссу
                    if (boss.Bounds.IntersectsWith(bossItem.Bounds))
                    {
                        bossHP -= 50;
                        bossItem.Visible = false;
                        itemReturning = false;
                        itemCollected = false;
                        itemDropTimer = 0;
                    }
                }
            }

            if (bossFight)
            {
                UpdateBossHP();

                if (bossHP <= 0)
                    KillBoss();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (labelCountdown.Visible) return;
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
            StartCountdown();
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
            gameState = GameState.Playing;

            StartCountdown();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            StartCountdown();
        }

        private void StartCountdown()
        {
            countdownValue = 3;
            labelCountdown.Text = countdownValue.ToString();
            labelCountdown.Visible = true;
            timerCountdown.Start();
        }

        private void timerPulse_Tick(object sender, EventArgs e)
        {
            int delta = pulse ? 1 : -1;

            btnStart.Width += delta * 2;
            btnStart.Height += delta * 2;
            btnStart.Left -= delta;
            btnStart.Top -= delta;

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
            }
            else
            {
                // Конец отсчёта
                timerCountdown.Stop();

                labelCountdown.Visible = false;

                timer.Start();
            }
        }

        private void StartBossFight()
        {
            bossFight = true;
            bossActive = true;

            boss.Visible = true;
            HPpanel.Visible = true;

            bossStartPos = new Point(boss.Left, 50);
            bossState = BossState.Entering;

            UpdateBossHP();
        }

        private void UpdateBossHP()
        {
            int maxWidth = 300;
            int hpWidth = (int)((float)bossHP / bossMaxHP * maxWidth);
            HPpanel.Width = Math.Max(0, hpWidth);

            if (bossHP < bossMaxHP * 0.3f)
                HPpanel.BackColor = Color.Red;
            else if (bossHP < bossMaxHP * 0.6f)
                HPpanel.BackColor = Color.Orange;
        }

        private void KillBoss()
        {
            bossActive = false;
            bossFight = false;
            HPpanel.Visible = false;
            boss.Visible = false;
            bossItem.Visible = false;

            timer.Stop();

            labelLose.Text = "ВЫ ПОБЕДИЛИ!";
            labelLose.BackColor = Color.Green;
            labelLose.Visible = true;

            btnRestart.Visible = true;
        }

        private void DropBossItem()
        {

            bossItem.Left = boss.Left + boss.Width / 2 - bossItem.Width / 2;
            bossItem.Top = boss.Top + boss.Height;
            bossItem.Visible = true; 

            itemCollected = false;
            itemReturning = false;
        }

        private void SpawnHealth()
        {
            // если уже есть или жизней максимум — не спавним
            if (healthItem.Visible || lives >= 3)
                return;

            healthItem.Left = rand.Next(150, 560);
            healthItem.Top = -1000;
            healthItem.Visible = true;

        }
    }
}