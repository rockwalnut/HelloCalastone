

using HelloCalastone.Services;

string filePath = "Assets/Hello.txt";

//di version
ITextService textService = new TextService();
IFileService fileService = new FileService();

var lines = await fileService.ReadFileByLineAsync(filePath);
foreach (var line in lines)
{
    string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    //Apply text filters to the line
    words = await textService.FilterMiddleVowelWordsAsync(words);
    words = await textService.FilterWordsLessThanLengthAsync(words, 3);
    words = await textService.FilterWordsByContainsAsync(words, 't');

    Console.WriteLine(string.Join(' ', words));
}


Console.ReadLine();

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
