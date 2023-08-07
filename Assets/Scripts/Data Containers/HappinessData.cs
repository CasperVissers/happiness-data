using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Happiness
{
    public class HappinessData
    {
        [JsonProperty("Country name")]
        public string CountryName { get; set; }

        [JsonProperty("Regional indicator")]
        public string RegionalIndicator { set => Region = GetRegion(value); }
        public Regions Region { get; private set; }

        [JsonProperty("Ladder score")]
        public double LadderScore { get; set; }

        [JsonProperty("Standard error of ladder score")]
        public double StandardErrorOfLadderScore { get; set; }

        [JsonProperty("upperwhisker")]
        public double UpperWhisker { get; set; }

        [JsonProperty("lowerwhisker")]
        public double LowerWhisker { get; set; }

        [JsonProperty("Logged GDP per capita")]
        public double LoggedGDPPerCapita { get; set; }

        [JsonProperty("Social support")]
        public double SocialSupport { get; set; }

        [JsonProperty("Healthy life expectancy")]
        public double HealthyLifeExpectancy { get; set; }

        [JsonProperty("Freedom to make life choices")]
        public double FreedomToMakeLifeChoices { get; set; }

        [JsonProperty("Generosity")]
        public double Generosity { get; set; }

        [JsonProperty("Perceptions of corruption")]
        public double PerceptionsOfCorruption { get; set; }

        [JsonProperty("Ladder score in Dystopia")]
        public double LadderScoreInDystopia { get; set; }

        [JsonProperty("Explained by: Log GDP per capita")]
        public double ExplainedByLogGDPPerCapita { get; set; }

        [JsonProperty("Explained by: Social support")]
        public double ExplainedBySocialSupport { get; set; }

        [JsonProperty("Explained by: Healthy life expectancy")]
        public double ExplainedByHealthyLifeExpectancy { get; set; }

        [JsonProperty("Explained by: Freedom to make life choices")]
        public double ExplainedByFreedomToMakeLifeChoices { get; set; }

        [JsonProperty("Explained by: Generosity")]
        public double ExplainedByGenerosity { get; set; }

        [JsonProperty("Explained by: Perceptions of corruption")]
        public double ExplainedbyPerceptionsOfCorruption { get; set; }

        [JsonProperty("Dystopia + residual")]
        public double DystopiaResidual { get; set; }

        /// <summary>
        /// Reads a string and tries to match it with one of the regions.
        /// </summary>
        private Regions GetRegion(string value)
        {
            switch(value)
            {
                case "Central and Eastern Europe":
                    return Regions.CentralAndEasternEurope;
                case "Western Europe":
                    return Regions.WesternEurope;
                case "East Asia":
                    return Regions.EastAsia;
                case "South Asia":
                    return Regions.SouthAsia;
                case "Southeast Asia":
                    return Regions.SoutheastAsia;
                case "Latin America and Caribbean":
                    return Regions.LatinAmericaAndCaribbean;
                case "North America and ANZ":
                    return Regions.NorthAmericaAndANZ;
                case "Middle East and North Africa":
                    return Regions.MiddleEastAndNorthAfrica;
                case "Sub-Saharan Africa":
                    return Regions.SubSaharanAfrica;
                case "Commonwealth of Independent States":
                    return Regions.CommonwealthOfIndependentStates;
                default:
                    throw new System.Exception($"Cannot find region for {value}");
            }
        }

        public enum Regions
        {
            // Europe
            CentralAndEasternEurope,
            WesternEurope,
            
            // Asia
            EastAsia,
            SouthAsia,
            SoutheastAsia,

            // Americas
            LatinAmericaAndCaribbean,
            NorthAmericaAndANZ,

            // Middle East and Africa
            MiddleEastAndNorthAfrica,
            SubSaharanAfrica,

            // Other
            CommonwealthOfIndependentStates,
        }
    }
}