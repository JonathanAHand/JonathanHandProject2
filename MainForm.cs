using JonathanHandProject2.Model;
using JonathanHandProject2.Utility;

namespace JonathanHandProject2
{
    /// <summary>
    /// The main UI controller for the Text Twist–style application.
    /// 
    /// This form:
    /// - Starts and manages new game rounds
    /// - Displays and updates the 7 playable letter buttons
    /// - Accepts player input and validates word submissions
    /// - Tracks round time using a timer
    /// - Records valid & invalid word attempts
    /// - Manages the high-score board
    /// - Exports game statistics
    /// - Provides adjustable game time via menu options
    /// 
    /// All UI elements referenced here are created in MainForm.Designer.cs.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Generates weighted random letters for each round.
        /// </summary>
        private LetterBag letterBag;

        /// <summary>
        /// Loads all valid dictionary words from dictionary.json.
        /// </summary>
        private WordDictionary wordDictionary;

        /// <summary>
        /// Validates words according to rules:
        /// - Minimum length
        /// - Dictionary presence
        /// - Available letters
        /// - Not previously used
        /// </summary>
        private WordValidator wordValidator;

        /// <summary>
        /// The round currently being played.
        /// Stores letters, attempts, time, and score.
        /// </summary>
        private GameRound? currentRound;

        /// <summary>
        /// Tracks all rounds played for export purposes.
        /// </summary>
        private GameHistory gameHistory;

        /// <summary>
        /// The 7 letters currently available in this round.
        /// </summary>
        private char[]? currentLetters;

        /// <summary>
        /// Length of the round in seconds.
        /// Configurable via the menu.
        /// </summary>
        private int roundTimeLimit = 60;

        /// <summary>
        /// Number of seconds remaining in the current round.
        /// </summary>
        private int currentTimeRemaining;

        /// <summary>
        /// WinForms timer used to count down each second.
        /// </summary>
        private System.Windows.Forms.Timer roundTimer;

        /// <summary>
        /// High-score manager containing all saved entries.
        /// </summary>
        private HighScoreBoard highScoreBoard;

        /// <summary>
        /// The name of the currently active player.
        /// </summary>
        private string currentPlayerName;

        /// <summary>
        /// Constructs the main game form, initializes all supporting
        /// systems (dictionary, validator, letter bag, timer),
        /// configures menu options, and prompts the player for a name.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            this.AcceptButton = submitButton;
            this.StartPosition = FormStartPosition.CenterScreen;

            // -------------------------------
            // Configure Timer Menu
            // -------------------------------
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

