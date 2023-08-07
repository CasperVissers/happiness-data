using Newtonsoft.Json;
using System.Collections.Generic;

namespace Happiness
{
    public static class HappinessDataGetter
    {
        /// <summary>
        /// Deserializes a json file into a list of happiness data.
        /// </summary>
        public static List<HappinessData> GetHappinessFromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<HappinessData>>(json);
        }
    }
}