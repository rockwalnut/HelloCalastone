


using HelloCalastone.Services;
using Moq;

namespace HelloCalastone.Test;

public class FileServiceTest
{
    [Fact]
    public async Task ReadFileAndApplyTextFilterAsync_ShouldFilterCorrectly()
    {
        string filePath = "Assets/Hello.txt";

        //moq
        var mockTextService = new Mock<ITextService>();

        string[] words = { "hello", "world", "test", "abc", "aeiou" };

        mockTextService.Setup(r => r.FilterMiddleVowelWordsAsync(It.IsAny<string[]>())).ReturnsAsync(words);
        mockTextService.Setup(r => r.FilterWordsLessThanLengthAsync(It.IsAny<string[]>(), It.IsAny<int>())).ReturnsAsync(words);
        mockTextService.Setup(r => r.FilterWordsByContainsAsync(It.IsAny<string[]>(), It.IsAny<char>())).ReturnsAsync(words);

        //arrange
        var _fileService = new FileService(mockTextService.Object);

        // Act
        var result = await _fileService.ReadFileAndApplyTextFilterAsync(filePath);
        
        // Assert
        Assert.Contains("hello", result);
        Assert.Contains("world", result);
        //Assert.DoesNotContain("aeiou", result);
    }

}