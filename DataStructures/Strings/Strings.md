# Strings — Learning Doc

## 1. Basic Concepts

**String** — An immutable sequence of characters in C#. Since strings can't be modified in-place, most manipulation requires converting to `char[]` or using `StringBuilder`. Many string problems reduce to array techniques applied to characters.

### Key Properties in C#

```csharp
string s = "hello";
s.Length;              // 5
s[0];                 // 'h' — indexed access O(1)
s.ToCharArray();      // convert to mutable char[]
new string(charArr);  // convert back to string
```

### Common Operations & Complexities

| Operation | Method | Time |
|---|---|---|
| Access char by index | `s[i]` | O(1) |
| Substring | `s.Substring(start, len)` | O(len) — creates new string |
| Concatenation | `s1 + s2` | O(n + m) — creates new string |
| StringBuilder append | `sb.Append(c)` | O(1) amortized |
| Compare | `s1 == s2` | O(n) |
| Contains / IndexOf | `s.Contains(t)` | O(n × m) worst case |
| Split | `s.Split(' ')` | O(n) |
| char check | `char.IsDigit()`, `char.IsLetter()`, `char.ToLower()` | O(1) |

### Key Terminology

| Term | Meaning |
|---|---|
| Substring | Contiguous slice of the string |
| Subsequence | Characters in order but not necessarily contiguous |
| Palindrome | Reads the same forward and backward |
| Anagram | Same characters, different arrangement |
| Prefix / Suffix | Beginning / ending portion of a string |
| GCD of strings | Longest string `x` that divides both strings by repetition |

### Immutability Note

Strings in C# are **immutable** — every modification creates a new string. For in-place work:
- Convert to `char[]`, modify, convert back: `new string(chars)`
- Use `StringBuilder` for incremental building (avoids O(n²) repeated concatenation)

---

## 2. Pattern Summary

1. **"Slide a fixed-size window and track a character property count"** — Sliding Window on Strings
   - Use when: Finding the max/min of a property (vowel count, distinct chars, etc.) in all substrings of length K.
   - Think: "Can I add the new char's contribution and subtract the old char's contribution as the window moves?"

2. **"Swap matching characters from both ends toward the center"** — Two Pointers (Opposite Ends) on Strings
   - Use when: Reversing or rearranging specific characters (vowels, letters) while leaving others in place.
   - Think: "Do I need to find matching characters from both ends and swap them inward?"

3. **"Walk backward (or use split-reverse) to reverse word order"** — Reverse Traversal / Word Reversal
   - Use when: Reversing the order of words (not characters) in a sentence.
   - Think: "Can I identify word boundaries and reassemble in reverse order?"

4. **"Walk through groups of repeating characters and encode them in-place"** — Run-Length Encoding / In-Place Compression
   - Use when: Compressing consecutive duplicate characters into character + count, modifying the array in-place.
   - Think: "Can I use a read pointer to count runs and a write pointer to place results?"

5. **"Reduce the problem to a known math property of the strings"** — Mathematical Reduction (GCD / Concatenation Check)
   - Use when: The problem involves repeating patterns, divisibility of strings, or structural properties checkable by concatenation.
   - Think: "Is there a mathematical shortcut (GCD, modulo, concatenation identity) that avoids brute-force checking?"

---

## 3. Pattern Deep Dives

### Pattern 1: Sliding Window on Strings

**Concept:** Initialize a window of size K by counting the target property in the first K characters. Then slide: add the new entering character's contribution, subtract the exiting character's contribution, and update the best result. Each character is processed at most twice (enter + exit).

**Template:**
```csharp
public int MaxPropertyInWindow(string s, int k)
{
    int count = 0, maxCount = 0;

    // Initialize first window
    for (int i = 0; i < k; i++)
        if (HasProperty(s[i])) count++;

    maxCount = count;

    // Slide the window
    for (int i = k; i < s.Length; i++)
    {
        if (HasProperty(s[i])) count++;       // new char enters
        if (HasProperty(s[i - k])) count--;   // old char exits
        maxCount = Math.Max(maxCount, count);
    }

    return maxCount;
}
```

**Key Insight:** By maintaining a running count and adjusting only at the edges, each window transition is O(1) — the entire string is processed in O(n) regardless of K.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [MaxVowelsInSubString.csx](./MaxVowelsInSubString.csx) | Max vowels in any substring of length K | Property = `IsVowel(c)`; count vowels entering/exiting the window |

