using System.Text.Json;
using JonathanHandProject2.Model;

namespace JonathanHandProject2.Persistence
{
    public class JsonHighScorePersistenceManager
    {
        public List<HighScoreEntry> Load(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<HighScoreEntry>();

            try
            {
                string json = File.ReadAllText(filePath);

                return JsonSerializer.Deserialize<List<HighScoreEntry>>(json)
                       ?? new List<HighScoreEntry>();
            }
            catch
            {
                return new List<HighScoreEntry>();
            }
        }

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
                // Ignore save errors for now
            }
        }
    }
}