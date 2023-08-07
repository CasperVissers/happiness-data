using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Happiness;
using UnityEngine.UIElements;
using System.Linq;

namespace UI.Happiness
{
    [RequireComponent(typeof(UIDocument))]
    public class HappinessUI : MonoBehaviour
    {
        [SerializeField]
        private int numberOfBars = 10;
        [SerializeField]
        private string barGraphName = "barGraph";

        private BarVisualElement[] bars;

        private VisualElement barGraph;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            barGraph = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>(barGraphName);

            bars = new BarVisualElement[numberOfBars];
            for (int i = 0; i < bars.Length; i++)
            {
                BarVisualElement bar = new();
                bars[i] = bar;
                barGraph.Add(bar);
            }
            AddDataToGraph(HappinessAnalyzer.GetHappinessByRegion(HappinessData.Regions.WesternEurope).ToList());
        }


        private void AddDataToGraph(List<HappinessData> data)
        {
            for (int i = 0; i < data.Count && i < bars.Length; i++)
            {
                bars[i].SetValue((float) data[i].LadderScore);
                bars[i].SetXLabel(data[i].CountryName);
            }

            // Hide non used graphs
            for (int i = data.Count; i < bars.Length; i++)
            {
                bars[i].HideBar(true);
            }
        }
    }
}