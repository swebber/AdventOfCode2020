using Day03;

var trees = new TreeMap("data01.txt");
int treeCount = trees.TraverseAndCountTrees(3, 1);

Console.WriteLine($"Trees: {trees.Count}");
Console.WriteLine($"Height: {trees.Height}");
Console.WriteLine($"Encountered Trees: {treeCount}");

List<int> treeCounts = new();
treeCounts.Add(trees.TraverseAndCountTrees(1, 1));
treeCounts.Add(trees.TraverseAndCountTrees(3, 1));
treeCounts.Add(trees.TraverseAndCountTrees(5, 1));
treeCounts.Add(trees.TraverseAndCountTrees(7, 1));
treeCounts.Add(trees.TraverseAndCountTrees(1, 2));

long product = 1;
foreach (int count in treeCounts)
{
    product *= count;
}

Console.WriteLine($"Product of encountered trees: {product}");