using AdventOfCode2025;

Console.WriteLine("Which Day?");
var day = Console.ReadLine();

switch (day)
{
    case "1":
        Day1.Run();
        break;
    case "2":
        Day2.Run();
        break;
    case "3":
        Day3.Run();
        break;
    default:
        break;
}
