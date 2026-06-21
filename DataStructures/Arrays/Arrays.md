# Arrays — Learning Doc

## 1. Basic Concepts

**Array** — A contiguous block of memory storing elements of the same type, accessed by index in O(1).

### Key Terminology

| Term | Meaning |
|---|---|
| Subarray | Contiguous slice of the array (e.g., `nums[i..j]`) |
| Subsequence | Elements in original order but not necessarily contiguous |
| Prefix Sum | Running total from index 0 to i |
| In-place | Modifying the array without extra allocation |
| Window | A range `[start, end]` that slides across the array |

### Common Operations & Complexities

| Operation | Time |
|---|---|
| Access by index | O(1) |
| Search (unsorted) | O(n) |
| Search (sorted) | O(log n) |
| Insert/Delete at end | O(1) amortized |
| Insert/Delete at middle | O(n) |
| Sort | O(n log n) |

---

## 2. Pattern Summary

1. **"Shrink the window from both ends to find the best pair"** — Two Pointers (Opposite Ends)
   - Use when: Array is sorted (or can be sorted) and you need to find pairs or maximize/minimize a value based on two positions.
   - Think: "Can I start from both ends and eliminate one side each step?"

2. **"Walk two pointers at different speeds through the array"** — Two Pointers (Same Direction)
   - Use when: Checking subsequences, partitioning in-place, or maintaining a read/write pointer.
   - Think: "Do I need to track two positions moving forward independently?"

3. **"Expand/shrink a window to find the best contiguous range"** — Sliding Window
   - Use when: Finding maximum/minimum/count of a contiguous subarray of fixed or variable length.
   - Think: "Am I looking for the best subarray where I can add to the right and remove from the left?"

4. **"Running totals reveal balance points and range sums"** — Prefix Sum
   - Use when: You need range sums, or need to find where left and right halves balance.
   - Think: "Can I precompute cumulative sums to answer queries in O(1)?"

5. **"Count, group, or look up elements by frequency or presence"** — HashMap / HashSet
   - Use when: Checking existence, counting occurrences, finding complements, or grouping elements.
   - Think: "Do I need O(1) lookup for previously seen values or their counts?"

6. **"Build the result from both ends of the array toward the center"** — Both-Ends Product / Accumulation
   - Use when: Each position's answer depends on all other elements (like product except self).
   - Think: "Can I split the computation into a left pass and a right pass?"

7. **"Greedily decide at each step using local conditions"** — Greedy / Local Decision
   - Use when: A simple local rule (check neighbors, track running min/max) leads to a global answer.
   - Think: "Can I make an irrevocable local choice at each index that's provably optimal?"

---

## 3. Pattern Deep Dives

### Pattern 1: Two Pointers — Opposite Ends

**Concept:** Place one pointer at the start and one at the end. Move the pointer that limits the current answer (e.g., the shorter height, the smaller value) inward. This eliminates provably suboptimal candidates each step.

**Template:**
```csharp
public int TwoPointerOpposite(int[] nums, int target)
{
    int left = 0, right = nums.Length - 1;
    int result = 0;

    while (left < right)
    {
        // Evaluate current pair
        int current = Evaluate(nums[left], nums[right]);
        result = Math.Max(result, current);

        // Move the limiting pointer
        if (nums[left] < nums[right]) left++;
        else right--;
    }

    return result;
}
```

**Key Insight:** For a fixed shorter side, the farthest opposite pointer already gives maximum width — so no better answer exists with that side. Safely discard it.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [ContainerWithMostWater.csx](ContainerWithMostWater.csx) | Max area between two lines | Move the shorter wall inward; area = width × min(height) |
| [MaxSumPairs.csx](MaxSumPairs.csx) | Max pair operations summing to K | Sort first, then two-pointer to find pairs = K |

---

### Pattern 2: Two Pointers — Same Direction

**Concept:** Use a slow pointer (write position or subsequence tracker) and a fast pointer (scanner). The fast pointer reads every element; the slow pointer only advances on a condition.

**Template:**
```csharp
public void TwoPointerSameDirection(int[] nums)
{
    int slow = 0;

    for (int fast = 0; fast < nums.Length; fast++)
    {
        if (MeetsCondition(nums[fast]))
        {
            Swap(nums, slow, fast); // or assign
            slow++;
        }
    }
}
```

