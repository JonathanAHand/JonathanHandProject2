using JonathanHandProject2.Model;
using JonathanHandProject2.Utility;
using System.Drawing;
using System.Collections.Generic;

using System;
using System.Windows.Forms;

namespace JonathanHandProject2
{
    public partial class MainForm : Form
    {
        private LetterBag letterBag;
        private WordDictionary wordDictionary;
        private WordValidator wordValidator;

        private GameRound currentRound;
        private GameHistory gameHistory;

        private char[] currentLetters;
        private int roundTimeLimit = 60;
        private int currentTimeRemaining;

        private System.Windows.Forms.Timer roundTimer;

        public MainForm()
        {
            InitializeComponent();

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

        private void StartNewRound()
        {
            currentLetters = letterBag.GetSevenRandomLetters();
            currentTimeRemaining = roundTimeLimit;

            currentRound = new GameRound(currentLetters, roundTimeLimit);

            DisplayLetters();
            ResetLetterButtons();
            UpdateTimerLabel();

            attemptsGrid.Rows.Clear();
            roundTimer.Start();
        }

        private void DisplayLetters()
        {
            letterButton1.Text = currentLetters[0].ToString();
            letterButton2.Text = currentLetters[1].ToString();
            letterButton3.Text = currentLetters[2].ToString();
            letterButton4.Text = currentLetters[3].ToString();
            letterButton5.Text = currentLetters[4].ToString();
            letterButton6.Text = currentLetters[5].ToString();
            letterButton7.Text = currentLetters[6].ToString();
        }

        private void RoundTimer_Tick(object sender, EventArgs e)
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
            timerLabel.Text = $"Time: {currentTimeRemaining}s";
        }

        private void TwistLetters()
        {
            letterBag.Shuffle(currentLetters);
            DisplayLetters();
        }

        private void SubmitWord()
        {
            if (currentRound == null)
                return;

            string userWord = wordInputTextBox.Text;

            WordAttempt attempt = wordValidator.ValidateWord(
                userWord,
                currentLetters,
                roundTimeLimit - currentTimeRemaining,
                currentRound.Attempts
            );

            currentRound.AddAttempt(attempt);
            AddAttemptToGrid(attempt);

            wordInputTextBox.Text = "";
            ResetLetterButtons();
        }

        private void AddAttemptToGrid(WordAttempt attempt)
        {
            if (attempt is ValidWordAttempt valid)
            {
                attemptsGrid.Rows.Add(valid.WordText, valid.Score, "VALID");
            }
            else if (attempt is InvalidWordAttempt invalid)
            {
                attemptsGrid.Rows.Add(invalid.WordText, 0, invalid.Reason.ToString());
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
            gameHistory.AddRound(currentRound);
            MessageBox.Show($"Round Over!\nScore: {currentRound.GetRoundScore()}");
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
    }
}
