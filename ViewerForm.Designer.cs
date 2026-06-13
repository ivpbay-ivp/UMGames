namespace UM
{
    partial class ViewerForm
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentTrack;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Panel playersPanel;
        private System.Windows.Forms.Panel indicatorPanel;
        private System.Windows.Forms.PictureBox bigIndicator;
        private System.Windows.Forms.Label lblIndicatorText;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label lblInfo;

        // Игроки (горизонтально)
        private System.Windows.Forms.Panel playerPanel1;
        private System.Windows.Forms.Panel playerPanel2;
        private System.Windows.Forms.Panel playerPanel3;
        private System.Windows.Forms.Panel playerPanel4;

        private System.Windows.Forms.PictureBox picIndicator1;
        private System.Windows.Forms.PictureBox picIndicator2;
        private System.Windows.Forms.PictureBox picIndicator3;
        private System.Windows.Forms.PictureBox picIndicator4;

        private System.Windows.Forms.Label lblPlayerName1;
        private System.Windows.Forms.Label lblPlayerName2;
        private System.Windows.Forms.Label lblPlayerName3;
        private System.Windows.Forms.Label lblPlayerName4;

        private System.Windows.Forms.Label lblPlayerScore1;
        private System.Windows.Forms.Label lblPlayerScore2;
        private System.Windows.Forms.Label lblPlayerScore3;
        private System.Windows.Forms.Label lblPlayerScore4;

        private System.Windows.Forms.Label lblPlayerPenalty1;
        private System.Windows.Forms.Label lblPlayerPenalty2;
        private System.Windows.Forms.Label lblPlayerPenalty3;
        private System.Windows.Forms.Label lblPlayerPenalty4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            statusPanel = new Panel();
            lblStatus = new Label();
            lblCurrentTrack = new Label();
            lblCounter = new Label();
            playersPanel = new Panel();
            playerPanel1 = new Panel();
            picIndicator1 = new PictureBox();
            lblPlayerName1 = new Label();
            lblPlayerScore1 = new Label();
            lblPlayerPenalty1 = new Label();
            playerPanel2 = new Panel();
            picIndicator2 = new PictureBox();
            lblPlayerName2 = new Label();
            lblPlayerScore2 = new Label();
            lblPlayerPenalty2 = new Label();
            playerPanel3 = new Panel();
            picIndicator3 = new PictureBox();
            lblPlayerName3 = new Label();
            lblPlayerScore3 = new Label();
            lblPlayerPenalty3 = new Label();
            playerPanel4 = new Panel();
            picIndicator4 = new PictureBox();
            lblPlayerName4 = new Label();
            lblPlayerScore4 = new Label();
            lblPlayerPenalty4 = new Label();
            indicatorPanel = new Panel();
            bigIndicator = new PictureBox();
            lblIndicatorText = new Label();
            infoPanel = new Panel();
            lblInfo = new Label();
            statusPanel.SuspendLayout();
            playersPanel.SuspendLayout();
            playerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIndicator1).BeginInit();
            playerPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIndicator2).BeginInit();
            playerPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIndicator3).BeginInit();
            playerPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIndicator4).BeginInit();
            indicatorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bigIndicator).BeginInit();
            infoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(40, 40, 40);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(805, 70);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "СЧЁТ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusPanel
            // 
            statusPanel.BackColor = Color.FromArgb(30, 30, 30);
            statusPanel.Controls.Add(lblStatus);
            statusPanel.Controls.Add(lblCurrentTrack);
            statusPanel.Controls.Add(lblCounter);
            statusPanel.Dock = DockStyle.Top;
            statusPanel.Location = new Point(0, 70);
            statusPanel.Name = "statusPanel";
            statusPanel.Size = new Size(805, 100);
            statusPanel.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Cyan;
            lblStatus.Location = new Point(20, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(760, 30);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Ожидание начала игры";
            // 
            // lblCurrentTrack
            // 
            lblCurrentTrack.Font = new Font("Arial", 12F);
            lblCurrentTrack.ForeColor = Color.White;
            lblCurrentTrack.Location = new Point(20, 45);
            lblCurrentTrack.Name = "lblCurrentTrack";
            lblCurrentTrack.Size = new Size(760, 25);
            lblCurrentTrack.TabIndex = 1;
            lblCurrentTrack.Text = "Трек: -";
            // 
            // lblCounter
            // 
            lblCounter.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblCounter.ForeColor = Color.Yellow;
            lblCounter.Location = new Point(20, 70);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new Size(760, 25);
            lblCounter.TabIndex = 2;
            lblCounter.Text = "Счётчик: 0";
            // 
            // playersPanel
            // 
            playersPanel.BackColor = Color.FromArgb(20, 20, 20);
            playersPanel.Controls.Add(playerPanel1);
            playersPanel.Controls.Add(playerPanel2);
            playersPanel.Controls.Add(playerPanel3);
            playersPanel.Controls.Add(playerPanel4);
            playersPanel.Dock = DockStyle.Top;
            playersPanel.Location = new Point(0, 170);
            playersPanel.Name = "playersPanel";
            playersPanel.Size = new Size(805, 263);
            playersPanel.TabIndex = 1;
            // 
            // playerPanel1
            // 
            playerPanel1.BackColor = Color.FromArgb(35, 35, 35);
            playerPanel1.BorderStyle = BorderStyle.FixedSingle;
            playerPanel1.Controls.Add(picIndicator1);
            playerPanel1.Controls.Add(lblPlayerName1);
            playerPanel1.Controls.Add(lblPlayerScore1);
            playerPanel1.Controls.Add(lblPlayerPenalty1);
            playerPanel1.Location = new Point(44, 15);
            playerPanel1.Name = "playerPanel1";
            playerPanel1.Size = new Size(180, 242);
            playerPanel1.TabIndex = 0;
            // 
            // picIndicator1
            // 
            picIndicator1.BackColor = Color.Red;
            picIndicator1.Location = new Point(59, 10);
            picIndicator1.Name = "picIndicator1";
            picIndicator1.Size = new Size(60, 60);
            picIndicator1.TabIndex = 0;
            picIndicator1.TabStop = false;
            // 
            // lblPlayerName1
            // 
            lblPlayerName1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerName1.ForeColor = Color.Red;
            lblPlayerName1.Location = new Point(3, 73);
            lblPlayerName1.Name = "lblPlayerName1";
            lblPlayerName1.Size = new Size(172, 77);
            lblPlayerName1.TabIndex = 1;
            lblPlayerName1.Text = "0";
            lblPlayerName1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerScore1
            // 
            lblPlayerScore1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerScore1.ForeColor = Color.White;
            lblPlayerScore1.Location = new Point(3, 150);
            lblPlayerScore1.Name = "lblPlayerScore1";
            lblPlayerScore1.Size = new Size(172, 40);
            lblPlayerScore1.TabIndex = 2;
            lblPlayerScore1.Text = "0";
            lblPlayerScore1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerPenalty1
            // 
            lblPlayerPenalty1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerPenalty1.ForeColor = Color.LightGreen;
            lblPlayerPenalty1.Location = new Point(3, 205);
            lblPlayerPenalty1.Name = "lblPlayerPenalty1";
            lblPlayerPenalty1.Size = new Size(172, 35);
            lblPlayerPenalty1.TabIndex = 3;
            lblPlayerPenalty1.Text = "0";
            lblPlayerPenalty1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // playerPanel2
            // 
            playerPanel2.BackColor = Color.FromArgb(35, 35, 35);
            playerPanel2.BorderStyle = BorderStyle.FixedSingle;
            playerPanel2.Controls.Add(picIndicator2);
            playerPanel2.Controls.Add(lblPlayerName2);
            playerPanel2.Controls.Add(lblPlayerScore2);
            playerPanel2.Controls.Add(lblPlayerPenalty2);
            playerPanel2.Location = new Point(230, 15);
            playerPanel2.Name = "playerPanel2";
            playerPanel2.Size = new Size(180, 242);
            playerPanel2.TabIndex = 1;
            // 
            // picIndicator2
            // 
            picIndicator2.BackColor = Color.Blue;
            picIndicator2.Location = new Point(59, 10);
            picIndicator2.Name = "picIndicator2";
            picIndicator2.Size = new Size(60, 60);
            picIndicator2.TabIndex = 0;
            picIndicator2.TabStop = false;
            // 
            // lblPlayerName2
            // 
            lblPlayerName2.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerName2.ForeColor = Color.Blue;
            lblPlayerName2.Location = new Point(3, 73);
            lblPlayerName2.Name = "lblPlayerName2";
            lblPlayerName2.Size = new Size(172, 77);
            lblPlayerName2.TabIndex = 1;
            lblPlayerName2.Text = "0";
            lblPlayerName2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerScore2
            // 
            lblPlayerScore2.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerScore2.ForeColor = Color.White;
            lblPlayerScore2.Location = new Point(3, 150);
            lblPlayerScore2.Name = "lblPlayerScore2";
            lblPlayerScore2.Size = new Size(172, 40);
            lblPlayerScore2.TabIndex = 2;
            lblPlayerScore2.Text = "0";
            lblPlayerScore2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerPenalty2
            // 
            lblPlayerPenalty2.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerPenalty2.ForeColor = Color.LightGreen;
            lblPlayerPenalty2.Location = new Point(3, 205);
            lblPlayerPenalty2.Name = "lblPlayerPenalty2";
            lblPlayerPenalty2.Size = new Size(172, 35);
            lblPlayerPenalty2.TabIndex = 3;
            lblPlayerPenalty2.Text = "0";
            lblPlayerPenalty2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // playerPanel3
            // 
            playerPanel3.BackColor = Color.FromArgb(35, 35, 35);
            playerPanel3.BorderStyle = BorderStyle.FixedSingle;
            playerPanel3.Controls.Add(picIndicator3);
            playerPanel3.Controls.Add(lblPlayerName3);
            playerPanel3.Controls.Add(lblPlayerScore3);
            playerPanel3.Controls.Add(lblPlayerPenalty3);
            playerPanel3.Location = new Point(416, 15);
            playerPanel3.Name = "playerPanel3";
            playerPanel3.Size = new Size(180, 242);
            playerPanel3.TabIndex = 2;
            // 
            // picIndicator3
            // 
            picIndicator3.BackColor = Color.Yellow;
            picIndicator3.Location = new Point(58, 10);
            picIndicator3.Name = "picIndicator3";
            picIndicator3.Size = new Size(60, 60);
            picIndicator3.TabIndex = 0;
            picIndicator3.TabStop = false;
            // 
            // lblPlayerName3
            // 
            lblPlayerName3.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerName3.ForeColor = Color.Yellow;
            lblPlayerName3.Location = new Point(3, 80);
            lblPlayerName3.Name = "lblPlayerName3";
            lblPlayerName3.Size = new Size(172, 70);
            lblPlayerName3.TabIndex = 1;
            lblPlayerName3.Text = "0";
            lblPlayerName3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerScore3
            // 
            lblPlayerScore3.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerScore3.ForeColor = Color.White;
            lblPlayerScore3.Location = new Point(3, 150);
            lblPlayerScore3.Name = "lblPlayerScore3";
            lblPlayerScore3.Size = new Size(172, 40);
            lblPlayerScore3.TabIndex = 2;
            lblPlayerScore3.Text = "0";
            lblPlayerScore3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerPenalty3
            // 
            lblPlayerPenalty3.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerPenalty3.ForeColor = Color.LightGreen;
            lblPlayerPenalty3.Location = new Point(3, 205);
            lblPlayerPenalty3.Name = "lblPlayerPenalty3";
            lblPlayerPenalty3.Size = new Size(176, 35);
            lblPlayerPenalty3.TabIndex = 3;
            lblPlayerPenalty3.Text = "0";
            lblPlayerPenalty3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // playerPanel4
            // 
            playerPanel4.BackColor = Color.FromArgb(35, 35, 35);
            playerPanel4.BorderStyle = BorderStyle.FixedSingle;
            playerPanel4.Controls.Add(picIndicator4);
            playerPanel4.Controls.Add(lblPlayerName4);
            playerPanel4.Controls.Add(lblPlayerScore4);
            playerPanel4.Controls.Add(lblPlayerPenalty4);
            playerPanel4.Location = new Point(602, 16);
            playerPanel4.Name = "playerPanel4";
            playerPanel4.Size = new Size(180, 242);
            playerPanel4.TabIndex = 3;
            // 
            // picIndicator4
            // 
            picIndicator4.BackColor = Color.Green;
            picIndicator4.Location = new Point(60, 9);
            picIndicator4.Name = "picIndicator4";
            picIndicator4.Size = new Size(60, 60);
            picIndicator4.TabIndex = 0;
            picIndicator4.TabStop = false;
            // 
            // lblPlayerName4
            // 
            lblPlayerName4.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerName4.ForeColor = Color.Green;
            lblPlayerName4.Location = new Point(3, 79);
            lblPlayerName4.Name = "lblPlayerName4";
            lblPlayerName4.Size = new Size(174, 70);
            lblPlayerName4.TabIndex = 1;
            lblPlayerName4.Text = "0";
            lblPlayerName4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerScore4
            // 
            lblPlayerScore4.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerScore4.ForeColor = Color.White;
            lblPlayerScore4.Location = new Point(3, 149);
            lblPlayerScore4.Name = "lblPlayerScore4";
            lblPlayerScore4.Size = new Size(172, 40);
            lblPlayerScore4.TabIndex = 2;
            lblPlayerScore4.Text = "0";
            lblPlayerScore4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerPenalty4
            // 
            lblPlayerPenalty4.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold);
            lblPlayerPenalty4.ForeColor = Color.LightGreen;
            lblPlayerPenalty4.Location = new Point(3, 204);
            lblPlayerPenalty4.Name = "lblPlayerPenalty4";
            lblPlayerPenalty4.Size = new Size(174, 35);
            lblPlayerPenalty4.TabIndex = 3;
            lblPlayerPenalty4.Text = "0";
            lblPlayerPenalty4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // indicatorPanel
            // 
            indicatorPanel.BackColor = Color.FromArgb(25, 25, 25);
            indicatorPanel.Controls.Add(bigIndicator);
            indicatorPanel.Controls.Add(lblIndicatorText);
            indicatorPanel.Dock = DockStyle.Fill;
            indicatorPanel.Location = new Point(0, 433);
            indicatorPanel.Name = "indicatorPanel";
            indicatorPanel.Size = new Size(805, 175);
            indicatorPanel.TabIndex = 0;
            // 
            // bigIndicator
            // 
            bigIndicator.BackColor = Color.Gray;
            bigIndicator.Location = new Point(3, 15);
            bigIndicator.Name = "bigIndicator";
            bigIndicator.Size = new Size(799, 145);
            bigIndicator.TabIndex = 0;
            bigIndicator.TabStop = false;
            // 
            // lblIndicatorText
            // 
            lblIndicatorText.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblIndicatorText.ForeColor = Color.White;
            lblIndicatorText.Location = new Point(200, 250);
            lblIndicatorText.Name = "lblIndicatorText";
            lblIndicatorText.Size = new Size(400, 40);
            lblIndicatorText.TabIndex = 1;
            lblIndicatorText.Text = "ОЖИДАНИЕ НАЖАТИЯ";
            lblIndicatorText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // infoPanel
            // 
            infoPanel.BackColor = Color.FromArgb(30, 30, 30);
            infoPanel.Controls.Add(lblInfo);
            infoPanel.Dock = DockStyle.Bottom;
            infoPanel.Location = new Point(0, 608);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(805, 35);
            infoPanel.TabIndex = 4;
            // 
            // lblInfo
            // 
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.Font = new Font("Arial", 10F);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(805, 35);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "🔴 Красный - Игрок1 | 🔵 Синий - Игрок2 | \U0001f7e1 Жёлтый - Игрок3 | \U0001f7e2 Зелёный - Игрок4";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ViewerForm
            // 
            BackColor = Color.Black;
            ClientSize = new Size(805, 643);
            Controls.Add(indicatorPanel);
            Controls.Add(playersPanel);
            Controls.Add(statusPanel);
            Controls.Add(lblTitle);
            Controls.Add(infoPanel);
            MinimumSize = new Size(800, 550);
            Name = "ViewerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Трансляция игры - Для зрителей";
            statusPanel.ResumeLayout(false);
            playersPanel.ResumeLayout(false);
            playerPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIndicator1).EndInit();
            playerPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIndicator2).EndInit();
            playerPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIndicator3).EndInit();
            playerPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIndicator4).EndInit();
            indicatorPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bigIndicator).EndInit();
            infoPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}