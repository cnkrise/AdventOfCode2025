namespace AdventOfCode2025
{
    // https://adventofcode.com/2025/day/7
    internal static class Day7
    {
        public static void Run()
        {
            int splits = 0;

            var lines = File.ReadAllLines("./Inputs/Day7.txt");
            char[][] array = lines.Select(x => x.ToCharArray()).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    var currentSpace = array[i][j];

                    if (currentSpace == '.')
                    {
                        if (i > 0)
                        {
                            if (array[i - 1][j] == 'S' || array[i - 1][j] == '|')
                                array[i][j] = '|';
                        }
                    }
                    else if (currentSpace == '^')
                    {
                        if (i > 0)
                        {
                            if (array[i - 1][j] == 'S' || array[i - 1][j] == '|')
                            {
                                if (j > 0 && array[i][j - 1] != '^')
                                    array[i][j - 1] = '|';

                                if (j < array.Length - 1 && array[i][j + 1] != '^')
                                    array[i][j + 1] = '|';

                                splits++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Part2: " + splits);
        }
    }
}