// Question - 
// Given an array of characters, for each group of repeating characters -
// Append the character followed by the group's length (no count if length is 1)
// Example AAABBCDD - A3B2CD2

// #compression

// You have to do it in place, so try to get count seperately and convert it to string
// Two solution - one with simpler number to string conversion for multiple digits
// Time - O(n), Space - O(1)
public int Compress(char[] chars)
{
    int current = 0;
    for (int i = 0; i < chars.Length;)
    {
        int j = i + 1;
        while (j < chars.Length && chars[i] == chars[j]) j++;

        current = AppendWithCount(chars, current, i, j - i);
        // current = addCount(chars, current, i, j - i);

        i = j;
    }

    return current;
}

private int AppendWithCount(char[] chars, int current, int i, int count)
{
    chars[current] = chars[i];
    current++;

    if (count == 1) return current;

    string digits = count.ToString();

    foreach (char c in digits)
    {
        chars[current] = c;
        current++;
    }

    return current;
}

// Not the best, tried to use stack to convert count more than 1 digit to string.
private int addCount(char[] chars, int current, int i, int count)
{
    chars[current] = chars[i];
    current++;

    if (count == 1) return current;

    Stack<int> stack = new Stack<int>();

    while (count > 0)
    {
        int digit = count % 10;
        count = count / 10;
        stack.Push(digit);
    }

    while (stack.Count != 0)
    {
        chars[current] = (char)('0' + stack.Pop());
        current++;
    }

    return current;
}