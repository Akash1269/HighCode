// Question -
// Given a string s containing *, each * removes itself and the nearest non-* character to its left.
// Return the final string after processing all stars.

// #stack

// Using simple stack solution in one go
// For converting to string use stack operation.
public string RemoveStars1(string s)
{
    var stack = new Stack<char>();

    foreach (char c in s)
    {
        if (c != '*') stack.Push(c);
        else stack.Pop();
    }

    // var sb = new StringBuilder();
    // while(stack.Count > 0) {
    //     sb.Insert(0, stack.Pop());
    // }

    // return sb.ToString();

    return new string(stack.Reverse().ToArray());
}

// Without using stack, basically use another char array to save last value, and only move index to place new char
// Cant use param as its read only
public string RemoveStars(string s)
{
    var ch = new char[s.Length];
    int index = 0;

    foreach (char c in s)
    {
        if (c != '*')
        {
            ch[index] = c;
            index++;
        }
        else
        {
            index--;
        }
    }

    // length is index, because index is already +1 due to last added.
    return new string(ch, 0, index);
}