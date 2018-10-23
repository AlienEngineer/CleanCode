
using System;
using Moq;
using TestMyStuff.Lib;
using Xunit;
namespace TestMyStuff
{
    public class NiceLittleTests
    {

        // Test1
        [Fact]
        public void Doing_some_calculation_must_return_a_non_null_result()
        {
            // Arrange
            var subject = new SubjectUnderTest();

            // Act
            var result = subject.SomeCalculation();

            // Assert
            Assert.NotNull(result);
        }

        // Test1
        [Fact]
        public void Doing_some_calculation_must_return_a_result_with_non_null_field()
        {
            // Arrange
            var subject = new SubjectUnderTest();

            // Act
            var result = subject.SomeCalculation();

            // Assert
            Assert.NotNull(result.Field);
        }

        // Test2
        [Fact]
        public void Doing_an_invalid_operation_must_throw_an_exception()
        {
            // Arrange
            var subject = new SubjectUnderTest();

            // Act
            var exception = Assert.Throws<Exception>(() => subject.InvalidOperation());

            // Assert
            Assert.Equal("some message", exception.Message);
        }

        // Test3
        // Removed duplication on Doing_some_calculation_must_return_a_non_null_result
        [Fact]
        public void Calculating_on_subject_1_must_not_equal_subject_2_calculation()
        {
            // Arrange
            var subject1 = new SubjectUnderTest();
            var subject2 = new SubjectUnderTest();

            // Act
            var result = subject1.SomeCalculation();
            var result2 = subject2.SomeCalculation();

            // Assert
            Assert.NotEqual(result2, result);
        }

        // Test4
        bool wasOperated = false;

        private SubjectWithDependency MakeSubjectWithDependency()
        {
            var mock = new Mock<IDependency>();

            mock.Setup(e => e.Operation())
                .Callback(() => { wasOperated = true; });

            return new SubjectWithDependency(mock.Object);
        }
        
        [Fact]
        public void Operating_on_subject_1_must_operate_dependency()
        {
            // Arrange
            var subject1 = MakeSubjectWithDependency();

            // Act
            subject1.Operation();

            // Assert
            Assert.True(wasOperated);
        }
    }
}
