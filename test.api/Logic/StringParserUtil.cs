// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace test.api.Logic;

public static class StringParserUtil
{
    /// <summary>
    /// Extract the longest increasing subsequence of numbers separated by whitespaces
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string ExtractLongestSubSequence(string? input)
    {

        if (string.IsNullOrEmpty(input))
        {
            return "";
        }

        var parsed = input?.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries) ?? [];

        var numbers = new List<int>();

        foreach (var item in parsed)
        {
            if (int.TryParse(item, out var number))
            {
                numbers.Add(number);
            }
        }

        if (numbers.Count < 1) return "";

        var biggestSubsequence = Array.Empty<int>();

        for (var i = 0; i < numbers?.Count; i++)
        {
            var sequenceStart = numbers[i];
            List<int> currentSequence = [];

            currentSequence.Add(sequenceStart);

            for (var subSequenceIndex = i + 1; subSequenceIndex <= numbers?.Count; subSequenceIndex++)
            {
                // check for the right boundary
                if (subSequenceIndex >= numbers.Count)
                {
                    // skip last iterations on numbers
                    i = numbers.Count - 1;
                    break;
                }

                var currentSubNumber = numbers[subSequenceIndex];
                var prevSubNumber = numbers[subSequenceIndex - 1];
                if (currentSubNumber <= prevSubNumber)
                {
                    i = subSequenceIndex - 1;
                    break;
                }

                currentSequence.Add(currentSubNumber);
            }

            // sequence is considered to be more than one element
            if (currentSequence.Count > 1)
            {
                var longestSequenceSize = biggestSubsequence.Length != 0 ?
                    biggestSubsequence.Length :
                    0;

                if (currentSequence.Count > longestSequenceSize)
                {
                    biggestSubsequence = [.. currentSequence];
                }
            }
        }

        return string.Join(' ', biggestSubsequence);
    }
}