**Key Insight:** The slow pointer marks the boundary of the "processed" section — everything before it satisfies the invariant.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [MoveZeros.csx](MoveZeros.csx) | Move all zeros to end, keep order | Slow = next non-zero position; swap non-zeros forward |
| [IsSubsequence.csx](IsSubsequence.csx) | Is `s` a subsequence of `t`? | Slow on `s`, fast on `t`; advance slow only on char match |

---

### Pattern 3: Sliding Window

**Concept:** Maintain a window `[start, end]` that expands by moving `end` right. When the window violates a constraint, shrink by moving `start` right. Track the best valid window seen.

**Template (variable-length):**
```csharp
public int SlidingWindow(int[] nums, int k)
{
    int start = 0, result = 0;
    int windowState = 0; // sum, count of zeros, etc.

    for (int end = 0; end < nums.Length; end++)
    {
        // Expand: add nums[end] to window state
        windowState += nums[end];

        // Shrink: while window is invalid
        while (WindowInvalid(windowState, k))
        {
            windowState -= nums[start];
            start++;
        }

        // Update result with current valid window
        result = Math.Max(result, end - start + 1);
    }

    return result;
}
```

**Template (fixed-length K):**
```csharp
public int FixedWindow(int[] nums, int k)
{
    int sum = 0, maxSum = int.MinValue;

    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
        if (i >= k) sum -= nums[i - k];       // remove leftmost
        if (i >= k - 1) maxSum = Math.Max(maxSum, sum); // window full
    }

    return maxSum;
}
```

**Key Insight:** The window never backtracks — each element is added once and removed at most once, giving O(n) even though there's a nested while loop.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [MaxAvgSubArray1.csx](MaxAvgSubArray1.csx) | Max average subarray of length K | Fixed window; track running sum |
| [MaxConsecutivesOnesIII.csx](MaxConsecutivesOnesIII.csx) | Longest 1s with at most K flips | Variable window; shrink when zero-count > K |
| [LongestSubArrayOfOnesDeleteOne.csx](LongestSubArrayOfOnesDeleteOne.csx) | Longest 1s after deleting one element | Variable window; allow exactly one 0 in window |

---

### Pattern 4: Prefix Sum

**Concept:** Precompute a running total so that any range sum `[i, j]` can be answered in O(1). Also useful for finding balance/pivot points where left sum equals right sum.

**Template:**
```csharp
public int PrefixSumPivot(int[] nums)
{
    int totalSum = nums.Sum();
    int leftSum = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        int rightSum = totalSum - leftSum - nums[i];
        if (leftSum == rightSum) return i;
        leftSum += nums[i];
    }

    return -1;
}
```

**Key Insight:** `rightSum = totalSum - leftSum - nums[i]` — you don't need a separate right-pass if you know the total.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [FidPivotIndex.csx](FidPivotIndex.csx) | Find pivot where left sum = right sum | Subtract current from right, compare with left |
| [HighestAltitude.csx](HighestAltitude.csx) | Highest altitude from gain array | Running prefix sum; track max seen |

---

### Pattern 5: HashMap / HashSet

**Concept:** Use a hash structure for O(1) lookups. Store seen values, frequencies, or complements to avoid nested loops.

**Template (complement lookup):**
```csharp
public int ComplementLookup(int[] nums, int target)
{
    var map = new Dictionary<int, int>(); // value → count
    int result = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        int complement = target - nums[i];

        if (map.ContainsKey(complement) && map[complement] > 0)
        {
            result++;
            map[complement]--;
        }
        else
        {
            map[nums[i]] = map.GetValueOrDefault(nums[i]) + 1;
        }
    }

    return result;
}
```

**Key Insight:** Instead of searching for a match in O(n), store what you *need* and check if the current element fulfills a previous need.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [MaxSumPairs.csx](MaxSumPairs.csx) | Pairs summing to K | Store complement (k - num); match in one pass |
| [DifferenceBetweenTwoArrays.csx](DifferenceBetweenTwoArrays.csx) | Unique elements in each array | HashSet for O(1) contains check |
| [UniqueNumberOfOccurences.csx](UniqueNumberOfOccurences.csx) | Are all frequencies unique? | Map for counts, Set for uniqueness of counts |
| [CloseString.csx](CloseString.csx) | Can strings transform into each other? | Char frequency arrays compared after sorting |

