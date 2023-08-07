using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Happiness.Testing
{
    public static class TestReadHappinessData
    {
        [MenuItem("Testing/Happiness/DataReader")]
        public static void DezerializeJsonInHappiness()
        {
            var data = HappinessDataGetter.GetHappinessData();
            ReadHappinessData(data);
        }

        [MenuItem("Testing/Happiness/RegionWesternEurope")]
        public static void GetHappinessByRegion()
        {
            ReadHappinessData(HappinessAnalyzer.GetHappinessByRegion(HappinessData.Regions.WesternEurope).ToList());
        }

        [MenuItem("Testing/Happiness/TopRegionEastAsia")]
        public static void GetTopHappinessByRegion()
        {
            ReadHappinessData(HappinessAnalyzer.GetHappiestCountriesByRegion(HappinessData.Regions.EastAsia, true).ToList());
        }


        private static void ReadHappinessData(List<HappinessData> data)
        {
            string msg = $"Found {data.Count} countries in data file\n";
            for (int i = 1; i <= data.Count; i++)
            {
                msg += $"{i}.\t{data[i - 1].CountryName}\t{data[i - 1].Region}\t{data[i - 1].LadderScore:F3}\n";
            }
            Debug.Log(msg);
        }
    }
}