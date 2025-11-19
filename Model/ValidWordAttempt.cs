namespace JonathanHandProject2.Model
{
    internal class ValidWordAttempt : WordAttempt
    {
        public int Score { get; }

        public ValidWordAttempt(string wordText, int submittedTime, int score)
            : base(wordText, submittedTime)
        {
            Score = score;
        }
    }
}