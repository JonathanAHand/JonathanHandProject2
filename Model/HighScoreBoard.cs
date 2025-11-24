using JonathanHandProject2.Persistence;

namespace JonathanHandProject2.Model
{
    public class HighScoreBoard
    {
        public List<HighScoreEntry> Entries { get; }

        public HighScoreBoard()
        {
            Entries = new List<HighScoreEntry>();
        }

        public void AddEntry(HighScoreEntry entry)
        {
            Entries.Add(entry);
        }

        public List<HighScoreEntry> GetSortedByScore()
        {
            return Entries
                .OrderByDescending(e => e.Score)
                .ToList();
        }

        public List<HighScoreEntry> GetSortedByTimeThenScore()
        {
            return Entries
                .OrderBy(e => e.TimeSeconds)
                .ThenByDescending(e => e.Score)
                .ToList();
        }

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

        public void SaveToFile(string filePath)
        {
            var manager = new JsonHighScorePersistenceManager();
            manager.Save(Entries, filePath);
        }

        public void ClearAll()
        {
            Entries.Clear();
        }
    }
}