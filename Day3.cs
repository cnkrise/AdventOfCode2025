namespace AdventOfCode2025
{
    // https://adventofcode.com/2025/day/3
    internal static class Day3
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("./Inputs/Day3.txt");

            var part1 = FlipBatteries(lines, 2);
            var part2 = FlipBatteries(lines, 12);

            Console.WriteLine("Part1 Sum: " + part1);
            Console.WriteLine("Part2 Sum: " + part2);
        }

        private static long FlipBatteries(string[] lines, int batteriesToFlip)
        {
            long sum = 0;

            foreach (var line in lines)
            {
                int[] largestNumbers = new int[batteriesToFlip];
                int[] largestNumbersIndex = new int[batteriesToFlip];

                for (var i = 0; i < batteriesToFlip; i++)
                {
                    var batteriesLeftToFlip = batteriesToFlip - 1 - i;

                    var lastIndex = 0;
                    var startingPoint = 0;
                    var lineLengthLeft = line.Length;

                    if (i > 0)
                    {
                        lastIndex = largestNumbersIndex[i - 1];
                        startingPoint = lastIndex + 1;
                    }

                    lineLengthLeft = line.Length - startingPoint;

                    var lineToExamine = line.Substring(startingPoint, lineLengthLeft - batteriesLeftToFlip);

                    var largestNum = lineToExamine.Select(x => int.Parse(x.ToString())).Max();

                    var largestNumIndex = lineToExamine.IndexOf(largestNum.ToString()) + startingPoint;

                    largestNumbers[i] = largestNum;
                    largestNumbersIndex[i] = largestNumIndex;
                }

                var numStr = new string(largestNumbers.Select(x => x.ToString()[0]).ToArray());
                var num = long.Parse(numStr);

                sum += num;
            }

            return sum;
        }
    }
}