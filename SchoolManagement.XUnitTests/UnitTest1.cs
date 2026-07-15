using FluentAssertions;

namespace SchoolManagement.XUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Calculate_2_Sum_3_Should_Be_5_Without_Fluent_Assertions()
        {
            //Arrange
            int x = 2;
            int y = 3;
            //Act
            int z = x + y;
            //Assert
            Assert.Equal(5, z);
        }

        [Fact]
        public void Calculate_2_Sum_3_Should_Be_5_With_Fluent_Assertions()
        {
            //Arrange
            int x = 2;
            int y = 3;
            //Act
            int z = x + y;
            //Assert
            z.Should().Be(5, $"sum of {x} + {y} not equal 5");
        }

        [Fact]
        public void File_Should_Be_End_With_pdf()
        {
            //Arrange
            var file = "assignment.pdf";

            //Assert
            file.Should().EndWith(".pdf");
        }

        [Fact]
        public void File_Should_Be_Start_With_A_And_End_With_pdf_And_Have_Length_14()
        {
            //Arrange
            var file = "Assignment.pdf";

            //Assert
            file.Should().StartWith("A", "should be start with A").And.EndWith(".pdf", "should be ends with .pdf").And.HaveLength(14, "should be have length of 14");
        }

        [Fact]
        public void String_Should_Be_Not_Null_Or_Have_White_Spaces_Or_Empty()
        {
            //var text = "";//null
            //var text = "  ";//white spaces
            var text = "Welcome to our website";

            text.Should().NotBeNullOrWhiteSpace().And.NotBeEmpty();
            text.Should().BeOfType<string>();

            bool status = true;
            status.Should().NotBe(false);

            int x = 10;
            x.Should().BePositive();
            x.Should().BeNegative();
            x.Should().BeGreaterThan(5);
            x.Should().BeLessThan(5);
            x.Should().NotBeInRange(1, 20);
            x.Should().NotBeCloseTo(x, 11);
        }
    }
}
