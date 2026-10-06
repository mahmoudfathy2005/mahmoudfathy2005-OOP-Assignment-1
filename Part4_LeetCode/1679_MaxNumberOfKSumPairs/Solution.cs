public class Solution
{
    public int MaxOperations(int[] nums, int k)
    {
        int Left = 0;
        int Right = nums.Length - 1;
        int operations = 0;
        nums.Sort();
        while (Left < Right)
        {
            if (nums[Left] + nums[Right] == k)
            {
                operations++;
                Left++;
                Right--;
            }
            else if (nums[Left] + nums[Right] < k)
            {
                Left++;
            }
            else
            {
                Right--;

            }
        }
            return operations;
        
    }
}