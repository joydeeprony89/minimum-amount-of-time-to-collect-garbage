namespace minimum_amount_of_time_to_collect_garbage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Example 1:

Input: garbage = ["G","P","GP","GG"], travel = [2,4,3]
Output: 21
Explanation:
The paper garbage truck:
1. Travels from house 0 to house 1
2. Collects the paper garbage at house 1
3. Travels from house 1 to house 2
4. Collects the paper garbage at house 2
Altogether, it takes 8 minutes to pick up all the paper garbage.
The glass garbage truck:
1. Collects the glass garbage at house 0
2. Travels from house 0 to house 1
3. Travels from house 1 to house 2
4. Collects the glass garbage at house 2
5. Travels from house 2 to house 3
6. Collects the glass garbage at house 3
Altogether, it takes 13 minutes to pick up all the glass garbage.
Since there is no metal garbage, we do not need to consider the metal garbage truck.
Therefore, it takes a total of 8 + 13 = 21 minutes to collect all the garbage.
Example 2:

Input: garbage = ["MMM","PGM","GP"], travel = [3,10]
Output: 37
Explanation:
The metal garbage truck takes 7 minutes to pick up all the metal garbage.
The paper garbage truck takes 15 minutes to pick up all the paper garbage.
The glass garbage truck takes 15 minutes to pick up all the glass garbage.
It takes a total of 7 + 15 + 15 = 37 minutes to collect all the garbage.
             */
        }
    }


    public class Solution
    {
        public int GarbageCollection(string[] garbage, int[] travel)
        {
            // Step 1 - as we need to pick all garbages , count of all chars G,P,M which takes 1 unit time, will be added to result
            // Step 2 - we need to find the last occurance of each chars G,P,M, so that based on the last occurance position will traverse till that position and the cost of travelling would be added. In question its mentioned we no need to travel till the end if there are no more that type of garbage is present.
            // to calculate step 2, we can create prefix array of travel array, and based on the last occurance of that garbage we can get the travel time from thisprefix array

            // calculate the char count and also find the last occurance of each chars
            var map = new Dictionary<char, int>();
            int charCount = 0;
            int ans = 0;
            for (int j = 0; j < garbage.Length; j++)
            {
                var g = garbage[j];
                var chars = g.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    char c = chars[i];
                    if (!map.ContainsKey(c)) map[c] = j;
                    else map[c] = j;
                    charCount++;
                }
            }

            // create travel Prefix array
            int prev = 0;
            for (int i = 0; i < travel.Length; i++)
            {
                prev += travel[i];
                travel[i] = prev;
            }
            int MIndex = map.ContainsKey('M') ? map['M'] - 1 : -1;
            int PIndex = map.ContainsKey('P') ? map['P'] - 1 : -1;
            int GIndex = map.ContainsKey('G') ? map['G'] - 1 : -1;
            if (MIndex != -1) ans += travel[MIndex];
            if (PIndex != -1) ans += travel[PIndex];
            if (GIndex != -1) ans += travel[GIndex];

            return ans + charCount;
        }
    }
}