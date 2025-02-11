using FluentAssertions;

namespace aoc2023.day17.tests;

public class Day17SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day17testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "102"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "not_implemented"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day17 = new Day17Solver(parser);

        var (answerOne, _) = day17.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day17 = new Day17Solver(parser);

        var (_, answerTwo) = day17.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
