using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day04;

internal static class PassportParser
{
    public static IReadOnlyList<Passport> ParseFromFile(string fn)
    {
        var appDir = AppDomain.CurrentDomain.BaseDirectory;
        var path = Path.Combine(appDir, "Data", fn);

        var lines = File.ReadAllLines(path);
        return ParseFromLines(lines);
    }

    public static IReadOnlyList<Passport> ParseFromText(string text)
    {
        var lines = text
            .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        return ParseFromLines(lines);
    }

    private static IReadOnlyList<Passport> ParseFromLines(IEnumerable<string> lines)
    {
        var passports = new List<Passport>();
        var tokens = new List<string>();

        foreach (var raw in lines)
        {
            var line = raw ?? string.Empty;
            if (string.IsNullOrWhiteSpace(line))
            {
                if (tokens.Count > 0)
                {
                    passports.Add(BuildPassport(tokens));
                    tokens.Clear();
                }

                continue;
            }

            tokens.AddRange(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }

        // final passport (no trailing blank line)
        if (tokens.Count > 0)
            passports.Add(BuildPassport(tokens));

        return passports;
    }

    private static Passport BuildPassport(IEnumerable<string> tokens)
    {
        var p = new Passport();

        foreach (var token in tokens)
        {
            var parts = token.Split(':', 2);
            if (parts.Length < 2)
                continue;

            var key = parts[0];
            var value = parts[1];

            switch (key)
            {
                case "byr":
                    int.TryParse(value, out var byr);
                    p.BirthYear = byr;
                    break;
                case "iyr":
                    int.TryParse(value, out var iyr);
                    p.IssueYear = iyr;
                    break;
                case "eyr":
                    int.TryParse(value, out var eyr);
                    p.ExpirationYear = eyr;
                    break;
                case "hgt":
                    p.Height = value ?? string.Empty;
                    break;
                case "hcl":
                    p.HairColor = value ?? string.Empty;
                    break;
                case "ecl":
                    p.EyeColor = value ?? string.Empty;
                    break;
                case "pid":
                    p.PassportId = value ?? string.Empty;
                    break;
                case "cid":
                    p.CountryId = value ?? string.Empty;
                    break;
                default:
                    // ignore unknown fields
                    break;
            }
        }

        return p;
    }
}