---

### Pattern 6: Both-Ends Product / Accumulation

**Concept:** When each element's result depends on all *other* elements, compute a left-to-right pass and a right-to-left pass, then combine them.

**Template:**
```csharp
public int[] BothEndsPass(int[] nums)
{
    int n = nums.Length;
    int[] result = new int[n];

    // Right-to-left pass: result[i] = product of nums[i..n-1]
    int rightProduct = 1;
    for (int i = n - 1; i >= 0; i--)
    {
        rightProduct *= nums[i];
        result[i] = rightProduct;
    }

    // Left-to-right pass: multiply with left product
    int leftProduct = 1;
    for (int i = 0; i < n - 1; i++)
    {
        result[i] = leftProduct * result[i + 1];
        leftProduct *= nums[i];
    }
    result[n - 1] = leftProduct;

    return result;
}
```

**Key Insight:** Product except self at index `i` = (product of everything left of i) × (product of everything right of i). Two passes, no division needed.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [ProductOfArrayExceptSelf.csx](ProductOfArrayExceptSelf.csx) | Product of array except self | Right-pass stored in output, left-pass applied on second sweep |

---

### Pattern 7: Greedy / Local Decision

**Concept:** At each index, make a locally optimal choice based on simple conditions (neighbors, running state). The greedy choice is provably safe — no future information can improve a past decision.

**Template:**
```csharp
public bool GreedyTrack(int[] nums)
{
    int first = int.MaxValue, second = int.MaxValue;

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] <= first) first = nums[i];
        else if (nums[i] <= second) second = nums[i];
        else return true; // found third element > second > first
    }

    return false;
}
```

**Key Insight:** By greedily keeping the smallest `first` and smallest `second > first`, any element larger than both proves a triplet exists — without tracking actual indices.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [IncreasingTripletSubsequence.csx](IncreasingTripletSubsequence.csx) | Exists i < j < k with nums[i] < nums[j] < nums[k]? | Track two smallest values; third proves triplet |
| [CanPlaceFlowers.csx](CanPlaceFlowers.csx) | Can place N flowers with no adjacency? | Check left/right neighbors; greedily plant when safe |

---

## 4. Additional Interview Patterns (Not Yet Practiced)

1. **"Binary search the answer in a sorted space"** — Binary Search on Arrays
   - Use when: Array is sorted and you need to find a target, boundary, or insertion point.
   - Think: "Is the search space sorted? Can I eliminate half each step?"
   - Example problems: Search in Rotated Sorted Array, Find First and Last Position, Peak Element

2. **"Track local min to find the best future gain"** — Kadane's / Max Subarray
   - Use when: Finding max/min sum subarray or best buy/sell timing.
   - Think: "Should I extend the current subarray or start fresh here?"
   - Example problems: Maximum Subarray, Best Time to Buy and Sell Stock, Maximum Product Subarray

3. **"Map values to indices for O(1) position lookups"** — Index Mapping
   - Use when: You need to know *where* elements are, not just *if* they exist.
   - Think: "Do I need the position of a value, not just its presence?"
   - Example problems: Two Sum (return indices), Next Greater Element, First Missing Positive

4. **"Sort and merge overlapping intervals"** — Interval Merging
   - Use when: Dealing with ranges, schedules, or overlapping segments.
   - Think: "Can I sort by start and greedily merge overlaps?"
   - Example problems: Merge Intervals, Insert Interval, Non-overlapping Intervals

5. **"Use a monotonic stack to find next greater/smaller"** — Monotonic Stack on Arrays
   - Use when: Finding the next greater/smaller element for each position.
   - Think: "For each element, what's the first element to the right/left that beats it?"
   - Example problems: Daily Temperatures, Next Greater Element, Trapping Rain Water

6. **"Cycle through indices to detect duplicates or cycles"** — Floyd's / Index Chasing
   - Use when: Values are in range [1, n] and you need to find duplicates without extra space.
   - Think: "Can I treat values as pointers to indices?"
   - Example problems: Find the Duplicate Number, First Missing Positive, Set Mismatch

