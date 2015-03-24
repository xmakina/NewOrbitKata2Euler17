namespace NumberWord
{
    using System.Linq;

    public class LetterCounter
    {
        /// <summary>
        /// Counts the number of letters in a string
        /// </summary>
        /// <param name="input">The string to be counted</param>
        /// <returns>The number of letters in the string</returns>
        public static int Count(string input)
        {
            // count the number of letters in the string
            var characters = input.ToCharArray();

            // ignore spaces and hyphens

            return characters.Count(character => character != ' ' && character != '-');
        }
    }
}