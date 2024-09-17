namespace xUnitProject.Tests;

public class StringValidatorTest
{
    [Fact]
    public void validateIsStringEmpty()
    {
        StringValidator validator = new StringValidator(); //Create a new instance
        //Act
        bool isStringEmpty = validator.isEmpty("foo");
        //Assert
        Assert.False(validator.isEmpty("foo")); //Assert that result is false
    }

    [Theory] //Variable set of inputs
    [InlineData("", true)]
    [InlineData("MyString", false)]
    [InlineData("MyString and me", false)]

    public void TestIsStringWhitespace(string input, bool expected)
    {
        StringValidator validator = new StringValidator();
        Assert.Equal(expected, validator.isEmpty(input));
    }

}