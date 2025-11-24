using JonathanHandProject2.Model;
using JonathanHandProject2.Utility;

namespace JonathanHandProject2
{
    public partial class MainForm : Form
    {
        private LetterBag letterBag;
        private WordDictionary wordDictionary;
        private WordValidator wordValidator;

        private GameRound? currentRound;
        private GameHistory gameHistory;

        private char[]? currentLetters;
        private int roundTimeLimit = 60;
        private int currentTimeRemaining;

        private System.Windows.Forms.Timer roundTimer;
        private HighScoreBoard highScoreBoard;

        private string currentPlayerName;

        public MainForm()
        {
            InitializeComponent();

            menuGameTime = new ToolStripMenuItem();
            menuTime60 = new ToolStripMenuItem();
            menuTime120 = new ToolStripMenuItem();
            menuTime180 = new ToolStripMenuItem();

            menuGameTime.Text = "Set Game Time";
            menuTime60.Text = "60 seconds";
            menuTime120.Text = "120 seconds";
            menuTime180.Text = "180 seconds";

            menuTime60.Click += (s, e) => SetTimerDuration(60);
            menuTime120.Click += (s, e) => SetTimerDuration(120);
            menuTime180.Click += (s, e) => SetTimerDuration(180);

            menuGameTime.DropDownItems.AddRange(new ToolStripItem[] {
                menuTime60,
                menuTime120,
                menuTime180
            });

            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                menuViewHighScores,
                menuExportStats,
                menuGameTime
            });

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;


            string playerName = PromptForPlayerName();
            this.currentPlayerName = playerName;

            highScoreBoard = new HighScoreBoard();
            highScoreBoard.LoadFromFile("highscores.json");

            wordDictionary = new WordDictionary();
            wordDictionary.LoadFromFile("dictionary.json");

            MessageBox.Show($"Dictionary loaded: {wordDictionary.Count} words");

            wordValidator = new WordValidator(wordDictionary);

            letterBag = new LetterBag();
            gameHistory = new GameHistory();

            roundTimer = new System.Windows.Forms.Timer();
            roundTimer.Interval = 1000;
            roundTimer.Tick += RoundTimer_Tick;

