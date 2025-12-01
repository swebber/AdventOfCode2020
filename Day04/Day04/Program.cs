// See https://aka.ms/new-console-template for more information
using Day04;

var passports = PassportParser.ParseFromFile("data01.txt");
Console.WriteLine($"Passports: {passports.Count}");

var validCount = passports.Count(p => p.IsValid());
Console.WriteLine($"Valid Passports: {validCount}");
