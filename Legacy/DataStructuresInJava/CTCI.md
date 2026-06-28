# CTCI in Java — Learning Doc

## 1. Overview

Solutions to **Cracking the Coding Interview** (6th Edition) Chapters 1–2, implemented in Java. Each file is self-contained and runnable with `java FileName.java` (Java 11+).

---

## 2. Arrays & Strings

### Key Concepts

| Concept | Java API | Time |
|---|---|---|
| Access char by index | `s.charAt(i)` | O(1) |
| String length | `s.length()` | O(1) |
| String → char array | `s.toCharArray()` | O(n) |
| char array → String | `new String(arr)` | O(n) |
| StringBuilder append | `sb.append(c)` | O(1) amortized |
| Substring | `s.substring(start, end)` | O(n) |
| Contains (substring) | `s.contains(t)` | O(n × m) |
| HashMap get/put | `map.getOrDefault(key, 0)` | O(1) avg |
| HashSet contains | `set.contains(val)` | O(1) avg |

### Immutability Note

Strings in Java are **immutable**. For in-place modifications, convert to `char[]`, work on it, and convert back with `new String(arr)`. For building strings incrementally, always use `StringBuilder` to avoid O(n²) repeated concatenation.

### Pattern Summary

1. **"Track what you've seen with a Set"** — HashSet for Uniqueness
   - Use when: Checking if all characters are unique, detecting duplicates
   - Think: "Have I seen this character/value before?"
   - Files: [IsUniqueChars.java](ArraysAndStrings/IsUniqueChars.java)

2. **"Count frequencies with a Map"** — HashMap Frequency Counting
   - Use when: Comparing character distributions, checking anagrams/permutations
   - Think: "Do both strings have the same character counts?"
   - Files: [IsPermutation.java](ArraysAndStrings/IsPermutation.java), [PalindromePermutation.java](ArraysAndStrings/PalindromePermutation.java)

3. **"Fill from the back to avoid overwriting"** — Reverse In-Place Fill
   - Use when: Expanding characters in-place (spaces → %20) without extra array
   - Think: "If I work backward, I won't clobber unprocessed characters"
   - Files: [URLify.java](ArraysAndStrings/URLify.java)

4. **"Two pointers at different speeds find mismatches"** — Edit Distance Check
   - Use when: Checking if strings differ by exactly one insert, delete, or replace
   - Think: "One pointer per string; on mismatch, advance the right one based on which operation"
   - Files: [OneEditAway.java](ArraysAndStrings/OneEditAway.java)

5. **"Count consecutive runs to compress"** — Run-Length Encoding
   - Use when: Compressing repeated characters into char + count
   - Think: "Walk forward counting consecutive chars, reset when char changes"
   - Files: [StringCompression.java](ArraysAndStrings/StringCompression.java)

6. **"Rotate 4 elements at a time, layer by layer"** — Matrix Layer Rotation
   - Use when: Rotating a square matrix 90° in-place
   - Think: "Each layer is a ring; rotate the 4 corresponding corners in a cycle"
   - Files: [RotateMatrix.java](ArraysAndStrings/RotateMatrix.java)

7. **"Use first row/column as markers"** — Space-Optimized Matrix Marking
   - Use when: Zeroing rows/columns without extra O(mn) storage
   - Think: "The matrix itself can store which rows/columns need zeroing"
   - Files: [ZeroMatrix.java](ArraysAndStrings/ZeroMatrix.java)

8. **"Concatenate string with itself to find rotations"** — Rotation via Concatenation
   - Use when: Checking if one string is a rotation of another
   - Think: "If s2 is a rotation of s1, then s2 is always a substring of s1+s1"
   - Files: [StringRotation.java](ArraysAndStrings/StringRotation.java)

### Pattern Deep Dives

#### Reverse In-Place Fill (URLify)

The key insight: when replacing a character with a longer sequence (space → `%20`), work **backward** so you never overwrite characters you haven't processed yet.

```
Original:  "M r J  "  (trueLength=4, extra space pre-allocated)
                  ↑ insertIndex

Step 1: arr[5] = 'J'    → "M r J J"
Step 2: arr[4] = '0'    →
Step 3: arr[3] = '2'    →
Step 4: arr[2] = '%'    → "M %20JJ"
Step 5: arr[1] = 'M'    → not needed, already in place
```

This avoids needing a second array — O(1) extra space.

#### Edit Distance Decision Tree (OneEditAway)

Given two strings, there are three possible single edits:
- **Replace**: Same length, exactly one position differs → both pointers advance together
- **Insert**: s2 is one longer, advance only s2's pointer past the extra char
- **Delete**: s1 is one longer, advance only s1's pointer past the removed char

