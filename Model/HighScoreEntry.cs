namespace JonathanHandProject2.Model
{
    public class HighScoreEntry
    {
        public string PlayerName { get; }
        public int Score { get; }
        public int TimeSeconds { get; }

        public HighScoreEntry(string playerName, int score, int timeSeconds)
        {
            PlayerName = playerName;
            Score = score;
            TimeSeconds = timeSeconds;
        }
    }
}