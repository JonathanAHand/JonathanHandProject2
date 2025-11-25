namespace JonathanHandProject2.Model;

/// <summary>
/// Represents a single round of gameplay. A GameRound tracks the
/// letters provided to the player, the time limit for the round,
/// every word attempt made, and the final scoring information once
/// the round ends.
///
/// Each round is created at the moment the player starts a new one
/// and is finalized when time runs out. After finalization, the round
/// is stored inside the GameHistory object for exporting or review.
/// </summary>
public class GameRound
{
    /// <summary>
    /// The seven letters generated for the round. These letters
    /// remain constant for the duration of the round.
    /// </summary>
    public char[] Letters { get; }

    /// <summary>
    /// The total amount of time (in seconds) the player has
    /// to complete the round.
    /// </summary>
    public int TimeLimit { get; }

    /// <summary>
    /// All word attempts made by the player during the round,
    /// stored in the order they were submitted. This includes
    /// both valid and invalid attempts.
    /// </summary>
    public List<WordAttempt> Attempts { get; }

    /// <summary>
    /// The name of the player who played this round. This is
    /// captured at the start of the round and stored for the
    /// game's history and stat exporting.
    /// </summary>
    public string PlayerName { get; }

    /// <summary>
    /// The final score for the round, calculated only after the
    /// round ends. This value is set by calling FinalizeRound().
    /// </summary>
    public int FinalScore { get; private set; }

    /// <summary>
    /// The total time the player used during the round, also set
    /// only when the round is finalized.
    /// </summary>
    public int TimeUsed { get; private set; }

    /// <summary>
    /// Creates a new GameRound using the provided letters, time limit,
    /// and the player's name. Attempts are collected during the round.
    /// </summary>
    public GameRound(char[] letters, int timeLimit, string playerName)
    {
        Letters = letters;
        TimeLimit = timeLimit;
        PlayerName = playerName;

        Attempts = new List<WordAttempt>();
    }

    /// <summary>
    /// Adds a word attempt to the round. The attempt can be valid or
    /// invalid. The order of attempts is preserved.
    /// </summary>
    /// <param name="attempt">The attempted word submitted by the player.</param>
    public void AddAttempt(WordAttempt attempt)
    {
        Attempts.Add(attempt);
    }

    /// <summary>
    /// Computes the total score for the round by summing the score
    /// of all valid word attempts. Invalid attempts are ignored.
    /// </summary>
    /// <returns>The total round score.</returns>
    public int GetRoundScore()
    {
        int total = 0;

        foreach (var attempt in Attempts)
        {
            if (attempt is ValidWordAttempt v)
            {
                total += v.Score;
            }
        }

        return total;
    }

    /// <summary>
    /// Finalizes the round by storing the final score and the time
    /// used by the player. This method is called only once at the
    /// end of the round.
    /// </summary>
    /// <param name="finalScore">The total score earned this round.</param>
    /// <param name="timeUsed">The amount of time the player used.</param>
    public void FinalizeRound(int finalScore, int timeUsed)
    {
        FinalScore = finalScore;
        TimeUsed = timeUsed;
    }
}