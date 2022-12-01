using Xunit.Abstractions;

namespace StringTrimmerTests
{
    public class TestsBase
    {
        protected readonly ITestOutputHelper _testOutputHelper;
        public TestsBase(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}
