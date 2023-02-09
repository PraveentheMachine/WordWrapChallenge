using Challenge;
using Xunit;
using Xunit.Abstractions;

namespace ChallengeTest;
public class WordWrapTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public WordWrapTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData("", 1, "" )]
    [InlineData("Tree", 2, "Tr\nee" )]
    [InlineData("Math", 4, "Math" )]
    [InlineData("Totara", 10, "Totara" )]
    [InlineData("1234", 1, "1\n2\n3\n4" )]
    [InlineData("Totara", 1, "T\no\nt\na\nr\na" )]
    [InlineData("Hi my name is Praveen", 3, "Hi\nmy\nnam\ne\nis\nPra\nvee\nn" )]
    [InlineData("Hi my name is Naveen", 5, "Hi my\nname\nis\nNavee\nn" )]
    [InlineData("Hi my name is Praveen", 10, "Hi my name\nis Praveen" )]
    [InlineData("Hi my name is PraveenB", 10, "Hi my name\nis\nPraveenB" )]
    [InlineData("Quick brown fox", 4, "Quic\nk\nbrow\nn\nfox" )]
    [InlineData("Quick brown fox 2", 5, "Quick\nbrown\nfox 2" )]
    [InlineData("Hi my name is Praveen Bandarage", 10, "Hi my name\nis Praveen\nBandarage" )]
    [InlineData("       Hi my       name is Praveen   ", 3, "Hi\nmy\nnam\ne\nis\nPra\nvee\nn" )]
    
    public void Wrap_Returns_CorrectlyWrappedString(string message, int length, string expectedResult)
    {
        //Arrange 
        var sut = new WordWrapChallenge();

        //Act 
        var result = sut.Wrap(message,length);
        _testOutputHelper.WriteLine(result);

        //Assert 
        Assert.Equal(expectedResult,result);
    }
    
    [Theory]
    [InlineData("Totara", -10)]
    [InlineData("Totara", 0)]
    public void Passing_NonPositive_Numbers_ShouldThrow(string message, int length)
    {
        //Arrange 
        var sut = new WordWrapChallenge();

        //Act
        var ex = Assert.Throws<ArgumentException>(() => sut.Wrap(message,length));
        
        //Assert
        Assert.Equal( $"The provided value was {length} which is a non positive number", ex.Message );
    }
}