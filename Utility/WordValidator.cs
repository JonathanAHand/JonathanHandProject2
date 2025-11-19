using JonathanHandProject2.Model;
using System.Collections.Generic;

namespace JonathanHandProject2.Utility
{
    internal class WordValidator
    {
        private readonly WordDictionary dictionary;

        public WordValidator(WordDictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        private string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return input.Trim().ToLower();
        }

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

        public WordAttempt ValidateWord(
            string rawWord,
            char[] availableLetters,
            int submittedTime,
            List<WordAttempt> priorAttempts)
        {
            string word = Normalize(rawWord);

            if (word.Length < 3)
            {
                return new InvalidWordAttempt(word, submittedTime, InvalidReason.TooShort);
            }

            if (!LettersAreAvailable(word, availableLetters))
            {
                return new InvalidWordAttempt(word, submittedTime, InvalidReason.LettersNotAvailable);
            }

            if (!dictionary.Contains(word))
            {
                return new InvalidWordAttempt(word, submittedTime, InvalidReason.NotInDictionary);
            }

            foreach (WordAttempt attempt in priorAttempts)
            {
                if (attempt is ValidWordAttempt valid && valid.WordText == word)
                {
                    return new InvalidWordAttempt(word, submittedTime, InvalidReason.AlreadyUsed);
                }
            }

            int score = CalculateScore(word);

            return new ValidWordAttempt(word, submittedTime, score);
        }
    }
}

