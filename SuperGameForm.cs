using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;

namespace UM
{
    public partial class SuperGameForm : Form
    {
        private GameManager gameManager;
        private List<string> songs;
        private int currentSongIndex = 0;
        private WaveOutEvent waveOutput;
        private AudioFileReader audioFileReader;
        private bool isPlaying = false;
        private long pausedPosition = 0;
        private bool isWaitingAnswer = false;
        private int lastPressedPlayer = -1;
        private string currentFolder = "";

        // Счётчики для каждого игрока в суперигре
        private int[] superScores;

        // Элементы управления
        private Label[] lblPlayerNames;
        private Label[] lblPlayerScores;
        private Label lblSongTitle;
        private Button btnPlay;
        private Button btnStop;
        private Button btnSuccess;
        private Button btnFail;
        private Button btnNext;
        private Button btnSelectFolder;
        private Label lblProgress;
        private ListBox listSongs;
        private Label lblStatus;
        private Label lblHint;
        private Label lblFolderPath;
        private Panel playersPanel;
        private System.Windows.Forms.Timer checkMusicTimer;

        public SuperGameForm(GameManager manager)
        {
            gameManager = manager;

            // Если игроков нет - создаём стандартных
            if (gameManager.GetPlayers().Count == 0)
            {
                gameManager.AddPlayer("Игрок1");
                gameManager.AddPlayer("Игрок2");
                gameManager.AddPlayer("Игрок3");
                gameManager.AddPlayer("Игрок4");
            }
            var players = gameManager.GetPlayers();
            superScores = new int[players.Count];  // Размер по количеству игроков
            InitializeComponents();
            this.KeyPreview = true;
            this.KeyDown += SuperGameForm_KeyDown;
        }

