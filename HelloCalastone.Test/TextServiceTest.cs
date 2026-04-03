using HelloCalastone.Services;

namespace HelloCalastone.Test;

public class TextServiceTest
{
    [Fact]
    public async Task FilterMiddleVowelWordsAsync_ShouldFilterCorrectly()
    {
        // Arrange
        var _textService = new TextService();
        string[] words = { "hello", "world", "test", "abc", "aeiou" };
      
        // Act
        var result = await _textService.FilterMiddleVowelWordsAsync(words);
        
        // Assert
        Assert.Contains("hello", result);
        Assert.Contains("world", result);
        Assert.DoesNotContain("aeiou", result);
    }


    [Fact]
    public async Task FilterWordsByLengthAsync_ShouldFilterCorrectly()
    {
        // Arrange
        var _textService = new TextService();
        string[] words = { "hello", "world", "test", "abc", "aeiou", "to", "do'" };

        // Act
        var result = await _textService.FilterWordsLessThanLengthAsync(words, 3);

        // Assert
        Assert.Contains("hello", result);
        Assert.Contains("world", result);
        Assert.DoesNotContain("to", result);
        Assert.DoesNotContain("do", result);
    }


    [Fact]
    public async Task FilterWordsByContainsAsync_ShouldFilterCorrectly()
    {
        // Arrange
        var _textService = new TextService();
        string[] words = { "hello", "world", "test", "abc", "aeiou" };

        // Act
        var result = await _textService.FilterWordsByContainsAsync(words, 't');

        // Assert
        Assert.Contains("hello", result);
        Assert.Contains("world", result);
        Assert.DoesNotContain("test", result);
    }
}