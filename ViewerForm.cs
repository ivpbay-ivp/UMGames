using System;
using System.Drawing;
using System.Windows.Forms;

namespace UM
{
    public partial class ViewerForm : Form
    {
        private GameManager gameManager;
        private System.Windows.Forms.Timer updateTimer;

        private Color[] playerColors = { Color.Red, Color.Blue, Color.Yellow, Color.Green };
        private PictureBox[] smallIndicators;
        private Label[] playerNames;
        private Label[] playerScores;
        private Label[] playerPenalties;

        public ViewerForm(GameManager manager)
        {
            gameManager = manager;
            InitializeComponent();

            smallIndicators = new PictureBox[] { picIndicator1, picIndicator2, picIndicator3, picIndicator4 };
            playerNames = new Label[] { lblPlayerName1, lblPlayerName2, lblPlayerName3, lblPlayerName4 };
            playerScores = new Label[] { lblPlayerScore1, lblPlayerScore2, lblPlayerScore3, lblPlayerScore4 };
            playerPenalties = new Label[] { lblPlayerPenalty1, lblPlayerPenalty2, lblPlayerPenalty3, lblPlayerPenalty4 };

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 500;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;

            try
            {
                var players = gameManager.GetPlayers();

                for (int i = 0; i < players.Count && i < playerNames.Length; i++)
                {
                    if (playerNames[i] != null && !playerNames[i].IsDisposed)
                        playerNames[i].Text = players[i].Name;

                    if (playerScores[i] != null && !playerScores[i].IsDisposed)
                        playerScores[i].Text = players[i].Score.ToString();

                    if (players[i].IsBlocked)
                    {
                        if (playerPenalties[i] != null && !playerPenalties[i].IsDisposed)
                        {
                            playerPenalties[i].Text = $"🚫 БЛОК: {players[i].BlockedRemaining}";
                            playerPenalties[i].ForeColor = Color.Red;
                        }
                        if (playerNames[i] != null && !playerNames[i].IsDisposed)
                            playerNames[i].ForeColor = Color.Gray;
                        if (playerScores[i] != null && !playerScores[i].IsDisposed)
                            playerScores[i].ForeColor = Color.Gray;
                    }
                    else
                    {
                        if (playerPenalties[i] != null && !playerPenalties[i].IsDisposed)
                        {
                            playerPenalties[i].Text = "✅ АКТИВЕН";
                            playerPenalties[i].ForeColor = Color.LightGreen;
                        }
                        if (playerNames[i] != null && !playerNames[i].IsDisposed)
                            playerNames[i].ForeColor = playerColors[i];
                        if (playerScores[i] != null && !playerScores[i].IsDisposed)
                            playerScores[i].ForeColor = Color.White;
                    }
                }
            }
            catch { }
        }

        public void HighlightPressedPlayer(int playerIndex, bool isActive)
        {
            if (!this.IsHandleCreated) return;

            if (smallIndicators == null || bigIndicator == null) return;

            if (playerIndex >= 0 && playerIndex < smallIndicators.Length)
            {
                if (isActive)
                {
                    bigIndicator.BackColor = playerColors[playerIndex];
                    lblIndicatorText.Text = $"НАЖАЛ {playerNames[playerIndex]?.Text}!";
                    lblIndicatorText.ForeColor = playerColors[playerIndex];
                    if (smallIndicators[playerIndex] != null)
                        smallIndicators[playerIndex].BackColor = playerColors[playerIndex];
                }
                else
                {
                    bigIndicator.BackColor = Color.Gray;
                    lblIndicatorText.Text = "ОЖИДАНИЕ НАЖАТИЯ";
                    lblIndicatorText.ForeColor = Color.White;

                    var players = gameManager.GetPlayers();
                    if (playerIndex < players.Count && players[playerIndex].IsBlocked)
                    {
                        if (smallIndicators[playerIndex] != null)
                            smallIndicators[playerIndex].BackColor = Color.DarkGray;
                    }
                    else
                    {
                        if (smallIndicators[playerIndex] != null)
                            smallIndicators[playerIndex].BackColor = Color.Gray;
                    }
                }
            }
        }

        public void ResetIndicators()
        {
            if (!this.IsHandleCreated) return;

            if (bigIndicator != null)
                bigIndicator.BackColor = Color.Gray;

            if (lblIndicatorText != null)
            {
                lblIndicatorText.Text = "ОЖИДАНИЕ НАЖАТИЯ";
                lblIndicatorText.ForeColor = Color.White;
            }

            if (smallIndicators != null)
            {
                var players = gameManager.GetPlayers();
                for (int i = 0; i < smallIndicators.Length; i++)
                {
                    if (smallIndicators[i] != null && !smallIndicators[i].IsDisposed)
                    {
                        if (i < players.Count && players[i].IsBlocked)
                            smallIndicators[i].BackColor = Color.DarkGray;
                        else
                            smallIndicators[i].BackColor = Color.Gray;
                    }
                }
            }
        }

        public void UpdateStatus(string status, string track, string counter)
        {
            if (!this.IsHandleCreated) return;

            this.BeginInvoke(new Action(() =>
            {
                if (lblStatus != null && !lblStatus.IsDisposed)
                    lblStatus.Text = status;
                if (lblCurrentTrack != null && !lblCurrentTrack.IsDisposed)
                    lblCurrentTrack.Text = track;
                if (lblCounter != null && !lblCounter.IsDisposed)
                    lblCounter.Text = counter;
            }));
        }

        // ДОБАВЬТЕ ЭТОТ МЕТОД
        public void UpdatePlayerNames(string[] names)
        {
            if (!this.IsHandleCreated) return;

            this.BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < names.Length && i < playerNames.Length; i++)
                {
                    if (playerNames[i] != null && !playerNames[i].IsDisposed)
                        playerNames[i].Text = names[i];
                }
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            updateTimer?.Stop();
            updateTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}