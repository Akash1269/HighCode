// Question -
// You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.
// Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, 
// return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.

// Simple and easy to figure out solution, improve over time
// Try to simplify conditions, save to make it easier like in this case we save life and right and then check.
// Edge cases are important, those are first and last element
public bool CanPlaceFlowers(int[] flowerbed, int n) {
    int length = flowerbed.Length;
    for(int i = 0; i < flowerbed.Length; i++) {
        bool isLeft = false;
        bool isRight = false;
        
        if (i == 0 || flowerbed[i - 1] == 0) isLeft = true;
        if (i == length - 1 || flowerbed[i + 1] == 0) isRight = true;
        if (flowerbed[i] == 0 && isLeft && isRight) {
            n--; i++;
        }
    }
    return n <= 0;
}