        private void InitializeComponents()
        {
            this.Text = "Суперигра - Все игроки";
            this.Size = new Size(800, 750);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            int y = 20;

            // Заголовок
            var lblTitle = new Label();
            lblTitle.Text = "🏆 СУПЕРИГРА 🏆";
            lblTitle.Location = new Point(250, y);
            lblTitle.Size = new Size(300, 40);
            lblTitle.ForeColor = Color.Gold;
            lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            y += 50;

            // Панель выбора папки
            var lblFolder = new Label();
            lblFolder.Text = "Папка с песнями:";
            lblFolder.Location = new Point(20, y);
            lblFolder.Size = new Size(120, 30);
            lblFolder.ForeColor = Color.White;

            lblFolderPath = new Label();
            lblFolderPath.Text = "Не выбрана";
            lblFolderPath.Location = new Point(150, y);
            lblFolderPath.Size = new Size(450, 30);
            lblFolderPath.ForeColor = Color.LightGray;
            lblFolderPath.BackColor = Color.FromArgb(50, 50, 50);

            btnSelectFolder = new Button();
            btnSelectFolder.Text = "📁 ВЫБРАТЬ ПАПКУ";
            btnSelectFolder.Location = new Point(610, y);
            btnSelectFolder.Size = new Size(150, 30);
            btnSelectFolder.BackColor = Color.LightBlue;
            btnSelectFolder.Font = new Font("Arial", 9, FontStyle.Bold);
            btnSelectFolder.Click += BtnSelectFolder_Click;

            y += 45;

            // Панель игроков (горизонтально)
            playersPanel = new Panel();
            playersPanel.Location = new Point(20, y);
            playersPanel.Size = new Size(740, 120);
            playersPanel.BackColor = Color.FromArgb(40, 40, 40);

            var players = gameManager.GetPlayers();
            lblPlayerNames = new Label[4];
            lblPlayerScores = new Label[4];

            int panelWidth = 170;
            int spacing = 10;
            int startX = 20;

            for (int i = 0; i < 4 && i < players.Count; i++)
            {
                int x = startX + i * (panelWidth + spacing);

                // Фон игрока
                var playerPanel = new Panel();
                playerPanel.Location = new Point(x, 10);
                playerPanel.Size = new Size(panelWidth, 100);
                playerPanel.BackColor = Color.FromArgb(50, 50, 50);
                playerPanel.BorderStyle = BorderStyle.FixedSingle;

                // Имя игрока
                lblPlayerNames[i] = new Label();
                lblPlayerNames[i].Text = players[i].Name;
                lblPlayerNames[i].Location = new Point(10, 10);
                lblPlayerNames[i].Size = new Size(150, 30);
                lblPlayerNames[i].ForeColor = GetPlayerColor(i);
                lblPlayerNames[i].Font = new Font("Arial", 12, FontStyle.Bold);
                lblPlayerNames[i].TextAlign = ContentAlignment.MiddleCenter;

                // Счёт в суперигре
                var lblScoreText = new Label();
                lblScoreText.Text = "Счёт:";
                lblScoreText.Location = new Point(10, 45);
                lblScoreText.Size = new Size(50, 25);
                lblScoreText.ForeColor = Color.White;
                lblScoreText.Font = new Font("Arial", 10);

                lblPlayerScores[i] = new Label();
                lblPlayerScores[i].Text = "0";
                lblPlayerScores[i].Location = new Point(60, 45);
                lblPlayerScores[i].Size = new Size(90, 25);
                lblPlayerScores[i].ForeColor = Color.LightGreen;
                lblPlayerScores[i].Font = new Font("Arial", 16, FontStyle.Bold);
                lblPlayerScores[i].TextAlign = ContentAlignment.MiddleRight;

                // Индикатор нажатия
                var indicator = new Panel();
                indicator.Location = new Point(10, 75);
                indicator.Size = new Size(150, 15);
                indicator.BackColor = Color.Gray;
                indicator.Tag = i;

                playerPanel.Controls.Add(lblPlayerNames[i]);
                playerPanel.Controls.Add(lblScoreText);
                playerPanel.Controls.Add(lblPlayerScores[i]);
                playerPanel.Controls.Add(indicator);
                playersPanel.Controls.Add(playerPanel);
            }

            y += 130;

            // Список песен
            var lblSongsList = new Label();
            lblSongsList.Text = "Песни в папке:";
            lblSongsList.Location = new Point(20, y);
            lblSongsList.Size = new Size(150, 25);
            lblSongsList.ForeColor = Color.White;

            listSongs = new ListBox();
            listSongs.Location = new Point(20, y + 30);
            listSongs.Size = new Size(250, 150);
            listSongs.Font = new Font("Arial", 10);
            listSongs.BackColor = Color.FromArgb(50, 50, 50);
            listSongs.ForeColor = Color.White;

            // Название текущей песни
            lblSongTitle = new Label();
            lblSongTitle.Location = new Point(300, y + 30);
            lblSongTitle.Size = new Size(450, 60);
            lblSongTitle.ForeColor = Color.Cyan;
            lblSongTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblSongTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSongTitle.Text = "Сначала выберите папку с песнями";

            y += 210;

            // Статус
            lblStatus = new Label();
            lblStatus.Location = new Point(20, y);
            lblStatus.Size = new Size(730, 30);
            lblStatus.ForeColor = Color.Yellow;
            lblStatus.Font = new Font("Arial", 12);
            lblStatus.Text = "Выберите папку с песнями для суперигры";

            y += 40;

            // Кнопки управления
            btnPlay = new Button();
            btnPlay.Text = "▶ ПРОИГРАТЬ";
            btnPlay.Location = new Point(20, y);
            btnPlay.Size = new Size(140, 45);
            btnPlay.BackColor = Color.Gold;
            btnPlay.Font = new Font("Arial", 11, FontStyle.Bold);
            btnPlay.Enabled = false;
            btnPlay.Click += BtnPlay_Click;

            btnStop = new Button();
            btnStop.Text = "⏹ СТОП";
            btnStop.Location = new Point(170, y);
            btnStop.Size = new Size(100, 45);
            btnStop.BackColor = Color.Orange;
            btnStop.Font = new Font("Arial", 11, FontStyle.Bold);
            btnStop.Enabled = false;
            btnStop.Click += BtnStop_Click;

            btnSuccess = new Button();
            btnSuccess.Text = "✓ ЗАСЧИТАТЬ";
            btnSuccess.Location = new Point(300, y);
            btnSuccess.Size = new Size(140, 45);
            btnSuccess.BackColor = Color.LightGreen;
            btnSuccess.Font = new Font("Arial", 11, FontStyle.Bold);
            btnSuccess.Enabled = false;
            btnSuccess.Click += BtnSuccess_Click;

            btnFail = new Button();
            btnFail.Text = "✗ НЕ ЗАСЧИТАТЬ";
            btnFail.Location = new Point(450, y);
            btnFail.Size = new Size(140, 45);
            btnFail.BackColor = Color.LightCoral;
            btnFail.Font = new Font("Arial", 11, FontStyle.Bold);
            btnFail.Enabled = false;
            btnFail.Click += BtnFail_Click;

            y += 55;

            btnNext = new Button();
            btnNext.Text = "СЛЕДУЮЩАЯ ПЕСНЯ →";
            btnNext.Location = new Point(20, y);
            btnNext.Size = new Size(250, 40);
            btnNext.BackColor = Color.LightBlue;
            btnNext.Font = new Font("Arial", 10, FontStyle.Bold);
            btnNext.Enabled = false;
            btnNext.Click += BtnNext_Click;

            lblHint = new Label();
            lblHint.Location = new Point(20, y + 50);
            lblHint.Size = new Size(730, 40);
            lblHint.ForeColor = Color.Gray;
            lblHint.Font = new Font("Arial", 9);
            lblHint.Text = "Правила: Выберите папку с песнями. Любой игрок может нажать кнопку. Ведущий решает - засчитать или нет. При засчитывании +1 очко в суперигру и основную игру.";

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblFolder);
            this.Controls.Add(lblFolderPath);
            this.Controls.Add(btnSelectFolder);
            this.Controls.Add(playersPanel);
            this.Controls.Add(lblSongsList);
            this.Controls.Add(listSongs);
            this.Controls.Add(lblSongTitle);
            this.Controls.Add(lblStatus);
            this.Controls.Add(btnPlay);
            this.Controls.Add(btnStop);
            this.Controls.Add(btnSuccess);
            this.Controls.Add(btnFail);
            this.Controls.Add(btnNext);
            this.Controls.Add(lblHint);

