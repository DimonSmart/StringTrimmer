using BenchmarkDotNet.Attributes;
using StringTrimmer;
using StringTrimmerTests.TestClasses;

namespace StringTrimmerTests.Benchmark
{
    public class StringTrimmerEtalonBenchmark
    {
        [Benchmark()]
        public void EtalonTrimSimpleClassTest()
        {
            var test = new SimpleTestClass(" A    B ");
            test.StringProperty = test.StringProperty!.Trim().RemoveConsecutiveSpaces();
        }

        [Benchmark()]
        public void EtalonTrimSimpleClassAlreadyTrimmedTest()
        {
            var test = new SimpleTestClass("ABC");
            test.StringProperty = test.StringProperty!.Trim().RemoveConsecutiveSpaces();
        }

        [Benchmark()]
        public void EtalonTrimComplexClassAlreadyTrimmedTest()
        {
            var test = new ComplexTestClass("ABC", "ABC", "ABC", "ABC", "ABC", "ABC", "ABC", "ABC", "ABC", "ABC");
            test.StringProperty00 = test.StringProperty00!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty01 = test.StringProperty01!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty02 = test.StringProperty02!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty03 = test.StringProperty03!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty04 = test.StringProperty04!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty05 = test.StringProperty05!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty06 = test.StringProperty06!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty07 = test.StringProperty07!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty08 = test.StringProperty08!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty09 = test.StringProperty09!.Trim().RemoveConsecutiveSpaces();
        }

        [Benchmark()]
        public void EtalonTrimComplexClassTest()
        {
            var test = new ComplexTestClass(" A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ", " A  B  C ");
            test.StringProperty00 = test.StringProperty00!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty01 = test.StringProperty01!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty02 = test.StringProperty02!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty03 = test.StringProperty03!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty04 = test.StringProperty04!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty05 = test.StringProperty05!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty06 = test.StringProperty06!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty07 = test.StringProperty07!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty08 = test.StringProperty08!.Trim().RemoveConsecutiveSpaces();
            test.StringProperty09 = test.StringProperty09!.Trim().RemoveConsecutiveSpaces();
        }
    }
}
