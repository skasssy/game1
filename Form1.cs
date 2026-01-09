using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        private Point pos;
        private bool dragging;

        private bool lose = false, pulse = true;
        private int countdownValue = 3;

        private int countCoins = 0;
        private int lives = 3;
        private int level = 1;
        private int highScore = 0;

        private int invulnerabilityTimer = 0;
        private bool isInvulnerable = false;

        private Random rand = new Random();
        private readonly int[] spawnPointsX = { 220, 340, 470, 600 };
        private readonly int[] leftSpawnPoints = { 190, 320 };
        private readonly int[] rightSpawnPoints = { 440, 570 };

        private int bossHP = 100;
        private int bossMaxHP = 100;
        private int bossLevel = 3;
        private int bossSpeed = 4;
        private int bossChargeCooldown = 0;
        private bool bossIntro = false;
        private bool bossFight = false;
        private bool bossActive = false;
        private Point bossStartPos;

        private int itemSpeed = 8;
        private int itemDropTimer = 0;
        private bool itemCollected = false;
        private bool itemReturning = false;

        private int bossHitTimer = 0;
        private int bossHitOffsetX = 0;
        private bool bossHitAnim = false;

        private int bossDeathTimer = 0;
        private bool bossDeathAnim = false;

        private Size startBtnSize;

        public Form1()
        {
            InitializeComponent();

            // Перетаскивание окна
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
                this.Close(); // Закрытие окна по клавише esc
            else if (e.KeyChar == 'p' || e.KeyChar == 'P')
                TogglePause(); // Пауза по клавише P
        }

        // Включение и выключение паузы
        private void TogglePause()
        {
            timer.Enabled = !timer.Enabled;
            if (Controls.ContainsKey("labelPause"))
            {
                labelPause.Visible = !timer.Enabled;
            }
        }

        // Проверка на выход из окна объектами
        private bool OutOfScreen(Control obj)
        {
            return obj.Top >= 650;
        }

        // Движение объектов на экране
        private void MoveObj(Control obj, int speed)
        {
            if (obj.Visible)
                obj.Top += speed;
        }

        // Рандомное появление объектов по оси X
        private int GetLeftLaneSpawn()
        {
            return leftSpawnPoints[rand.Next(leftSpawnPoints.Length)];
        }

        private int GetRightLaneSpawn()
        {
            return rightSpawnPoints[rand.Next(rightSpawnPoints.Length)];
        }

        private int GetRandomSpawnPoint()
        {
            return spawnPointsX[rand.Next(spawnPointsX.Length)];
        }

        // Сброс объектов
        private void ResetCoin()
        {
            coin.Left = GetRandomSpawnPoint();
            coin.Top = -50;
            coin.Visible = true;
        }

        private void ResetEnemy(PictureBox enemy, bool isLeftEnemy)
        {
            enemy.Left = isLeftEnemy ? GetLeftLaneSpawn() : GetRightLaneSpawn();
            enemy.Top = -rand.Next(100, 400);
        }


        private void ResetHealth()
        {
            if (health.Visible || lives >= 3)
                return;

            health.Left = GetRandomSpawnPoint();
            health.Top = -1000;
            health.Visible = true;
        }

        // Проверка на столкновение с врагами
        private void CheckCollisions()
        {
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
                // Включение неуязвимости игрока
                isInvulnerable = true;
                invulnerabilityTimer = 100;
            }
        }

        // Сбор монет
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

        // Переход на новый уровень или на уровень с боссом
        private void CheckLevelUp()
        {
            int newLevel = 1 + (countCoins / 3); // Новый уровень каждые 3 монеты

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

            if (level >= bossLevel && !bossActive && !bossFight)
            {
                bossIntro = true;
            }
        }

        // Обновление количества жизней
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

        // Проигрыш
        private void GameOver()
        {
            timer.Stop();

            labelLose.Text = "ВЫ ПРОИГРАЛИ!";
            labelLose.BackColor = Color.Red;

            labelLose.Visible = true;
            btnRestart.Visible = true;
            lose = true;
        }

        // Перезапуск
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
            boss.Left = (this.Width - boss.Width) / 2;
            boss.Top = -190;

            // Сброс скорости таймера
            timer.Interval = 15;

            // Сброс UI элементов
            labelLose.Visible = false;
            btnRestart.Visible = false;
            health.Visible = false;
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

            // Анимация смерти босса
            if (bossDeathAnim)
            {
                bossDeathTimer--;

                // Дрожание босса
                boss.Left = bossStartPos.X + rand.Next(-10, 11);
                boss.Top += rand.Next(-5, 6);

                // Мигание
                boss.Visible = bossDeathTimer % 4 != 0;

                if (bossDeathTimer <= 0)
                {
                    bossDeathAnim = false;
                    boss.Visible = false;

                    timer.Stop();

                    labelLose.Text = "ВЫ ПОБЕДИЛИ!";
                    labelLose.BackColor = Color.Green;
                    labelLose.Visible = true;
                    btnRestart.Visible = true;
                }

                return;
            }

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
            MoveObj(bg1, bgSpeed);
            MoveObj(bg2, bgSpeed);

            if (OutOfScreen(bg1))
            {
                bg1.Top = 0;
                bg2.Top = -650;
            }

            // Движение врагов
            MoveObj(enemy1, enemySpeed);
            MoveObj(enemy2, enemySpeed);

            // Восстановление объектов за пределами экрана
            if (!bossIntro && !bossFight)
            {
                if (OutOfScreen(enemy1)) ResetEnemy(enemy1, true);
                if (OutOfScreen(enemy2)) ResetEnemy(enemy2, false);

                if (!coin.Visible || OutOfScreen(coin))
                    ResetCoin();

                if (!health.Visible && lives < 3)
                    ResetHealth();
            }

            // Проверка столкновений с врагами
            CheckCollisions();


            // Проверка сбора монеты
            if (coin.Visible)
            {
                MoveObj(coin, bgSpeed);

                // подбор
                if (!bossIntro && !bossFight &&
                player.Bounds.IntersectsWith(coin.Bounds))
                    CollectCoin();
            }

            // Проверка сбора здоровья
            if (health.Visible)
            {
                MoveObj(health, bgSpeed);

                // подбор
                if (player.Bounds.IntersectsWith(health.Bounds))
                {
                    lives++;
                    if (lives > 3) lives = 3;

                    UpdateLivesDisplay();
                    health.Visible = false;
                }
            }

            if (bossIntro &&
                OutOfScreen(enemy1) &&
                OutOfScreen(enemy2))
            {
                bossIntro = false;
                StartBossFight();
            }

            if (bossFight && bossActive)
            {
                // Проверка на столкновение с игроком
                if (player.Bounds.IntersectsWith(boss.Bounds) && !isInvulnerable)
                {
                    HandleCollision();
                }

                switch (bossState)
                {
                    // Появление босса
                    case BossState.Entering:

                        MoveObj(boss, bossSpeed);

                        if (boss.Top >= bossStartPos.Y)
                        {
                            boss.Top = bossStartPos.Y;
                            bossState = BossState.Idle;
                            bossChargeCooldown = 0;
                        }
                        break;

                    // Слежка за игроком
                    case BossState.Idle:

                        // Увеличение счетчика атаки
                        bossChargeCooldown++;

                        int bossCenter = boss.Left + boss.Width / 2;
                        int playerCenter = player.Left + player.Width / 2;

                        if (playerCenter > bossCenter + 5)
                            bossStartPos.X += 2;
                        else if (playerCenter < bossCenter - 5)
                            bossStartPos.X -= 2;

                        if (bossChargeCooldown > 120)
                        {
                            bossState = BossState.Charging;
                            bossChargeCooldown = 0;
                        }
                        break;

                    // Нападение
                    case BossState.Charging:
                        MoveObj(boss, bossSpeed * 2);

                        if (OutOfScreen(boss))
                        {
                            bossState = BossState.Returning;
                        }
                        break;

                    // Возвращение на исходную точку
                    case BossState.Returning:
                        MoveObj(boss, -bossSpeed);

                        if (boss.Top <= bossStartPos.Y)
                        {
                            boss.Top = bossStartPos.Y;
                            bossState = BossState.Idle;
                        }
                        break;
                }
            }

            // Появление снаряда
            if (bossFight && bossActive && bossState == BossState.Idle)
            {
                itemDropTimer++;

                if (itemDropTimer > 150 && !bossItem.Visible && !itemReturning)
                {
                    DropBossItem();
                    itemDropTimer = 0;
                }
            }

            if (bossItem.Visible || itemReturning)
            {
                if (!itemCollected)
                {
                    MoveObj(bossItem, bgSpeed);

                    // Подбор снаряда игроком
                    if (player.Bounds.IntersectsWith(bossItem.Bounds))
                    {
                        itemCollected = true;
                        itemReturning = true;
                    }

                    // Снаряд не был пойман
                    if (OutOfScreen(bossItem) && !itemCollected)
                    {
                        itemReturning = false;
                        itemCollected = false;

                        bossItem.Visible = false;

                        itemDropTimer = 0;
                    }
                }
                // Снаряд возвращается к боссу
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

                    // Снаряд вернулся к боссу
                    if (boss.Bounds.IntersectsWith(bossItem.Bounds))
                    {
                        bossHP -= 25;

                        BossHit();

                        itemReturning = false;
                        itemCollected = false;

                        bossItem.Visible = false;

                        itemDropTimer = 0;
                    }
                }
            }

            if (bossHitAnim)
            {
                bossHitTimer--;

                // Дрожание 
                bossHitOffsetX = rand.Next(-4, 5);

                // Мигание через цвет
                boss.BackColor = bossHitTimer % 2 == 0 ? Color.DarkRed : Color.Transparent;

                if (bossHitTimer <= 0)
                {
                    bossHitAnim = false;
                    bossHitOffsetX = 0;
                    boss.BackColor = Color.Transparent;
                }
            }

            boss.Left = bossStartPos.X + bossHitOffsetX;

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

                // Основное управление игроком
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

        // Пульсация кнопки старта
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

        // Обратный отсчет перед началом игры
        private void StartCountdown()
        {
            countdownValue = 3;
            labelCountdown.Text = countdownValue.ToString();
            labelCountdown.Visible = true;
            timerCountdown.Start();
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

            boss.Left = (player.Parent.Width - boss.Width) / 2;
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

        private void BossHit()
        {
            bossHitAnim = true;
            bossHitTimer = 15;
        }

        private void KillBoss()
        {
            bossActive = false;
            bossFight = false;

            HPpanel.Visible = false;
            bossItem.Visible = false;

            bossDeathAnim = true;
            bossDeathTimer = 60;
            boss.BackColor = Color.OrangeRed;
        }

        private void DropBossItem()
        {

            bossItem.Left = boss.Left + boss.Width / 2 - bossItem.Width / 2;
            bossItem.Top = boss.Top + boss.Height;
            bossItem.Visible = true;

            itemCollected = false;
            itemReturning = false;
        }
    }
}