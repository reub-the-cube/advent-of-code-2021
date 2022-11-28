﻿// See https://aka.ms/new-console-template for more information

using AoC.Console;
using AoC.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.ConfigureDayServices())
    .Build();

Console.WriteLine("Which day's challenges would you like to run? Use a number from 1 to 25.");
var dayNumberInput = Console.ReadLine();

var dayNumber = ValidateDayNumber(dayNumberInput);
if (dayNumber.IsValid) InitialiseChallenge(dayNumber.Value);

Console.WriteLine("Press any key to finish.");
Console.ReadKey();

void InitialiseChallenge(int day)
{
    var input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"day{day}input.txt"));

    var dayServiceResolver = host.Services.GetService<Func<int, IDay>>() ?? throw new InvalidOperationException("Day service resolver not found.");
    var dayProcesser = dayServiceResolver(day);
    var (AnswerOne, AnswerTwo) = dayProcesser.CalculateAnswers(input);
    
    Console.WriteLine($"Final answer for day {day}, challenge 1: {AnswerOne}");
    Console.WriteLine($"Final answer for day {day}, challenge 2: {AnswerTwo}");
}

(bool IsValid, int Value) ValidateDayNumber(string? number)
{
    var isValid = int.TryParse(number, out var parsedNumber);
    
    switch (parsedNumber)
    {
        case >= 1 and <= 4:
            Console.WriteLine("This challenge is under construction.");
            break;
        case >= 5 and <= 25:
            Console.WriteLine("This challenge hasn't been implemented.");
            isValid = false;
            break;
        default:
            Console.WriteLine("This input was not valid. Please try again.");
            break;
    }

    return (isValid, parsedNumber);
}

