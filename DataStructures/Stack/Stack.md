# Stack — Learning Doc

## 1. Basic Concepts

**Stack** — A linear data structure following **LIFO** (Last In, First Out). The most recently added element is the first one removed. Think of it as a stack of plates — you can only add or remove from the top.

### Structure (used across code files)

```csharp
// C# built-in (used in problem files)
var stack = new Stack<T>();

// Array-based implementation
class Stack
{
    int[] list;
    int top; // index of next empty slot
}

// LinkedList-based implementation
class Stack
{
    Node Top; // points to most recent element
    class Node { int Data; Node Next; }
}
```

### Implementations

| Type | Pros | Cons | File |
|---|---|---|---|
| Array-based | Cache-friendly, simple | Fixed size (or resize cost) | [Implementation/StackUsingArray.csx](Implementation/StackUsingArray.csx) |
| LinkedList-based | Dynamic size, no overflow | Extra pointer memory per element | [Implementation/StackUsingList.csx](Implementation/StackUsingList.csx) |
| C# `Stack<T>` | Dynamic, built-in, optimized | — | Used in all problem files |

### Core Operations & Complexities

| Operation | Description | Time |
|---|---|---|
| `Push(x)` | Add element to the top | O(1) |
| `Pop()` | Remove and return top element | O(1) |
| `Peek()` | Return top element without removing | O(1) |
| `Count` | Number of elements | O(1) |
| `IsEmpty` | Check if stack is empty | O(1) |

### Key Terminology

| Term | Meaning |
|---|---|
| Top | The most recently pushed element (only accessible element) |
| Overflow | Pushing onto a full stack (array-based) |
| Underflow | Popping from an empty stack |
| LIFO | Last In, First Out — the core principle |
| Monotonic Stack | A stack that maintains elements in sorted order (increasing or decreasing) |

---

## 2. Pattern Summary

1. **"Process elements and undo/cancel the most recent one on a trigger"** — Stack as Undo/Cancel
   - Use when: A character, event, or action cancels/removes the most recent unprocessed item.
   - Think: "Does a trigger need to erase the last thing I added?"

2. **"When you hit a closing bracket, unwind back to the matching open bracket"** — Nested Structure Processing
   - Use when: Input has nested brackets, parentheses, or recursive encoding (e.g., `k[string]`).
   - Think: "Do I need to 'save state' when entering a nested level and 'restore' when exiting?"

3. **"Simulate collisions where new elements destroy older ones based on a rule"** — Stack as Collision Simulator
   - Use when: Elements interact with previously seen elements and can cancel or destroy them based on direction, size, or priority.
   - Think: "Does the current element need to fight/compare against recent elements until one wins?"

---

## 3. Pattern Deep Dives

### Pattern 1: Stack as Undo/Cancel

**Concept:** Push elements onto the stack as you encounter them. When you hit a "cancel" trigger (like `*`, backspace, or a special character), pop the top element — effectively undoing the last action. The stack naturally gives you the most recent item to cancel.

**Template:**
```csharp
public string ProcessWithCancel(string s, char cancelChar)
{
    var stack = new Stack<char>();

    foreach (char c in s)
    {
        if (c != cancelChar)
            stack.Push(c);
        else if (stack.Count > 0)
            stack.Pop(); // cancel most recent
    }

    return new string(stack.Reverse().ToArray());
}
```

**Key Insight:** The stack's LIFO property perfectly models "undo" — the most recent item is always the one that gets cancelled first.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [RemoveStarFromString.csx](RemoveStarFromString.csx) | Each `*` removes nearest non-star to its left | Push non-stars; pop on `*`. Also shows array-index approach as alternative to actual stack. |

---

### Pattern 2: Nested Structure Processing

**Concept:** Push characters/state onto the stack as you scan forward. When you encounter a closing delimiter (`]`, `)`), pop back to the matching opener to extract the nested content, process it (decode, evaluate, validate), and push the result back. The stack preserves outer context while you process inner levels.

**Template:**
```csharp
public string DecodeNested(string s)
{
    var stack = new Stack<char>();

    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] != ']')
        {
            stack.Push(s[i]); // push everything until closer
        }
        else
        {
            // 1. Extract content between brackets
            var content = new StringBuilder();
            while (stack.Peek() != '[')
                content.Insert(0, stack.Pop());
            stack.Pop(); // remove '['

            // 2. Extract multiplier/operator before '['
            var num = new StringBuilder();
            while (stack.Count > 0 && char.IsDigit(stack.Peek()))
                num.Insert(0, stack.Pop());
            int repeat = num.Length > 0 ? int.Parse(num.ToString()) : 1;

            // 3. Process and push result back
            for (int j = 0; j < repeat; j++)
                foreach (char c in content.ToString())
                    stack.Push(c);
        }
    }

    return new string(stack.Reverse().ToArray());
}
```

**Key Insight:** The stack implicitly handles arbitrary nesting depth — each `]` only processes its innermost `[`, and the expanded result becomes part of the outer level automatically.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [DecodeString.csx](DecodeString.csx) | Decode `k[encoded_string]` with nesting | Pop chars to `[`, extract count, expand string, push back. Handles `3[a2[c]]` → `accaccacc` |

---

### Pattern 3: Stack as Collision Simulator

**Concept:** Elements are pushed onto the stack. When a new element "conflicts" with the top (e.g., opposite direction, opposing sign), they collide. The winner stays (or both are destroyed). Keep colliding the current element against the stack top until it's resolved — either it survives and gets pushed, or it's destroyed.

