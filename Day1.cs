namespace AdventOfCode2025
{
    // https://adventofcode.com/2025/day/1
    internal static class Day1
    {
        public static void Run()
        {
            var landOnZero = 0;
            var passesZero = 0;
            var position = 50;
            var lines = File.ReadAllLines("./Inputs/Day1.txt");

            foreach (var line in lines)
            {
                var wasZero = position == 0;

                var digitStr = line.Substring(1, line.Length - 1);

                var rotations = int.Parse(digitStr);

                while (rotations > 99)
                {
                    passesZero++;
                    rotations -= 100;
                }

                if (line[0] == 'L')
                    rotations *= -1;

                position += rotations;

                if (position < 0)
                {
                    if (!wasZero)
                        passesZero++;

                    position += 100;
                }
                else if (position > 99)
                {
                    if (!wasZero)
                        passesZero++;

                    position -= 100;
                }
                else if (position == 0)
                {
                    passesZero++;
                    landOnZero++;
                }
            }

            Console.WriteLine("Lands On Zero: " + landOnZero);
            Console.WriteLine("Passes Zero: " + passesZero);
        }
    }
}
