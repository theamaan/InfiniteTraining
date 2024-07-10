using System;
using System.IO;

class FilePath
{
    static void Main()
    {
        string directoryPath = @"D:\InfiniteTraining\cSharp\Assessment\Code Challenge 4\Test\Test";
        string fileName = "example.txt";
        string filePath = Path.Combine(directoryPath, fileName);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Request text input from the user
        Console.WriteLine("Please enter the text to append to the file:");
        string userText = Console.ReadLine();

        // Generate a timestamp for the appended text
        string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string textToAppend = $"[{timeStamp}] {userText}";

        StreamWriter writer = null;
        try
        {
            writer = new StreamWriter(filePath, append: true);
            writer.WriteLine(textToAppend);
            Console.WriteLine($"Text appended successfully to {filePath} with a timestamp.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            if (writer != null)
            {
                writer.Close();
            }
        }
        Console.ReadLine();
    }
}
