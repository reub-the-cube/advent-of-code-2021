using FluentAssertions;

namespace aoc2023.day11.tests;

public class Day11SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day11testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "374"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "363293506944"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day11 = new Day11Solver(parser);

        var (answerOne, _) = day11.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day11 = new Day11Solver(parser);

        var (_, answerTwo) = day11.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
