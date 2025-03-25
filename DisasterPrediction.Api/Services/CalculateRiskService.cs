using DisasterPrediction.Api.Entities;
using DisasterPrediction.Api.Interfaces;
using DisasterPrediction.Api.Models;

namespace DisasterPrediction.Api.Services;

public class RiskCalculateService : IRiskCalculateService
{
    public Dictionary<string, int> CalculateRiskScores(Region region, EnvironmentalData environmentalData)
    {
        var risks = region.DisasterTypes
            .Select(disaster =>
            {
                var score = disaster.DisasterTypeName switch
                {
                    "flood" => CalculateFloodRisk(environmentalData.WeatherData.Rain.RainFall),
                    "wildfire" => CalculateWildfireRisk(environmentalData.WeatherData.Main.Temp, environmentalData.WeatherData.Main.Humidity),
                    "earthquake" => CalculateEarthquakeRisk(environmentalData.EarthquakeData),
                    _ => throw new ArgumentException("Invalid disaster type")
                };

                return (disaster.DisasterTypeName, score);
            })
            .ToDictionary();

        return risks;
    }

    public int CalculateFloodRisk(double rainfall)
    {
        var riskScore = rainfall switch
        {
            >= 100 => 100,
            >= 75 => 80,
            >= 50 => 60,
            >= 25 => 40,
            >= 10 => 20,
            _ => 0
        };

        return riskScore;
    }

    public int CalculateEarthquakeRisk(EarthquakeData earthquakeData)
    {
        if (earthquakeData.Metadata.Count == 0)
            return 0;

        var maxMagnitude = earthquakeData.Features.Max(x => x.Properties.Mag);
        var riskScore = maxMagnitude switch
        {
            > 8 => 100,
            > 7 => 80,
            > 6 => 60,
            > 5 => 50,
            > 4 => 40,
            _ => 0
        };

        return riskScore;
    }

    public int CalculateWildfireRisk(double temperature, int humidity)
    {
        int riskScore = 0;

        riskScore += temperature switch
        {
            > 40 => 50,
            > 30 => 30,
            > 20 => 20,
            > 10 => 10,
            _ => 0
        };

        riskScore += humidity switch
        {
            < 20 => 40,
            < 40 => 30,
            < 60 => 20,
            _ => 10
        };

        return riskScore;
    }

    public string GetRiskLevel(int riskScore)
    {

        var riskLevel = riskScore switch
        {
            >= 80 => "High",
            >= 50 => "Medium",
            _ => "Low",
        };

        return riskLevel;
    }

    public bool IsAlertTriggered(int riskScore, int? thresholdScore)
    {
        return thresholdScore is not null && riskScore >= thresholdScore;
    }
}
