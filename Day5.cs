namespace AdventOfCode2025
{
    // https://adventofcode.com/2025/day/5
    internal static class Day5
    {
        public static void Run()
        {
            var totalFresh = 0;
            var ranges = new List<(long begin, long end)>();
            var numbers = new List<long>();

            var lines = File.ReadAllLines("./Inputs/Day5.txt");

            var beforeBlankLine = true;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    beforeBlankLine = false;
                    continue;
                }

                if (beforeBlankLine)
                {
                    var splitLine = line.Split('-');
                    var rangeNumber1 = long.Parse(splitLine[0]);
                    var rangeNumber2 = long.Parse(splitLine[1]);

                    ranges.Add((rangeNumber1, rangeNumber2));
                }
                else
                {
                    var number = long.Parse(line);
                    var fresh = false;
                    foreach (var range in ranges)
                    {
                        if (number >= range.begin && number <= range.end)
                        {
                            fresh = true;
                            break;
                        }
                    }

                    if (fresh)
                        totalFresh++;
                }
            }

            // combine ranges
            for (int i = 0; i < ranges.Count; i++)
            {
                var (beg, end) = ranges[i];

                var overlapping = ranges.Where(x => x.begin <= beg && x.end >= beg || x.begin <= end && x.end >= end).ToArray();
                if (overlapping.Length > 1)
                {
                    var newRange = (overlapping.Min(x => x.begin), overlapping.Max(x => x.end));

                    foreach (var overlap in overlapping)
                    {
                        ranges.Remove(overlap);
                    }

                    ranges.Add(newRange);

                    i = 0;
                }
            }

            var totalNumbers = ranges.Sum(x => x.end - x.begin + 1);

            Console.WriteLine("Part1: " + totalFresh);
            Console.WriteLine("Part2: " + totalNumbers);
        }
    }
}