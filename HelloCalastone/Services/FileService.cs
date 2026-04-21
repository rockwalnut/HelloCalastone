using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HelloCalastone.Constants;

namespace HelloCalastone.Services;

public interface IFileService
{
    Task<IEnumerable<string>> ReadFileByLineAsync(string filePath);

    Task<string> ReadByLineIndexAsync(string filePath, int lineIndex);

    //Task<IEnumerable<string>> ReadFileAndApplyTextFilterAsync(string filePath);

}
public class FileService : IFileService 
{

    public FileService()
    {
    }

    public async Task<IEnumerable<string>> ReadFileByLineAsync(string filePath)
    {
        List<string> lines = new List<string>();

        //read file by line
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                lines.Add(line);
            }
        }

        return await Task.FromResult(lines);
    }

    public async Task<string> ReadByLineIndexAsync(string filePath, int lineIndex)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            int currentIndex = 0;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (currentIndex == lineIndex)
                {
                    return line;
                }
 
                currentIndex++;
            }
        }
 
        //throw new IndexOutOfRangeException($"The file does not contain a line at index {lineIndex}.");
        return Word.END_OF_FILE;
    }
}


