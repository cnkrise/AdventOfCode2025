namespace AdventOfCode2025
{
    // https://adventofcode.com/2025/day/4
    internal static class Day4
    {
        const char EmptySpace = '.';
        const char RollOfPaper = '@';
        const int MaxPaper = 4;
        public static void Run()
        {
            var firstRun = true;
            var currentRun = 0;
            var accessibleRolls = 0;

            var lines = File.ReadAllLines("./Inputs/Day4.txt");

            char[][] originalArray = lines.Select(x => x.ToCharArray()).ToArray();
            char[][] array = lines.Select(x => x.ToCharArray()).ToArray();
            char[][] arrayCopy = lines.Select(x => x.ToCharArray()).ToArray();

            do
            {
                currentRun = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        if (array[i][j] == RollOfPaper)
                        {
                            var count = 0;

                            // 1 2 3
                            // 4 * 6
                            // 7 8 9

                            // 1
                            if (i > 0 && j > 0 &&
                                array[i - 1][j - 1] == RollOfPaper)
                                count++;

                            // 2
                            if (j > 0 &&
                                array[i][j - 1] == RollOfPaper)
                                count++;

                            // 3
                            if (i < array.Length - 1 && j > 0 &&
                                array[i + 1][j - 1] == RollOfPaper)
                                count++;

                            // 4
                            if (i > 0 &&
                                array[i - 1][j] == RollOfPaper)
                                count++;

                            // 6
                            if (i < array.Length - 1 &&
                                array[i + 1][j] == RollOfPaper)
                                count++;

                            // 7
                            if (i > 0 && j < array[i].Length - 1 &&
                                array[i - 1][j + 1] == RollOfPaper)
                                count++;

                            // 8
                            if (j < array[i].Length - 1 &&
                                array[i][j + 1] == RollOfPaper)
                                count++;

                            // 9
                            if (i < array.Length - 1 && j < array[i].Length - 1 &&
                                array[i + 1][j + 1] == RollOfPaper)
                                count++;

                            if (count < MaxPaper)
                            {
                                currentRun++;

                                //Remove Roll
                                arrayCopy[i][j] = EmptySpace;
                            }
                        }
                    }
                }

                if (firstRun)
                {
                    Console.WriteLine("Part1: " + currentRun);
                    firstRun = false;
                }

                array = (char[][])arrayCopy.Clone();

                accessibleRolls += currentRun;

            } while (currentRun != 0);

            Console.WriteLine("Part2: " + accessibleRolls);
        }
    }
}