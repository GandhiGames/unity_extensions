using System.Text;


public static class StringExtensions
{
    public static bool ContainsPhrase(this string str, string[] phrases)
    {
        if (string.IsNullOrEmpty(str))
            return false;

        foreach (var phrase in phrases)
        {
            if (str.Contains(phrase))
            {
                return true;
            }
        }

        return false;
    }

    public static string Truncate(this string str, int maxLength)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        return str.Length <= maxLength ? str : str.Substring(0, maxLength);
    }

    public static string InsertCharEveryNChars(this string str, char insertCharacter, int n, out int charsInserted)
    {
        charsInserted = 0;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            if (i % n == 0)
            {
                sb.Append(insertCharacter);

                charsInserted++;
            }

            if (str[i] == insertCharacter)
            {
                charsInserted++;
            }

            sb.Append(str[i]);
        }

        return sb.ToString();
    }

}
