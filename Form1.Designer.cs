namespace UM
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления
        private System.Windows.Forms.ComboBox cmbGameFolder;
        private System.Windows.Forms.Button btnRefreshGames;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnStartFirstTour;
        private System.Windows.Forms.Button btnStartSecondTour;
        private System.Windows.Forms.Button btnPlayTrack;
        private System.Windows.Forms.Button btnScore;
        private System.Windows.Forms.Button btnNotScore;
        private System.Windows.Forms.Button btnSaveScore;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label lblCurrentTrack;
        private System.Windows.Forms.GroupBox grpGameControl;
        private System.Windows.Forms.GroupBox grpTourControl;
        private System.Windows.Forms.GroupBox grpPlayers;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

        // Игроки
        private System.Windows.Forms.Label lblPlayer11;
        private System.Windows.Forms.Label lblPlayer21;
        private System.Windows.Forms.Label lblPlayer31;
        private System.Windows.Forms.Label lblPlayer41;
        private System.Windows.Forms.Label lblScore1;
        private System.Windows.Forms.Label lblScore2;
        private System.Windows.Forms.Label lblScore3;
        private System.Windows.Forms.Label lblScore4;
        private System.Windows.Forms.Button btnBlock1;
        private System.Windows.Forms.Button btnBlock2;
        private System.Windows.Forms.Button btnBlock3;
        private System.Windows.Forms.Button btnBlock4;
        private System.Windows.Forms.Button btnUnblock1;
        private System.Windows.Forms.Button btnUnblock2;
        private System.Windows.Forms.Button btnUnblock3;
        private System.Windows.Forms.Button btnUnblock4;
        private System.Windows.Forms.NumericUpDown numAdd1;
        private System.Windows.Forms.NumericUpDown numAdd2;
        private System.Windows.Forms.NumericUpDown numAdd3;
        private System.Windows.Forms.NumericUpDown numAdd4;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.Button btnAdd2;
        private System.Windows.Forms.Button btnAdd3;
        private System.Windows.Forms.Button btnAdd4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cmbGameFolder = new ComboBox();
            btnRefreshGames = new Button();
            btnOpenFolder = new Button();
            btnStartFirstTour = new Button();
            btnStartSecondTour = new Button();
            btnPlayTrack = new Button();
            btnScore = new Button();
            btnNotScore = new Button();
            btnSaveScore = new Button();
            btnSettings = new Button();
            lblStatus = new Label();
            lblCounter = new Label();
            lblCurrentTrack = new Label();
            grpGameControl = new GroupBox();
            grpTourControl = new GroupBox();
            BtnFinishTrack = new Button();
            btnResumeMusic = new Button();
            grpPlayers = new GroupBox();
            btnResetScores = new Button();
            btnUpdatePlayerName = new Button();
            lblPlayer4 = new TextBox();
            lblPlayer3 = new TextBox();
            lblPlayer2 = new TextBox();
            lblPlayer1 = new TextBox();
            button1 = new Button();
            lblPenalty4 = new Label();
            lblPenalty3 = new Label();
            lblPenalty2 = new Label();
            lblPenalty1 = new Label();
            lblPlayer11 = new Label();
            lblScore1 = new Label();
            numAdd1 = new NumericUpDown();
            btnAdd1 = new Button();
            btnBlock1 = new Button();
            btnUnblock1 = new Button();
            lblPlayer21 = new Label();
            lblScore2 = new Label();
            numAdd2 = new NumericUpDown();
            btnAdd2 = new Button();
            btnBlock2 = new Button();
            btnUnblock2 = new Button();
            lblPlayer31 = new Label();
            lblScore3 = new Label();
            numAdd3 = new NumericUpDown();
            btnAdd3 = new Button();
            btnBlock3 = new Button();
            btnUnblock3 = new Button();
            lblPlayer41 = new Label();
            lblScore4 = new Label();
            numAdd4 = new NumericUpDown();
            btnAdd4 = new Button();
            btnBlock4 = new Button();
            btnUnblock4 = new Button();
            grpStatus = new GroupBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            folderBrowserDialog = new FolderBrowserDialog();
            btnSuperGame = new Button();
            grpGameControl.SuspendLayout();
            grpTourControl.SuspendLayout();
            grpPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAdd1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAdd2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAdd3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAdd4).BeginInit();
            grpStatus.SuspendLayout();
            SuspendLayout();
            // 
            // cmbGameFolder
            // 
            cmbGameFolder.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGameFolder.Font = new Font("Microsoft Sans Serif", 10F);
            cmbGameFolder.Location = new Point(12, 29);
            cmbGameFolder.Margin = new Padding(4, 3, 4, 3);
            cmbGameFolder.Name = "cmbGameFolder";
            cmbGameFolder.Size = new Size(256, 24);
            cmbGameFolder.TabIndex = 0;
            // 
            // btnRefreshGames
            // 
            btnRefreshGames.Font = new Font("Microsoft Sans Serif", 9F);
            btnRefreshGames.Location = new Point(420, 27);
            btnRefreshGames.Margin = new Padding(4, 3, 4, 3);
            btnRefreshGames.Name = "btnRefreshGames";
            btnRefreshGames.Size = new Size(140, 32);
            btnRefreshGames.TabIndex = 2;
            btnRefreshGames.Text = "Обновить";
            btnRefreshGames.UseVisualStyleBackColor = true;
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Font = new Font("Microsoft Sans Serif", 9F);
            btnOpenFolder.Location = new Point(280, 27);
            btnOpenFolder.Margin = new Padding(4, 3, 4, 3);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(128, 32);
            btnOpenFolder.TabIndex = 1;
            btnOpenFolder.Text = "Выбрать папку";
            btnOpenFolder.UseVisualStyleBackColor = true;
            // 
            // btnStartFirstTour
            // 
            btnStartFirstTour.BackColor = Color.LightBlue;
            btnStartFirstTour.Enabled = false;
            btnStartFirstTour.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            btnStartFirstTour.Location = new Point(12, 29);
            btnStartFirstTour.Margin = new Padding(4, 3, 4, 3);
            btnStartFirstTour.Name = "btnStartFirstTour";
            btnStartFirstTour.Size = new Size(268, 52);
            btnStartFirstTour.TabIndex = 0;
            btnStartFirstTour.Text = "Начать 1 ТУР";
            btnStartFirstTour.UseVisualStyleBackColor = false;
            // 
            // btnStartSecondTour
            // 
            btnStartSecondTour.BackColor = Color.LightGreen;
            btnStartSecondTour.Enabled = false;
            btnStartSecondTour.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            btnStartSecondTour.Location = new Point(292, 29);
            btnStartSecondTour.Margin = new Padding(4, 3, 4, 3);
            btnStartSecondTour.Name = "btnStartSecondTour";
            btnStartSecondTour.Size = new Size(268, 52);
            btnStartSecondTour.TabIndex = 1;
            btnStartSecondTour.Text = "Начать 2 ТУР";
            btnStartSecondTour.UseVisualStyleBackColor = false;
            // 
            // btnPlayTrack
            // 
            btnPlayTrack.BackColor = Color.Gold;
            btnPlayTrack.Enabled = false;
            btnPlayTrack.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnPlayTrack.Location = new Point(12, 98);
            btnPlayTrack.Margin = new Padding(4, 3, 4, 3);
            btnPlayTrack.Name = "btnPlayTrack";
            btnPlayTrack.Size = new Size(358, 52);
            btnPlayTrack.TabIndex = 2;
            btnPlayTrack.Text = "▶ ЗАПУСТИТЬ СЛЕДУЮЩУЮ ПЕСНЮ";
            btnPlayTrack.UseVisualStyleBackColor = false;
            // 
            // btnScore
            // 
            btnScore.BackColor = Color.LightGreen;
            btnScore.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnScore.Location = new Point(12, 167);
            btnScore.Margin = new Padding(4, 3, 4, 3);
            btnScore.Name = "btnScore";
            btnScore.Size = new Size(169, 46);
            btnScore.TabIndex = 3;
            btnScore.Text = "✓ ЗАСЧИТАТЬ";
            btnScore.UseVisualStyleBackColor = false;
            // 
            // btnNotScore
            // 
            btnNotScore.BackColor = Color.LightCoral;
            btnNotScore.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnNotScore.Location = new Point(198, 167);
            btnNotScore.Margin = new Padding(4, 3, 4, 3);
            btnNotScore.Name = "btnNotScore";
            btnNotScore.Size = new Size(172, 46);
            btnNotScore.TabIndex = 4;
            btnNotScore.Text = "✗ НЕ ЗАСЧИТАТЬ";
            btnNotScore.UseVisualStyleBackColor = false;
            btnNotScore.Click += BtnNotScore_Click;
            // 
            // btnSaveScore
            // 
            btnSaveScore.BackColor = Color.LightGray;
            btnSaveScore.Font = new Font("Microsoft Sans Serif", 9F);
            btnSaveScore.Location = new Point(27, 508);
            btnSaveScore.Margin = new Padding(4, 3, 4, 3);
            btnSaveScore.Name = "btnSaveScore";
            btnSaveScore.Size = new Size(222, 46);
            btnSaveScore.TabIndex = 21;
            btnSaveScore.Text = "💾 СОХРАНИТЬ СЧЁТ";
            btnSaveScore.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.LightGray;
            btnSettings.Font = new Font("Microsoft Sans Serif", 9F);
            btnSettings.Location = new Point(257, 508);
            btnSettings.Margin = new Padding(4, 3, 4, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(222, 46);
            btnSettings.TabIndex = 22;
            btnSettings.Text = "⚙ НАСТРОЙКИ";
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblStatus.ForeColor = Color.DarkBlue;
            lblStatus.Location = new Point(18, 35);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(261, 18);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Статус: Выберите папку с игрой";
            // 
            // lblCounter
            // 
            lblCounter.AutoSize = true;
            lblCounter.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblCounter.ForeColor = Color.Blue;
            lblCounter.Location = new Point(18, 75);
            lblCounter.Margin = new Padding(4, 0, 4, 0);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new Size(114, 24);
            lblCounter.TabIndex = 1;
            lblCounter.Text = "Счётчик: 0";
            // 
            // lblCurrentTrack
            // 
            lblCurrentTrack.AutoSize = true;
            lblCurrentTrack.Font = new Font("Microsoft Sans Serif", 10F);
            lblCurrentTrack.Location = new Point(18, 121);
            lblCurrentTrack.Margin = new Padding(4, 0, 4, 0);
            lblCurrentTrack.Name = "lblCurrentTrack";
            lblCurrentTrack.Size = new Size(113, 17);
            lblCurrentTrack.TabIndex = 2;
            lblCurrentTrack.Text = "Текущий трек: -";
            // 
            // grpGameControl
            // 
            grpGameControl.Controls.Add(cmbGameFolder);
            grpGameControl.Controls.Add(btnOpenFolder);
            grpGameControl.Controls.Add(btnRefreshGames);
            grpGameControl.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            grpGameControl.Location = new Point(14, 14);
            grpGameControl.Margin = new Padding(4, 3, 4, 3);
            grpGameControl.Name = "grpGameControl";
            grpGameControl.Padding = new Padding(4, 3, 4, 3);
            grpGameControl.Size = new Size(583, 69);
            grpGameControl.TabIndex = 0;
            grpGameControl.TabStop = false;
            grpGameControl.Text = "Выбор игры";
            // 
            // grpTourControl
            // 
            grpTourControl.Controls.Add(BtnFinishTrack);
            grpTourControl.Controls.Add(btnResumeMusic);
            grpTourControl.Controls.Add(btnStartFirstTour);
            grpTourControl.Controls.Add(btnStartSecondTour);
            grpTourControl.Controls.Add(btnPlayTrack);
            grpTourControl.Controls.Add(btnScore);
            grpTourControl.Controls.Add(btnNotScore);
            grpTourControl.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            grpTourControl.Location = new Point(14, 90);
            grpTourControl.Margin = new Padding(4, 3, 4, 3);
            grpTourControl.Name = "grpTourControl";
            grpTourControl.Padding = new Padding(4, 3, 4, 3);
            grpTourControl.Size = new Size(583, 231);
            grpTourControl.TabIndex = 1;
            grpTourControl.TabStop = false;
            grpTourControl.Text = "Управление туром";
            // 
            // BtnFinishTrack
            // 
            BtnFinishTrack.BackColor = Color.DarkRed;
            BtnFinishTrack.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            BtnFinishTrack.ForeColor = SystemColors.ControlLightLight;
            BtnFinishTrack.Location = new Point(388, 98);
            BtnFinishTrack.Margin = new Padding(4, 3, 4, 3);
            BtnFinishTrack.Name = "BtnFinishTrack";
            BtnFinishTrack.Size = new Size(172, 52);
            BtnFinishTrack.TabIndex = 6;
            BtnFinishTrack.Text = "ЗАВЕРШИТЬ ТРЕК";
            BtnFinishTrack.UseVisualStyleBackColor = false;
            BtnFinishTrack.Click += BtnFinishTrack_Click;
            // 
            // btnResumeMusic
            // 
            btnResumeMusic.BackColor = Color.Silver;
            btnResumeMusic.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnResumeMusic.Location = new Point(388, 167);
            btnResumeMusic.Margin = new Padding(4, 3, 4, 3);
            btnResumeMusic.Name = "btnResumeMusic";
            btnResumeMusic.Size = new Size(172, 46);
            btnResumeMusic.TabIndex = 5;
            btnResumeMusic.Text = "▶ ПРОДОЛЖИТЬ";
            btnResumeMusic.UseVisualStyleBackColor = false;
            btnResumeMusic.Click += BtnResumeMusic_Click;
            // 
            // grpPlayers
            // 
            grpPlayers.Controls.Add(btnSuperGame);
            grpPlayers.Controls.Add(btnResetScores);
            grpPlayers.Controls.Add(btnUpdatePlayerName);
            grpPlayers.Controls.Add(lblPlayer4);
            grpPlayers.Controls.Add(lblPlayer3);
            grpPlayers.Controls.Add(lblPlayer2);
            grpPlayers.Controls.Add(lblPlayer1);
            grpPlayers.Controls.Add(button1);
            grpPlayers.Controls.Add(lblPenalty4);
            grpPlayers.Controls.Add(lblPenalty3);
            grpPlayers.Controls.Add(lblPenalty2);
            grpPlayers.Controls.Add(lblPenalty1);
            grpPlayers.Controls.Add(lblPlayer11);
            grpPlayers.Controls.Add(lblScore1);
            grpPlayers.Controls.Add(numAdd1);
            grpPlayers.Controls.Add(btnAdd1);
            grpPlayers.Controls.Add(btnBlock1);
            grpPlayers.Controls.Add(btnUnblock1);
            grpPlayers.Controls.Add(lblPlayer21);
            grpPlayers.Controls.Add(lblScore2);
            grpPlayers.Controls.Add(numAdd2);
            grpPlayers.Controls.Add(btnAdd2);
            grpPlayers.Controls.Add(btnBlock2);
            grpPlayers.Controls.Add(btnUnblock2);
            grpPlayers.Controls.Add(lblPlayer31);
            grpPlayers.Controls.Add(lblScore3);
            grpPlayers.Controls.Add(numAdd3);
            grpPlayers.Controls.Add(btnAdd3);
            grpPlayers.Controls.Add(btnBlock3);
            grpPlayers.Controls.Add(btnUnblock3);
            grpPlayers.Controls.Add(lblPlayer41);
            grpPlayers.Controls.Add(lblScore4);
            grpPlayers.Controls.Add(numAdd4);
            grpPlayers.Controls.Add(btnAdd4);
            grpPlayers.Controls.Add(btnBlock4);
            grpPlayers.Controls.Add(btnUnblock4);
            grpPlayers.Controls.Add(btnSaveScore);
            grpPlayers.Controls.Add(btnSettings);
            grpPlayers.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            grpPlayers.Location = new Point(607, 14);
            grpPlayers.Margin = new Padding(4, 3, 4, 3);
            grpPlayers.Name = "grpPlayers";
            grpPlayers.Padding = new Padding(4, 3, 4, 3);
            grpPlayers.Size = new Size(525, 554);
            grpPlayers.TabIndex = 2;
            grpPlayers.TabStop = false;
            grpPlayers.Text = "Игроки";
            // 
            // btnResetScores
            // 
            btnResetScores.BackColor = Color.LightGray;
            btnResetScores.Font = new Font("Microsoft Sans Serif", 9F);
            btnResetScores.Location = new Point(257, 456);
            btnResetScores.Margin = new Padding(4, 3, 4, 3);
            btnResetScores.Name = "btnResetScores";
            btnResetScores.Size = new Size(222, 46);
            btnResetScores.TabIndex = 33;
            btnResetScores.Text = "Сброс очков";
            btnResetScores.UseVisualStyleBackColor = false;
            btnResetScores.Click += btnResetScores_Click;
            // 
            // btnUpdatePlayerName
            // 
            btnUpdatePlayerName.BackColor = Color.LightGray;
            btnUpdatePlayerName.Font = new Font("Microsoft Sans Serif", 9F);
            btnUpdatePlayerName.Location = new Point(27, 406);
            btnUpdatePlayerName.Margin = new Padding(4, 3, 4, 3);
            btnUpdatePlayerName.Name = "btnUpdatePlayerName";
            btnUpdatePlayerName.Size = new Size(222, 46);
            btnUpdatePlayerName.TabIndex = 32;
            btnUpdatePlayerName.Text = "Обновить имена";
            btnUpdatePlayerName.UseVisualStyleBackColor = false;
            btnUpdatePlayerName.Click += btnUpdatePlayerName_Click;
            // 
            // lblPlayer4
            // 
            lblPlayer4.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblPlayer4.Location = new Point(59, 318);
            lblPlayer4.Name = "lblPlayer4";
            lblPlayer4.Size = new Size(127, 31);
            lblPlayer4.TabIndex = 31;
            // 
            // lblPlayer3
            // 
            lblPlayer3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblPlayer3.Location = new Point(59, 220);
            lblPlayer3.Name = "lblPlayer3";
            lblPlayer3.Size = new Size(127, 31);
            lblPlayer3.TabIndex = 30;
            // 
            // lblPlayer2
            // 
            lblPlayer2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblPlayer2.Location = new Point(59, 122);
            lblPlayer2.Name = "lblPlayer2";
            lblPlayer2.Size = new Size(127, 31);
            lblPlayer2.TabIndex = 29;
            // 
            // lblPlayer1
            // 
            lblPlayer1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblPlayer1.Location = new Point(59, 24);
            lblPlayer1.Name = "lblPlayer1";
            lblPlayer1.Size = new Size(127, 31);
            lblPlayer1.TabIndex = 28;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.Font = new Font("Microsoft Sans Serif", 9F);
            button1.Location = new Point(257, 406);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(222, 46);
            button1.TabIndex = 27;
            button1.Text = "Открыть окно для зрителей";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lblPenalty4
            // 
            lblPenalty4.BackColor = Color.RosyBrown;
            lblPenalty4.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblPenalty4.ForeColor = Color.Green;
            lblPenalty4.Location = new Point(301, 318);
            lblPenalty4.Margin = new Padding(4, 0, 4, 0);
            lblPenalty4.Name = "lblPenalty4";
            lblPenalty4.Size = new Size(129, 35);
            lblPenalty4.TabIndex = 26;
            lblPenalty4.Text = "Штраф:";
            lblPenalty4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPenalty3
            // 
            lblPenalty3.BackColor = Color.RosyBrown;
            lblPenalty3.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblPenalty3.ForeColor = Color.Green;
            lblPenalty3.Location = new Point(301, 220);
            lblPenalty3.Margin = new Padding(4, 0, 4, 0);
            lblPenalty3.Name = "lblPenalty3";
            lblPenalty3.Size = new Size(129, 35);
            lblPenalty3.TabIndex = 25;
            lblPenalty3.Text = "Штраф:";
            lblPenalty3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPenalty2
            // 
            lblPenalty2.BackColor = Color.RosyBrown;
            lblPenalty2.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblPenalty2.ForeColor = Color.Green;
            lblPenalty2.Location = new Point(301, 122);
            lblPenalty2.Margin = new Padding(4, 0, 4, 0);
            lblPenalty2.Name = "lblPenalty2";
            lblPenalty2.Size = new Size(129, 35);
            lblPenalty2.TabIndex = 24;
            lblPenalty2.Text = "Штраф:";
            lblPenalty2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPenalty1
            // 
            lblPenalty1.BackColor = Color.RosyBrown;
            lblPenalty1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblPenalty1.ForeColor = Color.Green;
            lblPenalty1.Location = new Point(301, 24);
            lblPenalty1.Margin = new Padding(4, 0, 4, 0);
            lblPenalty1.Name = "lblPenalty1";
            lblPenalty1.Size = new Size(129, 35);
            lblPenalty1.TabIndex = 23;
            lblPenalty1.Text = "Штраф:";
            lblPenalty1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPlayer11
            // 
            lblPlayer11.BackColor = Color.Red;
            lblPlayer11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblPlayer11.Location = new Point(27, 24);
            lblPlayer11.Margin = new Padding(4, 0, 4, 0);
            lblPlayer11.Name = "lblPlayer11";
            lblPlayer11.Size = new Size(25, 35);
            lblPlayer11.TabIndex = 0;
            lblPlayer11.Text = "1";
            // 
            // lblScore1
            // 
            lblScore1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblScore1.ForeColor = Color.Green;
            lblScore1.Location = new Point(196, 23);
            lblScore1.Margin = new Padding(4, 0, 4, 0);
            lblScore1.Name = "lblScore1";
            lblScore1.Size = new Size(93, 35);
            lblScore1.TabIndex = 1;
            lblScore1.Text = "0";
            lblScore1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numAdd1
            // 
            numAdd1.Location = new Point(27, 70);
            numAdd1.Margin = new Padding(4, 3, 4, 3);
            numAdd1.Name = "numAdd1";
            numAdd1.Size = new Size(82, 23);
            numAdd1.TabIndex = 2;
            numAdd1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnAdd1
            // 
            btnAdd1.Location = new Point(120, 67);
            btnAdd1.Margin = new Padding(4, 3, 4, 3);
            btnAdd1.Name = "btnAdd1";
            btnAdd1.Size = new Size(58, 32);
            btnAdd1.TabIndex = 3;
            btnAdd1.Tag = "1";
            btnAdd1.Text = "+";
            btnAdd1.UseVisualStyleBackColor = true;
            // 
            // btnBlock1
            // 
            btnBlock1.BackColor = Color.Orange;
            btnBlock1.Location = new Point(196, 67);
            btnBlock1.Margin = new Padding(4, 3, 4, 3);
            btnBlock1.Name = "btnBlock1";
            btnBlock1.Size = new Size(93, 32);
            btnBlock1.TabIndex = 4;
            btnBlock1.Tag = "1";
            btnBlock1.Text = "Блок";
            btnBlock1.UseVisualStyleBackColor = false;
            // 
            // btnUnblock1
            // 
            btnUnblock1.BackColor = Color.LightBlue;
            btnUnblock1.Location = new Point(301, 67);
            btnUnblock1.Margin = new Padding(4, 3, 4, 3);
            btnUnblock1.Name = "btnUnblock1";
            btnUnblock1.Size = new Size(105, 32);
            btnUnblock1.TabIndex = 5;
            btnUnblock1.Tag = "1";
            btnUnblock1.Text = "Разблок";
            btnUnblock1.UseVisualStyleBackColor = false;
            // 
            // lblPlayer21
            // 
            lblPlayer21.BackColor = Color.Blue;
            lblPlayer21.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblPlayer21.Location = new Point(27, 122);
            lblPlayer21.Margin = new Padding(4, 0, 4, 0);
            lblPlayer21.Name = "lblPlayer21";
            lblPlayer21.Size = new Size(25, 35);
            lblPlayer21.TabIndex = 6;
            lblPlayer21.Text = "2";
            // 
            // lblScore2
            // 
            lblScore2.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblScore2.ForeColor = Color.Green;
            lblScore2.Location = new Point(196, 122);
            lblScore2.Margin = new Padding(4, 0, 4, 0);
            lblScore2.Name = "lblScore2";
            lblScore2.Size = new Size(93, 35);
            lblScore2.TabIndex = 7;
            lblScore2.Text = "0";
            lblScore2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numAdd2
            // 
            numAdd2.Location = new Point(27, 168);
            numAdd2.Margin = new Padding(4, 3, 4, 3);
            numAdd2.Name = "numAdd2";
            numAdd2.Size = new Size(82, 23);
            numAdd2.TabIndex = 7;
            numAdd2.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnAdd2
            // 
            btnAdd2.Location = new Point(120, 166);
            btnAdd2.Margin = new Padding(4, 3, 4, 3);
            btnAdd2.Name = "btnAdd2";
            btnAdd2.Size = new Size(58, 32);
            btnAdd2.TabIndex = 8;
            btnAdd2.Tag = "2";
            btnAdd2.Text = "+";
            btnAdd2.UseVisualStyleBackColor = true;
            // 
            // btnBlock2
            // 
            btnBlock2.BackColor = Color.Orange;
            btnBlock2.Location = new Point(196, 166);
            btnBlock2.Margin = new Padding(4, 3, 4, 3);
            btnBlock2.Name = "btnBlock2";
            btnBlock2.Size = new Size(93, 32);
            btnBlock2.TabIndex = 9;
            btnBlock2.Tag = "2";
            btnBlock2.Text = "Блок";
            btnBlock2.UseVisualStyleBackColor = false;
            // 
            // btnUnblock2
            // 
            btnUnblock2.BackColor = Color.LightBlue;
            btnUnblock2.Location = new Point(301, 166);
            btnUnblock2.Margin = new Padding(4, 3, 4, 3);
            btnUnblock2.Name = "btnUnblock2";
            btnUnblock2.Size = new Size(105, 32);
            btnUnblock2.TabIndex = 10;
            btnUnblock2.Tag = "2";
            btnUnblock2.Text = "Разблок";
            btnUnblock2.UseVisualStyleBackColor = false;
            // 
            // lblPlayer31
            // 
            lblPlayer31.BackColor = Color.Yellow;
            lblPlayer31.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblPlayer31.Location = new Point(27, 220);
            lblPlayer31.Margin = new Padding(4, 0, 4, 0);
            lblPlayer31.Name = "lblPlayer31";
            lblPlayer31.Size = new Size(25, 35);
            lblPlayer31.TabIndex = 11;
            lblPlayer31.Text = "3";
            // 
            // lblScore3
            // 
            lblScore3.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblScore3.ForeColor = Color.Green;
            lblScore3.Location = new Point(196, 220);
            lblScore3.Margin = new Padding(4, 0, 4, 0);
            lblScore3.Name = "lblScore3";
            lblScore3.Size = new Size(93, 35);
            lblScore3.TabIndex = 12;
            lblScore3.Text = "0";
            lblScore3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numAdd3
            // 
            numAdd3.Location = new Point(27, 266);
            numAdd3.Margin = new Padding(4, 3, 4, 3);
            numAdd3.Name = "numAdd3";
            numAdd3.Size = new Size(82, 23);
            numAdd3.TabIndex = 12;
            numAdd3.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnAdd3
            // 
            btnAdd3.Location = new Point(120, 264);
            btnAdd3.Margin = new Padding(4, 3, 4, 3);
            btnAdd3.Name = "btnAdd3";
            btnAdd3.Size = new Size(58, 32);
            btnAdd3.TabIndex = 13;
            btnAdd3.Tag = "3";
            btnAdd3.Text = "+";
            btnAdd3.UseVisualStyleBackColor = true;
            // 
            // btnBlock3
            // 
            btnBlock3.BackColor = Color.Orange;
            btnBlock3.Location = new Point(196, 264);
            btnBlock3.Margin = new Padding(4, 3, 4, 3);
            btnBlock3.Name = "btnBlock3";
            btnBlock3.Size = new Size(93, 32);
            btnBlock3.TabIndex = 14;
            btnBlock3.Tag = "3";
            btnBlock3.Text = "Блок";
            btnBlock3.UseVisualStyleBackColor = false;
            // 
            // btnUnblock3
            // 
            btnUnblock3.BackColor = Color.LightBlue;
            btnUnblock3.Location = new Point(301, 264);
            btnUnblock3.Margin = new Padding(4, 3, 4, 3);
            btnUnblock3.Name = "btnUnblock3";
            btnUnblock3.Size = new Size(105, 32);
            btnUnblock3.TabIndex = 15;
            btnUnblock3.Tag = "3";
            btnUnblock3.Text = "Разблок";
            btnUnblock3.UseVisualStyleBackColor = false;
            // 
            // lblPlayer41
            // 
            lblPlayer41.BackColor = Color.Green;
            lblPlayer41.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblPlayer41.Location = new Point(27, 318);
            lblPlayer41.Margin = new Padding(4, 0, 4, 0);
            lblPlayer41.Name = "lblPlayer41";
            lblPlayer41.Size = new Size(25, 35);
            lblPlayer41.TabIndex = 16;
            lblPlayer41.Text = "4";
            // 
            // lblScore4
            // 
            lblScore4.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblScore4.ForeColor = Color.Green;
            lblScore4.Location = new Point(196, 318);
            lblScore4.Margin = new Padding(4, 0, 4, 0);
            lblScore4.Name = "lblScore4";
            lblScore4.Size = new Size(93, 35);
            lblScore4.TabIndex = 17;
            lblScore4.Text = "0";
            lblScore4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numAdd4
            // 
            numAdd4.Location = new Point(27, 364);
            numAdd4.Margin = new Padding(4, 3, 4, 3);
            numAdd4.Name = "numAdd4";
            numAdd4.Size = new Size(82, 23);
            numAdd4.TabIndex = 17;
            numAdd4.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnAdd4
            // 
            btnAdd4.Location = new Point(120, 362);
            btnAdd4.Margin = new Padding(4, 3, 4, 3);
            btnAdd4.Name = "btnAdd4";
            btnAdd4.Size = new Size(58, 32);
            btnAdd4.TabIndex = 18;
            btnAdd4.Tag = "4";
            btnAdd4.Text = "+";
            btnAdd4.UseVisualStyleBackColor = true;
            // 
            // btnBlock4
            // 
            btnBlock4.BackColor = Color.Orange;
            btnBlock4.Location = new Point(196, 362);
            btnBlock4.Margin = new Padding(4, 3, 4, 3);
            btnBlock4.Name = "btnBlock4";
            btnBlock4.Size = new Size(93, 32);
            btnBlock4.TabIndex = 19;
            btnBlock4.Tag = "4";
            btnBlock4.Text = "Блок";
            btnBlock4.UseVisualStyleBackColor = false;
            // 
            // btnUnblock4
            // 
            btnUnblock4.BackColor = Color.LightBlue;
            btnUnblock4.Location = new Point(301, 362);
            btnUnblock4.Margin = new Padding(4, 3, 4, 3);
            btnUnblock4.Name = "btnUnblock4";
            btnUnblock4.Size = new Size(105, 32);
            btnUnblock4.TabIndex = 20;
            btnUnblock4.Tag = "4";
            btnUnblock4.Text = "Разблок";
            btnUnblock4.UseVisualStyleBackColor = false;
            // 
            // grpStatus
            // 
            grpStatus.Controls.Add(lblStatus);
            grpStatus.Controls.Add(lblCounter);
            grpStatus.Controls.Add(lblCurrentTrack);
            grpStatus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            grpStatus.Location = new Point(14, 328);
            grpStatus.Margin = new Padding(4, 3, 4, 3);
            grpStatus.Name = "grpStatus";
            grpStatus.Padding = new Padding(4, 3, 4, 3);
            grpStatus.Size = new Size(583, 240);
            grpStatus.TabIndex = 3;
            grpStatus.TabStop = false;
            grpStatus.Text = "Статус игры";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            // 
            // btnSuperGame
            // 
            btnSuperGame.BackColor = Color.LightGray;
            btnSuperGame.Font = new Font("Microsoft Sans Serif", 9F);
            btnSuperGame.Location = new Point(27, 456);
            btnSuperGame.Margin = new Padding(4, 3, 4, 3);
            btnSuperGame.Name = "btnSuperGame";
            btnSuperGame.Size = new Size(222, 46);
            btnSuperGame.TabIndex = 34;
            btnSuperGame.Text = "Суперигра!";
            btnSuperGame.UseVisualStyleBackColor = false;
            btnSuperGame.Click += btnSuperGame_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 578);
            Controls.Add(grpStatus);
            Controls.Add(grpPlayers);
            Controls.Add(grpTourControl);
            Controls.Add(grpGameControl);
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Музыкальная игра";
            KeyDown += Form1_KeyDown;
            grpGameControl.ResumeLayout(false);
            grpTourControl.ResumeLayout(false);
            grpPlayers.ResumeLayout(false);
            grpPlayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAdd1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAdd2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAdd3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAdd4).EndInit();
            grpStatus.ResumeLayout(false);
            grpStatus.PerformLayout();
            ResumeLayout(false);
        }

        private Button btnResumeMusic;
        private Button BtnFinishTrack;
        private Label lblPenalty4;
        private Label lblPenalty3;
        private Label lblPenalty2;
        private Label lblPenalty1;
        private Button button1;
        private TextBox lblPlayer4;
        private TextBox lblPlayer3;
        private TextBox lblPlayer2;
        private TextBox lblPlayer1;
        private Button btnUpdatePlayerName;
        private Button btnResetScores;
        private Button btnSuperGame;
    }
}