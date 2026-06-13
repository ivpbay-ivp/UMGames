using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UM;

namespace UM
{
    public partial class Form1 : Form
    {
        private GameManager gameManager;
        private int currentTrackIndex = 0;
        private bool isWaitingForAnswer = false;
        private int lastPressedPlayer = -1;
        private int currentScoreCounter = 0;
        private string currentTheme = "";
        private string currentGameFolder = "";  // ДОБАВЬТЕ ЭТУ СТРОКУ
        private ViewerForm viewerForm;

        public Form1()
        {
            InitializeComponent();
            gameManager = new GameManager();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.Load += Form1_Load;
            LoadGamesList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameManager.TrackEnded += GameManager_TrackEnded;
            btnOpenFolder.Click += BtnOpenFolder_Click;
            btnRefreshGames.Click += BtnRefreshGames_Click;
            cmbGameFolder.SelectedIndexChanged += CmbGameFolder_SelectedIndexChanged;
            btnStartFirstTour.Click += BtnStartFirstTour_Click;
            btnStartSecondTour.Click += BtnStartSecondTour_Click;
            btnPlayTrack.Click += BtnPlayTrack_Click;
            btnScore.Click += BtnScore_Click;
            btnNotScore.Click += BtnNotScore_Click;
            btnResumeMusic.Click += BtnResumeMusic_Click;
            btnSaveScore.Click += BtnSaveScore_Click;
            btnSettings.Click += BtnSettings_Click;
            gameTimer.Tick += GameTimer_Tick;
            this.btnAdd1.Click += (s, ev) => SubtractPoints(0);
            this.btnAdd2.Click += (s, ev) => SubtractPoints(1);
            this.btnAdd3.Click += (s, ev) => SubtractPoints(2);
            this.btnAdd4.Click += (s, ev) => SubtractPoints(3);
            numAdd1.KeyPress += numAdd_KeyPress;
            numAdd2.KeyPress += numAdd_KeyPress;
            numAdd3.KeyPress += numAdd_KeyPress;
            numAdd4.KeyPress += numAdd_KeyPress;
            // Кнопки блокировки
            this.btnBlock1.Click += (s, ev) => BlockPlayer(0);
            this.btnBlock2.Click += (s, ev) => BlockPlayer(1);
            this.btnBlock3.Click += (s, ev) => BlockPlayer(2);
            this.btnBlock4.Click += (s, ev) => BlockPlayer(3);

            // Кнопки разблокировки
            this.btnUnblock1.Click += (s, ev) => UnblockPlayer(0);
            this.btnUnblock2.Click += (s, ev) => UnblockPlayer(1);
            this.btnUnblock3.Click += (s, ev) => UnblockPlayer(2);
            this.btnUnblock4.Click += (s, ev) => UnblockPlayer(3);

            numAdd1.Minimum = -10000;
            numAdd1.Maximum = 10000;
            numAdd2.Minimum = -10000;
            numAdd2.Maximum = 10000;
            numAdd3.Minimum = -10000;
            numAdd3.Maximum = 10000;
            numAdd4.Minimum = -10000;
            numAdd4.Maximum = 10000;
        }

