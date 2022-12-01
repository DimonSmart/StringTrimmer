using BenchmarkDotNet.Attributes;
using StringTrimmer;
using StringTrimmerTests.TestClasses;

namespace StringTrimmerTests.Benchmark
{
    public class StringTrimmerBenchmark
    {
        [Benchmark()]
        public void TrimSimpleClassAlreadyTrimmedTest()
        {
            var test = new PrivateSetterTestClass("ABC");
            test.TrimExtraSpaces(ClassTrimmerOptions.TrimPrivateProperties);
        }

        [Benchmark()]
        public void TrimSimpleClassTest()
        {
            var test = new PrivateSetterTestClass(" A    B ");
            test.TrimExtraSpaces(ClassTrimmerOptions.TrimPrivateProperties);
        }

        [Benchmark()]
        public void TestComplexClassTrimmed()
        {
            var test = new ComplexTestClass("ABC", "ABC", "ABC", "ABC", "ABC", "ABC", "ABC", "ABC", "ABC", "ABC");
            test.TrimExtraSpaces(ClassTrimmerOptions.TrimPrivateProperties);
        }

        [Benchmark()]
        public void TestComplexClass()
        {
            var test = new ComplexTestClass(" A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ");
            test.TrimExtraSpaces(ClassTrimmerOptions.TrimPrivateProperties);
        }
    }
}
