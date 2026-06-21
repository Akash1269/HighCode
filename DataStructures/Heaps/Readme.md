Priority Queue

- This uses heap data strucutre
- Implements set S of elements with key 

Basic Functions

1. Insert (S, x) - Insert x
2. Max (S) - Return element with largest key
3. Extract-Max(S) - Return elment with largest key and remove it
4. Increase key (S, x, k) - Increase value of x's key to new value k (ex - increase priority value)

Heap - Implementation of priority queue, which is a array strucutre visualized as a complete binary tree (But not full)
Note example : 16, 14, 10, 8, 7, 9, 3, 2, 4, 1 (max heap) 

Heap as a Tree - 
1. Root of tree - First element - i = 1
2. Parent = i/ 2
3. Left Child = 2i
4. Right Child = 2i + 1

Heap can be of two types (recursively) -
Max Heap = Key of node >= keys of its children
Min Heap = Key of node <= keys of its children

If heap is not a max or min heap, we need to build the max or min heap, using heap sort
Height of heap binary tree is always going to be log2(n)

Heap Operations - 
1. Build max heap - Produces max heap on unordered array
2. Max heapify - Correct a single violation of the heap property in subtree's root/node
3. Heap Size - Returns size of heap/array

Def - MaxHeapify (arr, i) 
Assumes that the tree rooted at left(i) and right(i) are max heaps
This is will work bottom up as leaves are by default max heaps

Algorithm Max_Heapify - Complexity log(n)
1. At any node i, exchange value with bigger children
2. Call maxHeapify on two children 2i, 2i + 1 recursively


Build_max_heap(A) :
    for i = n / 2 down to 1
        do max_heapify (A, i)

Complexity of build max heap is build_max_heap - Big O is O(n logn)
- But if we carefull analyze with total no of operations since we do very less operations at bottom which is not logn, 
- so if we plot in a series, its going to be almost O(n)
- Each level heapify takes O(L) for levels from bottom/leaves

Maths of order =
- n/2 * 0c + n/4 * 1c + n/8 * 2c + n/16 * 3c + 1 (log n c)
- n / 4 = 2^k
- C2^k (1/1 + 2/2 + 3/4 + 4/8 + --- + (k+1) / 2^k) 
- C 2^k ( 3 )  = 3 c n / 4 * x = O(n)

Elements of n/2 + 1 to n are always leaves, whatever the value of n is

HeapSort - O(n logn)
1. Turn unordered array into max heap
2. Find max element a[1]
3. Swap elements a[n] with a[1] - now max element is at the end of array
2. Discard node [n] from heap and decrement heap size by 1
3. New root may violate max heap and call heapify on root again