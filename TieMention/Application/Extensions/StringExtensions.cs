using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

public static class StringExtensions
{
    public static string ToSlug(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        string normalizedString = input.Normalize(NormalizationForm.FormD); //DEV
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char c in normalizedString)
        {
            UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        string withoutDiacritics = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

        string slug = withoutDiacritics.ToLowerInvariant().Replace(' ', '-');

        // Remove invalid characters
        slug = Regex.Replace(slug, @"[^a-z0-9\-]", "");

        // Remove duplicate hyphens
        slug = Regex.Replace(slug, @"-+", "-").Trim('-');

        return slug;
    }
}