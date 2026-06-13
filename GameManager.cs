using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NAudio.Wave;
using System.Windows.Forms;

namespace UM
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsBlocked { get; set; }
        public int BlockedRemaining { get; set; }
        public int PenaltyCount { get; set; }  // Добавьте это поле
    }

    public class GameSettings
    {
        public int Tour1Points { get; set; } = 10;
        public int CounterStartValue { get; set; } = 10;
        public PenaltyType PenaltyType { get; set; } = PenaltyType.Block;
        public int PenaltyPoints { get; set; } = 5;
        public Dictionary<string, char> ButtonMappings { get; set; } = new Dictionary<string, char>();
        public List<int> QuestionPoints { get; set; } = new List<int> { 5, 10, 20, 25 };
    }

    public enum PenaltyType
    {
        Block,
        SubtractPoints,
        Nothing
    }

    public class TrackInfo
    {
        public string FilePath { get; set; }
        public string Theme { get; set; }
        public int QuestionNumber { get; set; }
        public int Points { get; set; }
    }

    public class GameManager
    {
        public GameSettings Settings { get; private set; }
        public int CurrentTour { get; private set; }
        private List<Player> players;
        private string currentGamePath;
        private WaveOutEvent waveOutput;
        private AudioFileReader audioFileReader;
        private bool isPlaying;
        public event EventHandler TrackEnded;
        private List<TrackInfo> currentTourTracksInfo;
        private long pausedPosition = 0;

        public GameManager()
        {
            Settings = new GameSettings();
            players = new List<Player>();
            waveOutput = new WaveOutEvent();
            LoadDefaultSettings();
        }

        private void LoadDefaultSettings()
        {
            Settings.ButtonMappings["Игрок1"] = 'A';
            Settings.ButtonMappings["Игрок2"] = 'S';
            Settings.ButtonMappings["Игрок3"] = 'D';
            Settings.ButtonMappings["Игрок4"] = 'F';
        }

        public bool LoadGame(string gamePath)
        {
            currentGamePath = gamePath;
            return Directory.Exists(gamePath);
        }



        public string ExtractThemeFromTrackName(string trackName)
        {
            var parts = trackName.Split('_');
            if (parts.Length >= 2)
                return string.Join("_", parts.Take(parts.Length - 1));
            return trackName;
        }

        private int ExtractQuestionNumber(string trackName)
        {
            var parts = trackName.Split('_');
            if (parts.Length >= 1 && int.TryParse(parts.Last(), out int number))
                return number;
            return 1;
        }

        private int GetPointsForQuestionNumber(int questionNumber)
        {
            if (questionNumber >= 1 && questionNumber <= Settings.QuestionPoints.Count)
                return Settings.QuestionPoints[questionNumber - 1];
            return Settings.QuestionPoints.LastOrDefault();
        }

        public void StartTour(int tourNumber)
        {
            CurrentTour = tourNumber;
            string tourFolder = tourNumber == 1 ? "tour1" : "tour2";
            string fullTourPath = Path.Combine(currentGamePath, tourFolder);

            if (Directory.Exists(fullTourPath))
            {
                var audioFiles = Directory.GetFiles(fullTourPath, "*.mp3")
                    .Concat(Directory.GetFiles(fullTourPath, "*.wav"))
                    .ToList();
                audioFiles.Sort();

                currentTourTracksInfo = new List<TrackInfo>();
                foreach (var file in audioFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    currentTourTracksInfo.Add(new TrackInfo
                    {
                        FilePath = file,
                        Theme = ExtractThemeFromTrackName(fileName),
                        QuestionNumber = ExtractQuestionNumber(fileName),
                        Points = GetPointsForQuestionNumber(ExtractQuestionNumber(fileName))
                    });
                }
            }
        }

        public TrackInfo GetCurrentTrackInfo(int index)
        {
            if (currentTourTracksInfo != null && index < currentTourTracksInfo.Count)
                return currentTourTracksInfo[index];
            return null;
        }

        public int GetCurrentTrackPoints(int index)
        {
            var trackInfo = GetCurrentTrackInfo(index);
            if (trackInfo != null && CurrentTour == 1)
                return trackInfo.Points;
            return GetTour1Points();
        }

        public int GetTotalTracksCount()
        {
            return currentTourTracksInfo?.Count ?? 0;
        }

        public void PlayTrack(int trackIndex)
        {
            if (currentTourTracksInfo == null || trackIndex >= currentTourTracksInfo.Count)
                return;
            PlayTrack(currentTourTracksInfo[trackIndex].FilePath);
        }

        public void PlayTrack(string trackPath)
        {
            try
            {
                StopMusic();
                audioFileReader = new AudioFileReader(trackPath);
                waveOutput.Init(audioFileReader);
                waveOutput.Play();
                isPlaying = true;

                // Диагностика
                System.Diagnostics.Debug.WriteLine($"PlayTrack: состояние = {waveOutput.PlaybackState}");

                waveOutput.PlaybackStopped += OnPlaybackStopped;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                isPlaying = false;
            }
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            isPlaying = false;
            TrackEnded?.Invoke(this, EventArgs.Empty);
            if (waveOutput != null)
                waveOutput.PlaybackStopped -= OnPlaybackStopped;
        }

        public void PauseMusic()
        {
            if (waveOutput != null && waveOutput.PlaybackState == PlaybackState.Playing)
            {
                if (audioFileReader != null)
                    pausedPosition = audioFileReader.Position;
                waveOutput.Pause();
                isPlaying = false;
            }
        }

        public void ResumeMusic()
        {
            if (waveOutput != null && waveOutput.PlaybackState == PlaybackState.Paused)
            {
                if (audioFileReader != null)
                    audioFileReader.Position = pausedPosition;
                waveOutput.Play();
                isPlaying = true;
            }
        }

        public void StopMusic()
        {
            if (waveOutput != null)
                waveOutput.Stop();
            if (audioFileReader != null)
                audioFileReader.Position = 0;
            isPlaying = false;
        }

        public bool IsMusicPlaying()
        {
            // Упрощаем проверку
            return waveOutput != null && waveOutput.PlaybackState == PlaybackState.Playing;
        }

        public int CheckButtonPress(Keys key)
        {
            // Преобразуем нажатую клавишу в символ
            char pressedChar = KeyToChar(key);

            // Проходим по настройкам кнопок
            for (int i = 0; i < Settings.ButtonMappings.Count; i++)
            {
                // Получаем клавишу для i-го игрока
                var mapping = Settings.ButtonMappings.ElementAt(i);

                // Если клавиша совпала - возвращаем индекс
                if (mapping.Value == pressedChar)
                {
                    return i;  // индекс 0,1,2,3
                }
            }
            return -1;  // никто не нажал
        }

        private char KeyToChar(Keys key)
        {
            // Обычные буквы
            if (key >= Keys.A && key <= Keys.Z)
                return (char)('A' + (key - Keys.A));

            // Цифры
            if (key >= Keys.D0 && key <= Keys.D9)
                return (char)('0' + (key - Keys.D0));

            // Специальные символы
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
                default:
                    return '\0';
            }
        }
        public void AddPlayer(string name)
        {
            if (!players.Any(p => p.Name == name))
                players.Add(new Player { Name = name, Score = 0, IsBlocked = false});
        }

        public void AddPoints(string playerName, int points)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);
            if (player != null && !player.IsBlocked)
            {
                player.Score += points;
                // НЕ снимаем блокировку здесь
            }
        }

        public void PenalizePlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);
            if (player != null && Settings.PenaltyType == PenaltyType.Block)
            {
                player.IsBlocked = true;
                player.BlockedRemaining = 3;  // 2 штрафных трека
            }
        }

        public void BlockPlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);
            if (player != null)
            {
                player.IsBlocked = true;
                player.BlockedRemaining = 3;
            }
        }

        public void UnblockPlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);
            if (player != null)
            {
                player.IsBlocked = false;

                player.BlockedRemaining = 0;  // ДОБАВЬТЕ ЭТУ СТРОКУ
            }
        }

        public List<Player> GetPlayers() => players;
        public int GetTour1Points() => Settings.Tour1Points;
        public int GetCounterStartValue() => Settings.CounterStartValue;

        public void SaveScoreToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Сохранение от {DateTime.Now}");
                writer.WriteLine($"Игра: {Path.GetFileName(currentGamePath)}");
                writer.WriteLine(new string('-', 50));
                foreach (var player in players.OrderByDescending(p => p.Score))
                    writer.WriteLine($"{player.Name}: {player.Score} очков{(player.IsBlocked ? " (Заблокирован)" : "")}");
            }
        }

        public void UpdateSettings(GameSettings newSettings) => Settings = newSettings;
        public void Dispose()
        {
            StopMusic();
            waveOutput?.Dispose();
            audioFileReader?.Dispose();
        }
    }
}