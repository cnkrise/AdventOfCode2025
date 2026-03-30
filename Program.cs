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
    case "4":
        Day4.Run();
        break;
    case "5":
        Day5.Run();
        break;
    case "6":
        Day6.Run();
        break;
    case "7":
        Day7.Run();
        break;
    case "T":
        TestDay.Run();
        break;
    default:
        break;
}
