// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using System.Text.Json;

namespace EquityX.Maui.FileHandler;
public class StorageManager
{
    /// <summary>
    /// STORE DATA
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <param name="data"></param>
    public static void StoreToFile<T>(string filePath, T data)
    {
        try
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            // left for now
            Console.WriteLine($"Failed to serialize data: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// LOAD DATA
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static T LoadFromFile<T>(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }
        }
        catch (Exception ex)
        {
            // left for now
            Console.WriteLine($"Failed to deserialize data: {ex.Message}", ex);
        }
        return default(T);
    }

    /// <summary>
    /// GET FILE PATH
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetFilePath(string fileName)
    {
        return Path.Combine(FileSystem.AppDataDirectory, fileName);
    }

    /// <summary>
    /// CHECK FILE EXIST OR NOT
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static bool IsFileEmpty(string fileName)
    {
        if (File.Exists(fileName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
