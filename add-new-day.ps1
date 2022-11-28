dotnet new aoc-dayx -n aoc.day04 -o AoC.Day04
dotnet new xunit -n aoc.day04.tests -o Aoc.Day04.Tests

dotnet sln add AoC.Day04
dotnet sln add AoC.Day04.Tests

dotnet add .\AoC.Console\AoC.Console.csproj reference .\AoC.Day04\aoc.day04.csproj
dotnet add .\AoC.Day04.Tests\aoc.day04.tests.csproj reference .\AoC.Day04\aoc.day04.csproj
dotnet add .\AoC.Day04.Tests\aoc.day04.tests.csproj package FluentAssertions


Write-Host("Do the following:");
Write-Host("1)	Update AoC.<new-day> project:")
Write-Host("	a) DayX.cs - give it a new filename");
Write-Host("	b) ServiceCollection.cs - update to remove DayX references");
Write-Host("2)	Update AoC.Console project:");
Write-Host("	a) Program.cs - update days which are accepted from the input");
Write-Host("	b) ServiceCollection.cs - add new project services and update service resolver");
Write-Host("3)	Update AoC.<new-day>.Tests:");
Write-Host("	a) UnitTest1.cs - give it a new filename")
Write-Host("	b) Replace the content of it with: ")

$unitTestContent = @"
    private readonly string[] INPUT = new string[] { };         // <-------- new day's test example input goes here

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var dayX = new DayX(parser);

        var (answerOne, _) = dayX.CalculateAnswers(INPUT);

        answerOne.Should().Be(150);                             // <--------- solution from web page test example goes here
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var dayX = new DayX(parser);

        var (_, answerTwo) = dayX.CalculateAnswers(INPUT);

        Assert.Fail(\"We don't have part 2 of the day's challenge yet so it is not implemented\");
    }
"@
Write-Host($unitTestContent)