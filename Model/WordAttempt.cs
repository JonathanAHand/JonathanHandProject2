namespace JonathanHandProject2.Model;

/// <summary>
/// An abstract base class that represents a single attempt made by the player
/// during a game round. This class stores information that is shared by both
/// valid and invalid attempts, specifically:
///  - The text of the word that the player typed
///  - The timestamp (in seconds) when the word was submitted
///
/// This class is not instantiated directly. Instead, the application creates
/// either a <see cref="ValidWordAttempt"/> or an <see cref="InvalidWordAttempt"/>
/// depending on whether the player's input passes all validation rules.
///
/// It serves as a common parent type so the game can store a unified list of
/// all attempts (valid and invalid) inside each <see cref="GameRound"/>.
/// </summary>
public abstract class WordAttempt
{
    /// <summary>
    /// The word entered by the player. This value is shared across both valid
    /// and invalid attempts.
    /// </summary>
    public string WordText { get; protected set; }

    /// <summary>
    /// The in-round timestamp (in seconds) when the attempt was entered.
    /// </summary>
    public int TimeEntered { get; protected set; }

    /// <summary>
    /// Initializes the shared word and timestamp for any word attempt. Intended
    /// to be called only by subclasses such as <see cref="ValidWordAttempt"/>
    /// and <see cref="InvalidWordAttempt"/>.
    /// </summary>
    protected WordAttempt(string wordText, int timeEntered)
    {
        WordText = wordText;
        TimeEntered = timeEntered;
    }
}