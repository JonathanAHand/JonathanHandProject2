namespace JonathanHandProject2.Model
{
    public class InvalidWordAttempt : WordAttempt
    {
        public InvalidReason Reason { get; private set; }

        public InvalidWordAttempt(string wordText, int timeEntered, InvalidReason reason)
            : base(wordText, timeEntered)
        {
            Reason = reason;
        }
    }
}