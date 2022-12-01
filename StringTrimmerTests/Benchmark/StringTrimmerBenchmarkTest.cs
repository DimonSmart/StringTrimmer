using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Xunit;
using Xunit.Abstractions;

namespace StringTrimmerTests.Benchmark
{
    public class StringTrimmerBenchmarkTest : TestsBase
    {
        public StringTrimmerBenchmarkTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void BenchmarkTest()
        {
            Summary result = BenchmarkRunner.Run<StringTrimmerBenchmark>();
            _testOutputHelper.WriteLine(result.ResultsDirectoryPath);
        }


        [Fact]
        public void BenchmarkEtalonTest()
        {
            Summary result = BenchmarkRunner.Run<StringTrimmerEtalonBenchmark>();
            _testOutputHelper.WriteLine(result.ResultsDirectoryPath);
        }
    }
}
