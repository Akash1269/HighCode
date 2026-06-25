// Question - 

// #priorityQueue #heap #hashSet

// Solution 4, most optimized using both and smallest, and only maintain newly added smaller elements
// Since bigger elements than smallest were never removed, this is key to the solution
public class SmallestInfiniteSet
{
    PriorityQueue<int, int> pq;
    HashSet<int> set;
    int smallest;

    public SmallestInfiniteSet()
    {
        pq = new PriorityQueue<int, int>();
        set = new HashSet<int>();
        smallest = 1;
    }

    public int PopSmallest()
    {
        if (pq.Count > 0)
        {
            int value = pq.Dequeue();
            set.Remove(value);
            return value;
        }

        return smallest++;
    }

    public void AddBack(int num)
    {
        if (num < smallest && !set.Contains(num))
        {
            pq.Enqueue(num, num);
            set.Add(num);
        }
    }
}

// Solution 3 - Using Priority queue and hashset (to avoid duplicates) together
public class SmallestInfiniteSet
{
    PriorityQueue<int, int> pq;
    HashSet<int> set;

    public SmallestInfiniteSet()
    {
        pq = new PriorityQueue<int, int>();
        set = new HashSet<int>();

        for (int i = 1; i <= 1000; i++)
        {
            pq.Enqueue(i, i);
            set.Add(i);
        }
    }

    public int PopSmallest()
    {
        int value = pq.Dequeue();
        set.Remove(value);
        return value;
    }

    public void AddBack(int num)
    {
        if (!set.Contains(num))
        {
            pq.Enqueue(num, num);
            set.Add(num);
        }
    }
}

// Solution 2 - Lil bit more efficient since it saves the smallest element and maintains it
// Much better than solution 1 but still not most efficient
public class SmallestInfiniteSet
{
    HashSet<int> removedSet;
    int smallest = 1;
    public SmallestInfiniteSet()
    {
        removedSet = new HashSet<int>();
    }

    public int PopSmallest()
    {
        int item = smallest;
        removedSet.Add(smallest);

        smallest++;
        while (removedSet.Contains(smallest) && smallest < 1000)
        {
            smallest++;
        }

        return item;
    }

    public void AddBack(int num)
    {
        if (!removedSet.Contains(num)) return;
        removedSet.Remove(num);

        if (num < smallest)
        {
            smallest = num;
        }
    }
}

// Solution 1 - Using set and checking what is removed assuming 
// At start we have all the elements in the set
public class SmallestInfiniteSet
{
    HashSet<int> removedSet;
    public SmallestInfiniteSet()
    {
        removedSet = new HashSet<int>();
    }

    public int PopSmallest()
    {
        int i = 1;
        while (removedSet.Contains(i) && i < 1000)
        {
            i++;
        }

        removedSet.Add(i);
        return i;
    }

    public void AddBack(int num)
    {
        if (!removedSet.Contains(num)) return;
        removedSet.Remove(num);
    }
}

// Solution 0 - Almost same as removed set with same time and spacce complexity
// Straigh forward we maintain the set itself not removed
public class SmallestInfiniteSet
{
    HashSet<int> set;
    public SmallestInfiniteSet()
    {
        set = new HashSet<int>();
        for (int i = 0; i < 1000; i++)
        {
            set.Add(i);
        }
    }

    public int PopSmallest()
    {
        int i = 1;
        while (!set.Contains(i) && i < 1000)
        {
            i++;
        }

        set.Remove(i);
        return i;
    }

    public void AddBack(int num)
    {
        if (set.Contains(num)) return;
        set.Add(num);
    }
}