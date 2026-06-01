// Question - 
// There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes. The biker starts his trip on point 0 with altitude equal 0.

// #prefixSum

// simple Intuitive solution to keep running sum for current altitude
public int LargestAltitude(int[] gain)
{
    int maxAlt = 0, currentAlt = 0;

    for (int i = 0; i < gain.Length; i++)
    {
        currentAlt += gain[i];
        maxAlt = Math.Max(currentAlt, maxAlt);
    }

    return maxAlt;
}