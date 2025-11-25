using JonathanHandProject2.Model;

namespace JonathanHandProject2.Utility
{
    /// <summary>
    /// Validates player-submitted words during a game round.
    /// This class enforces all rules required for a submitted word
    /// to be considered valid:
    ///  - Word must be at least 3 characters
    ///  - Word must be made only from the available letters
    ///  - Word must appear in the dictionary
    ///  - Word must not have been used previously in the same round
    /// 
    /// Produces either a ValidWordAttempt or InvalidWordAttempt
    /// with an appropriate InvalidReason.
    /// </summary>
    internal class WordValidator
    {
        /// <summary>
        /// The dictionary containing all allowed real words.
        /// Loaded once from dictionary.json in MainForm.
        /// </summary>
        private readonly WordDictionary dictionary;

        public WordValidator(WordDictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        /// <summary>
        /// Converts input to lowercase and trims whitespace.
        /// Returns an empty string if input is null or whitespace.
        /// </summary>
        private string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return input.Trim().ToLower();
        }

        /// <summary>
        /// Verifies that the submitted word can be constructed
        /// from the available seven letters by consuming letters
        /// from a temporary copy of the pool.
        /// </summary>
        private bool LettersAreAvailable(string word, char[] availableLetters)
        {
            List<char> pool = new List<char>(availableLetters);

            foreach (char c in word)
            {
                if (!pool.Remove(c))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Scores words based on length.
        /// These scoring values match the project specification.
        /// </summary>
        private int CalculateScore(string word)
        {
            switch (word.Length)
            {
                case 3: return 90;
                case 4: return 160;
                case 5: return 250;
                case 6: return 360;
                case 7: return 490;
                default: return 0;
            }
        }

        /// <summary>
        /// Validates a player's submitted word.
        /// Applies all game rules in the correct order and returns
        /// either a ValidWordAttempt or InvalidWordAttempt
        /// with the correct InvalidReason assigned.
        /// </summary>
        public WordAttempt ValidateWord(
            string rawWord,
            char[] availableLetters,
            int submittedTime,
            List<WordAttempt> priorAttempts)
        {
            // Defensive check for rare edge case
            if (availableLetters == null)
            {
                return new InvalidWordAttempt(rawWord ?? "", submittedTime, InvalidReason.LettersNotAvailable);
            }

            string word = Normalize(rawWord);

            // Rule 1: length requirement
            if (word.Length < 3)
            {
                return new InvalidWordAttempt(word, submittedTime, InvalidReason.TooShort);
            }

            // Rule 2: must use only available letters
            if (!LettersAreAvailable(word, availableLetters))
            {
                return new InvalidWordAttempt(word, submittedTime, InvalidReason.LettersNotAvailable);
            }

            // Rule 3: must exist in dictionary
            if (!dictionary.Contains(word))
            {
                return new InvalidWordAttempt(word, submittedTime, InvalidReason.NotInDictionary);
            }

            // Rule 4: cannot repeat valid words within the same round
            foreach (WordAttempt attempt in priorAttempts)
            {
                if (attempt is ValidWordAttempt valid && valid.WordText == word)
                {
                    return new InvalidWordAttempt(word, submittedTime, InvalidReason.AlreadyUsed);
                }
            }

            // Word is valid → assign score and return success object
            int score = CalculateScore(word);

            return new ValidWordAttempt(word, submittedTime, score);
        }
    }
}
