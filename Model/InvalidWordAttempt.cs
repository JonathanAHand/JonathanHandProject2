namespace JonathanHandProject2.Model;

/// <summary>
/// Represents a word submission that failed validation. This class stores the
/// reason the attempt was invalid and inherits common attempt data from
/// <see cref="WordAttempt"/>.
///
/// Invalid attempts occur when the player's input violates one or more rules,
/// such as using unavailable letters, submitting a duplicate word, or entering
/// a word not found in the dictionary.
/// </summary>
public class InvalidWordAttempt : WordAttempt
{
    /// <summary>
    /// Converts an InvalidReason enum value (e.g. LettersNotAvailable)
    /// into a human-readable string ("Letters Not Available").
    ///
    /// This method is used when displaying invalid word reasons in the UI.
    /// </summary>
    /// <param name="reason">The reason the word was invalid.</param>
    /// <returns>A formatted string suitable for display.</returns>
    public static string FormatReason(InvalidReason reason)
    {
        string text = reason.ToString();

        return string.Concat(
            text.Select((c, i) => i > 0 && char.IsUpper(c) ? " " + c : c.ToString())
        );
    }

    /// <summary>
    /// The specific rule that caused the attempt to be considered invalid.
    /// </summary>
    public InvalidReason Reason { get; private set; }

    /// <summary>
    /// Creates a new invalid attempt and records the word, the time the
    /// attempt was submitted, and the rule violation that invalidated it.
    /// </summary>
    /// <param name="wordText">The text of the submitted word.</param>
    /// <param name="timeEntered">The timestamp (seconds into the round) when the word was entered.</param>
    /// <param name="reason">The rule violation.</param>
    public InvalidWordAttempt(string wordText, int timeEntered, InvalidReason reason)
        : base(wordText, timeEntered)
    {
        Reason = reason;
    }
}