```java
if (s1.length() > s2.length())
    i++;       // skip deleted char in s1
else if (s2.length() > s1.length())
    j++;       // skip inserted char in s2
// equal length: replacement — both advance via loop increment
```

The critical subtlety: when lengths are equal, **don't** skip either pointer. Both advance naturally, which correctly handles the replacement case.

#### Matrix Layer Rotation

For an NxN matrix rotated 90° clockwise, each element moves in a 4-element cycle:

```
top-left      →  top-right
   ↑                 ↓
bottom-left  ←  bottom-right

matrix[i][j]                 → matrix[j][n-i-1]
matrix[n-j-1][i]             → matrix[i][j]
matrix[n-i-1][n-j-1]         → matrix[n-j-1][i]
matrix[j][n-i-1]             → matrix[n-i-1][n-j-1]
```

Process layer by layer (outer ring → inner ring), with `n/2` layers total.

---

## 3. Linked Lists

### Key Concepts

| Concept | Description |
|---|---|
| Node structure | `data` + `next` pointer (singly linked) |
| Head pointer | Entry point to the list; losing it = losing the list |
| Traversal | O(n) — must walk node by node |
| Insert at head | O(1) — `newNode.next = head; head = newNode` |
| Insert at tail | O(n) — walk to end, then `last.next = newNode` |
| Delete with prev | O(1) — `prev.next = current.next` |
| Delete without prev | Copy next node's data, skip next node (can't delete last) |

### Runner (Fast/Slow) Pointer

The most important linked list technique. Two pointers traverse at different speeds:

```java
Node slow = head, fast = head;
while (fast != null && fast.next != null) {
    slow = slow.next;        // 1 step
    fast = fast.next.next;   // 2 steps
}
// When fast reaches end, slow is at middle
```