            waveOutput = new WaveOutEvent();



        // В конструкторе:
        checkMusicTimer = new System.Windows.Forms.Timer();
checkMusicTimer.Interval = 500;
checkMusicTimer.Tick += (s, ev) =>
{
    if (isWaitingAnswer && !isPlaying && lastPressedPlayer == -1)
    {
        checkMusicTimer.Stop();
        NextSong();
    }
};
        }

        private Color GetPlayerColor(int index)
        {
            Color[] colors = { Color.Red, Color.Blue, Color.Yellow, Color.Green };
            return colors[index % colors.Length];
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку с песнями для суперигры";
                dialog.ShowNewFolderButton = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentFolder = dialog.SelectedPath;
                    lblFolderPath.Text = currentFolder;
                    LoadSongsFromFolder();
                }
            }
        }

        private void LoadSongsFromFolder()
        {
            if (string.IsNullOrEmpty(currentFolder) || !Directory.Exists(currentFolder))
            {
                lblStatus.Text = "Папка не выбрана или не существует!";
                return;
            }

            songs = Directory.GetFiles(currentFolder, "*.mp3")
                .Concat(Directory.GetFiles(currentFolder, "*.wav"))
                .ToList();

            listSongs.Items.Clear();
            foreach (var song in songs)
            {
                listSongs.Items.Add(Path.GetFileNameWithoutExtension(song));
            }

            if (songs.Count == 0)
            {
                lblStatus.Text = "В выбранной папке нет MP3 или WAV файлов!";
                lblSongTitle.Text = "Нет песен";
                btnPlay.Enabled = false;
            }
            else
            {
                lblStatus.Text = $"Загружено {songs.Count} песен. Выберите песню и нажмите Проиграть.";
                btnPlay.Enabled = true;
                listSongs.SelectedIndex = 0;
                currentSongIndex = 0;
                lblSongTitle.Text = Path.GetFileNameWithoutExtension(songs[0]);
            }

            // Обновляем имена игроков
            var players = gameManager.GetPlayers();
            for (int i = 0; i < players.Count && i < 4; i++)
            {
                if (lblPlayerNames[i] != null)
                    lblPlayerNames[i].Text = players[i].Name;
            }

            listSongs.SelectedIndexChanged += (s, ev) =>
            {
                if (listSongs.SelectedIndex >= 0)
                {
                    currentSongIndex = listSongs.SelectedIndex;
                    lblSongTitle.Text = Path.GetFileNameWithoutExtension(songs[currentSongIndex]);
                }
            };
   

            // Пересоздаём массив супер-очков под актуальное количество игроков
            superScores = new int[players.Count];

            for (int i = 0; i < players.Count && i < 4; i++)
            {
                if (lblPlayerNames[i] != null)
                {
                    lblPlayerNames[i].Text = players[i].Name;
                    lblPlayerNames[i].Visible = true;
                    lblPlayerScores[i].Text = "0";
                    lblPlayerScores[i].Visible = true;
                }
            }

            // Скрываем панели лишних игроков
            for (int i = players.Count; i < 4; i++)
            {
                if (playersPanel.Controls.Count > i)
                {
                    playersPanel.Controls[i].Visible = false;
                }
            }
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            checkMusicTimer.Start();
            if (songs == null || songs.Count == 0 || currentSongIndex >= songs.Count)
            {
                lblStatus.Text = "Нет выбранной песни!";
                return;
            }

            try
            {
                StopMusic();
                audioFileReader = new AudioFileReader(songs[currentSongIndex]);
                waveOutput.Init(audioFileReader);
                waveOutput.Play();
                isPlaying = true;
                isWaitingAnswer = true;
                lastPressedPlayer = -1;

                btnPlay.Enabled = false;
                btnStop.Enabled = true;
                btnSuccess.Enabled = false;
                btnFail.Enabled = false;
                btnNext.Enabled = false;

                // Сбрасываем индикаторы
                ResetIndicators();

                lblStatus.Text = $"Играет: {Path.GetFileNameWithoutExtension(songs[currentSongIndex])}";
                lblStatus.ForeColor = Color.LightGreen;
                lblHint.Text = "Любой игрок может нажать кнопку на устройстве!";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void ResetIndicators()
        {
            foreach (Control panel in playersPanel.Controls)
            {
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is Panel && ctrl.Tag != null)
                    {
                        ctrl.BackColor = Color.Gray;
                    }
                }
            }
        }

        private void HighlightIndicator(int playerIndex)
        {
            int idx = 0;
            foreach (Control panel in playersPanel.Controls)
            {
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is Panel && ctrl.Tag != null && (int)ctrl.Tag == playerIndex)
                    {
                        ctrl.BackColor = GetPlayerColor(playerIndex);
                    }
                }
                idx++;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            StopMusic();
            btnPlay.Enabled = true;
            btnStop.Enabled = false;
            isWaitingAnswer = false;
            lblStatus.Text = "Воспроизведение остановлено";
            checkMusicTimer.Stop();
        }

        private void SuperGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Пробел - продолжить музыку
            if (e.KeyCode == Keys.Space && isWaitingAnswer && !isPlaying && lastPressedPlayer != -1)
            {
                ResumeMusic();
                lblStatus.Text = "Музыка продолжена...";
                btnSuccess.Enabled = false;
                btnFail.Enabled = false;
                lastPressedPlayer = -1;
                ResetIndicators();
                e.Handled = true;
                return;
            }

            // Обработка нажатий от игроков
            if (isWaitingAnswer && isPlaying)
            {
                int idx = gameManager.CheckButtonPress(e.KeyCode);

                var players = gameManager.GetPlayers();
                if (idx == -1 || idx >= players.Count)
                {
                    return;
                }

                // ПРОВЕРКА БЛОКИРОВКИ
                if (players[idx].IsBlocked)
                {
                    lblStatus.Text = $"{players[idx].Name} ЗАБЛОКИРОВАН до конца этой песни!";
                    lblStatus.ForeColor = Color.Red;
                    return;
                }

                PauseMusic();
                lastPressedPlayer = idx;
                HighlightIndicator(idx);
                btnSuccess.Enabled = true;
                btnFail.Enabled = true;

                lblStatus.Text = $"{players[idx].Name} нажал! Засчитать?";
                lblStatus.ForeColor = Color.Yellow;
                e.Handled = true;
            }
        }

        private void BtnSuccess_Click(object sender, EventArgs e)
        {
            checkMusicTimer.Stop();
            if (lastPressedPlayer == -1) return;

            var players = gameManager.GetPlayers();
            if (lastPressedPlayer >= players.Count)
            {
                lastPressedPlayer = -1;
                return;
            }

            // Увеличиваем счёт в суперигре
            superScores[lastPressedPlayer]++;
            lblPlayerScores[lastPressedPlayer].Text = superScores[lastPressedPlayer].ToString();

            // Добавляем очки в основную игру
            players[lastPressedPlayer].Score++;

            lblStatus.Text = $"✓ ЗАСЧИТАНО! {players[lastPressedPlayer].Name} +1 очко!";
            lblStatus.ForeColor = Color.LightGreen;

            StopMusic();
            isWaitingAnswer = false;

            // Переход к следующей песне
            NextSong();
        }

        private void BtnFail_Click(object sender, EventArgs e)
        {
            if (lastPressedPlayer == -1) return;

            var players = gameManager.GetPlayers();
            if (lastPressedPlayer >= players.Count)
            {
                lastPressedPlayer = -1;
                return;
            }

            // БЛОКИРУЕМ ИГРОКА НА ТЕКУЩИЙ ТРЕК
            players[lastPressedPlayer].IsBlocked = true;
            players[lastPressedPlayer].BlockedRemaining = 1;  // Блокировка только на этот трек

            lblStatus.Text = $"✗ НЕ ЗАСЧИТАНО! {players[lastPressedPlayer].Name} заблокирован до конца этой песни!";
            lblStatus.ForeColor = Color.Orange;

            // Продолжаем играть ту же песню
            ResumeMusic();
            isWaitingAnswer = true;
            btnSuccess.Enabled = false;
            btnFail.Enabled = false;

            // Сбрасываем нажавшего, но блокировка остаётся
            lastPressedPlayer = -1;
            ResetIndicators();

            // Обновляем отображение блокировки
            UpdatePlayerBlockDisplay();
            checkMusicTimer.Stop();
        }

        // Добавьте метод обновления отображения блокировки
        private void UpdatePlayerBlockDisplay()
        {
            var players = gameManager.GetPlayers();
            int idx = 0;
            foreach (Control panel in playersPanel.Controls)
            {
                if (idx < players.Count && players[idx].IsBlocked)
                {
                    // Меняем цвет фона панели для заблокированного игрока
                    panel.BackColor = Color.FromArgb(80, 30, 30);

                    // Меняем цвет индикатора
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is Panel && ctrl.Tag != null)
                        {
                            ctrl.BackColor = Color.DarkRed;
                        }
                    }
                }
                else if (idx < players.Count)
                {
                    panel.BackColor = Color.FromArgb(50, 50, 50);
                }
                idx++;
            }
        }

        private void PauseMusic()
        {
            if (waveOutput != null && waveOutput.PlaybackState == PlaybackState.Playing)
            {
                if (audioFileReader != null)
                    pausedPosition = audioFileReader.Position;
                waveOutput.Pause();
                isPlaying = false;
            }
        }

        private void ResumeMusic()
        {
            if (waveOutput != null && waveOutput.PlaybackState == PlaybackState.Paused)
            {
                if (audioFileReader != null)
                    audioFileReader.Position = pausedPosition;
                waveOutput.Play();
                isPlaying = true;
            }
        }

        private void NextSong()
        {
            StopMusic();

            // СНИМАЕМ БЛОКИРОВКУ СО ВСЕХ ИГРОКОВ ПЕРЕД НОВЫМ ТРЕКОМ
            var players = gameManager.GetPlayers();
            foreach (var player in players)
            {
                if (player.BlockedRemaining > 0)
                {
                    player.BlockedRemaining--;
                    if (player.BlockedRemaining == 0)
                    {
                        player.IsBlocked = false;
                    }
                }
            }
            UpdatePlayerBlockDisplay();

            btnPlay.Enabled = true;
            btnStop.Enabled = false;
            btnSuccess.Enabled = false;
            btnFail.Enabled = false;
            isWaitingAnswer = false;
            lastPressedPlayer = -1;
            ResetIndicators();

            if (currentSongIndex + 1 < songs.Count)
            {
                currentSongIndex++;
                listSongs.SelectedIndex = currentSongIndex;
                lblSongTitle.Text = Path.GetFileNameWithoutExtension(songs[currentSongIndex]);
                lblStatus.Text = $"Следующая песня: {Path.GetFileNameWithoutExtension(songs[currentSongIndex])}";
                lblStatus.ForeColor = Color.Cyan;
                btnNext.Enabled = true;
            }
            else
            {
                lblStatus.Text = "Все песни сыграны! Суперигра окончена.";
                btnPlay.Enabled = false;
                btnSuccess.Enabled = false;
                btnFail.Enabled = false;
                btnNext.Enabled = false;
                btnStop.Enabled = false;

                var playersList = gameManager.GetPlayers();
                string results = "Итоги суперигры:\n";
                for (int i = 0; i < playersList.Count && i < 4; i++)
                {
                    results += $"{playersList[i].Name}: {superScores[i]} очков\n";
                }

                MessageBox.Show(results, "Суперигра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            NextSong();
        }

        private void StopMusic()
        {
            if (waveOutput != null)
                waveOutput.Stop();
            if (audioFileReader != null)
                audioFileReader.Dispose();
            isPlaying = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopMusic();
            waveOutput?.Dispose();
            base.OnFormClosing(e);
        }
    }
}