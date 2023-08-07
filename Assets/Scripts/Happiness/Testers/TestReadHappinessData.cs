using UnityEditor;
using UnityEngine;

namespace Happiness.Testing
{
    public static class TestReadHappinessData
    {
        const string FILE_NAME = "Assets/Resources/Happiness Data/happinessData.json";

        [MenuItem("Testing/Happiness/DataReader")]
        public static void DezerializeJsonInHappiness()
        {
            var jsonFile = System.IO.File.ReadAllText(FILE_NAME);
            var data = HappinessDataGetter.GetHappinessFromJson(jsonFile);

            string msg = $"Found {data.Count} countries in data file\n";
            for (int i = 1; i <= data.Count; i++)
            {
                msg += $"{i}. {data[i-1].CountryName}\n";
            }
            Debug.Log(msg);
        }
    }
}