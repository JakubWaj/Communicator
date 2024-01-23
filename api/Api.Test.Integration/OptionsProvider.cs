﻿using Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Api.Test.Integration;

public class OptionsProvider
{
    private readonly IConfigurationRoot _configuration = GetConfigurationRoot();

    public T Get<T>(string sectionName) where T : class, new() => _configuration.GetOptions<T>(sectionName);
    
    private static IConfigurationRoot GetConfigurationRoot()
        => new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json", true)
            .AddEnvironmentVariables()
            .Build();
}