7. **"Partition the array around a pivot in-place"** — Dutch National Flag / Three-Way Partition
   - Use when: Sorting into 2-3 groups in one pass (zeros/ones/twos, negatives/zeros/positives).
   - Think: "Can I maintain three regions with two boundary pointers?"
   - Example problems: Sort Colors, Move Zeroes (extended), Segregate 0s and 1s

---

## 5. Problem Difficulty Progression

| # | Problem | File | Difficulty | Key Pattern |
|---|---|---|---|---|
| 1 | Highest Altitude | [HighestAltitude.csx](HighestAltitude.csx) | Easy | Prefix Sum |
| 2 | Find Pivot Index | [FidPivotIndex.csx](FidPivotIndex.csx) | Easy | Prefix Sum |
| 3 | Move Zeros | [MoveZeros.csx](MoveZeros.csx) | Easy | Two Pointers (same direction) |
| 4 | Is Subsequence | [IsSubsequence.csx](IsSubsequence.csx) | Easy | Two Pointers (same direction) |
| 5 | Can Place Flowers | [CanPlaceFlowers.csx](CanPlaceFlowers.csx) | Easy | Greedy |
| 6 | Unique Occurrences | [UniqueNumberOfOccurences.csx](UniqueNumberOfOccurences.csx) | Easy | HashMap |
| 7 | Difference Between Arrays | [DifferenceBetweenTwoArrays.csx](DifferenceBetweenTwoArrays.csx) | Easy | HashSet |
| 8 | Max Average Subarray I | [MaxAvgSubArray1.csx](MaxAvgSubArray1.csx) | Easy | Sliding Window (fixed) |
| 9 | Close Strings | [CloseString.csx](CloseString.csx) | Medium | HashMap / Frequency Sort |
| 10 | Max Consecutive Ones III | [MaxConsecutivesOnesIII.csx](MaxConsecutivesOnesIII.csx) | Medium | Sliding Window (variable) |
| 11 | Longest Subarray of 1s (Delete One) | [LongestSubArrayOfOnesDeleteOne.csx](LongestSubArrayOfOnesDeleteOne.csx) | Medium | Sliding Window (variable) |
| 12 | Max Sum Pairs | [MaxSumPairs.csx](MaxSumPairs.csx) | Medium | Two Pointers / HashMap |
| 13 | Container With Most Water | [ContainerWithMostWater.csx](ContainerWithMostWater.csx) | Medium | Two Pointers (opposite ends) |
| 14 | Increasing Triplet Subsequence | [IncreasingTripletSubsequence.csx](IncreasingTripletSubsequence.csx) | Medium | Greedy (track two mins) |
| 15 | Product of Array Except Self | [ProductOfArrayExceptSelf.csx](ProductOfArrayExceptSelf.csx) | Medium | Both-Ends Accumulation |
| 16 | Equal Row-Col Pairs (Matrix) | [EqualRowColPairsMatrics.csx](EqualRowColPairsMatrics.csx) | Medium | Matrix Transpose + Compare |

---

## 6. Quick Reference: When to Use What

| Signal / Situation | Pattern | Why |
|---|---|---|
| "Find pair that sums to K" in sorted array | Two Pointers (opposite) | Eliminate one end each step |
| "Find pair that sums to K" in unsorted array | HashMap (complement) | O(1) lookup for needed value |
| "Check if X is a subsequence of Y" | Two Pointers (same direction) | Walk both forward, match greedily |
| "Move/partition elements in-place" | Two Pointers (read/write) | Maintain boundary of processed region |
| "Max/min of all subarrays of size K" | Sliding Window (fixed) | Add right, remove left, O(n) |
| "Longest subarray satisfying a condition" | Sliding Window (variable) | Expand right, shrink left when violated |
| "Sum of range [i, j]" or "balance point" | Prefix Sum | Precompute totals for O(1) range queries |
| "Each element depends on all others" | Both-Ends Pass | Left pass + Right pass combine results |
| "Exists increasing subsequence of length K" | Greedy (track running mins) | Maintain smallest candidates seen so far |
| "Count occurrences / check existence" | HashMap / HashSet | O(1) frequency tracking and lookup |
| "Max water / area between boundaries" | Two Pointers (opposite) | Width decreases inward; move limiting side |
