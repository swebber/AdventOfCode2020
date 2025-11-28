var input = ParseInput("data01.txt");

int n = 3; // Find 3 numbers that sum to 2020
var result = FindNSum(input, n, 2020);

if (result != null)
{
    Console.WriteLine($"Found: {string.Join(", ", result)}");
    Console.WriteLine($"Product: {result.Aggregate(1, (acc, val) => acc * val)}");
}
else
{
    Console.WriteLine("No combination found.");
}

static List<int>? FindNSum(List<int> input, int n, int targetSum)
{
    var result = new List<int>();
    bool found = FindNSumHelper(input, n, targetSum, 0, result);
    return found ? result : null;
}

// Helper: recursive backtracking
static bool FindNSumHelper(List<int> numbers, int n, int targetSum, int start, List<int> path)
{
    if (n == 0 && targetSum == 0) return true;
    if (n == 0 || targetSum < 0) return false;

    for (int i = start; i < numbers.Count; i++)
    {
        path.Add(numbers[i]);
        if (FindNSumHelper(numbers, n - 1, targetSum - numbers[i], i + 1, path)) return true;

        path.RemoveAt(path.Count - 1);
    }

    return false;
}

static List<int> ParseInput(string fn)
{
    var appDir = AppDomain.CurrentDomain.BaseDirectory;
    var filePath = Path.Combine(appDir, "Data", fn);

    return File.ReadAllLines(filePath)
        .Select(line => int.Parse(line))
        .ToList();
}