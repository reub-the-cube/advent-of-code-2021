﻿using aoc.day04;
using AoC.Core;
using AoC.Day01;
using AoC.Day02;
using AoC.Day03;
using aoc2021.day05;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection2021
    {
        public static IServiceCollection Configure2021Services(this IServiceCollection services)
        {
            return services
                .ConfigureDay1Services()
                .ConfigureDay2Services()
                .ConfigureDay3Services()
                .ConfigureDay4Services()
                .ConfigureDay05Services();
        }

        public static IDaySolver ResolveDayFor2021(this IServiceProvider serviceProvider, int day)
        {
            return day switch
            {
                1 => serviceProvider.GetService<Day1>() ?? throw new InvalidOperationException(),
                2 => serviceProvider.GetService<Day2>() ?? throw new InvalidOperationException(),
                3 => serviceProvider.GetService<Day3>() ?? throw new InvalidOperationException(),
                4 => serviceProvider.GetService<Day4>() ?? throw new InvalidOperationException(),
                5 => serviceProvider.GetService<Day05Solver>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
        }
    }
}
