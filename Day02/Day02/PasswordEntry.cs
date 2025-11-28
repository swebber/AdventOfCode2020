namespace Day02;

internal class PasswordEntry
{
    public int Min { get; set; }
    public int Max { get; set; }
    public char Letter { get; set; }
    public required string Password { get; set; }

    public bool IsValidByCountPassword()
    {
        var count = Password.Count(c => c == Letter);
        return count >= Min && count <= Max;
    }

    public bool IsValidByPositionPassword()
    {
        bool firstPositionMatches = Password[Min - 1] == Letter;
        bool secondPositionMatches = Password[Max - 1] == Letter;
        return firstPositionMatches ^ secondPositionMatches;
    }
}
