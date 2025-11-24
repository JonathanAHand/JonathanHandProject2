using JonathanHandProject2.Model;

namespace JonathanHandProject2
{
    public partial class HighScoreForm : Form
    {
        private readonly HighScoreBoard board;

        public HighScoreForm(HighScoreBoard board)
        {
            InitializeComponent();
            this.board = board;
            LoadScores();
        }

        private void LoadScores()
        {
            scoreGrid.Rows.Clear();

            foreach (var entry in board.GetSortedByScore())
            {
                scoreGrid.Rows.Add(entry.PlayerName, entry.Score, entry.TimeSeconds);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            board.ClearAll();
            scoreGrid.Rows.Clear();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HighScoreForm_Load(object sender, EventArgs e)
        {
            LoadScores();
        }

    }
}