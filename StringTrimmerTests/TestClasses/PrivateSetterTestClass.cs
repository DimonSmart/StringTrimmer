namespace StringTrimmerTests.TestClasses;

public class PrivateSetterTestClass
{
    public PrivateSetterTestClass(string s)
    {
        StringProperty = s;
    }

    public string? StringProperty { get; private set; }
}

