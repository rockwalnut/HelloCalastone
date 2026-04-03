
using HelloCalastone.Services;
using Moq;

namespace HelloCalastone.Test;

public class AppTest
{
    [Fact]
    public async Task RunWithDependencyInjectionsAsync_ShouldReturnResultCorrectly()
    {
         // Arrange
        var mockFileService = new Mock<IFileService>();
        var fakeLines = new List<string> { 
            "apple pie", 
            "banana bread", 
            "apple crumble" 
        };
   
        string[] words = { "hello", "world", "test", "abc", "aeiou", "to", "do'" };

        mockFileService
            .Setup(fs => fs.ReadFileByLineAsync(It.IsAny<string>())) // with any file path
            .ReturnsAsync(fakeLines); // return the fake lines

        var mockTextService = new Mock<ITextService>();

        mockTextService
            .Setup(ts => ts.FilterMiddleVowelWordsAsync(It.IsAny<string[]>()))
            .ReturnsAsync(words);   
    
        mockTextService.Setup(ts => ts.FilterWordsLessThanLengthAsync(It.IsAny<string[]>(), It.IsAny<int>()))
            .ReturnsAsync(words);  //   Return the same words for simplicity

        mockTextService
            .Setup(ts => ts.FilterWordsByContainsAsync(It.IsAny<string[]>(), It.IsAny<char>()))
            .ReturnsAsync(words); // Return the same words for simplicity

        var app = new App(mockFileService.Object, mockTextService.Object);

        // Act
        await app.RunWithDependencyInjectionsAsync();

        // Assert
        //Assert.Equal(2, result);
    }
    

}