---

### Pattern 2: Two Pointers (Opposite Ends) on Strings

**Concept:** Convert the string to a `char[]` for mutability. Place pointers at start and end. Move each pointer inward, skipping characters that don't match the target criteria. When both point at valid targets, swap them and advance both.

**Template:**
```csharp
public string SwapTargetCharsFromEnds(string s)
{
    char[] chars = s.ToCharArray();
    int left = 0, right = chars.Length - 1;

    while (left < right)
    {
        if (!IsTarget(chars[left])) left++;
        else if (!IsTarget(chars[right])) right--;
        else
        {
            char temp = chars[left];
            chars[left] = chars[right];
            chars[right] = temp;
            left++;
            right--;
        }
    }

    return new string(chars);
}
```

**Key Insight:** By skipping non-target characters, you reverse only the target characters' positions while all other characters stay exactly where they were.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [ReverseVowels.csx](./ReverseVowels.csx) | Reverse only vowels in a string | Target = vowels (a, e, i, o, u, both cases); skip consonants |

---

### Pattern 3: Reverse Traversal / Word Reversal

**Concept:** To reverse word order, traverse the string from the end. Identify each word's boundaries (sequence of non-space characters), extract it, and append to the result. This naturally produces words in reverse order. Skip multiple spaces between words.

**Template:**
```csharp
public string ReverseWordOrder(string s)
{
    var sb = new StringBuilder();

    for (int i = s.Length - 1; i >= 0; i--)
    {
        // Find end of a word (skip trailing spaces)
        if (s[i] == ' ') continue;

        int end = i;
        while (i >= 0 && s[i] != ' ') i--;
        // i is now at space before the word (or -1)

        sb.Append(s, i + 1, end - i);
        sb.Append(' ');
    }

    sb.Length--; // remove trailing space
    return sb.ToString();
}
```

**Key Insight:** Traversing right-to-left reverses word order, while each word's characters remain in the correct left-to-right sequence because you extract them as a substring.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [ReverseWords.csx](./ReverseWords.csx) | Reverse word order in sentence | Also handles multiple spaces between words; two approaches shown (backward scan vs. split to list) |

---

### Pattern 4: Run-Length Encoding / In-Place Compression

**Concept:** Use a read pointer to scan groups of consecutive identical characters, counting the run length. Use a separate write pointer to place the character and its count digits back into the array. The write pointer always stays behind or at the read pointer, so in-place modification is safe.

**Template:**
```csharp
public int CompressInPlace(char[] chars)
{
    int write = 0;

    for (int read = 0; read < chars.Length;)
    {
        char current = chars[read];
        int count = 0;

        // Count the run
        while (read < chars.Length && chars[read] == current)
        {
            read++;
            count++;
        }

        // Write character
        chars[write++] = current;

        // Write count (only if > 1)
        if (count > 1)
        {
            foreach (char digit in count.ToString())
                chars[write++] = digit;
        }
    }

    return write; // new length
}
```

**Key Insight:** The write pointer never overtakes the read pointer because the compressed form is always ≤ the original length (a single char stays as-is; runs like `aaa` become `a3` which is shorter).

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [StringCompression.csx](./StringCompression.csx) | Compress `AAABBCDD` → `A3B2CD2` in-place | Multi-digit counts handled via `count.ToString()` or manual stack-based digit extraction |

---

### Pattern 5: Mathematical Reduction (GCD / Concatenation Check)

**Concept:** Instead of brute-force checking all possible divisor strings, use a mathematical shortcut. If a GCD string exists, then `str1 + str2 == str2 + str1` (concatenation commutes). The GCD string's length is exactly `GCD(len1, len2)` — Euclid's algorithm applied to string lengths.

**Template:**
```csharp
public string GcdOfStrings(string str1, string str2)
{
    // Quick check: if GCD exists, concatenation must commute
    if (str1 + str2 != str2 + str1)
        return "";

    // GCD of lengths gives the answer length
    int gcdLen = GCD(str1.Length, str2.Length);
    return str1.Substring(0, gcdLen);
}

private int GCD(int a, int b)
{
    return b == 0 ? a : GCD(b, a % b);
}
```

