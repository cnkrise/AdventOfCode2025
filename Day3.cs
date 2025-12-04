namespace AdventOfCode2025
{
    // https://adventofcode.com/2025/day/3
    internal static class Day3
    {
        public static void Run()
        {
            long invalidIdSumPart1 = 0;
            long invalidIdSumPart2 = 0;
            var text = File.ReadAllText("./Inputs/Day3.txt");

            var ranges = text.Split(',');

            foreach (var range in ranges)
            {
                var rangeSplit = range.Split("-");
                var firstNumber = long.Parse(rangeSplit[0]);
                var secondNumber = long.Parse(rangeSplit[1]);

                for (var i = firstNumber; i <= secondNumber; i++)
                {
                    var numStr = i.ToString();

                    for (var j = 2; j <= numStr.Length; j++)
                    {
                        if (numStr.Length % j == 0)
                        {
                            var parts = new List<string>(j);

                            var subStrLen = numStr.Length / j;

                            for (var k = 0; k < j; k++)
                            {
                                parts.Add(numStr.Substring(k * subStrLen, subStrLen));
                            }

                            if (parts.All(x => x == parts[0]))
                            {
                                if (j == 2)
                                    invalidIdSumPart1 += i;

                                invalidIdSumPart2 += i;

                                break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Part1 Invalid Ids Sum: " + invalidIdSumPart1);
            Console.WriteLine("Part2 Invalid Ids Sum: " + invalidIdSumPart2);
        }
    }
}
