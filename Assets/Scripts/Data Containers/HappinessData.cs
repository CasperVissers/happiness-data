using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Happiness
{
    public partial class HappinessData
    {
        [JsonProperty("Country name")]
        public string CountryName { get; set; }

        [JsonProperty("Regional indicator")]
        public string RegionalIndicator { get; set; }

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
    }

    public partial class HappinessData
    {
        public static List<HappinessData> ReadDataFromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<HappinessData>>(json);
        }
    }
}