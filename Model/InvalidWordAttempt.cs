namespace JonathanHandProject2.Model
{
    public class InvalidWordAttempt : WordAttempt
    {
        public static string FormatReason(InvalidReason reason)
        {
            string text = reason.ToString();

            return string.Concat(
                text.Select((c, i) => i > 0 && char.IsUpper(c) ? " " + c : c.ToString())
            );
        }

        public InvalidReason Reason { get; private set; }

        public InvalidWordAttempt(string wordText, int timeEntered, InvalidReason reason)
            : base(wordText, timeEntered)
        {
            Reason = reason;
        }
    }
}