            menuGameTime.DropDownItems.AddRange(new ToolStripItem[]
            {
                menuTime60, menuTime120, menuTime180
            });

            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                menuViewHighScores,
                menuExportStats,
                menuGameTime
            });

            var menuContinueSession = new ToolStripMenuItem();
            menuContinueSession.Text = "Continue Session";
            menuContinueSession.Click += menuContinueSession_Click;

            gameToolStripMenuItem.DropDownItems.Insert(0, menuContinueSession);

            // -------------------------------
            // Window Configuration
            // -------------------------------
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // -------------------------------
            // Player Name
            // -------------------------------
            string playerName = PromptForPlayerName();
            this.currentPlayerName = playerName;

            // -------------------------------
            // Load High Scores
            // -------------------------------
            highScoreBoard = new HighScoreBoard();
            highScoreBoard.LoadFromFile("highscores.json");

            // -------------------------------
            // Load Dictionary
            // -------------------------------
            wordDictionary = new WordDictionary();
            wordDictionary.LoadFromFile("dictionary.json");
            //MessageBox.Show($"Dictionary loaded: {wordDictionary.Count} words");

            // -------------------------------
            // Create Validator and Utility Systems
            // -------------------------------
            wordValidator = new WordValidator(wordDictionary);
            letterBag = new LetterBag();
            gameHistory = new GameHistory();

            // -------------------------------
            // Round Timer Setup
            // -------------------------------
            roundTimer = new System.Windows.Forms.Timer();
            roundTimer.Interval = 1000; // 1 second
            roundTimer.Tick += RoundTimer_Tick;

            // -------------------------------
            // Attach letter button click events
            // -------------------------------
            HookLetterButtons();
        }

        /// <summary>
        /// Adjusts the round duration based on menu selection.
        /// Updates UI and resets countdown timer.
        /// </summary>
        private void SetTimerDuration(int seconds)
        {
            roundTimeLimit = seconds;
            currentTimeRemaining = seconds;

            timerLabel.Text = $"Time Left: {seconds}s";

            MessageBox.Show($"Game timer set to {seconds} seconds.",
                "Timer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Begins a new game round by:
        /// - Generating 7 random letters
        /// - Resetting timer
        /// - Creating a new GameRound model
        /// - Clearing UI lists
        /// - Enabling buttons
        /// - Starting countdown timer
        /// </summary>
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

        /// <summary>
        /// Displays the 7 generated letters onto the UI buttons.
        /// </summary>
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

        /// <summary>
        /// Occurs each second during a round.
        /// Decrements timer, updates UI,
        /// ends round when time runs out.
        /// </summary>
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

        /// <summary>
        /// Updates the on-screen timer label with remaining seconds.
        /// </summary>
        private void UpdateTimerLabel()
        {
            timerLabel.Text = $"Time Left: {currentTimeRemaining}s";
        }

        /// <summary>
        /// Shuffles current letter order,
        /// updates UI, and resets button availability.
        /// </summary>
        private void TwistLetters()
        {
            if (currentLetters == null || currentLetters.Length != 7)
                return;

            letterBag.Shuffle(currentLetters);

            DisplayLetters();
            ResetLetterButtons();

            wordInputTextBox.Text = "";
        }

        /// <summary>
        /// Validates the player's submitted word and:
        /// - Adds valid words to the grid
        /// - Adds invalid words to the invalid list box
        /// - Updates attempt lists
        /// </summary>
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

            // Validate, including dictionary lookup, available letters,
            // and checking whether the word was previously used.
            WordAttempt attempt = wordValidator.ValidateWord(
                userWord,
                currentLetters,
                roundTimeLimit - currentTimeRemaining,
                currentRound.Attempts);

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
                    MessageBoxIcon.Warning);

                string reasonText = InvalidWordAttempt.FormatReason(invalid.Reason);

                string entryText =
                    $"Invalid-word: {invalid.WordText} -- Time: {invalid.TimeEntered}s -- Reason: {reasonText}";

                invalidListBox.Items.Add(entryText);
            }

            wordInputTextBox.Text = "";
            ResetLetterButtons();
        }

        /// <summary>
        /// Adds a valid submitted word to the attempts data grid.
        /// </summary>
        private void AddAttemptToGrid(WordAttempt attempt)
        {
            if (attempt is ValidWordAttempt valid)
            {
                attemptsGrid.Rows.Add(valid.WordText, valid.Score, "VALID");
            }
        }

        /// <summary>
        /// Hooks all letter buttons so that clicking a button
        /// appends its letter to the input textbox and disables the button.
        /// Prevents reuse of the same letter unless round resets.
        /// </summary>
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

        /// <summary>
        /// Finalizes the round:
        /// - Stops timer
        /// - Calculates final score
        /// - Saves HighScoreEntry
        /// - Adds round to GameHistory
        /// - Displays round summary popup
        /// </summary>
        private void EndRound()
        {
            if (currentRound == null)
                return;

            roundTimer.Stop();

            int finalScore = currentRound.GetRoundScore();
            int timeUsed = roundTimeLimit - currentTimeRemaining;

            currentRound.FinalizeRound(finalScore, timeUsed);

            gameHistory.AddRound(currentRound);

            // Save high score
            var entry = new HighScoreEntry(currentPlayerName, finalScore, timeUsed);
            highScoreBoard.AddEntry(entry);
            highScoreBoard.SaveToFile("highscores.json");

            // Build summary string
            List<ValidWordAttempt> validAttempts = new();

            foreach (var attempt in currentRound.Attempts)
            {
                if (attempt is ValidWordAttempt v)
                    validAttempts.Add(v);
            }

            string summary = "Valid Words This Round:\n\n";
            foreach (var v in validAttempts)
                summary += $"{v.WordText} – {v.Score} pts\n";

            summary += $"\nTotal Score: {finalScore}";

            MessageBox.Show(summary, "Round Summary");
        }

        /// <summary>
        /// Re-enables all letter buttons for the next word attempt.
        /// </summary>
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

        /// <summary>
        /// User clicked "New Game" → begins a new round.
        /// </summary>
        private void newGameButton_Click(object sender, EventArgs e)
        {
            StartNewRound();
        }

        /// <summary>
        /// User clicked "Twist" → shuffle letters.
        /// </summary>
        private void twistButton_Click(object sender, EventArgs e)
        {
            TwistLetters();
        }

        /// <summary>
        /// User clicked "Submit" → validate and record the word.
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            SubmitWord();
        }

        /// <summary>
        /// Opens the HighScoreForm dialog window.
        /// </summary>
        private void menuViewHighScores_Click(object sender, EventArgs e)
        {
            HighScoreForm form = new HighScoreForm(highScoreBoard);
            form.ShowDialog();
        }

        /// <summary>
        /// (Removed feature — intentionally left empty.)
        /// </summary>
        private void menuResetScores_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Allows user to export the GameHistory to JSON.
        /// Ensures at least one round exists before exporting.
        /// </summary>
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

        /// <summary>
        /// Sets round time to 60 seconds from the legacy handler.
        /// (Replaced by dynamic menu; kept for compatibility.)
        /// </summary>
        private void menuTime60_Click(object sender, EventArgs e)
        {
            roundTimeLimit = 60;
            MessageBox.Show("Game time set to 60 seconds.");
            UpdateTimerLabel();
        }

        /// <summary>
        /// Sets round time to 120 seconds from the legacy handler.
        /// </summary>
        private void menuTime120_Click(object sender, EventArgs e)
        {
            roundTimeLimit = 120;
            MessageBox.Show("Game time set to 120 seconds.");
            UpdateTimerLabel();
        }

        /// <summary>
        /// Sets round time to 180 seconds from the legacy handler.
        /// </summary>
        private void menuTime180_Click(object sender, EventArgs e)
        {
            roundTimeLimit = 180;
            MessageBox.Show("Game time set to 180 seconds.");
            UpdateTimerLabel();
        }

        /// <summary>
        /// Prompts the user for their name using VB's InputBox.
        /// Defaults to "Player" if empty.
        /// </summary>
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

        /// <summary>
        /// Currently unused form-load event.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Allows the user to continue from a previously exported stats file.
        /// Loads GameHistory and restores the last used time limit.
        /// </summary>
        private void menuContinueSession_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select Previously Exported Stats File";
            openDialog.Filter = "JSON File|*.json|All Files|*.*";

            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            var (loadedHistory, restoredTime) =
                StatsImportUtility.Import(openDialog.FileName, currentPlayerName);

            if (loadedHistory == null || restoredTime == null)
            {
                MessageBox.Show(
                    "Unable to load previous stats. Starting a new session with the default 60-second timer.",
                    "Continue Session",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                gameHistory = new GameHistory();
                roundTimer.Stop();
                currentRound = null;

                SetTimerDuration(60);

                attemptsGrid.Rows.Clear();
                invalidListBox.Items.Clear();
                return;
            }

            gameHistory = loadedHistory;
            currentRound = null;

            SetTimerDuration(restoredTime.Value);

            attemptsGrid.Rows.Clear();
            invalidListBox.Items.Clear();

            MessageBox.Show(
                $"Session continued. Timer restored to {restoredTime.Value} seconds.",
                "Continue Session",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }




    }
}
