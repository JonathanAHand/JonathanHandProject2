using System.Text.Json;

namespace JonathanHandProject2.Utility;

/// <summary>
/// Represents a dictionary of valid English words used by the game.
/// The dictionary is loaded from the external `dictionary.json` file
/// at program startup. Words are stored in a HashSet for fast lookup.
///
/// This class allows the game to determine whether a player's
/// submitted word is a real dictionary word.
/// </summary>
public class WordDictionary
{
    /// <summary>
    /// Stores all unique dictionary words in lowercase form
    /// for fast O(1) lookup.
    /// </summary>
    private HashSet<string> dictionaryWords = new HashSet<string>();

    /// <summary>
    /// Gets the total number of dictionary words currently loaded.
    /// </summary>
    public int Count => dictionaryWords.Count;

    /// <summary>
    /// Helper class that matches the JSON schema in dictionary.json.
    /// Each object in the file looks like:
    /// {
    ///   "letter": "a",
    ///   "words": [ "able", "apple", ... ]
    /// }
    ///
    /// This class is *only* for JSON deserialization.
    /// </summary>
    private class Entry
    {
        public string? letter { get; set; }
        public List<string>? words { get; set; }
    }

    /// <summary>
    /// Loads all words from the specified dictionary.json file.
    /// Words from all letter groups are flattened into a single
    /// HashSet<string> for fast membership checking.
    ///
    /// Throws FileNotFoundException if the dictionary file is missing.
    /// </summary>
    public void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Dictionary file not found.", filePath);

        string jsonText = File.ReadAllText(filePath);

        List<Entry>? entries = JsonSerializer.Deserialize<List<Entry>>(jsonText);

        dictionaryWords =
            entries?
                .Where(e => e.words != null)
                .SelectMany(e => e.words!)
                .Select(w => w.ToLowerInvariant())
                .Distinct()
                .ToHashSet()
            ?? new HashSet<string>();
    }

    /// <summary>
    /// Returns true if the given word exists in the dictionary.
    /// Comparison is case-insensitive.
    /// </summary>
    public bool Contains(string word)
    {
        return dictionaryWords.Contains(word.ToLowerInvariant());
    }
}