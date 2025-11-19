namespace JonathanHandProject2.Model
{
    internal class InvalidWordAttempt : WordAttempt
    {
        public InvalidReason Reason { get; }

        public InvalidWordAttempt(string wordText, int submittedTime, InvalidReason reason)
            : base(wordText, submittedTime)
        {
            Reason = reason;
        }
    }
}