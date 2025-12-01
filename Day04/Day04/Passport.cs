using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Day04;

internal class Passport
{
    public int BirthYear { get; set; }
    public int IssueYear { get; set; }
    public int ExpirationYear { get; set; }
    public string Height { get; set; } = string.Empty;
    public string HairColor { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string PassportId { get; set; } = string.Empty;
    public string CountryId { get; set; } = string.Empty;

    internal bool IsValid()
    {
        if (BirthYear < 1920 || BirthYear > 2002) return false;
        if (IssueYear < 2010 || IssueYear > 2020) return false;
        if (ExpirationYear < 2020 || ExpirationYear > 2030) return false;
        if (string.IsNullOrWhiteSpace(Height)) return false;
        if (string.IsNullOrWhiteSpace(HairColor)) return false;
        if (string.IsNullOrWhiteSpace(EyeColor)) return false;
        if (string.IsNullOrWhiteSpace(PassportId)) return false;

        return true;
    }
}
