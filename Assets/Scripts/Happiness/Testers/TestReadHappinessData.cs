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

        [MenuItem("Testing/Happiness/RegionReaderWesternEurope")]
        public static void GetHappinessByRegion()
        {
            ReadHappinessData(HappinessAnalyzer.GetHappinessByRegion(HappinessData.Regions.WesternEurope));
        }


        private static void ReadHappinessData(IEnumerable<HappinessData> data)
        {
            var listData = data.ToList();
            string msg = $"Found {listData.Count} countries in data file\n";
            for (int i = 1; i <= listData.Count; i++)
            {
                msg += $"{i}. {listData[i - 1].CountryName}\n";
            }
            Debug.Log(msg);
        }
    }
}