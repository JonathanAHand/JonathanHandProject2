namespace JonathanHandProject2.Utility
{
    /// <summary>
    /// Represents the collection of letters available for generating
    /// random 7-letter sets for each game round. This class models a
    /// “Scrabble-like” bag of letters with weighted character frequency.
    ///
    /// Responsibilities:
    ///  - Store a weighted list of letters
    ///  - Provide a random selection of 7 letters
    ///  - Shuffle the current letters (for the Twist button)
    ///
    /// The LetterBag never removes letters from the bag; each round is
    /// independent and letters do not get consumed. This keeps gameplay
    /// consistent and simple.
    /// </summary>
    internal class LetterBag
    {
        private List<char> bag;
        private Random random;

        /// <summary>
        /// Initializes the bag with a weighted distribution of
        /// English letters similar to Scrabble frequencies.
        /// </summary>
        public LetterBag()
        {
            random = new Random();
            bag = new List<char>();

            AddLetters('e', 11);
            AddLetters('t', 9);
            AddLetters('o', 8);
            AddLetters('a', 6);
            AddLetters('i', 6);
            AddLetters('n', 6);
            AddLetters('s', 6);
            AddLetters('h', 5);
            AddLetters('r', 5);
            AddLetters('l', 4);
            AddLetters('d', 3);
            AddLetters('u', 3);
            AddLetters('w', 3);
            AddLetters('y', 3);
            AddLetters('b', 2);
            AddLetters('c', 2);
            AddLetters('f', 2);
            AddLetters('g', 2);
            AddLetters('m', 2);
            AddLetters('p', 2);
            AddLetters('v', 2);
            AddLetters('j', 1);
            AddLetters('k', 1);
            AddLetters('q', 1);
            AddLetters('x', 1);
            AddLetters('z', 1);
        }

        /// <summary>
        /// Adds a specific number of the given letter into the bag.
        /// </summary>
        private void AddLetters(char letter, int count)
        {
            for (int i = 0; i < count; i++)
                bag.Add(letter);
        }

        /// <summary>
        /// Randomly selects seven letters from the bag. Letters are chosen
        /// with replacement — meaning the bag is not depleted — ensuring
        /// consistency across rounds.
        /// </summary>
        public char[] GetSevenRandomLetters()
        {
            char[] letters = new char[7];

            for (int i = 0; i < 7; i++)
            {
                int index = random.Next(bag.Count);
                letters[i] = bag[index];
            }

            return letters;
        }

        /// <summary>
        /// Shuffles an existing array of letters in place using the
        /// Fisher–Yates shuffle algorithm. Used by the “Twist” button.
        /// </summary>
        public void Shuffle(char[] letters)
        {
            for (int i = letters.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (letters[i], letters[j]) = (letters[j], letters[i]);
            }
        }
    }
}
