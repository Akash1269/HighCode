// Question - 
// Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

// #twoPointer

// Simply run with two pointer single pass O(n) all chars in s has to be present in t in same order
public bool IsSubsequence(string s, string t)
{
    int sIndex = 0;
    int tIndex = 0;

    while (sIndex < s.Length && tIndex < t.Length)
    {
        if (s[sIndex] == t[tIndex]) sIndex++;
        tIndex++;
    }

    if (sIndex == s.Length) return true;

    return false;
}