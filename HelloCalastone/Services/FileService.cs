using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloCalastone.Services;

public interface IFileService
{
    Task<IEnumerable<string>> ReadFileByLineAsync(string filePath);

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
}


