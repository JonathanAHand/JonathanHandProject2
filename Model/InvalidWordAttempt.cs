namespace JonathanHandProject2.Model
{
    internal class InvalidWordAttempt : WordAttempt
    {
        public string Reason { get; }

        public InvalidWordAttempt(string wordText, int submittedTime, string reason)
            : base(wordText, submittedTime)
        {
            Reason = reason;
        }
    }
}