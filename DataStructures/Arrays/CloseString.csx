// Question - 
// Two strings are close if you can transform one into the other using unlimited operations:
// Swap any characters (reorder freely), Swap character identities globally (e.g., all a ↔ all b)
// Return true if word1 can become word2, else false.

// #hashTable #charIndexArray

// Simple intuitive using set and dictionaries, go over all distinct chars and distinct counts matching
// Takes lot of time and heavy operations for dictionary
public bool CloseStrings(string word1, string word2)
{
    if (word1.Length != word2.Length) return false;

    var map1 = new int[26];
    var map2 = new int[26];

    var map1 = new Dictionary<char, int>();
    var map2 = new Dictionary<char, int>();
    char c1, c2;

    // Create two dictionaries to create map of frequency of chars
    for (int i = 0; i < word1.Length; i++)
    {
        c1 = word1[i];
        c2 = word2[i];

        map1[c1] = map1.ContainsKey(c1) ? ++map1[c1] : 1;
        map2[c2] = map2.ContainsKey(c2) ? ++map2[c2] : 1;
    }

    // All chars set should be same and count also should be same but not necessarily of same char
    if (map1.Count != map2.Count) return false;

    foreach (char x in map1.Keys)
    {
        if (!map2.ContainsKey(x)) return false;
    }

    int[] freq1 = map1.Values.ToArray();
    Array.Sort(freq1);

    int[] freq2 = map2.Values.ToArray();
    Array.Sort(freq2);

    for (int i = 0; i < freq1.Length; i++)
    {
        if (freq1[i] != freq2[i]) return false;
    }

    return true;
}

// Improve this using char index array, easy and simple operations, still similar logic
public bool CloseStrings(string word1, string word2)
{
    if (word1.Length != word2.Length) return false;

    var map1 = new int[26];
    var map2 = new int[26];

    // Create two char map to count using char as index
    for (int i = 0; i < word1.Length; i++)
    {

        map1[word1[i] - 'a']++;
        map2[word2[i] - 'a']++;
    }

    // All chars set should be same and count also should be same but not necessarily of same char
    // Check if map1 and map2 has same non-zero count chars 
    for (int i = 0; i < map1.Length; i++)
    {
        if ((map1[i] == 0 && map2[i] != 0) || (map1[i] != 0 && map2[i] == 0)) return false;
    }

    // Sort counts and then check if each count match, not necessarily mapping to same char
    Array.Sort(map1);
    Array.Sort(map2);

    for (int i = 0; i < map1.Length; i++)
    {
        if (map1[i] != map2[i]) return false;
    }

    return true;
}