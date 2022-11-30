param([Parameter(Mandatory=$true)][int]$year,
      [Parameter(Mandatory=$true)][int]$day)

if (!(Test-Path -Path .\Inputs\$($year)\day$($day.ToString("00"))input.txt)) {
   Write-Host("Input file for the day does not exist. Create it under the `Inputs` directory first and try again.")
   Return;
}
if (!(Test-Path -Path .\Inputs\$($year)\day$($day.ToString("00"))testinput.txt)) {
   Write-Host("Input file for the day's tests does not exist. Create it under the `Inputs` directory first and try again.")
   Return;
}

cd .\$($year)
if (!(Test-Path -Path "aoc-$($year).sln" -PathType Leaf)) {
    dotnet new sln --name "aoc-$($year)"
	dotnet sln add .\..\AoC.Console\
}

$projectName = "aoc.$($year).day$($day.ToString("00"))"

if (Test-Path -Path .\$($projectName) -PathType Container) {
    Write-Host("$($projectName) folder already exists. You might want to try creating a different day, or maybe you have the wrong year.")
    Return;
}

dotnet new aoc-dayx -n $($projectName) -o $($projectName)
dotnet new xunit -n "$($projectName).tests" -o "$($projectName).tests"

dotnet sln add $($projectName)
dotnet sln add "$($projectName).tests"

dotnet add .\..\AoC.Console\AoC.Console.csproj reference .\$($projectName)\$($projectName).csproj
dotnet add .\$($projectName).Tests\$($projectName).tests.csproj reference .\$($projectName)\$($projectName).csproj
dotnet add .\$($projectName).Tests\$($projectName).tests.csproj package FluentAssertions


Write-Host("Now do the following:");
Write-Host("1)	Update .\$($projectName) project:")
Write-Host("	a) DayX.cs - give it a new filename");
Write-Host("	b) ServiceCollection.cs - update to remove DayX references");
Write-Host("2)	Update .\..\AoC.Console project:");
Write-Host("	a) ServiceCollection.cs - add new project services and update service resolver");
Write-Host("3)	Update .\$($projectName).tests:");
Write-Host("	a) UnitTest1.cs - give it a new filename")
Write-Host("	b) Replace the content of it with the below: ")
Write-Host("	c) Add a constructor to assign the input: ")
Write-Host("         INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $""..\\..\\..\\..\\AoC.Console\\$($year)\\$($day.ToString("00"))testinput.txt"")");
Write-Host("")

$unitTestContent = @"
    private readonly string[] INPUT = new string[] { };         // <-------- new day's test example input goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

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

cd ..