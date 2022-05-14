using Microsoft.Extensions.Configuration;
using solid_training;

var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();
Configuration.Config = config;

var step1 = new Step1();
var step2 = new Step2();
var step3 = new Step3();

public static class Configuration
{
    public static IConfiguration? Config { get; set; }
}