namespace JonathanHandProject2.Model
{
    public class ValidWordAttempt : WordAttempt
    {
        public int Score { get; private set; }

        public ValidWordAttempt(string wordText, int timeEntered, int score)
            : base(wordText, timeEntered)
        {
            Score = score;
        }
    }
}