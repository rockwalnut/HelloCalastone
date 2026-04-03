using HelloCalastone.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelloCalastone.Services;

public interface ITextService
{
    Task<string[]> FilterMiddleVowelWordsAsync(string[] words);

    Task<string[]> FilterWordsLessThanLengthAsync(string[] words, int length);

    Task<string[]> FilterWordsByContainsAsync(string[] words, char letter);
}


public class TextService : ITextService
{
    //private IFileService _fileService;

    public TextService()
    {
    }

    public async Task<string[]> FilterMiddleVowelWordsAsync(string[] words)
    {
        //filter the words that have a vowel in the middle
        var filteredWords = words.Where(word =>
        {
            if (word.Length < 3) return true;
            else
            {
                var middleIndex = word.Length / 2;
                return !Word.VOWELS.Contains(word[middleIndex].ToString().ToUpper());
            }
        });

        return await Task.FromResult(filteredWords.ToArray());
    }

    public async Task<string[]> FilterWordsLessThanLengthAsync(string[] words, int length)
    {
        //filter the words that have a length less than a specific length
        var filteredWords = words.Where(word =>
        {
            //apply regex to remove special characters from the word befor count a length
            string cleanWord = Regex.Replace(word, @"[^a-zA-Z0-9]", "");

            if (cleanWord.Length >= length) return true;
            else return false;
        });

        return await Task.FromResult(filteredWords.ToArray());
    }

    public async Task<string[]> FilterWordsByContainsAsync(string[] words, char letter)
    {
        //filter the words that have a specific character
        var filteredWords = words.Where(word =>
        {
            if (word.Contains(letter)) return false;
            else return true;
        });

        return await Task.FromResult(filteredWords.ToArray());
    }
}

