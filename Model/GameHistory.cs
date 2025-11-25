namespace JonathanHandProject2.Model;

/// <summary>
/// Represents the complete history of all rounds played during the
/// current game session. This class is responsible for storing 
/// each round as it finishes and providing basic checks for 
/// whether any rounds exist.
///
/// The GameHistory object is created once at the start of the game
/// and persists for the player's entire session. Each call to
/// AddRound() records the final state of a completed GameRound,
/// including letters used, attempts submitted, time spent, and
/// scoring data.
/// </summary>
public class GameHistory
{
    /// <summary>
    /// A list containing all completed game rounds, in the order
    /// they were played. Each element is a fully finalized 
    /// GameRound object.
    /// </summary>
    public List<GameRound> Rounds { get; }

    /// <summary>
    /// Initializes an empty GameHistory collection. The history
    /// will grow over time as each round is completed and added.
    /// </summary>
    public GameHistory()
    {
        Rounds = new List<GameRound>();
    }

    /// <summary>
    /// Adds a finished GameRound to the history. This is typically
    /// called at the end of a round when the timer expires or the 
    /// player starts a new round.
    /// </summary>
    /// <param name="round">The fully finalized GameRound to store.</param>
    public void AddRound(GameRound round)
    {
        Rounds.Add(round);
    }

    /// <summary>
    /// Returns true if at least one round has been played in the
    /// session. Used by features such as exporting stats to ensure 
    /// that there is meaningful data available.
    /// </summary>
    /// <returns>True if one or more rounds exist; otherwise false.</returns>
    public bool HasRounds()
    {
        return Rounds.Count > 0;
    }
}