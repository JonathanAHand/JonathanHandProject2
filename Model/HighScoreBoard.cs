using System.Collections.Generic;
using System.Linq;

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

        public void ClearAll()
        {
            Entries.Clear();
        }
    }
}