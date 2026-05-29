# Data Structures — Interview Prep

A collection of interview prep questions organized by topic. Each file is self-contained and runnable via `dotnet script`.

```powershell
dotnet script Arrays/TwoSum.csx
```

---

## Arrays

| File | Question | Tags |
|---|---|---|
| [CanPlaceFlowers.csx](Arrays/CanPlaceFlowers.csx) | Place `n` flowers in a flowerbed without adjacent flowers | `#greedy` |
| [ContainerWithMostWater.csx](Arrays/ContainerWithMostWater.csx) | Find two lines forming a container that holds the most water | `#twoPointer` |
| [IncreasingTripletSubsequence.csx](Arrays/IncreasingTripletSubsequence.csx) | Check if an increasing triplet subsequence exists in array | `#subSequence` |
| [IsSubsequence.csx](Arrays/IsSubsequence.csx) | Check if string `s` is a subsequence of string `t` | `#twoPointer` |
| [MaxSumPairs.csx](Arrays/MaxSumPairs.csx) | Max number of pairs whose sum equals `k` you can remove | `#hashmap` |
| [MoveZeros.csx](Arrays/MoveZeros.csx) | Move all zeros to end while maintaining relative order | `#twoPointer` |
| [ProductOfArrayExceptSelf.csx](Arrays/ProductOfArrayExceptSelf.csx) | Return array where each element is product of all others | `#bothEnds` |

---

## Strings

| File | Question | Tags |
|---|---|---|
| [ReverseVowels.csx](Strings/ReverseVowels.csx) | Reverse only the vowels in a string | `#twoPointer` `#bothEnds` |
| [ReverseWords.csx](Strings/ReverseWords.csx) | Reverse the order of words in a string | `#inPlace` |
| [StringCompression.csx](Strings/StringCompression.csx) | Compress repeating characters with count (e.g. `AAAB` → `A3B`) | `#twoPointer` |
| [StringsGCD.csx](Strings/StringsGCD.csx) | Find the largest string that divides both given strings | `#euclid` `#gcd` |

---

## LinkedList

| File | Question | Tags |
|---|---|---|
| [LinkedList.csx](LinkedList/LinkedList.csx) | Full singly linked list implementation with all operations | `#linkedList` `#sentinel` `#prevPointer` |
| [LinkedListOperations.csx](LinkedList/LinkedListOperations.csx) | Additional linked list operations: sort, reverse, duplicates | `#linkedList` `#sort` `#reverse` |

---

## Tag Index

| Tag | Files |
|---|---|
| `#twoPointer` | ContainerWithMostWater, IsSubsequence, MoveZeros, ReverseVowels, StringCompression |
| `#greedy` | CanPlaceFlowers |
| `#hashmap` | MaxSumPairs |
| `#bothEnds` | ProductOfArrayExceptSelf, ReverseVowels |
| `#inPlace` | ReverseWords |
| `#gcd` `#euclid` | StringsGCD |
| `#subSequence` | IncreasingTripletSubsequence |
| `#linkedList` | LinkedList, LinkedListOperations |
| `#sentinel` | LinkedList |
| `#reverse` | LinkedListOperations |
