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
        /// Get the happiness data of the countries within a region.
        /// </summary>
        public static IEnumerable<HappinessData> GetHappinessByRegion(HappinessData.Regions region)
        {
            return Data.Where(data => data.Region == region);
        }
    }
}