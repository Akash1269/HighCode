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
| [CircularLinkedList.csx](LinkedList/CircularLinkedList.csx) | Circular linked list implementation with insert, delete, display | `#linkedList` `#circular` `#implementation` |
| [DoublyLinkedList.csx](LinkedList/DoublyLinkedList.csx) | Doubly linked list implementation with forward/backward traversal | `#linkedList` `#doubly` `#implementation` |

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
| [BinarySearchTree.csx](Tree/Implementation/BinarySearchTree.csx) | Full BST: insert, delete, traversals, BFS, height, mirror, copy | `#tree` `#bst` `#implementation` |

### Problems

| File | Question | Tags |
|---|---|---|
| [GoodNodesCount.csx](Tree/GoodNodesCount.csx) | Count good nodes where value >= all ancestors on path to root | `#tree` `#recursive` `#dfs` |
| [SimilarLeavesTrees.csx](Tree/SimilarLeavesTrees.csx) | Check if two trees have the same leaf sequence | `#tree` `#recursive` |
| [MaxDepthToLeaf.csx](Tree/MaxDepthToLeaf.csx) | Get max depth of tree from root to leaf | `#tree` `#recursive` `#dfs` `#bfs` `#stack` `#queue` |
| [MinDepthToLeaf.csx](Tree/MinDepthToLeaf.csx) | Find minimum depth (shortest root-to-leaf path) | `#recursion` `#tree` |
| [PathToLeafSum.csx](Tree/PathToLeafSum.csx) | Check if target sum path exists from root to any leaf | `#tree` `#dfs` |
| [PathSumList.csx](Tree/PathSumList.csx) | Return all root-to-leaf paths that sum to target | `#tree` `#dfs` |
| [AnyPathSumList.csx](Tree/AnyPathSumList.csx) | Count paths that sum to target (can start from any node) | `#tree` `#dfs` |
| [LCAOfTwoNodes.csx](Tree/LCAOfTwoNodes.csx) | Find the lowest common ancestor of two given nodes | `#tree` `#dfs` `#lca` |
| [ZigZagPathMaxLength.csx](Tree/ZigZagPathMaxLength.csx) | Find longest path alternating between left and right child | `#tree` `#dfs` |
| [AreTwoNodesCousins.csx](Tree/AreTwoNodesCousins.csx) | Check if two nodes are cousins (same depth, different parents) | `#tree` `#recursive` `#dfs` `#bfs` |
| [AvgOfLevels.csx](Tree/AvgOfLevels.csx) | Find average of each level and return as a list | `#tree` `#bfs` `#queue` |
| [LevelOrderTraverse.csx](Tree/LevelOrderTraverse.csx) | Return level order traversal as list of lists | `#bfs` `#tree` `#queue` |
| [LevelOrderBottomUpTraverse.csx](Tree/LevelOrderBottomUpTraverse.csx) | Return level order traversal bottom-up as list of lists | `#bfs` `#tree` `#queue` |
| [MaxSumLevel.csx](Tree/MaxSumLevel.csx) | Find level with maximum sum | `#bfs` `#tree` `#queue` |
| [ZigZagLevelTraverse.csx](Tree/ZigZagLevelTraverse.csx) | Return zigzag level order traversal | `#zigzag` `#bfs` `#queue` `#tree` |
| [ReplaceCousinsSum.csx](Tree/ReplaceCousinsSum.csx) | Replace node values with sum of all cousins' values | `#tree` `#recursive` `#bfs` |
| [BSTSearch.csx](Tree/BSTSearch.csx) | Find node in BST and return subtree | `#bst` `#recursive` `#dfs` |
| [BSTCopy.csx](Tree/BSTCopy.csx) | Create copy of a binary tree or tree | `#bst` `#tree` |
| [BSTDeleteNode.csx](Tree/BSTDeleteNode.csx) | Delete a node in BST with key, maintain BST order | `#bst` |
| [BSTMirror.csx](Tree/BSTMirror.csx) | Create mirror image of tree | `#bst` `#tree` |

---

## Heaps

### Implementation

| File | Description | Tags |
|---|---|---|
| [Heap.csx](Heaps/Implementation/Heap.csx) | Max heap implementation with insert, delete, extract, heapify, and heap sort | `#heap` `#implementation` |

### Problems

