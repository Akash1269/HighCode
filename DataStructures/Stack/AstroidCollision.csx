// Question
// Given an array of asteroids where the absolute value represents size and the sign represents direction, return the asteroids remaining after all collisions. 
// When two asteroids moving toward each other collide, the smaller one explodes, and if they are the same size, both explode.

// #stack

// Lil complicated and time consuming, analyze the conditions on paper well to know right conditions up front
public int[] AsteroidCollision(int[] roids)
{
    var stack = new Stack<int>();

    for (int i = 0; i < roids.Length; i++)
    {

        // Conditions to just add are more than collision
        // stack empty
        // peek +ve, current +ve
        // peek -ve, current +ve
        // peek -ve, current -ve
        if (stack.Count == 0 || roids[i] > 0 || stack.Peek() < 0)
        {
            stack.Push(roids[i]);
            // Console.WriteLine("Pushed : " + roids[i]);
        }

        // evaluate recurrsively who will survive the crash until there is no crash, only iterate for peek, current is fixed to be negative
        // peek +ve, current -ve
        else
        {
            // to know if current element still needs to add or not
            bool shouldPush = true;
            int current = -roids[i];
            while (stack.Count > 0 && stack.Peek() > 0)
            {

                // Console.WriteLine("Compared : " + stack.Peek() + " | " + roids[i]);
                if (current > stack.Peek())
                {
                    stack.Pop();
                }
                else if (current < stack.Peek())
                {
                    shouldPush = false;
                    break;
                }
                else
                {
                    stack.Pop();
                    shouldPush = false;
                    break;
                }
            }

            if (shouldPush)
            {
                stack.Push(roids[i]);
            }
        }
    }

    return stack.Reverse().ToArray();
}