using FluentAssertions;
using StringTrimmer;
using Xunit;

namespace StringTrimmerTests;

public class TrimExtraSpacesTests
{
    [Theory]
    [InlineData(" A ", "A")]
    [InlineData(" A", "A")]
    [InlineData("A ", "A")]
    [InlineData("A", "A")]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData(" A B ", "A B")]
    [InlineData(" A  B ", "A B")]
    [InlineData(" A B", "A B")]
    [InlineData(" A  B", "A B")]
    [InlineData("A B ", "A B")]
    [InlineData("A  B ", "A B")]
    public void TrimExtraSpacesTest(string source, string expected)
    {
        var test = new SimpleTestClass { StringProperty = source };
        test.TrimExtraSpaces();
        test.StringProperty.Should().Be(expected);
    }

    [Theory]
    [InlineData(" A ")]
    [InlineData(" A")]
    [InlineData("A ")]
    [InlineData("A")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" A B ")]
    [InlineData(" A  B ")]
    [InlineData(" A B")]
    [InlineData(" A  B")]
    [InlineData("A B ")]
    [InlineData("A  B ")]
    public void TrimExtraSpaces_ShouldSkipFieldsWithoutPublicSetter(string source)
    {
        var test = new PrivateSetterTestClass(source);
        test.TrimExtraSpaces();
        test.StringProperty.Should().Be(source);
    }


    [Theory]
    [InlineData(" A ", "A")]
    [InlineData(" A", "A")]
    [InlineData("A ", "A")]
    [InlineData("A", "A")]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData(" A B ", "A B")]
    [InlineData(" A  B ", "A B")]
    [InlineData(" A B", "A B")]
    [InlineData(" A  B", "A B")]
    [InlineData("A B ", "A B")]
    [InlineData("A  B ", "A B")]
    public void TrimExtraSpaces_ShouldTrimFieldsWithoutPublicSetter(string source, string expected)
    {
        var test = new PrivateSetterTestClass(source);
        test.TrimExtraSpaces(ClassTrimmerOptions.TrimPrivateProperties);
        test.StringProperty.Should().Be(expected);
    }
}