| File | Question | Tags |
|---|---|---|
| [KthLargest.csx](Heaps/KthLargest.csx) | Given an integer array nums and an integer k, return the kth largest element in the array (without sorting) | `#priorityQueue` `#heap` |
| [KthLargestStream.csx](Heaps/KthLargestStream.csx) | Define Kth largest in a stream of integers, where on insert return kth largest at that point | `#heap` |
| [MaxSubsequenceScore.csx](Heaps/MaxSubsequenceScore.csx) | Choose exactly k indices from nums1 and nums2 to maximize (sum of chosen nums1 values) × (minimum chosen nums2 value) | `#heap` `#sort` |
| [SmallestInfiniteSet.csx](Heaps/SmallestInfiniteSet.csx) | SmallestInfiniteSet | `#priorityQueue` `#heap` `#hashSet` |
| [CostOfHiringKWorkers.csx](Heaps/CostOfHiringKWorkers.csx) | Given array of workers with their cost, choose k workers picking one lowest-cost worker per round from first or last x candidates | `#heap` |

---

## Graph

### Implementation

| File | Description | Tags |
|---|---|---|
| [GraphUsingList.csx](Graph/Implementation/GraphUsingList.csx) | Graph implementation using adjacency list (node-based) | `#graph` `#implementation` |
| [GraphUsingMatrix.csx](Graph/Implementation/GraphUsingMatrix.csx) | Graph implementation using adjacency matrix | `#graph` `#implementation` |

### Problems

| File | Question | Tags |
|---|---|---|
| [ConnectedProvinces.csx](Graph/ConnectedProvinces.csx) | Find the number of connected provinces (connected components) using BFS/DFS | `#graph` `#dfs` `#bfs` |
| [PathToCity.csx](Graph/PathToCity.csx) | Find the minimum number of edges to reverse so every node has a path to node 0 | `#dfs` `#tree` |
| [VisitRoomsWithKeys.csx](Graph/VisitRoomsWithKeys.csx) | Return true if you can visit all rooms given keys found in each room | `#graph` `#dfs` |

---

## Binary Search

### Problems

| File | Question | Tags |
|---|---|---|
| [EatBananasInHours.csx](../Algorithms/BinarySearch/EatBananasInHours.csx) | Find minimum eating speed k such that all banana piles are eaten within h hours | `#binarySearch` |
| [GuessNumber.csx](../Algorithms/BinarySearch/GuessNumber.csx) | Given number n and chosen number x, guess the number x from range 1 to n | `#binarySearch` |
| [PeakElement.csx](../Algorithms/BinarySearch/PeakElement.csx) | Find a peak element (strictly greater than its neighbors) and return its index | `#binarySearch` |
| [SuccessfulSpellsAndPotions.csx](../Algorithms/BinarySearch/SuccessfulSpellsAndPotions.csx) | Return array where pairs[i] = number of potions where spells[i] * potions[j] >= success | `#binarySearch` |

---

## Princeton

### Implementation

