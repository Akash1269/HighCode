// Question - 
// Given an input string s, reverse the order of the words.
// A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.

// #inPlace 

// Do in single pass without list, but string builder is still needed
// Traverse from end pick a word and append using
// Space - O(n), Time - O(n)

public string ReverseWords(string s)
{
    var sb = new StringBuilder();

    for (int i = s.Length - 1; i >= 0; i--)
    {
        int left = i;

        while (left >= 0 && s[left] != ' ')
        {
            left--;
        }

        if (left != i)
        {
            sb.Append(s.Substring(left + 1, i - left));
            sb.Append(' ');

            i = left;
        }
    }

    sb.Length--;

    return sb.ToString();
}

// Store words in list and then create new string from appending list in reverse order
// Space - O(n), Time - O(n)
public class Solution {
    public string ReverseWords(string s) {
        var list = new List<string>();
        var sb = new StringBuilder();

        for(int i = 0; i < s.Length; i++) {
            if (s[i] != ' ') {
                sb.Append(s[i]);
            } else if (sb.Length > 0) {
                list.Add(sb.ToString());
                sb.Clear();
            }
        }

        if(sb.Length > 0) {
            list.Add(sb.ToString());
        }

        sb.Clear();
        for(int i = list.Count - 1; i >= 0; i--){
            sb.Append(list[i] + " ");
        }

        sb.Length--;
        return sb.ToString();
    }
}