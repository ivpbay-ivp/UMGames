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
        private PictureBox[] indicators;
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
            updateTimer.Interval = 200;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }


        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                var players = gameManager.GetPlayers();

                for (int i = 0; i < players.Count && i < 4; i++)
                {
                    // НЕ меняем имена - они уже установлены из Form1
                    // playerNames[i].Text = players[i].Name;  // УБРАТЬ!

                    playerScores[i].Text = players[i].Score.ToString();

                    if (players[i].IsBlocked)
                    {
                        playerPenalties[i].Text = $"🚫 БЛОК: {players[i].BlockedRemaining}";
                        playerPenalties[i].ForeColor = Color.Red;
                        playerPenalties[i].Font = new Font("Arial", 12, FontStyle.Bold);
                        smallIndicators[i].BackColor = Color.DarkGray;
                        playerNames[i].ForeColor = Color.Gray;
                        playerScores[i].ForeColor = Color.Gray;
                    }
                    else
                    {
                        playerPenalties[i].Text = "✅ АКТИВЕН";
                        playerPenalties[i].ForeColor = Color.LightGreen;
                        playerPenalties[i].Font = new Font("Arial", 10, FontStyle.Regular);
                        smallIndicators[i].BackColor = Color.Gray;
                        playerNames[i].ForeColor = playerColors[i];
                        playerScores[i].ForeColor = Color.White;
                    }
                }
            }
            catch { }
        }

        public void HighlightPressedPlayer(int playerIndex)
        {
            if (playerIndex >= 0 && playerIndex < 4)
            {
                // Большой индикатор
                bigIndicator.BackColor = playerColors[playerIndex];
                lblIndicatorText.Text = $"НАЖАЛ {playerNames[playerIndex].Text}!";
                lblIndicatorText.ForeColor = playerColors[playerIndex];

                // Маленький индикатор
                smallIndicators[playerIndex].BackColor = playerColors[playerIndex];

                // Таймер для сброса
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, args) =>
                {
                    bigIndicator.BackColor = Color.Gray;
                    lblIndicatorText.Text = "ОЖИДАНИЕ НАЖАТИЯ";
                    lblIndicatorText.ForeColor = Color.White;

                    var players = gameManager.GetPlayers();
                    if (playerIndex < players.Count && players[playerIndex].IsBlocked)
                        smallIndicators[playerIndex].BackColor = Color.DarkGray;
                    else
                        smallIndicators[playerIndex].BackColor = Color.Gray;

                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        public void UpdateStatus(string status, string track, string counter)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    lblStatus.Text = status;
                    lblCurrentTrack.Text = track;
                    lblCounter.Text = counter;
                }));
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            updateTimer?.Stop();
            updateTimer?.Dispose();
            base.OnFormClosing(e);
        }

        public void UpdatePlayerNames(string[] names)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    for (int i = 0; i < names.Length && i < playerNames.Length; i++)
                    {
                        playerNames[i].Text = names[i];
                    }
                }));
            }
        }

    }
}
