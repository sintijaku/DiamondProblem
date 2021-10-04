using DiamondProblem;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DiamondProblemTests
{
    [TestFixture]
    public class Tests
    {
        private DiamondCreator _diamondCreator;

        [SetUp]
        public void Setup()
        {
            _diamondCreator = new DiamondCreator();
        }

        [Test]
        public void DiamondCreator_ProvidedLetterA_ReturnsA()
        {
            // Act
            var result = _diamondCreator.CreateDiamond("A");

            // Assert
            Assert.AreEqual("A", result[0]);
        }

        [Test]
        public void DiamondCreate_ProvidedLetterB_ReturnsLetterB_In_WidestPoint()
        {
            // Act
            var result = _diamondCreator.CreateDiamond("B");

            // Assert
            Assert.That(result[1].StartsWith("B"));
            Assert.That(result[1].Count(x => x == 'B') == 2);
        }

        [Test]
        public void DiamondCreate_ProvidedLetterB_FirstAndLastLineContainLetterA()
        {
            // Act
            var result = _diamondCreator.CreateDiamond("B");

            // Assert
            Assert.That(result[0].Contains("A"));
            Assert.That(result[2].Contains("A"));
        }

        [Test]
        public void DiamondCreate_ProvidedLetterB_PrintsCorrectDiamondShape()
        {
            // Arrange
            var expectedResult = new List<string>()
            {
                " A ",
                "B B",
                " A "
            };

            // Act
            var result = _diamondCreator.CreateDiamond("B");

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void DiamondCreate_ProvidedLetterC_FirstAndLastLineContainLetterA()
        {
            // Act
            var result = _diamondCreator.CreateDiamond("C");

            // Assert
            result[0].Should().Contain("A");
            result[4].Should().Contain("A");
        }

        [Test]
        public void DiamondCreate_ProvidedLetterC_WidestPointContainsC()
        {
            // Act
            var result = _diamondCreator.CreateDiamond("C");

            // Assert
            Assert.That(result[2].StartsWith("C"));
            Assert.That(result[2].Count(x => x == 'C') == 2);
        }

        [Test]
        public void DiamondCreate_ProvidedLetterD_PrintsDiamondShape()
        {
            // Arrange
            var expectedResult = new List<string>()
            {
                "   A   ",
                "  B B  ",
                " C   C ",
                "D     D",
                " C   C ",
                "  B B  ",
                "   A   "
            };

            // Act
            var result = _diamondCreator.CreateDiamond("D");

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("A", 0)]
        [TestCase("B", 2)]
        [TestCase("C", 4)]
        [TestCase("H", 14)]
        public void DiamondCreate_ProvidedDifferentLetters_PrintsCorrectCountOfSpacesForFirstLine(string letter, int expectedResult)
        {
            // Act
            var result = _diamondCreator.CreateDiamond(letter);

            // Assert
            Assert.AreEqual(expectedResult, result[0].Count(x => x == ' '));
        }

        [TestCase("A", 0)]
        [TestCase("B", 1)]
        [TestCase("C", 3)]
        [TestCase("H", 13)]
        public void DiamondCreate_ProvidedDifferentLetters_PrintsCorrectCountOfSpacesForMiddleLine(string letter, int expectedResult)
        {
            // Act
            var result = _diamondCreator.CreateDiamond(letter);
            var middleLineIndex = (result.Count - 1) / 2;

            // Assert
            Assert.AreEqual(expectedResult, result[middleLineIndex].Count(x => x == ' '));
        }

        [TestCase("A", 1)]
        [TestCase("B", 3)]
        [TestCase("C", 5)]
        [TestCase("H", 15)]
        public void DiamondCreate_ProvidedDifferentLetters_PrintsCorrectCountOfLines(string letter, int expectedResult)
        {
            // Act
            var result = _diamondCreator.CreateDiamond(letter);

            // Assert
            Assert.AreEqual(expectedResult, result.Count());
        }

        [TestCase("A", true)]
        [TestCase("B", true)]
        [TestCase("C", true)]
        [TestCase("H", true)]
        public void DiamondCreate_ProvidedDifferentLetters_PrintsCorrectLetterInWidestPoint(string letter, bool expectedResult)
        {
            // Act
            var result = _diamondCreator.CreateDiamond(letter);
            var middleLineIndex = (result.Count - 1) / 2;

            // Assert
            Assert.AreEqual(expectedResult, result[middleLineIndex].Contains(letter));
        }
    }
}