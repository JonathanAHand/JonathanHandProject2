namespace JonathanHandProject2.Model
{
    public abstract class WordAttempt
    {
        public string WordText { get; protected set; }
        public int TimeEntered { get; protected set; }

        protected WordAttempt(string wordText, int timeEntered)
        {
            WordText = wordText;
            TimeEntered = timeEntered;
        }
    }
}