// Qustions - 
// Given a string s, reverse only all the vowels in the string and return it.
// The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

// #twoPointer #bothEnds 

// Solution is simple just start from both ends and swap it till it meets
public string ReverseVowels(string s)
{
    int start = 0;
    int end = s.Length - 1;
    char[] cs = s.ToCharArray();

    while (start < end)
    {
        if (!IsVowel(cs[start]))
        {
            start++;
        }
        else if (!IsVowel(cs[end]))
        {
            end--;
        }
        else
        {
            char temp = cs[start];
            cs[start] = cs[end];
            cs[end] = temp;
            start++; end--;
        }
    }

    return new string(cs);
}

bool IsVowel(char c)
{
    c = char.ToLower(c);

    return c == 'a' ||
        c == 'e' ||
        c == 'i' ||
        c == 'o' ||
        c == 'u';
}