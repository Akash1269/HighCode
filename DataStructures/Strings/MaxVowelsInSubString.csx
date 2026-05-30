// Question - 
// Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.

// #slidingWindow

// Simple intuitive solution sliding window count of vowels
public int MaxVowels(string s, int k)
{
    int maxVowelCount = 0;
    int vowelCount = 0;

    for (int i = 0; i < k; i++)
    {
        if (IsVowel(s[i])) vowelCount++;
    }

    maxVowelCount = vowelCount;
    for (int i = k; i < s.Length; i++)
    {
        // if new element is vowel, to be added
        if (IsVowel(s[i])) vowelCount++;

        // if old element was vowel, to be removed
        if (IsVowel(s[i - k])) vowelCount--;

        maxVowelCount = Math.Max(maxVowelCount, vowelCount);
    }

    return maxVowelCount;
}

bool IsVowel(char c)
{
    return c == 'a' ||
        c == 'e' ||
        c == 'i' ||
        c == 'o' ||
        c == 'u';
}