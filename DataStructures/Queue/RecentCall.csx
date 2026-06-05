// Question - 
// Implement a RecentCounter that tracks requests over time. Each call to ping(t) adds a request at time t (milliseconds) 
// and returns the number of requests that occurred in the inclusive range [t - 3000, t]. 
// It is guaranteed that each new t is strictly greater than the previous one.

// #queue

// Simple and intuitive solution once your know queue only keeps count of whats needed
public class RecentCounter
{
    Queue<int> q;

    public RecentCounter()
    {
        q = new Queue<int>();
    }

    public int Ping(int t)
    {
        q.Enqueue(t);

        while (q.Count > 0 && q.Peek() < (t - 3000))
            q.Dequeue();

        return q.Count;
    }
}