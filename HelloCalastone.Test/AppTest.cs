



using System.IO.Pipes;
using HelloCalastone.Services;
using Moq;

namespace HelloCalastone.Test;

public class AppTest
{
    /*[Fact]
    public async Task Main_ShouldReturnResultCorrectly()
    {
        // Arrange
        string[] words = { "hello", "world", "test", "abc", "aeiou", "to", "'do" };

        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(r => r.ReadFileByLineAsync("mock"))
                .ReturnsAsync(words);

        var fileService = new FileService();

        // Act
        var result = await fileService.ReadFileByLineAsync("mock");

        // Assert
        Assert.Contains("world", result);
        Assert.Contains("test", result);
    }*/

}