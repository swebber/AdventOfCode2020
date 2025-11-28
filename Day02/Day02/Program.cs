using Day02;
using System.Text.RegularExpressions;

var input = ParseInput("data01.txt");
int validCount = input.Count(entry => entry.IsValidByCountPassword());
int validPositionCount = input.Count(entry => entry.IsValidByPositionPassword());
Console.WriteLine($"Number of valid passwords (by count): {validCount}");
Console.WriteLine($"Number of valid passwords (by position): {validPositionCount}");

static List<PasswordEntry> ParseInput(string fn)
{
    var appDir = AppDomain.CurrentDomain.BaseDirectory;
    var filePath = Path.Combine(appDir, "Data", fn);

    var lines = File.ReadAllLines(filePath);
    var entries = new List<PasswordEntry>();

    foreach (var item in lines)
    {
        var match = Regex.Match(item, @"^(\d+)-(\d+) (\w): (\w+)$");
        if (!match.Success) continue;

        entries.Add(new PasswordEntry
        {
            Min = int.Parse(match.Groups[1].Value),
            Max = int.Parse(match.Groups[2].Value),
            Letter = match.Groups[3].Value[0],
            Password = match.Groups[4].Value
        });
    }

    return entries;
}