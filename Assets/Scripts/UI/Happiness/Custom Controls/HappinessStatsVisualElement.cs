using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using Happiness;

namespace UI
{
    public class HappinessStatsVisualElement : VisualElement
    {
        #region UXML
        public new class UxmlFactory : UxmlFactory<HappinessStatsVisualElement> { }
        #endregion

        public HappinessStatsVisualElement()
        {
            styleSheets.Add(StyleSheets.General.GetStyleSheet());
            styleSheets.Add(StyleSheets.Stats.GetStyleSheet());

            this.AddToClassList(StyleSheets.Stats.statsContainer);

            countryLabel = new Label();
            countryLabel.text = "Country, Region";
            countryLabel.AddToClassList(StyleSheets.General.textFont);
            countryLabel.AddToClassList(StyleSheets.General.textSize2);
            this.Add(countryLabel);

            ladderStats = new("Ladder Score");
            this.Add(ladderStats);

            loggedGBPStats = new("Logged GDP per capita");
            this.Add(loggedGBPStats);

            socialSupportStats = new("Social support");
            this.Add(socialSupportStats);

            healthyLifeStats = new("Healthy life expectancy");
            this.Add(healthyLifeStats);

            freedomStats = new("Freedom to make life choices");
            this.Add(freedomStats);
        }

        private readonly Label countryLabel;
        private readonly StatsVisualElement ladderStats;
        private readonly StatsVisualElement loggedGBPStats;
        private readonly StatsVisualElement socialSupportStats;
        private readonly StatsVisualElement healthyLifeStats;
        private readonly StatsVisualElement freedomStats;


        public void SetData(HappinessData data)
        {
            countryLabel.text = $"{data.CountryName}, {data.Region}";

            ladderStats.Value = (float)data.LadderScore;
            loggedGBPStats.Value = (float)data.LoggedGDPPerCapita;
            socialSupportStats.Value = (float)data.SocialSupport;
            healthyLifeStats.Value = (float)data.HealthyLifeExpectancy;
            freedomStats.Value = (float)data.FreedomToMakeLifeChoices;
        }

        public void SetComparetoStats(HappinessData data)
        {
            ladderStats.CompareToValue = (float) data.LadderScore;
            loggedGBPStats.CompareToValue = (float) data.LoggedGDPPerCapita;
            socialSupportStats.CompareToValue = (float) data.SocialSupport;
            healthyLifeStats.CompareToValue = (float) data.HealthyLifeExpectancy;
            freedomStats.CompareToValue = (float) data.FreedomToMakeLifeChoices;
        }


    }
}