| File | Description | Tags |
|---|---|---|
| [AdvancedSorts.csx](../Algorithms/Princeton/AdvancedSorts.csx) | Advanced Sorting: Merge Sort, Quick Sort, Heap Sort, Quick Select | `#sorting` `#merge-sort` `#quick-sort` `#heap-sort` `#quick-select` `#princeton` |
| [BinaryHeap.csx](../Algorithms/Princeton/BinaryHeap.csx) | Binary Heap (Max Priority Queue) | `#heap` `#priority-queue` `#princeton` |
| [ElementarySorts.csx](../Algorithms/Princeton/ElementarySorts.csx) | Elementary Sorting: Bubble, Selection, Insertion, Shell Sort | `#sorting` `#bubble-sort` `#selection-sort` `#insertion-sort` `#shell-sort` `#princeton` |
| [GenericArrayList.csx](../Algorithms/Princeton/GenericArrayList.csx) | Resizable Generic Array List (Dynamic Array) | `#array` `#generics` `#princeton` |
| [QuickFind.csx](../Algorithms/Princeton/QuickFind.csx) | Union Find: Quick Find (Eager Approach) | `#union-find` `#array` `#princeton` |
| [QuickUnion.csx](../Algorithms/Princeton/QuickUnion.csx) | Union Find: Quick Union (Lazy Approach) | `#union-find` `#tree` `#princeton` |
| [WeightedQuickUnion.csx](../Algorithms/Princeton/WeightedQuickUnion.csx) | Union Find: Weighted Quick Union with Path Compression | `#union-find` `#tree` `#path-compression` `#princeton` |

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
| `#queue` | Dota2Senator, RecentCall, QueueUsingArray, QueueUsingList, AvgOfLevels, LevelOrderTraverse, LevelOrderBottomUpTraverse, MaxSumLevel, ZigZagLevelTraverse, MaxDepthToLeaf |
| `#tree` | GoodNodesCount, SimilarLeavesTrees, MaxDepthToLeaf, MinDepthToLeaf, PathToLeafSum, PathSumList, AnyPathSumList, LCAOfTwoNodes, ZigZagPathMaxLength, BinarySearchTree, AreTwoNodesCousins, AvgOfLevels, LevelOrderTraverse, LevelOrderBottomUpTraverse, MaxSumLevel, ZigZagLevelTraverse, ReplaceCousinsSum, BSTSearch, BSTCopy, BSTMirror, PathToCity, QuickUnion, WeightedQuickUnion |
| `#bst` | BinarySearchTree, BSTSearch, BSTCopy, BSTDeleteNode, BSTMirror |
| `#dfs` | GoodNodesCount, MaxDepthToLeaf, PathToLeafSum, PathSumList, AnyPathSumList, LCAOfTwoNodes, ZigZagPathMaxLength, AreTwoNodesCousins, BSTSearch, ConnectedProvinces, PathToCity, VisitRoomsWithKeys |
| `#bfs` | MaxDepthToLeaf, BinarySearchTree, AreTwoNodesCousins, AvgOfLevels, LevelOrderTraverse, LevelOrderBottomUpTraverse, MaxSumLevel, ZigZagLevelTraverse, ReplaceCousinsSum, ConnectedProvinces |
| `#recursive` | GoodNodesCount, SimilarLeavesTrees, MaxDepthToLeaf, AreTwoNodesCousins, ReplaceCousinsSum, BSTSearch |
| `#implementation` | StackUsingArray, StackUsingList, QueueUsingArray, QueueUsingList, BinarySearchTree, CircularLinkedList, DoublyLinkedList, GraphUsingList, GraphUsingMatrix |
| `#linkedList` | LinkedList, LinkedListOperations, LinkedListReverse, DeleteMiddleNode, OddEvenSeperated, TwinListSum, CircularLinkedList, DoublyLinkedList |
| `#lca` | LCAOfTwoNodes |
| `#circular` | CircularLinkedList |
| `#doubly` | DoublyLinkedList |
| `#sentinel` | LinkedList |
| `#reverse` | LinkedListOperations |
| `#recursion` | MinDepthToLeaf |
| `#zigzag` | ZigZagLevelTraverse |
| `#graph` | ConnectedProvinces, VisitRoomsWithKeys, GraphUsingList, GraphUsingMatrix |
| `#heap` | Heap, KthLargest, KthLargestStream, MaxSubsequenceScore, SmallestInfiniteSet, CostOfHiringKWorkers, BinaryHeap |
| `#priorityQueue` | KthLargest, SmallestInfiniteSet |
| `#sort` | MaxSubsequenceScore |
| `#hashSet` | SmallestInfiniteSet |
| `#binarySearch` | EatBananasInHours, GuessNumber, PeakElement, SuccessfulSpellsAndPotions |
| `#sorting` | AdvancedSorts, ElementarySorts |
| `#merge-sort` | AdvancedSorts |
| `#quick-sort` | AdvancedSorts |
| `#heap-sort` | AdvancedSorts |
| `#quick-select` | AdvancedSorts |
| `#princeton` | AdvancedSorts, BinaryHeap, ElementarySorts, GenericArrayList, QuickFind, QuickUnion, WeightedQuickUnion |
| `#priority-queue` | BinaryHeap |
| `#bubble-sort` | ElementarySorts |
| `#selection-sort` | ElementarySorts |
| `#insertion-sort` | ElementarySorts |
| `#shell-sort` | ElementarySorts |
| `#generics` | GenericArrayList |
| `#union-find` | QuickFind, QuickUnion, WeightedQuickUnion |
| `#path-compression` | WeightedQuickUnion |
