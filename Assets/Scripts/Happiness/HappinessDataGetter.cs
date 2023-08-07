using Newtonsoft.Json;
using System.Collections.Generic;

namespace Happiness
{
    public static class HappinessDataGetter
    {
        const string FILE_NAME = "Assets/Resources/Happiness Data/happinessData.json";

        /// <summary>
        /// Deserializes a json file into a list of happiness data.
        /// </summary>
        public static List<HappinessData> GetHappinessData()
        {
            var jsonFile = System.IO.File.ReadAllText(FILE_NAME);
            return JsonConvert.DeserializeObject<List<HappinessData>>(jsonFile);
        }
    }
}