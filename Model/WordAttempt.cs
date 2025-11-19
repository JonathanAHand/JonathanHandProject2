namespace JonathanHandProject2.Model
{
    internal abstract class WordAttempt
    {
        public string WordText { get; }
        public int SubmittedTime { get; }

        protected WordAttempt(string wordText, int submittedTime)
        {
            WordText = wordText;
            SubmittedTime = submittedTime;
        }
    }
}