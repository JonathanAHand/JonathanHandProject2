using System;
using System.Collections.Generic;

namespace JonathanHandProject2.Utility
{
    internal class LetterBag
    {
        private List<char> bag;
        private Random random;

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

        private void AddLetters(char letter, int count)
        {
            for (int i = 0; i < count; i++)
            {
                bag.Add(letter);
            }
        }

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