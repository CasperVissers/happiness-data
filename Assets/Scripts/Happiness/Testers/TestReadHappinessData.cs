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

            string msg = $"Found {data.Count} countries in data file\n";
            for (int i = 1; i <= data.Count; i++)
            {
                msg += $"{i}. {data[i-1].CountryName}\n";
            }
            Debug.Log(msg);
        }
    }
}