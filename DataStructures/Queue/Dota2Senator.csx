// Question 
// Given a string of senators 'R' (Radiant) and 'D' (Dire), each senator can ban one future senator from the opposing party during their turn.
// Simulate the process and return which party wins: "Radiant" or "Dire".

// #queue 

// Not so intuitive, as you dont need to maintain single queue but use indices of these senates in a queue
// Just another approach when comparing two elements put it in two different queues
public string PredictPartyVictory(string senate)
{
    var dSenates = new Queue<int>();
    var rSenates = new Queue<int>();
    int n = senate.Length;

    for (int i = 0; i < senate.Length; i++)
    {
        if (senate[i] == 'R') rSenates.Enqueue(i);
        else dSenates.Enqueue(i);
    }

    while (dSenates.Count > 0 && rSenates.Count > 0)
    {
        int dPos = dSenates.Dequeue();
        int rPos = rSenates.Dequeue();
        if (dPos < rPos)
        {
            dSenates.Enqueue(dPos + n);
        }
        else
        {
            rSenates.Enqueue(rPos + n);
        }
    }

    return dSenates.Count == 0 ? "Radiant" : "Dire";
}

// More intuitive approach but not efficient, as finding and deleting is costly
// this can be improved more with hold the delete till we discover that element and mark and skip it
public string PredictPartyVictory(string senate)
{
    var list = new List<char>();
    var rCount = 0;
    var dCount = 0;

    for (int i = 0; i < senate.Length; i++)
    {
        list.Add(senate[i]);

        if (senate[i] == 'R')
        {
            rCount++;
        }
        else
        {
            dCount++;
        }
    }

    int j = 0;
    while (rCount != 0 && dCount != 0)
    {
        if (list[j] == 'R' && dCount > 0)
        {
            Find(list, 'D', j);
            dCount--;
        }
        else if (list[j] == 'D' && rCount > 0)
        {
            Find(list, 'R', j);
            rCount--;
        }

        j = (j + 1) % list.Count;
    }

    if (rCount >= dCount)
        return "Radiant";
    else
        return "Dire";
}

void Find(List<char> list, char oppositeParty, int from)
{

    int n = list.Count;
    int i = (from + 1) % n;

    while (i != from)
    {
        if (list[i] == oppositeParty)
        {
            list[i] = '0'; // ban
            break;
        }

        i = (i + 1) % n;
    }
}
