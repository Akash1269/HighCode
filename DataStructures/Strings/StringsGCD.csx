// Question - 
// For two strings s and t, we say "t divides s" if and only if s = t + t + t + ... + t + t (i.e., t is concatenated with itself one or more times).
// Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.

// #euclid, #gcd, #knowit

// Concept - if GCD Exists it would be sure by concatenating a+b = b+a
// GCD would always exactly be length of GCD (s1.length, s2,length)
public string GcdOfStrings(string str1, string str2)
{
    if (str1 + str2 != str2 + str1)
    {
        return "";
    }

    int gcd = GCD(str1.Length, str2.Length);

    return str1.Substring(0, gcd);
}

// This for loops is not required since as it GCD of length is the length of GCD string also
// It is not possible to have any other length smaller, even if smaller repeating pattern exist, its not longest
public string GcdOfStringsInLoop(string str1, string str2) {
        if(str1 + str2 != str2 + str1) {
            return "";
        }

        int gcd = GCD(str1.Length, str2.Length);

        for(int i = gcd; i > 0; i--) { 
            if (str1.Substring(0, i) == str2.Substring(0, i)){
                return str1.Substring(0, i);
            }
        }

        return "";
    }
 
// Euclid's algorithm - Repeatedly replace the bigger problem with the remainder.
// Even among x and y any can be bigger, since in next loop it will get swapped
public int GCD(int x, int y)
{
    if (y != 0)
    {
        return GCD(y, x % y);
    }

    return x;
}