        private void BtnPlayTrack_Click(object sender, EventArgs e)
        {
            if (currentTrackIndex >= gameManager.GetTotalTracksCount())
            {
                MessageBox.Show("Все треки сыграны!");
                return;
            }

            // ВЫЧИТАЕМ СЧЁТЧИКИ ШТРАФНЫХ ТРЕКОВ
            var players = gameManager.GetPlayers();
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].BlockedRemaining > 0)
                {
                    players[i].BlockedRemaining--;
                    if (players[i].BlockedRemaining == 0)
                    {
                        players[i].IsBlocked = false;
                    }
                }
            }
            UpdateScoresDisplay();

            lastPressedPlayer = -1;
            isWaitingForAnswer = true;
            btnResumeMusic.Enabled = false;
            var trackInfo = gameManager.GetCurrentTrackInfo(currentTrackIndex);

            if (gameManager.CurrentTour == 1 && trackInfo != null)
            {
                // Для 1 тура показываем очки за вопрос
                lblCounter.Text = $"РАЗЫГРЫВАЕТСЯ: {trackInfo.Points} ОЧКОВ";
            }
            else if (gameManager.CurrentTour == 2 && trackInfo != null)
            {
                if (trackInfo.Theme != currentTheme)
                {
                    currentTheme = trackInfo.Theme;
                    currentScoreCounter = gameManager.GetCounterStartValue();
                }
                lblCounter.Text = $"СЧЁТЧИК: {currentScoreCounter} | ТЕМА: {currentTheme}";
            }

            gameManager.PlayTrack(currentTrackIndex);
            if (gameManager.CurrentTour == 2) gameTimer.Start();

            lblStatus.Text = "Музыка играет...";
            btnPlayTrack.Enabled = false;

            if (trackInfo != null)
                lblCurrentTrack.Text = $"{trackInfo.Theme} - вопрос {trackInfo.QuestionNumber}";

            UpdateViewerStatus();
            if (viewerForm != null && !viewerForm.IsDisposed)
            {
                viewerForm.ResetIndicators();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isWaitingForAnswer || lastPressedPlayer != -1) return;

            // Получаем индекс игрока (0,1,2,3) или -1
            int idx = gameManager.CheckButtonPress(e.KeyCode);
            if (idx == -1) return;

            // Проверяем блокировку
            var players = gameManager.GetPlayers();
            if (players[idx].IsBlocked)
            {
                lblStatus.Text = $"{players[idx].Name} ЗАБЛОКИРОВАН!";
                return;  // Выходим, музыку не останавливаем
            }

            // ТОЛЬКО ТЕПЕРЬ ставим музыку на паузу
            gameManager.PauseMusic();

            gameTimer.Stop();
            lastPressedPlayer = idx;
            lblStatus.Text = $"{players[idx].Name} нажал!";
            btnResumeMusic.Enabled = true;

            if (viewerForm != null && !viewerForm.IsDisposed)
            {
                viewerForm.HighlightPressedPlayer(idx, true);  // true - включить
            }

            e.Handled = true;
        }

        private void BtnScore_Click(object sender, EventArgs e)
        {
            if (lastPressedPlayer == -1)
            {
                lblStatus.Text = "Нет нажавшего игрока!";
                return;
            }

            var players = gameManager.GetPlayers();
            if (lastPressedPlayer >= players.Count) return;

            int points = gameManager.CurrentTour == 1 ?
                gameManager.GetCurrentTrackPoints(currentTrackIndex) : currentScoreCounter;

            gameManager.AddPoints(players[lastPressedPlayer].Name, points);
            gameManager.StopMusic();

            isWaitingForAnswer = false;
            currentTrackIndex++;
            btnPlayTrack.Enabled = true;
            lastPressedPlayer = -1;
            btnResumeMusic.Enabled = false;
            UpdateScoresDisplay();



            // Сбрасываем отображение очков
            if (gameManager.CurrentTour == 1)
                lblCounter.Text = "1 ТУР";
            if (viewerForm != null && !viewerForm.IsDisposed)
            {
                viewerForm.HighlightPressedPlayer(lastPressedPlayer, false);  // false - выключить
            }
            UpdateViewerStatus();
        }

        private void BtnNotScore_Click(object sender, EventArgs e)
        {
            if (lastPressedPlayer == -1) return;

            var players = gameManager.GetPlayers();
            gameManager.PenalizePlayer(players[lastPressedPlayer].Name);

            // НЕ снимаем блокировку здесь
            UpdateScoresDisplay();

            lastPressedPlayer = -1;
            btnResumeMusic.Enabled = true;
            lblStatus.Text = $"❌ Штраф. Можно продолжить музыку";
            if (viewerForm != null && !viewerForm.IsDisposed)
            {
                viewerForm.HighlightPressedPlayer(lastPressedPlayer, false);
            }
            UpdateViewerStatus();
        }

        private void BtnResumeMusic_Click(object sender, EventArgs e)
        {
            gameManager.ResumeMusic();
            if (gameManager.CurrentTour == 2) gameTimer.Start();

            lastPressedPlayer = -1;
            btnResumeMusic.Enabled = false;
            isWaitingForAnswer = true;  // Продолжаем ждать нажатия
            lblStatus.Text = "Музыка продолжена, ждём нажатия";
            if (viewerForm != null && !viewerForm.IsDisposed)
            {
                viewerForm.ResetIndicators();
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameManager.CurrentTour == 2 && gameManager.IsMusicPlaying())
            {
                currentScoreCounter++;
                var trackInfo = gameManager.GetCurrentTrackInfo(currentTrackIndex);
                if (trackInfo != null)
                {
                    lblCounter.Text = $"СЧЁТЧИК: {currentScoreCounter} | ТЕМА: {trackInfo.Theme}";
                }
            }
        }

        private void LoadGamesList()
        {
            cmbGameFolder.Items.Clear();
            if (!Directory.Exists("games"))
                Directory.CreateDirectory("games");
            foreach (var game in Directory.GetDirectories("games"))
                cmbGameFolder.Items.Add(Path.GetFileName(game));
        }

        private void UpdateScoresDisplay()
        {
            var players = gameManager.GetPlayers();
            var scores = new Label[] { lblScore1, lblScore2, lblScore3, lblScore4 };
            var penalties = new Label[] { lblPenalty1, lblPenalty2, lblPenalty3, lblPenalty4 };
            var blockButtons = new Button[] { btnBlock1, btnBlock2, btnBlock3, btnBlock4 };

            for (int i = 0; i < players.Count && i < scores.Length; i++)
            {
                scores[i].Text = players[i].Score.ToString();

                if (players[i].IsBlocked)
                {
                    penalties[i].Text = $"Блок: {players[i].BlockedRemaining}";
                    penalties[i].ForeColor = Color.Red;
                    blockButtons[i].BackColor = Color.DarkOrange;
                    blockButtons[i].Text = "Заблок";
                }
                else
                {
                    penalties[i].Text = "Блок: 0";
                    penalties[i].ForeColor = Color.Gray;
                    blockButtons[i].BackColor = Color.Orange;
                    blockButtons[i].Text = "Блок";
                }
            }
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentGameFolder = dialog.SelectedPath;
                    if (gameManager.LoadGame(currentGameFolder))
                    {
                        btnStartFirstTour.Enabled = true;
                        btnStartSecondTour.Enabled = true;
                        lblStatus.Text = $"Игра: {Path.GetFileName(currentGameFolder)}";

                        // ========== ЗДЕСЬ СОЗДАЮТСЯ ИГРОКИ ==========
                        // Очищаем старых
                        gameManager.GetPlayers().Clear();

                        // Добавляем игроков с именами из lblPlayer (с главной формы)
                        gameManager.AddPlayer(lblPlayer1.Text);
                        gameManager.AddPlayer(lblPlayer2.Text);
                        gameManager.AddPlayer(lblPlayer3.Text);
                        gameManager.AddPlayer(lblPlayer4.Text);
                        // ===========================================

                        UpdateScoresDisplay();
                    }
                }
            }
            if (viewerForm != null && !viewerForm.IsDisposed)
            {
                string[] names = new string[]
                {
        lblPlayer1.Text,
        lblPlayer2.Text,
        lblPlayer3.Text,
        lblPlayer4.Text
                };
                viewerForm.UpdatePlayerNames(names);
            }
        }

        private void BtnRefreshGames_Click(object sender, EventArgs e) => LoadGamesList();
        private void CmbGameFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGameFolder.SelectedItem != null)
            {
                currentGameFolder = Path.Combine("games", cmbGameFolder.SelectedItem.ToString());
                gameManager.LoadGame(currentGameFolder);
                btnStartFirstTour.Enabled = true;
                btnStartSecondTour.Enabled = true;
                lblStatus.Text = $"Игра: {cmbGameFolder.SelectedItem}";

                // ========== ЗДЕСЬ ТОЖЕ СОЗДАЮТСЯ ИГРОКИ ==========
                gameManager.GetPlayers().Clear();
                gameManager.AddPlayer(lblPlayer1.Text);
                gameManager.AddPlayer(lblPlayer2.Text);
                gameManager.AddPlayer(lblPlayer3.Text);
                gameManager.AddPlayer(lblPlayer4.Text);
                // =================================================

                UpdateScoresDisplay();
            }
            if (viewerForm != null && !viewerForm.IsDisposed)
            {
                string[] names = new string[]
                {
        lblPlayer1.Text.Split('[')[0].Trim(),
        lblPlayer2.Text.Split('[')[0].Trim(),
        lblPlayer3.Text.Split('[')[0].Trim(),
        lblPlayer4.Text.Split('[')[0].Trim()
                };
                viewerForm.UpdatePlayerNames(names);
            }
        }

        private void BtnStartFirstTour_Click(object sender, EventArgs e)
        {
            gameManager.StartTour(1);
            currentTrackIndex = 0;
            btnPlayTrack.Enabled = true;
            lblCounter.Text = "1 ТУР";
            SyncPlayersFromForm();
        }

        private void BtnStartSecondTour_Click(object sender, EventArgs e)
        {
            gameManager.StartTour(2);
            currentTrackIndex = 0;
            currentScoreCounter = gameManager.GetCounterStartValue();
            currentTheme = "";
            btnPlayTrack.Enabled = true;
            lblCounter.Text = $"СЧЁТЧИК: {currentScoreCounter}";
            SyncPlayersFromForm();
        }







        private void GameManager_TrackEnded(object sender, EventArgs e)
        {
            if (lastPressedPlayer != -1) return;
            if (!isWaitingForAnswer) return;

            try
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            if (this.IsDisposed) return;

                            gameTimer.Stop();
                            isWaitingForAnswer = false;
                            btnPlayTrack.Enabled = true;
                            btnResumeMusic.Enabled = false;
                            currentTrackIndex++;
                            lastPressedPlayer = -1;
                            lblStatus.Text = "Песня закончилась, никто не нажал";

                            if (gameManager.CurrentTour == 1)
                                lblCounter.Text = "1 ТУР";

                            UpdateViewerStatus();
                        }
                        catch { }
                    }));
                }
            }
            catch { }
            if (viewerForm != null && !viewerForm.IsDisposed)
            {
                viewerForm.ResetIndicators();
            }
        }
 
        private void BtnSaveScore_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog() { Filter = "txt|*.txt" })
                if (dlg.ShowDialog() == DialogResult.OK)
                    gameManager.SaveScoreToFile(dlg.FileName);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var frm = new SettingsForm(gameManager.Settings);
            if (frm.ShowDialog() == DialogResult.OK)
                gameManager.UpdateSettings(frm.UpdatedSettings);
        }

        protected override void OnFormClosing(FormClosingEventArgs e) { gameManager.Dispose(); base.OnFormClosing(e); }


        private void BtnFinishTrack_Click(object sender, EventArgs e)
        {
            gameManager.StopMusic();
            isWaitingForAnswer = false;
            currentTrackIndex++;
            btnPlayTrack.Enabled = true;
            btnResumeMusic.Enabled = false;
            lastPressedPlayer = -1;
            lblStatus.Text = "Трек завершён";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (viewerForm == null || viewerForm.IsDisposed)
            {
                viewerForm = new ViewerForm(gameManager);
                viewerForm.Show();
            }
            else
            {
                viewerForm.BringToFront();
            }
        }
        private void UpdateViewerStatus()
        {
            if (viewerForm != null && !viewerForm.IsDisposed)
            {
                string counterText = gameManager.CurrentTour == 2 ? $"Счётчик: {currentScoreCounter}" : "1 ТУР";
                viewerForm.UpdateStatus(lblStatus.Text, lblCurrentTrack.Text, counterText);
            }
        }

        private void SyncPlayersFromForm()
        {
            var players = gameManager.GetPlayers();

            if (players.Count >= 1) players[0].Name = lblPlayer1.Text;
            if (players.Count >= 2) players[1].Name = lblPlayer2.Text;
            if (players.Count >= 3) players[2].Name = lblPlayer3.Text;
            if (players.Count >= 4) players[3].Name = lblPlayer4.Text;

            UpdateScoresDisplay();
            UpdateViewerStatus();
        }

        private void btnUpdatePlayerName_Click(object sender, EventArgs e)
        {
            var players = gameManager.GetPlayers();
            if (players.Count >= 4)
            {
                players[0].Name = lblPlayer1.Text;
                players[1].Name = lblPlayer2.Text;
                players[2].Name = lblPlayer3.Text;
                players[3].Name = lblPlayer4.Text;
                UpdateScoresDisplay();

                if (viewerForm != null && !viewerForm.IsDisposed)
                {
                    string[] names = new string[] { lblPlayer1.Text, lblPlayer2.Text, lblPlayer3.Text, lblPlayer4.Text };
                    viewerForm.UpdatePlayerNames(names);
                }
            }
        }

        private void btnResetScores_Click(object sender, EventArgs e)
        {
            var players = gameManager.GetPlayers();
            foreach (var player in players)
            {
                player.Score = 0;
                player.IsBlocked = false;        // Снимаем блокировку
                player.BlockedRemaining = 0;     // Обнуляем счётчик блокировки
            }
            lblPlayer1.Text = "1";
            lblPlayer2.Text = "2";
            lblPlayer3.Text = "3";
            lblPlayer4.Text = "4";
            UpdateScoresDisplay();
            UpdateViewerStatus();
            lblStatus.Text = "Все очки сброшены!";
        }
        private void SubtractPoints(int playerIndex)
        {
            var players = gameManager.GetPlayers();
            if (playerIndex < players.Count)
            {
                int points = 0;
                switch (playerIndex)
                {
                    case 0: points = (int)numAdd1.Value; break;
                    case 1: points = (int)numAdd2.Value; break;
                    case 2: points = (int)numAdd3.Value; break;
                    case 3: points = (int)numAdd4.Value; break;
                }

                // Прямо добавляем число (оно может быть отрицательным)
                players[playerIndex].Score += points;

                // Защита от отрицательного счёта (если не хотим уходить в минус)
                if (players[playerIndex].Score < 0)
                    players[playerIndex].Score = 0;

                UpdateScoresDisplay();
                UpdateViewerStatus();

                string action = points >= 0 ? "добавлено" : "вычтено";
                lblStatus.Text = $"{players[playerIndex].Name} {action} {Math.Abs(points)} очков!";
            }
        }
        private void numAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод минуса
            if (e.KeyChar == '-')
            {
                NumericUpDown num = (NumericUpDown)sender;
                if (num.Value >= 0)
                {
                    num.Value = -num.Value;
                }
                e.Handled = true;
            }
        }
        private void BlockPlayer(int playerIndex)
        {
            var players = gameManager.GetPlayers();
            if (playerIndex < players.Count)
            {
                players[playerIndex].IsBlocked = true;
                players[playerIndex].BlockedRemaining = 3;
                UpdateScoresDisplay();
                lblStatus.Text = $"{players[playerIndex].Name} заблокирован на 2 песни!";

                if (lastPressedPlayer == playerIndex)
                {
                    lastPressedPlayer = -1;
                }
            }
        }

        private void UnblockPlayer(int playerIndex)
        {
            var players = gameManager.GetPlayers();
            if (playerIndex < players.Count)
            {
                players[playerIndex].IsBlocked = false;
                players[playerIndex].BlockedRemaining = 0;
                UpdateScoresDisplay();
                lblStatus.Text = $"{players[playerIndex].Name} разблокирован!";
            }
        }

        private void btnSuperGame_Click(object sender, EventArgs e)
        {

            var superGame = new SuperGameForm(gameManager);
            superGame.ShowDialog();
            UpdateScoresDisplay();
            UpdateViewerStatus();
        }
    }

}