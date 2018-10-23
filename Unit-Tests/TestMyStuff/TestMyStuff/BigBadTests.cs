using System;
using Moq;
using TestMyStuff.Lib;
using Xunit;

namespace TestMyStuff
{
    public class BigBadTests
    {
        [Fact]
        public void Test1()
        {
            var subject = new SubjectUnderTest();

            var result = subject.SomeCalculation();

            Assert.NotNull(result);
            Assert.NotNull(result.Field);
        }

        [Fact]
        public void Test2()
        {
            var subject = new SubjectUnderTest();

            try
            {
                subject.InvalidOperation();
                Assert.False(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [Fact]
        public void Test3()
        {
            var subject1 = new SubjectUnderTest();
            var subject2 = new SubjectUnderTest();

            var result = subject1.SomeCalculation();

            if (result != null)
            {
                var result2 = subject2.SomeCalculation();
                Assert.NotNull(result2);
                Assert.NotEqual(result2, result);
            }
            else
            {
                var result2 = subject2.SomeCalculation();
                Assert.NotNull(result2);
            }
        }

        [Fact]
        public void Test4()
        {
            var mock = new Mock<IDependency>();
            var subject1 = new SubjectWithDependency(mock.Object);

            subject1.Operation();

            mock.Verify(e => e.Operation());
        }

    }

}