            HookLetterButtons();

        }

        private void SetTimerDuration(int seconds)
        {
            roundTimeLimit = seconds;
            currentTimeRemaining = seconds;

            timerLabel.Text = $"Time Left: {seconds}s";

            MessageBox.Show($"Game timer set to {seconds} seconds.",
                "Timer Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void StartNewRound()
        {
            currentLetters = letterBag.GetSevenRandomLetters();
            currentTimeRemaining = roundTimeLimit;

            currentRound = new GameRound(currentLetters, roundTimeLimit, currentPlayerName);

            DisplayLetters();
            ResetLetterButtons();
            UpdateTimerLabel();

            attemptsGrid.Rows.Clear();
            invalidListBox.Items.Clear();

            roundTimer.Start();
        }


        private void DisplayLetters()
        {
            if (currentLetters == null) return;

            letterButton1.Text = currentLetters[0].ToString();
            letterButton2.Text = currentLetters[1].ToString();
            letterButton3.Text = currentLetters[2].ToString();
            letterButton4.Text = currentLetters[3].ToString();
            letterButton5.Text = currentLetters[4].ToString();
            letterButton6.Text = currentLetters[5].ToString();
            letterButton7.Text = currentLetters[6].ToString();
        }

        private void RoundTimer_Tick(object? sender, EventArgs e)
        {
            currentTimeRemaining--;
            UpdateTimerLabel();

            if (currentTimeRemaining <= 0)
            {
                roundTimer.Stop();
                EndRound();
            }
        }

        private void UpdateTimerLabel()
        {
            timerLabel.Text = $"Time Left: {currentTimeRemaining}s";
        }
        
        private void TwistLetters()
        {
            if (currentLetters == null || currentLetters.Length != 7)
                return;

            letterBag.Shuffle(currentLetters);

            DisplayLetters();

            ResetLetterButtons();

            wordInputTextBox.Text = "";
        }

        private void SubmitWord()
        {
            if (currentRound == null)
                return;

            if (currentLetters == null)
            {
                MessageBox.Show("No letters available — start a new round.", "Error");
                return;
            }

            string userWord = wordInputTextBox.Text;

            WordAttempt attempt = wordValidator.ValidateWord(
                userWord,
                currentLetters,
                roundTimeLimit - currentTimeRemaining,
                currentRound.Attempts
            );

            currentRound.AddAttempt(attempt);

            if (attempt is ValidWordAttempt valid)
            {
                AddAttemptToGrid(valid);
            }
            else if (attempt is InvalidWordAttempt invalid)
            {
                MessageBox.Show(
                    $"Invalid word: {invalid.Reason}",
                    "Invalid Word",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                string reasonText = InvalidWordAttempt.FormatReason(invalid.Reason);

                string entryText =
                    $"Invalid-word: {invalid.WordText} -- Time: {invalid.TimeEntered}s -- Reason: {reasonText}";

                invalidListBox.Items.Add(entryText);
            }

            wordInputTextBox.Text = "";
            ResetLetterButtons();
        }

        private void AddAttemptToGrid(WordAttempt attempt)
        {
            if (attempt is ValidWordAttempt valid)
            {
                attemptsGrid.Rows.Add(valid.WordText, valid.Score, "VALID");
            }
        }

        private void HookLetterButtons()
        {
            Button[] buttons =
            {
                letterButton1, letterButton2, letterButton3,
                letterButton4, letterButton5, letterButton6,
                letterButton7
            };

            foreach (Button btn in buttons)
            {
                btn.Click += (s, e) =>
                {
                    if (btn.Enabled)
                    {
                        wordInputTextBox.Text += btn.Text;
                        btn.Enabled = false;
                    }
                };
            }
        }

        private void EndRound()
        {
            if (currentRound == null)
                return;
            roundTimer.Stop();

            int finalScore = currentRound.GetRoundScore();
            int timeUsed = roundTimeLimit - currentTimeRemaining;

            currentRound.FinalizeRound(finalScore, timeUsed);

            gameHistory.AddRound(currentRound);

            var entry = new HighScoreEntry(currentPlayerName, finalScore, timeUsed);
            highScoreBoard.AddEntry(entry);
            highScoreBoard.SaveToFile("highscores.json");

            List<ValidWordAttempt> validAttempts = new List<ValidWordAttempt>();

            foreach (var attempt in currentRound.Attempts)
            {
                if (attempt is ValidWordAttempt v)
                    validAttempts.Add(v);
            }

            string summary = "Valid Words This Round:\n\n";

            foreach (var v in validAttempts)
            {
                summary += $"{v.WordText} – {v.Score} pts\n";
            }

            summary += $"\nTotal Score: {finalScore}";

            MessageBox.Show(summary, "Round Summary");
        }

        private void ResetLetterButtons()
        {
            Button[] buttons =
            {
                letterButton1, letterButton2, letterButton3,
                letterButton4, letterButton5, letterButton6,
                letterButton7
            };

            foreach (Button btn in buttons)
                btn.Enabled = true;
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            StartNewRound();
        }

        private void twistButton_Click(object sender, EventArgs e)
        {
            TwistLetters();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            SubmitWord();
        }

        private void menuViewHighScores_Click(object sender, EventArgs e)
        {
            HighScoreForm form = new HighScoreForm(highScoreBoard);
            form.ShowDialog();
        }

        private void menuResetScores_Click(object sender, EventArgs e)
        {

        }

        private void menuExportStats_Click(object sender, EventArgs e)
        {
            if (gameHistory == null || gameHistory.Rounds.Count == 0)
            {
                MessageBox.Show("No rounds have been played. Nothing to export.",
                    "Export Stats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Export Game Stats";
            saveDialog.Filter = "JSON File|*.json|Text File|*.txt|CSV File|*.csv";
            saveDialog.FileName = "gamestats";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StatsExportUtility.Export(gameHistory, saveDialog.FileName);
                    MessageBox.Show("Stats exported successfully!",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to export stats:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void menuTime60_Click(object sender, EventArgs e)
        {
            roundTimeLimit = 60;
            MessageBox.Show("Game time set to 60 seconds.");
            UpdateTimerLabel();
        }

        private void menuTime120_Click(object sender, EventArgs e)
        {
            roundTimeLimit = 120;
            MessageBox.Show("Game time set to 120 seconds.");
            UpdateTimerLabel();
        }

        private void menuTime180_Click(object sender, EventArgs e)
        {
            roundTimeLimit = 180;
            MessageBox.Show("Game time set to 180 seconds.");
            UpdateTimerLabel();
        }

        private string PromptForPlayerName()
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your name:",
                "Player Name",
                "Player"
            );

            if (string.IsNullOrWhiteSpace(name))
                name = "Player";

            return name;
        }
    }
}
