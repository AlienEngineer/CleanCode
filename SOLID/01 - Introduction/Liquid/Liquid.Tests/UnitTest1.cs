using System.IO;
using Xunit;

namespace Liquid.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_program_for_client_1()
        {
            // Arrange
            var client = 1;

            // Act
            Program.Main(new [] { client.ToString() });

            // Assert
            Assert.True(File.Exists(".\\MyOutput1.csv"));
            var readAllLines = File.ReadAllLines(".\\MyOutput1.csv");

            Assert.Equal("12094958399.10,10/08/2018", readAllLines[readAllLines.Length-1]);
        }
        
        [Fact]
        public void Test_program_for_client_2()
        {
            // Arrange
            var client = 2;

            // Act
            Program.Main(new [] { client.ToString() });

            // Assert
            Assert.True(File.Exists(".\\MyOutput2.csv"));
            var readAllLines = File.ReadAllLines(".\\MyOutput2.csv");

            Assert.Equal("82091205702.93,10/08/2018", readAllLines[readAllLines.Length-1]);
        }
    }
}
