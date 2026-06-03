// Question 
// Given an encoded string, return its decoded string. 
// The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times.

// #stack

// works only for some cases of non nested count and strings, except - 3[a2[c]] 
public string DecodeString(string s)
{
    var output = new StringBuilder();
    string count = ""; string t = "";

    int i = 0;
    while (i < s.Length)
    {
        if (char.IsDigit(s[i]))
            count = count + s[i];

        else if (char.IsLetter(s[i])) t = t + s[i];
        else if (s[i] == ']')
        {
            int repeat = count != "" ? int.Parse(count) : 1;

            for (int j = 0; j < repeat; j++)
            {
                output.Append(t);
            }
            Console.WriteLine("Count - " + repeat + ", string - " + t);

            count = "";
            t = "";
        }
        i++;
    }

    if (t != "")
    {
        output.Append(t);
    }

    return output.ToString();
}


// Main solution using stack, works for all cases
public string DecodeString(string s)
{
    var stack = new Stack<char>();
    int n; string t = "";

    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] != ']')
            stack.Push(s[i]);
        else
        {
            t = GetString(stack);
            n = GetCount(stack);
            ExpandAndPush(stack, t, n);
        }
    }

    return new string(stack.Reverse().ToArray());
}

string GetString(Stack<char> stack)
{
    var s = new StringBuilder();

    while (stack.Count > 0 && stack.Peek() != '[')
    {
        s.Insert(0, stack.Pop());
    }

    stack.Pop();

    return s.ToString();
}

int GetCount(Stack<char> stack)
{
    var count = new StringBuilder();

    while (stack.Count > 0 && char.IsDigit(stack.Peek()))
    {
        count.Insert(0, stack.Pop());
    }

    return count.Length != 0 ? int.Parse(count.ToString()) : 1;
}

void ExpandAndPush(Stack<char> stack, string s, int n)
{
    for (int i = 0; i < n; i++)
    {
        foreach (char c in s)
        {
            stack.Push(c);
        }
    }
}