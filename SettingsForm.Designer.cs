namespace UM
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.NumericUpDown numCounterStart;
        private System.Windows.Forms.ComboBox cmbPenaltyType;
        private System.Windows.Forms.NumericUpDown numPenaltyPoints;
        private System.Windows.Forms.TextBox txtKey1;
        private System.Windows.Forms.TextBox txtKey2;
        private System.Windows.Forms.TextBox txtKey3;
        private System.Windows.Forms.TextBox txtKey4;
        private System.Windows.Forms.NumericUpDown numQ1;
        private System.Windows.Forms.NumericUpDown numQ2;
        private System.Windows.Forms.NumericUpDown numQ3;
        private System.Windows.Forms.NumericUpDown numQ4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        // Label
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label lblQuestionPoints;
        private System.Windows.Forms.Label lblQ1;
        private System.Windows.Forms.Label lblQ2;
        private System.Windows.Forms.Label lblQ3;
        private System.Windows.Forms.Label lblQ4;
        private System.Windows.Forms.Label lblPenalty;
        private System.Windows.Forms.Label lblPenaltyPoints;
        private System.Windows.Forms.Label lblKeyMapping;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblPlayer3;
        private System.Windows.Forms.Label lblPlayer4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            numCounterStart = new NumericUpDown();
            cmbPenaltyType = new ComboBox();
            numPenaltyPoints = new NumericUpDown();
            txtKey1 = new TextBox();
            txtKey2 = new TextBox();
            txtKey3 = new TextBox();
            txtKey4 = new TextBox();
            numQ1 = new NumericUpDown();
            numQ2 = new NumericUpDown();
            numQ3 = new NumericUpDown();
            numQ4 = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            lblCounter = new Label();
            lblQuestionPoints = new Label();
            lblQ1 = new Label();
            lblQ2 = new Label();
            lblQ3 = new Label();
            lblQ4 = new Label();
            lblPenalty = new Label();
            lblPenaltyPoints = new Label();
            lblKeyMapping = new Label();
            lblPlayer1 = new Label();
            lblPlayer2 = new Label();
            lblPlayer3 = new Label();
            lblPlayer4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numCounterStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPenaltyPoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQ1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQ2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQ3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQ4).BeginInit();
            SuspendLayout();
            // 
            // numCounterStart
            // 
            numCounterStart.Location = new Point(280, 20);
            numCounterStart.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCounterStart.Name = "numCounterStart";
            numCounterStart.Size = new Size(100, 23);
            numCounterStart.TabIndex = 1;
            numCounterStart.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // cmbPenaltyType
            // 
            cmbPenaltyType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPenaltyType.Items.AddRange(new object[] { "Блокировка на 2 песни", "Вычитание очков", "Ничего" });
            cmbPenaltyType.Location = new Point(230, 260);
            cmbPenaltyType.Name = "cmbPenaltyType";
            cmbPenaltyType.Size = new Size(200, 23);
            cmbPenaltyType.TabIndex = 12;
            // 
            // numPenaltyPoints
            // 
            numPenaltyPoints.Enabled = false;
            numPenaltyPoints.Location = new Point(230, 305);
            numPenaltyPoints.Name = "numPenaltyPoints";
            numPenaltyPoints.Size = new Size(100, 23);
            numPenaltyPoints.TabIndex = 14;
            numPenaltyPoints.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // txtKey1
            // 
            txtKey1.Location = new Point(130, 400);
            txtKey1.Name = "txtKey1";
            txtKey1.Size = new Size(80, 23);
            txtKey1.TabIndex = 17;
            txtKey1.Text = "A";
            txtKey1.TextAlign = HorizontalAlignment.Center;
            // 
            // txtKey2
            // 
            txtKey2.Location = new Point(130, 440);
            txtKey2.Name = "txtKey2";
            txtKey2.Size = new Size(80, 23);
            txtKey2.TabIndex = 19;
            txtKey2.Text = "S";
            txtKey2.TextAlign = HorizontalAlignment.Center;
            // 
            // txtKey3
            // 
            txtKey3.Location = new Point(130, 480);
            txtKey3.Name = "txtKey3";
            txtKey3.Size = new Size(80, 23);
            txtKey3.TabIndex = 21;
            txtKey3.Text = "D";
            txtKey3.TextAlign = HorizontalAlignment.Center;
            // 
            // txtKey4
            // 
            txtKey4.Location = new Point(130, 520);
            txtKey4.Name = "txtKey4";
            txtKey4.Size = new Size(80, 23);
            txtKey4.TabIndex = 23;
            txtKey4.Text = "F";
            txtKey4.TextAlign = HorizontalAlignment.Center;
            // 
            // numQ1
            // 
            numQ1.Location = new Point(130, 105);
            numQ1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQ1.Name = "numQ1";
            numQ1.Size = new Size(80, 23);
            numQ1.TabIndex = 4;
            numQ1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numQ2
            // 
            numQ2.Location = new Point(130, 140);
            numQ2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQ2.Name = "numQ2";
            numQ2.Size = new Size(80, 23);
            numQ2.TabIndex = 6;
            numQ2.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // numQ3
            // 
            numQ3.Location = new Point(130, 175);
            numQ3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQ3.Name = "numQ3";
            numQ3.Size = new Size(80, 23);
            numQ3.TabIndex = 8;
            numQ3.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // numQ4
            // 
            numQ4.Location = new Point(130, 210);
            numQ4.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQ4.Name = "numQ4";
            numQ4.Size = new Size(80, 23);
            numQ4.TabIndex = 10;
            numQ4.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LightGreen;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(130, 570);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 24;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightCoral;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(280, 570);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblCounter
            // 
            lblCounter.Location = new Point(20, 20);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new Size(250, 25);
            lblCounter.TabIndex = 0;
            lblCounter.Text = "Начальное значение счётчика (2 тур):";
            // 
            // lblQuestionPoints
            // 
            lblQuestionPoints.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblQuestionPoints.Location = new Point(20, 70);
            lblQuestionPoints.Name = "lblQuestionPoints";
            lblQuestionPoints.Size = new Size(300, 30);
            lblQuestionPoints.TabIndex = 2;
            lblQuestionPoints.Text = "Очки за номера вопросов (1 тур):";
            // 
            // lblQ1
            // 
            lblQ1.Location = new Point(40, 105);
            lblQ1.Name = "lblQ1";
            lblQ1.Size = new Size(80, 25);
            lblQ1.TabIndex = 3;
            lblQ1.Text = "Вопрос 1:";
            // 
            // lblQ2
            // 
            lblQ2.Location = new Point(40, 140);
            lblQ2.Name = "lblQ2";
            lblQ2.Size = new Size(80, 25);
            lblQ2.TabIndex = 5;
            lblQ2.Text = "Вопрос 2:";
            // 
            // lblQ3
            // 
            lblQ3.Location = new Point(40, 175);
            lblQ3.Name = "lblQ3";
            lblQ3.Size = new Size(80, 25);
            lblQ3.TabIndex = 7;
            lblQ3.Text = "Вопрос 3:";
            // 
            // lblQ4
            // 
            lblQ4.Location = new Point(40, 210);
            lblQ4.Name = "lblQ4";
            lblQ4.Size = new Size(80, 25);
            lblQ4.TabIndex = 9;
            lblQ4.Text = "Вопрос 4:";
            // 
            // lblPenalty
            // 
            lblPenalty.Location = new Point(20, 260);
            lblPenalty.Name = "lblPenalty";
            lblPenalty.Size = new Size(200, 25);
            lblPenalty.TabIndex = 11;
            lblPenalty.Text = "Тип штрафа:";
            // 
            // lblPenaltyPoints
            // 
            lblPenaltyPoints.Location = new Point(20, 305);
            lblPenaltyPoints.Name = "lblPenaltyPoints";
            lblPenaltyPoints.Size = new Size(200, 25);
            lblPenaltyPoints.TabIndex = 13;
            lblPenaltyPoints.Text = "Количество вычитаемых очков:";
            // 
            // lblKeyMapping
            // 
            lblKeyMapping.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            lblKeyMapping.Location = new Point(20, 365);
            lblKeyMapping.Name = "lblKeyMapping";
            lblKeyMapping.Size = new Size(250, 30);
            lblKeyMapping.TabIndex = 15;
            lblKeyMapping.Text = "Настройка кнопок игроков:";
            // 
            // lblPlayer1
            // 
            lblPlayer1.Location = new Point(40, 400);
            lblPlayer1.Name = "lblPlayer1";
            lblPlayer1.Size = new Size(80, 25);
            lblPlayer1.TabIndex = 16;
            lblPlayer1.Text = "Игрок1:";
            // 
            // lblPlayer2
            // 
            lblPlayer2.Location = new Point(40, 440);
            lblPlayer2.Name = "lblPlayer2";
            lblPlayer2.Size = new Size(80, 25);
            lblPlayer2.TabIndex = 18;
            lblPlayer2.Text = "Игрок2:";
            // 
            // lblPlayer3
            // 
            lblPlayer3.Location = new Point(40, 480);
            lblPlayer3.Name = "lblPlayer3";
            lblPlayer3.Size = new Size(80, 25);
            lblPlayer3.TabIndex = 20;
            lblPlayer3.Text = "Игрок3:";
            // 
            // lblPlayer4
            // 
            lblPlayer4.Location = new Point(40, 520);
            lblPlayer4.Name = "lblPlayer4";
            lblPlayer4.Size = new Size(80, 25);
            lblPlayer4.TabIndex = 22;
            lblPlayer4.Text = "Игрок4:";
            // 
            // SettingsForm
            // 
            ClientSize = new Size(534, 621);
            Controls.Add(lblCounter);
            Controls.Add(numCounterStart);
            Controls.Add(lblQuestionPoints);
            Controls.Add(lblQ1);
            Controls.Add(numQ1);
            Controls.Add(lblQ2);
            Controls.Add(numQ2);
            Controls.Add(lblQ3);
            Controls.Add(numQ3);
            Controls.Add(lblQ4);
            Controls.Add(numQ4);
            Controls.Add(lblPenalty);
            Controls.Add(cmbPenaltyType);
            Controls.Add(lblPenaltyPoints);
            Controls.Add(numPenaltyPoints);
            Controls.Add(lblKeyMapping);
            Controls.Add(lblPlayer1);
            Controls.Add(txtKey1);
            Controls.Add(lblPlayer2);
            Controls.Add(txtKey2);
            Controls.Add(lblPlayer3);
            Controls.Add(txtKey3);
            Controls.Add(lblPlayer4);
            Controls.Add(txtKey4);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройки игры";
            ((System.ComponentModel.ISupportInitialize)numCounterStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPenaltyPoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQ1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQ2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQ3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQ4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}