**Used in**: palindrome check (find middle), cycle detection (Floyd's), finding kth-to-last

### Pattern Summary

1. **"Track seen values with a Set to remove duplicates"** — HashSet Dedup
   - Use when: Removing duplicate values from an unsorted list
   - Think: "Have I seen this value? If yes, unlink the node"
   - Files: [RemoveDuplicates.java](LinkedLists/RemoveDuplicates.java)

2. **"Two pointers spaced k apart find the kth-to-last"** — Runner Technique (Fixed Gap)
   - Use when: Finding the kth element from the end without knowing list length
   - Think: "Advance one pointer k steps ahead, then walk both — when leader hits null, trailer is at the answer"
   - Files: [KthToLastNode.java](LinkedLists/KthToLastNode.java)

3. **"Copy next node's data to delete without head access"** — Node Swap Trick
   - Use when: Deleting a node when you only have a reference to it (not the head)
   - Think: "I can't unlink myself, but I can become my next neighbor and skip them"
   - Limitation: Cannot delete the last node
   - Files: [DeleteMiddleNode.java](LinkedLists/DeleteMiddleNode.java)

4. **"Move smaller nodes to front, larger to back"** — In-Place Partition
   - Use when: Partitioning a list around a value (all < x before all >= x)
   - Think: "Unlink the node and re-attach at head or tail based on comparison"
   - Files: [PartitionList.java](LinkedLists/PartitionList.java)

5. **"Walk both lists digit by digit with a carry"** — Digit-by-Digit Addition
   - Use when: Adding two numbers represented as linked lists
   - Think: "Process pairs of digits + carry, handle different lengths and final carry"
   - Files: [AddTwoNumbers.java](LinkedLists/AddTwoNumbers.java)

6. **"Push first half onto stack, compare with second half"** — Stack + Fast/Slow for Palindrome
   - Use when: Checking if a linked list reads the same forward and backward
   - Think: "Use fast/slow to find the middle, push first half onto stack, pop and compare with second half"
   - Files: [LinkedListPalindrome.java](LinkedLists/LinkedListPalindrome.java)

7. **"Equalize lengths, then walk in sync until pointers meet"** — Intersection Detection
   - Use when: Finding where two lists merge into one
   - Think: "Same tail? Then trim the longer list and walk both until they point to the same node"
   - Files: [ListIntersection.java](LinkedLists/ListIntersection.java)

8. **"Fast/slow pointers meet inside the loop, then reset to find the start"** — Floyd's Cycle Detection
   - Use when: Detecting if a list has a cycle and finding where it begins
   - Think: "After collision, reset slow to head and advance both by 1 — they meet at the loop start"
   - Why it works: The distance from head to loop start equals the distance from collision point to loop start (mod loop length)
   - Files: [DetectLoop.java](LinkedLists/DetectLoop.java)

### Pattern Deep Dives

#### Floyd's Cycle Detection (DetectLoop)

This is the most elegant linked list algorithm. Two phases:

**Phase 1 — Detect collision:**
```
slow moves 1 step, fast moves 2 steps
They MUST meet inside the loop (if one exists)
```

**Phase 2 — Find loop start:**
```
Reset slow to head
Advance both by 1 step
They meet at the loop entry
```

**Why Phase 2 works:**
Let `k` = distance from head to loop start, `L` = loop length.
When they first meet, slow has traveled `k + m` steps, fast has traveled `k + m + nL` steps.
Since fast moves twice as fast: `2(k + m) = k + m + nL` → `k + m = nL` → `k = nL - m`.
So walking `k` steps from the collision point wraps around to the loop start — the same distance as walking from the head.

#### Recursive vs Iterative Addition (AddTwoNumbers)

Three approaches for adding numbers as linked lists:

| Approach | Digit Order | Method | Key Idea |
|---|---|---|---|
| Iterative reverse | Least significant first | Walk both lists, sum + carry | Natural digit processing order |
| Recursive reverse | Least significant first | Recurse to build result from end | Each call handles one digit pair |
| Recursive forward | Most significant first | Pad shorter list, recurse to end first | Must pad to align digits, carry propagates back up the call stack |

The forward-order version is hardest because you need to process least-significant digits first (bottom of recursion) but build the result from most-significant (top). The `CarryResult` wrapper class propagates both the carry and the partial result node back up.

---

## 4. File Index

### Arrays & Strings

| # | File | Problem | Pattern | Complexity |
|---|---|---|---|---|
| 1.1 | [IsUniqueChars.java](ArraysAndStrings/IsUniqueChars.java) | All unique characters | HashSet | O(n) / O(n) |
| 1.2 | [IsPermutation.java](ArraysAndStrings/IsPermutation.java) | Permutation check | HashMap frequency | O(n) / O(n) |
| 1.3 | [URLify.java](ArraysAndStrings/URLify.java) | Replace spaces with %20 | Reverse fill | O(n) / O(1) |
| 1.4 | [PalindromePermutation.java](ArraysAndStrings/PalindromePermutation.java) | Palindrome permutation check | Odd count | O(n) / O(1) |
| 1.5 | [OneEditAway.java](ArraysAndStrings/OneEditAway.java) | One edit distance check | Two pointers | O(n) / O(1) |
| 1.6 | [StringCompression.java](ArraysAndStrings/StringCompression.java) | Run-length compression | Counting runs | O(n) / O(n) |
| 1.7 | [RotateMatrix.java](ArraysAndStrings/RotateMatrix.java) | 90° matrix rotation | Layer rotation | O(n²) / O(1) |
| 1.8 | [ZeroMatrix.java](ArraysAndStrings/ZeroMatrix.java) | Zero row/column on zero | Marker rows | O(mn) / O(1) |
| 1.9 | [StringRotation.java](ArraysAndStrings/StringRotation.java) | String rotation check | Concatenation | O(n) / O(n) |

### Linked Lists

| # | File | Problem | Pattern | Complexity |
|---|---|---|---|---|
| 2.1 | [RemoveDuplicates.java](LinkedLists/RemoveDuplicates.java) | Remove duplicates | HashSet | O(n) / O(n) |
| 2.2 | [KthToLastNode.java](LinkedLists/KthToLastNode.java) | Kth to last element | Two pointers + recursion | O(n) / O(1) |
| 2.3 | [DeleteMiddleNode.java](LinkedLists/DeleteMiddleNode.java) | Delete node without head | Node copy trick | O(1) / O(1) |
| 2.4 | [PartitionList.java](LinkedLists/PartitionList.java) | Partition around value | Rearrange pointers | O(n) / O(1) |
| 2.5 | [AddTwoNumbers.java](LinkedLists/AddTwoNumbers.java) | Add numbers as lists | Digit-by-digit + carry | O(n) / O(n) |
| 2.6 | [LinkedListPalindrome.java](LinkedLists/LinkedListPalindrome.java) | Palindrome check | Stack + fast/slow | O(n) / O(n) |
| 2.7 | [ListIntersection.java](LinkedLists/ListIntersection.java) | Find intersection node | Length diff + sync walk | O(n) / O(1) |
| 2.8 | [DetectLoop.java](LinkedLists/DetectLoop.java) | Find loop start | Floyd's algorithm | O(n) / O(1) |