**Template:**
```csharp
public int[] SimulateCollisions(int[] elements)
{
    var stack = new Stack<int>();

    foreach (int current in elements)
    {
        bool survived = true;

        // Collision condition: current conflicts with stack top
        while (stack.Count > 0 && WillCollide(stack.Peek(), current))
        {
            if (Strength(stack.Peek()) < Strength(current))
            {
                stack.Pop(); // top is destroyed, continue checking
            }
            else if (Strength(stack.Peek()) == Strength(current))
            {
                stack.Pop(); // both destroyed
                survived = false;
                break;
            }
            else
            {
                survived = false; // current is destroyed
                break;
            }
        }

        if (survived) stack.Push(current);
    }

    return stack.Reverse().ToArray();
}
```

**Key Insight:** The stack holds "survivors so far." Each new element only needs to fight the most recent survivors — once it can't beat the top, it either dies or coexists.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [AstroidCollision.csx](AstroidCollision.csx) | Asteroids collide based on direction (sign) and size | Collision only when top is positive (+→) and current is negative (←−). Larger absolute value wins. Equal = both destroyed. |

---

## 4. Additional Interview Patterns (Not Yet Practiced)

1. **"Check if every opener has a matching closer in the right order"** — Valid Parentheses / Bracket Matching
   - Use when: Validating balanced brackets `()[]{}` or matching open/close delimiters.
   - Think: "Does each closer need to match the most recent unmatched opener?"
   - Example problems: Valid Parentheses, Minimum Remove to Make Valid, Longest Valid Parentheses

2. **"Find the next taller building by looking back at shorter ones"** — Monotonic Stack (Next Greater/Smaller Element)
   - Use when: For each element, find the next element that is greater (or smaller) in O(n).
   - Think: "Do I need to look at 'what's waiting for a bigger/smaller value' as I scan?"
   - Example problems: Daily Temperatures, Next Greater Element I/II, Stock Span, Trapping Rain Water

3. **"Evaluate 3 + 5 * 2 respecting operator precedence"** — Expression Evaluation (Infix/Postfix)
   - Use when: Evaluating mathematical expressions with operators and precedence.
   - Think: "Do I need one stack for numbers and one for operators, processing by precedence?"
   - Example problems: Basic Calculator I/II/III, Evaluate Reverse Polish Notation

4. **"Find the largest rectangle that fits under the histogram bars"** — Largest Rectangle in Histogram
   - Use when: Finding maximum rectangular area in a histogram or matrix of 1s.
   - Think: "For each bar, how far left and right can it extend without hitting a shorter bar?"
   - Example problems: Largest Rectangle in Histogram, Maximal Rectangle

5. **"Track the minimum at every state of the stack"** — Min Stack / Max Stack
   - Use when: Need O(1) access to both the top element AND the current minimum/maximum.
   - Think: "Can I store extra metadata with each push so min/max is always available?"
   - Example problems: Min Stack, Max Stack, Maximum Frequency Stack

6. **"Simplify a file path by treating `..` as pop and directory as push"** — Path Simplification
   - Use when: Processing paths, commands, or sequences where some tokens cancel previous ones.
   - Think: "Does `..` or a special token undo/go-back to the previous state?"
   - Example problems: Simplify Path, Backspace String Compare, Robot Return to Origin

7. **"Use a stack to simulate recursion iteratively"** — Iterative DFS / Recursion Simulation
   - Use when: Converting recursive tree/graph traversal to iterative, or when recursion depth might overflow.
   - Think: "Can I replace the call stack with an explicit stack to control traversal?"
   - Example problems: Binary Tree Inorder Traversal (iterative), Flatten Nested List Iterator

---

## 5. Problem Difficulty Progression

| # | Problem | File | Difficulty | Key Pattern |
|---|---|---|---|---|
| 1 | Remove Stars from String | [RemoveStarFromString.csx](RemoveStarFromString.csx) | Medium | Stack as Undo/Cancel |
| 2 | Decode String | [DecodeString.csx](DecodeString.csx) | Medium | Nested Structure Processing |
| 3 | Asteroid Collision | [AstroidCollision.csx](AstroidCollision.csx) | Medium | Stack as Collision Simulator |

---

## 6. Quick Reference: When to Use What

| Signal / Situation | Pattern | Why |
|---|---|---|
| "Remove/cancel the most recent item" | Stack as Undo/Cancel | LIFO = most recent first |
| "Nested brackets/encoding like `k[...]`" | Nested Structure Processing | Stack preserves outer context while processing inner |
| "Elements destroy each other based on a rule" | Collision Simulator | Fight against top until resolved |
| "Match openers with closers" | Valid Parentheses | Each closer matches the most recent unmatched opener |
| "Next greater/smaller element for each position" | Monotonic Stack | Pop smaller elements when a larger one arrives |
| "Evaluate math expression with precedence" | Expression Evaluation | Operator stack respects priority ordering |
| "Track running minimum alongside stack state" | Min Stack | Store min metadata with each level |
| "Process `..` or undo tokens in a path/sequence" | Path Simplification | Pop = go back one level |
| "Convert recursive DFS to iterative" | Explicit Stack DFS | Stack replaces the call stack |

---

## 7. The Stack Intuition

**When to reach for a stack:**

Ask yourself: *"Does the problem have a 'most recent' dependency?"*

If the answer to any of these is yes, a stack likely helps:
- Does a new element interact with the **last** unprocessed element?
- Is there **nesting** (things inside things)?
- Do I need to **undo** or **go back** to a previous state?
- Am I scanning left-to-right and need to remember what's **still unresolved**?

The stack's power is that it always gives you the **most recent unresolved item** in O(1).
