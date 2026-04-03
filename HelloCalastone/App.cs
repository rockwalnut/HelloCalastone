

using HelloCalastone.Services;

namespace HelloCalastone;

public class App
{
    private ITextService _textService;
    private IFileService _fileService;

    public App(IFileService fileService, ITextService textService)
    {
        _fileService = fileService;
        _textService = textService;
    }

    string filePath = "Assets/Hello.txt";

    public async Task<IEnumerable<string>> RunWithDependencyInjectionsAsync()
    {       
        var lines = await _fileService.ReadFileByLineAsync(filePath);
        var filteredLines = new List<string>();

        foreach (var line in lines)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //Apply text filters to the line
            words = await _textService.FilterMiddleVowelWordsAsync(words);
            words = await _textService.FilterWordsLessThanLengthAsync(words, 3);
            words = await _textService.FilterWordsByContainsAsync(words, 't');

            filteredLines.Add(string.Join(' ', words));
        }

        return filteredLines;
    }

    public async Task RunWithLessMemoryConsumeAsync()
    {
        //less memory consume version
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //Apply text filters to the line
                words = await _textService.FilterMiddleVowelWordsAsync(words);
                words = await _textService.FilterWordsLessThanLengthAsync(words, 3);
                words = await _textService.FilterWordsByContainsAsync(words, 't');

                Console.WriteLine(string.Join(' ', words));
            }
        }
    }

    public static async Task Main(string[] args)
    {
        var app = new App(new FileService(), new TextService());
        var results = await app.RunWithDependencyInjectionsAsync();

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}
