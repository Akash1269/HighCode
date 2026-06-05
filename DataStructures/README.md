# Data Structures — Interview Prep

A collection of data structure implementations and interview prep questions. Each file is self-contained and runnable via `dotnet script`.

```powershell
dotnet script Arrays/TwoSum.csx
```

> **Convention:** Files are organized by topic. Each section has two subsections:
> - **Implementation** — building the DS from scratch
> - **Problems** — LeetCode/interview questions using that DS

---

## Arrays

### Implementation

| File | Description | Tags |
|---|---|---|
| [ArrayLibrary.csx](Arrays/ArrayLibrary.csx) | Library management system using array of structs (CRUD, sort, file I/O) | `#array` `#implementation` |

### Problems

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

### Implementation

| File | Description | Tags |
|---|---|---|
| [LinkedList.csx](LinkedList/LinkedList.csx) | Full singly linked list implementation with all operations | `#linkedList` `#sentinel` `#prevPointer` |
| [LinkedListOperations.csx](LinkedList/LinkedListOperations.csx) | Additional linked list operations: sort, reverse, duplicates | `#linkedList` `#sort` `#reverse` |

### Problems

| File | Question | Tags |
|---|---|---|
| [DeleteMiddleNode.csx](LinkedList/DeleteMiddleNode.csx) | Find and delete the middle node (index n/2 ceiling) | `#linkedList` `#twoPointer` |
| [LinkedListReverse.csx](LinkedList/LinkedListReverse.csx) | Reverse a singly linked list | `#linkedList` |
| [OddEvenSeperated.csx](LinkedList/OddEvenSeperated.csx) | Separate odd and even indexed nodes in order | `#linkedList` `#twoPointer` |
| [TwinListSum.csx](LinkedList/TwinListSum.csx) | Find max sum of twin node pairs in a linked list | `#linkedList` `#twoPointer` `#stack` |

---

## Stack

### Implementation

| File | Description | Tags |
|---|---|---|
| [StackUsingArray.csx](Stack/StackUsingArray.csx) | Stack implementation using a fixed-size array | `#stack` `#implementation` |
| [StackUsingList.csx](Stack/StackUsingList.csx) | Stack implementation using a linked list | `#stack` `#implementation` |

### Problems

| File | Question | Tags |
|---|---|---|
| [AstroidCollision.csx](Stack/AstroidCollision.csx) | Return asteroids remaining after all collisions | `#stack` |
| [DecodeString.csx](Stack/DecodeString.csx) | Decode encoded string `k[encoded_string]` repeated k times | `#stack` |
| [RemoveStarFromString.csx](Stack/RemoveStarFromString.csx) | Remove stars and nearest non-star character to the left | `#stack` |

---

## Queue

### Implementation

| File | Description | Tags |
|---|---|---|
| [QueueUsingArray.csx](Queue/QueueUsingArray.csx) | Circular queue implementation using a fixed-size array | `#queue` `#implementation` |
| [QueueUsingList.csx](Queue/QueueUsingList.csx) | Queue implementation using a linked list | `#queue` `#implementation` |

### Problems

| File | Question | Tags |
|---|---|---|
| [Dota2Senator.csx](Queue/Dota2Senator.csx) | Simulate senate voting to determine winning party | `#queue` |
| [RecentCall.csx](Queue/RecentCall.csx) | Count requests in the last 3000ms time window | `#queue` |

---

## Tree

### Implementation

| File | Description | Tags |
|---|---|---|
| [BinarySearchTree.csx](Tree/BinarySearchTree.csx) | Full BST: insert, delete, traversals, BFS, height, mirror, copy | `#tree` `#bst` `#implementation` |

### Problems

| File | Question | Tags |
|---|---|---|
| [GoodNodes.csx](Tree/GoodNodes.csx) | Count good nodes where value >= all ancestors on path to root | `#tree` `#recursive` `#dfs` |
| [LeafSimilarTrees.csx](Tree/LeafSimilarTrees.csx) | Check if two trees have the same leaf sequence | `#tree` `#recursive` |
| [MaxDepth.csx](Tree/MaxDepth.csx) | Get max depth of tree from root to leaf | `#tree` `#recursive` `#dfs` `#bfs` |
| [PathSum1.csx](Tree/PathSum1.csx) | Check if target sum path exists from root to any leaf | `#tree` `#dfs` |
| [PathSum2.csx](Tree/PathSum2.csx) | Return all root-to-leaf paths that sum to target | `#tree` `#dfs` |
| [PathSum3.csx](Tree/PathSum3.csx) | Count paths that sum to target (can start from any node) | `#tree` `#dfs` |

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
| `#stack` | RemoveStarFromString, AstroidCollision, DecodeString, StackUsingArray, StackUsingList |
| `#queue` | Dota2Senator, RecentCall, QueueUsingArray, QueueUsingList |
| `#tree` | GoodNodes, LeafSimilarTrees, MaxDepth, PathSum1, PathSum2, PathSum3, BinarySearchTree |
| `#bst` | BinarySearchTree |
| `#dfs` | GoodNodes, MaxDepth, PathSum1, PathSum2, PathSum3 |
| `#bfs` | MaxDepth, BinarySearchTree |
| `#recursive` | GoodNodes, LeafSimilarTrees, MaxDepth |
| `#implementation` | StackUsingArray, StackUsingList, QueueUsingArray, QueueUsingList, BinarySearchTree |
| `#linkedList` | LinkedList, LinkedListOperations, LinkedListReverse, DeleteMiddleNode, OddEvenSeperated, TwinListSum |
| `#sentinel` | LinkedList |
| `#reverse` | LinkedListOperations |
