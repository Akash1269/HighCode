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
| [CloseString.csx](Arrays/CloseString.csx) | Check if two strings are close (reorder/swap char identities) | `#hashTable` `#charIndexArray` |
| [ContainerWithMostWater.csx](Arrays/ContainerWithMostWater.csx) | Find two lines forming a container that holds the most water | `#twoPointer` |
| [DifferenceBetweenTwoArrays.csx](Arrays/DifferenceBetweenTwoArrays.csx) | Find distinct integers in each array not present in the other | `#hashMap` |
| [EqualRowColPairsMatrics.csx](Arrays/EqualRowColPairsMatrics.csx) | Count pairs where row `ri` and column `cj` are equal | `#matrix` |
| [FidPivotIndex.csx](Arrays/FidPivotIndex.csx) | Find pivot index where left sum equals right sum | `#prefixSum` |
| [HighestAltitude.csx](Arrays/HighestAltitude.csx) | Find the highest altitude reached during a road trip | `#prefixSum` |
| [IncreasingTripletSubsequence.csx](Arrays/IncreasingTripletSubsequence.csx) | Check if an increasing triplet subsequence exists in array | `#subSequence` |
| [IsSubsequence.csx](Arrays/IsSubsequence.csx) | Check if string `s` is a subsequence of string `t` | `#twoPointer` |
| [LongestSubArrayOfOnesDeleteOne.csx](Arrays/LongestSubArrayOfOnesDeleteOne.csx) | Longest subarray of 1's after deleting one element | `#slidingWindow` |
| [MaxAvgSubArray1.csx](Arrays/MaxAvgSubArray1.csx) | Find contiguous subarray of length `k` with max average | `#slidingWindow` |
| [MaxConsecutivesOnesIII.csx](Arrays/MaxConsecutivesOnesIII.csx) | Max consecutive 1's if you can flip at most `k` zeros | `#slidingWindow` |
| [MaxSumPairs.csx](Arrays/MaxSumPairs.csx) | Max number of pairs whose sum equals `k` you can remove | `#hashmap` |
| [MoveZeros.csx](Arrays/MoveZeros.csx) | Move all zeros to end while maintaining relative order | `#twoPointer` |
| [ProductOfArrayExceptSelf.csx](Arrays/ProductOfArrayExceptSelf.csx) | Return array where each element is product of all others | `#bothEnds` |
| [UniqueNumberOfOccurences.csx](Arrays/UniqueNumberOfOccurences.csx) | Check if number of occurrences of each value is unique | `#hashMap` |

---

## Strings

| File | Question | Tags |
|---|---|---|
| [MaxVowelsInSubString.csx](Strings/MaxVowelsInSubString.csx) | Max vowel letters in any substring of length `k` | `#slidingWindow` |
| [ReverseVowels.csx](Strings/ReverseVowels.csx) | Reverse only the vowels in a string | `#twoPointer` `#bothEnds` |
| [ReverseWords.csx](Strings/ReverseWords.csx) | Reverse the order of words in a string | `#inPlace` |
| [StringCompression.csx](Strings/StringCompression.csx) | Compress repeating characters with count (e.g. `AAAB` → `A3B`) | `#twoPointer` |
| [StringsGCD.csx](Strings/StringsGCD.csx) | Find the largest string that divides both given strings | `#euclid` `#gcd` |

---

## LinkedList

| File | Question | Tags |
|---|---|---|
| [DeleteMiddleNode.csx](LinkedList/DeleteMiddleNode.csx) | Find and delete the middle node (index n/2 ceiling) | `#linkedList` `#twoPointer` |
| [LinkedList.csx](LinkedList/LinkedList.csx) | Full singly linked list implementation with all operations | `#linkedList` `#sentinel` `#prevPointer` |
| [LinkedListOperations.csx](LinkedList/LinkedListOperations.csx) | Additional linked list operations: sort, reverse, duplicates | `#linkedList` `#sort` `#reverse` |
| [LinkedListReverse.csx](LinkedList/LinkedListReverse.csx) | Reverse a singly linked list | `#linkedList` |
| [OddEvenSeperated.csx](LinkedList/OddEvenSeperated.csx) | Separate odd and even indexed nodes in order | `#linkedList` `#twoPointer` |

---

## Stack

| File | Question | Tags |
|---|---|---|
| [AstroidCollision.csx](Stack/AstroidCollision.csx) | Return asteroids remaining after all collisions | `#stack` |
| [DecodeString.csx](Stack/DecodeString.csx) | Decode encoded string `k[encoded_string]` repeated k times | `#stack` |
| [RemoveStarFromString.csx](Stack/RemoveStarFromString.csx) | Remove stars and nearest non-star character to the left | `#stack` |

---

## Queue

| File | Question | Tags |
|---|---|---|
| [Dota2Senator.csx](Queue/Dota2Senator.csx) | Simulate senate voting to determine winning party | `#queue` |
| [RecentCall.csx](Queue/RecentCall.csx) | Count requests in the last 3000ms time window | `#queue` |

---

## Tag Index

| Tag | Files |
|---|---|
| `#twoPointer` | ContainerWithMostWater, IsSubsequence, MoveZeros, ReverseVowels, StringCompression, DeleteMiddleNode, OddEvenSeperated |
| `#greedy` | CanPlaceFlowers |
| `#hashMap` | MaxSumPairs, DifferenceBetweenTwoArrays, UniqueNumberOfOccurences |
| `#hashTable` | CloseString |
| `#bothEnds` | ProductOfArrayExceptSelf, ReverseVowels |
| `#inPlace` | ReverseWords |
| `#gcd` `#euclid` | StringsGCD |
| `#subSequence` | IncreasingTripletSubsequence |
| `#prefixSum` | FidPivotIndex, HighestAltitude |
| `#slidingWindow` | MaxAvgSubArray1, MaxConsecutivesOnesIII, LongestSubArrayOfOnesDeleteOne, MaxVowelsInSubString |
| `#matrix` | EqualRowColPairsMatrics |
| `#stack` | RemoveStarFromString, AstroidCollision, DecodeString |
| `#queue` | Dota2Senator, RecentCall |
| `#linkedList` | LinkedList, LinkedListOperations, LinkedListReverse, DeleteMiddleNode, OddEvenSeperated |
| `#sentinel` | LinkedList |
| `#reverse` | LinkedListOperations |
