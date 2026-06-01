// Question - Given two 0-indexed integer arrays nums1 and nums2, return a list answer of size 2 where:
// answer[0] is a list of all distinct integers in nums1 which are not present in nums2.
// answer[1] is a list of all distinct integers in nums2 which are not present in nums1.

// #HashMap

// Simple approach, intuitive
public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
{
    var set1 = new HashSet<int>(nums1);
    var set2 = new HashSet<int>(nums2);

    var list1 = new List<int>();
    var list2 = new List<int>();

    foreach (int x in set1)
    {
        if (!set2.Contains(x)) list1.Add(x);
    }

    foreach (int x in set2)
    {
        if (!set1.Contains(x)) list2.Add(x);
    }

    return new List<IList<int>>() { list1, list2 };
}