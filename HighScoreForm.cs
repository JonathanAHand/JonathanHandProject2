using JonathanHandProject2.Model;

namespace JonathanHandProject2
{
    /// <summary>
    /// A Windows Form used to display the game's high score table.
    /// This form shows all saved high scores in a grid, sorted in
    /// descending order by score.
    ///
    /// The form allows the user to:
    ///   • View all high score entries
    ///   • Reset (clear) all stored high scores
    ///   • Close the form and return to the main game window
    ///
    /// The form receives a HighScoreBoard instance from MainForm,
    /// ensuring it always displays the current and accurate high score data.
    /// </summary>
    public partial class HighScoreForm : Form
    {
        /// <summary>
        /// Reference to the shared HighScoreBoard maintained by MainForm.
        /// The board is passed into the constructor so this form never
        /// creates or owns its own data.
        /// </summary>
        private readonly HighScoreBoard board;

        /// <summary>
        /// Initializes the form, loads UI components, and immediately
        /// loads the high score data into the grid.
        /// </summary>
        public HighScoreForm(HighScoreBoard board)
        {
            InitializeComponent();
            this.board = board;
            LoadScores();
        }

        /// <summary>
        /// Clears the score grid and repopulates it with the current
        /// list of high scores in descending order.
        ///
        /// Uses the HighScoreBoard's GetSortedByScore() method to
        /// ensure consistent ordering.
        /// </summary>
        private void LoadScores()
        {
            scoreGrid.Rows.Clear();

            foreach (var entry in board.GetSortedByScore())
            {
                scoreGrid.Rows.Add(entry.PlayerName, entry.Score, entry.TimeSeconds);
            }
        }

        /// <summary>
        /// Clears all high scores from memory and also wipes them
        /// from the UI grid. This does NOT save immediately — the
        /// HighScoreBoard persists changes when MainForm triggers a save.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            board.ClearAll();
            scoreGrid.Rows.Clear();
        }

        /// <summary>
        /// Closes the form (returns to the main game).
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Ensures that whenever the form is opened (even if opened
        /// multiple times during the application), it refreshes the grid.
        /// </summary>
        private void HighScoreForm_Load(object sender, EventArgs e)
        {
            LoadScores();
        }

    }
}
