using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JonathanHandProject2.Utility
{
    internal class WordDictionary
    {
        private HashSet<string> dictionaryWords;

        public WordDictionary()
        {
            dictionaryWords = new HashSet<string>();
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Dictionary file not found.", filePath);
            }

            string jsonText = File.ReadAllText(filePath);

            List<string>? words = JsonSerializer.Deserialize<List<string>>(jsonText);

            dictionaryWords = new HashSet<string>();

            if (words != null)
            {
                foreach (string word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        dictionaryWords.Add(word.Trim().ToLower());
                    }
                }
            }
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }

            return dictionaryWords.Contains(word.Trim().ToLower());
        }
    }
}