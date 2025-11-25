using System.Text.Json;
using JonathanHandProject2.Model;

namespace JonathanHandProject2.Persistence
{
    /// <summary>
    /// Handles saving and loading high score data to and from a JSON file.
    /// This class is used exclusively by <see cref="HighScoreBoard"/> to
    /// persist player high scores between program sessions.
    ///
    /// The format is a simple JSON array of HighScoreEntry objects, and
    /// serialization is done through System.Text.Json.
    /// </summary>
    public class JsonHighScorePersistenceManager
    {
        /// <summary>
        /// Reads the high score JSON file from disk and converts it into a
        /// list of <see cref="HighScoreEntry"/> objects. If the file does
        /// not exist or contains invalid JSON, the method safely returns
        /// an empty list so the application can continue running normally.
        /// </summary>
        public List<HighScoreEntry> Load(string filePath)
        {
            // If file doesn't exist, return an empty list immediately.
            if (!File.Exists(filePath))
                return new List<HighScoreEntry>();

            try
            {
                string json = File.ReadAllText(filePath);

                // Deserialize into a list of entries; if null, return empty.
                return JsonSerializer.Deserialize<List<HighScoreEntry>>(json)
                       ?? new List<HighScoreEntry>();
            }
            catch
            {
                // Invalid JSON, unreadable file, permissions error, etc.
                // The program should fail gracefully—return empty list.
                return new List<HighScoreEntry>();
            }
        }

        /// <summary>
        /// Saves a list of <see cref="HighScoreEntry"/> objects to disk
        /// in formatted JSON form. Any exceptions (bad file path, write
        /// permissions, locked file, etc.) are silently ignored so the
        /// game is never allowed to crash during saving.
        /// </summary>
        public void Save(List<HighScoreEntry> entries, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, json);
            }
            catch
            {
                // Intentionally swallowing save errors.
            }
        }
    }
}
