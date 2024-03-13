using Again2.Models;

namespace Again2.Helpers;

public static class SliderExtencion
{
    public static bool CheckFileType(this IFormFile file, string fileType)
    {
        return file.ContentType.Contains(fileType);
    }
    public static bool CheckFileSize(this IFormFile file, int size)
    {
        return file.Length /1024 < size;
    }
}
