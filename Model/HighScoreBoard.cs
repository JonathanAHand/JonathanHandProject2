using JonathanHandProject2.Persistence;

namespace JonathanHandProject2.Model;

/// <summary>
/// Represents the full set of high score entries stored for the game.
/// This class acts as the in-memory model for all high scores and
/// provides methods for adding new entries, sorting them, clearing
/// them, and loading/saving them through the persistence layer.
///
/// The board itself does not enforce maximum size, duplicate checks,
/// or validation — it simply stores and manages whatever entries the
/// application chooses to record.
/// </summary>
public class HighScoreBoard
{
    /// <summary>
    /// The list of all high score entries currently stored
    /// in memory. Items are kept in the order they were added,
    /// unless sorting methods are explicitly called.
    /// </summary>
    public List<HighScoreEntry> Entries { get; }

    /// <summary>
    /// Creates an empty high score board with no stored entries.
    /// Entries can later be loaded from a JSON file or added one
    /// at a time through AddEntry().
    /// </summary>
    public HighScoreBoard()
    {
        Entries = new List<HighScoreEntry>();
    }

    /// <summary>
    /// Adds a new high score entry to the list.
    /// </summary>
    /// <param name="entry">The new entry being added.</param>
    public void AddEntry(HighScoreEntry entry)
    {
        Entries.Add(entry);
    }

    /// <summary>
    /// Returns a list of high score entries sorted from the highest score
    /// to the lowest score. The original list is not modified.
    /// </summary>
    /// <returns>A new list sorted by score (descending).</returns>
    public List<HighScoreEntry> GetSortedByScore()
    {
        return Entries
            .OrderByDescending(e => e.Score)
            .ToList();
    }

    /// <summary>
    /// Returns a new list sorted primarily by time taken (ascending)
    /// and secondarily by score (descending). This allows the game
    /// to highlight fast players who also performed well.
    /// </summary>
    /// <returns>A new list sorted by time, then score.</returns>
    public List<HighScoreEntry> GetSortedByTimeThenScore()
    {
        return Entries
            .OrderBy(e => e.TimeSeconds)
            .ThenByDescending(e => e.Score)
            .ToList();
    }

    /// <summary>
    /// Loads high score entries from a JSON file using the
    /// JsonHighScorePersistenceManager. If loading succeeds,
    /// the current list is cleared and replaced with the
    /// entries from the file.
    /// </summary>
    /// <param name="filePath">The path of the JSON file to load.</param>
    public void LoadFromFile(string filePath)
    {
        var manager = new JsonHighScorePersistenceManager();
        var loaded = manager.Load(filePath);

        if (loaded != null)
        {
            Entries.Clear();
            Entries.AddRange(loaded);
        }
    }

    /// <summary>
    /// Saves the current high score entries to the specified file
    /// using the JsonHighScorePersistenceManager.
    /// </summary>
    public void SaveToFile(string filePath)
    {
        var manager = new JsonHighScorePersistenceManager();
        manager.Save(Entries, filePath);
    }

    /// <summary>
    /// Removes all high score entries from the board. This is used by
    /// your "Reset High Scores" feature in the HighScoreForm.
    /// </summary>
    public void ClearAll()
    {
        Entries.Clear();
    }
}