using System.Text;

namespace Challenge;

public class WordWrapChallenge
{
    public string Wrap(string message, int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException($"The provided value was {length} which is a non positive number");
        }

        if (message.Length < length)
        {
            return message;
        }

        var words = message.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var currentLineLength = 0;
        var result = new StringBuilder();

        foreach (var word in words)
        {
            var currentWordLength = word.Length;
            // Handle case where we can fit the word within the line with a space 
            if (currentWordLength < length - currentLineLength - 1)
            {
                result.Append(word + " ");
                currentLineLength += currentWordLength + 1;
            }
            // Handle cases where the current word's length exceeds both the remaining line space as well as the
            // length limit.  
            else
            {
                // Ensure at all times that we do not have a space present when processing words that exceed line limits.  
                if (currentLineLength + currentWordLength > length && result.Length > 0 &&
                    result[result.Length - 1] == ' ')
                {
                    result = result.Remove(result.Length - 1, 1);
                    result.Append("\n");
                }

                //Handle cases where we must split the word or add with no space. Add newline in all cases with the final
                //newline in the string removed when returning the result.
                var startOfWordIndex = 0;
                while (word.Substring(startOfWordIndex, currentWordLength - startOfWordIndex).Length > length)
                {
                    result.Append(word.Substring(startOfWordIndex, length) + "\n");
                    startOfWordIndex += length;
                }

                result.Append(word.Substring(startOfWordIndex, currentWordLength - startOfWordIndex) + "\n");
                currentLineLength = 0;
            }
        }

        return result.ToString().Remove(result.Length - 1);
    }
}