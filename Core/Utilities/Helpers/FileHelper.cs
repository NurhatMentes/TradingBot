namespace Core.Utilities.Helpers;

public static class FileHelper
{
    public static string GetUniqueFileName(string fileName)
    {
        fileName = Path.GetFileName(fileName);
        return string.Concat(Path.GetFileNameWithoutExtension(fileName)
            , "_"
            , Guid.NewGuid().ToString().AsSpan(0, 4)
            , Path.GetExtension(fileName));
    }

    public static string GetFileExtension(string fileName)
    {
        return Path.GetExtension(fileName)?.ToLowerInvariant();
    }

    public static bool IsValidFileExtension(string fileName, string[] allowedExtensions)
    {
        var extension = GetFileExtension(fileName);
        return !string.IsNullOrEmpty(extension) && allowedExtensions.Contains(extension);
    }
}