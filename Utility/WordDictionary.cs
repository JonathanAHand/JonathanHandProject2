using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JonathanHandProject2.Utility
{
    public class WordDictionary
    {
        private HashSet<string> dictionaryWords = new HashSet<string>();

        public int Count => dictionaryWords.Count;


        /// <summary>
        /// Internal helper model used only for deserializing dictionary.json.
        /// The JSON file contains an array of objects:
        /// { "letter": "a", "words": [...] }
        /// This class matches that structure.
        /// </summary>
        private class Entry
        {
            public string? letter { get; set; }
            public List<string>? words { get; set; }
        }


        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Dictionary file not found.", filePath);

            string jsonText = File.ReadAllText(filePath);

            List<Entry>? entries = JsonSerializer.Deserialize<List<Entry>>(jsonText);

            dictionaryWords = entries?
                                  .Where(e => e.words != null)
                                  .SelectMany(e => e.words!)
                                  .Select(w => w.ToLowerInvariant())
                                  .Distinct()
                                  .ToHashSet()
                              ?? new HashSet<string>();
        }


        public bool Contains(string word)
        {
            return dictionaryWords.Contains(word.ToLowerInvariant());
        }
    }
}