using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Happiness
{
    public static class HappinessDataGetter
    {
        const string FOLDER = "Happiness Data";
        const string FILE_NAME = "happinessData";

        /// <summary>
        /// Deserializes a json file into a list of happiness data.
        /// </summary>
        public static List<HappinessData> GetHappinessData()
        {
            var jsonFile = Resources.Load<TextAsset>($"{FOLDER}/{FILE_NAME}");
            return JsonConvert.DeserializeObject<List<HappinessData>>(jsonFile.text);
        }
    }
}