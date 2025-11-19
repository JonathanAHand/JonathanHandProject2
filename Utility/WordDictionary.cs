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

            // Deserialize the entire dictionary.json into Entry objects
            List<Entry>? entries = JsonSerializer.Deserialize<List<Entry>>(jsonText);

            // Flatten all word lists into a single set
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