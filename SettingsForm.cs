using System;
using System.Windows.Forms;

namespace UM
{
    public partial class SettingsForm : Form
    {
        public GameSettings UpdatedSettings { get; private set; }

        public SettingsForm(GameSettings currentSettings)
        {
            UpdatedSettings = currentSettings;
            InitializeComponent();

            cmbPenaltyType.SelectedIndexChanged += (s, e) => numPenaltyPoints.Enabled = cmbPenaltyType.SelectedIndex == 1;

            txtKey1.KeyDown += TxtKey_KeyDown;
            txtKey2.KeyDown += TxtKey_KeyDown;
            txtKey3.KeyDown += TxtKey_KeyDown;
            txtKey4.KeyDown += TxtKey_KeyDown;

            btnSave.Click += BtnSave_Click;

            LoadData();
        }

        private void TxtKey_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            // Преобразуем клавишу в символ
            char symbol = KeyToChar(e.KeyCode);

            if (symbol != '\0')
            {
                txt.Text = symbol.ToString();
            }
            else
            {
                txt.Text = e.KeyCode.ToString();
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private char KeyToChar(Keys key)
        {
            if (key >= Keys.A && key <= Keys.Z)
                return (char)('A' + (key - Keys.A));
            if (key >= Keys.D0 && key <= Keys.D9)
                return (char)('0' + (key - Keys.D0));

            switch (key)
            {
                case Keys.OemQuestion: return '/';
                case Keys.OemPeriod: return '.';
                case Keys.Oemcomma: return ',';
                case Keys.OemMinus: return '-';
                case Keys.Oemplus: return '+';
                case Keys.OemSemicolon: return ';';
                case Keys.OemQuotes: return '\'';
                case Keys.OemOpenBrackets: return '[';
                case Keys.OemCloseBrackets: return ']';
                case Keys.OemBackslash: return '\\';
                case Keys.Divide: return '/';
                case Keys.Multiply: return '*';
                case Keys.Subtract: return '-';
                case Keys.Add: return '+';
                case Keys.Space: return ' ';
                default: return '\0';
            }
        }

        private void LoadData()
        {
            if (UpdatedSettings == null) return;

            numCounterStart.Value = UpdatedSettings.CounterStartValue;

            if (UpdatedSettings.QuestionPoints.Count >= 1) numQ1.Value = UpdatedSettings.QuestionPoints[0];
            if (UpdatedSettings.QuestionPoints.Count >= 2) numQ2.Value = UpdatedSettings.QuestionPoints[1];
            if (UpdatedSettings.QuestionPoints.Count >= 3) numQ3.Value = UpdatedSettings.QuestionPoints[2];
            if (UpdatedSettings.QuestionPoints.Count >= 4) numQ4.Value = UpdatedSettings.QuestionPoints[3];

            if (UpdatedSettings.PenaltyType == PenaltyType.Block) cmbPenaltyType.SelectedIndex = 0;
            else if (UpdatedSettings.PenaltyType == PenaltyType.SubtractPoints) cmbPenaltyType.SelectedIndex = 1;
            else cmbPenaltyType.SelectedIndex = 2;

            numPenaltyPoints.Value = UpdatedSettings.PenaltyPoints;

            if (UpdatedSettings.ButtonMappings.ContainsKey("Игрок1")) txtKey1.Text = UpdatedSettings.ButtonMappings["Игрок1"].ToString();
            if (UpdatedSettings.ButtonMappings.ContainsKey("Игрок2")) txtKey2.Text = UpdatedSettings.ButtonMappings["Игрок2"].ToString();
            if (UpdatedSettings.ButtonMappings.ContainsKey("Игрок3")) txtKey3.Text = UpdatedSettings.ButtonMappings["Игрок3"].ToString();
            if (UpdatedSettings.ButtonMappings.ContainsKey("Игрок4")) txtKey4.Text = UpdatedSettings.ButtonMappings["Игрок4"].ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (UpdatedSettings == null) UpdatedSettings = new GameSettings();

            UpdatedSettings.CounterStartValue = (int)numCounterStart.Value;

            UpdatedSettings.QuestionPoints.Clear();
            UpdatedSettings.QuestionPoints.Add((int)numQ1.Value);
            UpdatedSettings.QuestionPoints.Add((int)numQ2.Value);
            UpdatedSettings.QuestionPoints.Add((int)numQ3.Value);
            UpdatedSettings.QuestionPoints.Add((int)numQ4.Value);

            if (cmbPenaltyType.SelectedIndex == 0) UpdatedSettings.PenaltyType = PenaltyType.Block;
            else if (cmbPenaltyType.SelectedIndex == 1) UpdatedSettings.PenaltyType = PenaltyType.SubtractPoints;
            else UpdatedSettings.PenaltyType = PenaltyType.Nothing;

            UpdatedSettings.PenaltyPoints = (int)numPenaltyPoints.Value;

            UpdatedSettings.ButtonMappings.Clear();
            UpdatedSettings.ButtonMappings["Игрок1"] = txtKey1.Text[0];
            UpdatedSettings.ButtonMappings["Игрок2"] = txtKey2.Text[0];
            UpdatedSettings.ButtonMappings["Игрок3"] = txtKey3.Text[0];
            UpdatedSettings.ButtonMappings["Игрок4"] = txtKey4.Text[0];

            DialogResult = DialogResult.OK;
            Close();
        }


    }
}