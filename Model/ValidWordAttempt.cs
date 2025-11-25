namespace JonathanHandProject2.Model;

/// <summary>
/// Represents a successful word submission during a game round.
/// Stores the calculated score for the word and inherits common
/// attempt information from <see cref="WordAttempt"/>.
/// 
/// ValidWordAttempt instances are created whenever the player enters
/// a word that meets all validation rules (minimum length, correct
/// letters, exists in dictionary, and not previously played).
/// </summary>
public class ValidWordAttempt : WordAttempt
{
    /// <summary>
    /// The score awarded for the valid word, based on word length.
    /// </summary>
    public int Score { get; private set; }

    /// <summary>
    /// Initializes a new instance of a valid word attempt, storing
    /// the word text, the timestamp when the word was entered, and
    /// the score associated with the word.
    /// </summary>
    /// <param name="wordText">The valid word submitted by the player.</param>
    /// <param name="timeEntered">The timestamp (in seconds) when the word was entered.</param>
    /// <param name="score">The calculated score for this word.</param>
    public ValidWordAttempt(string wordText, int timeEntered, int score)
        : base(wordText, timeEntered)
    {
        Score = score;
    }
}