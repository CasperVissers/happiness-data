using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

namespace Happiness
{
    public static class HappinessAnalyzer
    {
        /// <summary>
        /// Happiness data in a list format
        /// </summary>
        public static List<HappinessData> Data
        {
            get
            {
                _data ??= HappinessDataGetter.GetHappinessData();
                return _data;
            }
        }
        private static List<HappinessData> _data;
        
        /// <summary>
        /// Get the happiness data of the Netherlands.
        /// </summary>
        public static HappinessData GetHappinessOfTheNetherlands()
        {
            return Data.Where(data => data.CountryName == "Netherlands").First();
        }


        /// <summary>
        /// Get the happiness data of the countries within a region.
        /// </summary>
        public static IEnumerable<HappinessData> GetHappinessByRegion(HappinessData.Regions region)
        {
            return Data.Where(data => data.Region == region);
        }

        /// <summary>
        /// Orders the countries within a region by the happiness ladder score. It
        /// is possible to append the Netherlands by the countries in the region.
        /// </summary>
        /// <param name="region">Region to sort by</param>
        /// <param name="includeNetherlands">Optional parameter to include the 
        /// Netherlands in the resutls (always included in Western Europe)</param>
        /// <returns></returns>
        public static IOrderedEnumerable<HappinessData> GetHappiestCountriesByRegion(HappinessData.Regions region, bool includeNetherlands = false)
        {
            var countryData = GetHappinessByRegion(region).ToHashSet();
            if (includeNetherlands) countryData.Add(GetHappinessOfTheNetherlands());

            return countryData.OrderByDescending(data => data.LadderScore);
        }
    }
}