**Key Insight:** If `s1 + s2 == s2 + s1`, a common repeating unit must exist, and its length is always `GCD(|s1|, |s2|)` — no need to check shorter candidates.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [StringsGCD.csx](./StringsGCD.csx) | Largest string X dividing both str1 and str2 | Concatenation commutativity as existence check; Euclid's algorithm for length |

---

## 4. Additional Interview Patterns (Not Yet Practiced)

*Based on general knowledge of common LeetCode/interview patterns for strings, not found in the analyzed files.*

1. **"Expand outward from each center to find the longest mirror"** — Palindrome Expansion (Expand Around Center)
   - Use when: Finding longest palindromic substring, counting palindromic substrings.
   - Think: "Can I try each position (and between positions) as a center and expand while chars match?"
   - Example problems: Longest Palindromic Substring, Palindromic Substrings, Valid Palindrome II

2. **"Slide a variable window and track char frequencies to find valid substrings"** — Variable Sliding Window with HashMap
   - Use when: Finding shortest/longest substring containing all required characters, or with at most K distinct chars.
   - Think: "Can I expand right to satisfy a condition, then shrink left to minimize?"
   - Example problems: Minimum Window Substring, Longest Substring Without Repeating Characters, Longest Substring with At Most K Distinct Characters

3. **"Sort or count characters to check if two strings are rearrangements"** — Anagram Detection / Frequency Comparison
   - Use when: Checking anagrams, grouping anagrams, finding anagram substrings.
   - Think: "Do I just need the same character counts regardless of order?"
   - Example problems: Valid Anagram, Group Anagrams, Find All Anagrams in a String

4. **"Build a prefix function to skip redundant comparisons during matching"** — KMP / Pattern Matching
   - Use when: Finding occurrences of a pattern in a text efficiently, or finding repeated prefix-suffix patterns.
   - Think: "Can I precompute how far to jump back on a mismatch instead of restarting?"
   - Example problems: Implement strStr(), Repeated Substring Pattern, Shortest Palindrome

5. **"Use a trie to efficiently store and search among many strings"** — Trie (Prefix Tree)
   - Use when: Autocomplete, prefix matching, word search in a dictionary, or spell checking.
   - Think: "Am I searching for prefixes or matching among a large set of strings?"
   - Example problems: Implement Trie, Word Search II, Design Search Autocomplete

---

## 5. Problem Difficulty Progression

| # | Problem | File | Difficulty | Key Pattern |
|---|---|---|---|---|
| 1 | Reverse Vowels | [ReverseVowels.csx](./ReverseVowels.csx) | Easy | Two Pointers (Opposite Ends) |
| 2 | GCD of Strings | [StringsGCD.csx](./StringsGCD.csx) | Easy | Mathematical Reduction (GCD) |
| 3 | Reverse Words | [ReverseWords.csx](./ReverseWords.csx) | Medium | Reverse Traversal |
| 4 | Max Vowels in Substring | [MaxVowelsInSubString.csx](./MaxVowelsInSubString.csx) | Medium | Sliding Window |
| 5 | String Compression | [StringCompression.csx](./StringCompression.csx) | Medium | Run-Length Encoding (In-Place) |

---

## 6. Quick Reference: When to Use What

| Signal / Situation | Pattern | Why |
|---|---|---|
| "Max/min property in all substrings of length K" | Sliding Window (fixed) | O(1) update per slide step |
| "Reverse only specific chars (vowels, digits)" | Two Pointers (opposite ends) | Skip non-targets, swap targets inward |
| "Reverse word order, not character order" | Reverse Traversal | Right-to-left scan preserves each word's chars |
| "Compress consecutive duplicates in-place" | Run-Length Encoding (read/write pointers) | Write pointer stays behind read; safe in-place |
| "Find repeating unit / divisor string" | GCD + Concatenation Check | Math shortcut avoids brute-force divisor search |
| "Longest palindromic substring" | Expand Around Center | Try each center, expand outward |
| "Shortest substring containing all target chars" | Variable Sliding Window + HashMap | Expand right to satisfy, shrink left to minimize |
| "Check if strings are anagrams" | Frequency Count / Sort | Same chars regardless of arrangement |
| "Find pattern in text efficiently" | KMP / Prefix Function | Precomputed jumps avoid redundant comparisons |
| "Search among many strings by prefix" | Trie | Shared prefix structure, O(L) lookup |
