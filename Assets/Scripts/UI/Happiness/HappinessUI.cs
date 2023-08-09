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
        [SerializeField]
        private string buttonsName = "buttons";

        private BarVisualElement[] bars;
        private RegionButton[] regionButtons;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            AddBarGraphs(root);
            AddRegionButtons(root);

            AddDataToGraph(HappinessAnalyzer.GetHappinessByRegion(HappinessData.Regions.WesternEurope).ToList());
        }

        private void AddBarGraphs(VisualElement root)
        {
            var barGraph = root.Q<VisualElement>(barGraphName);

            bars = new BarVisualElement[numberOfBars];
            for (int i = 0; i < bars.Length; i++)
            {
                bars[i] = new();
                barGraph.Add(bars[i]);
            }
        }

        private void AddRegionButtons(VisualElement root)
        {
            var buttonContainer = root.Q<VisualElement>(buttonsName);

            regionButtons = new RegionButton[(int) HappinessData.Regions.Count];
            for (int i = 0; i < regionButtons.Length; i++)
            {
                regionButtons[i] = new RegionButton((HappinessData.Regions) i);
                regionButtons[i].clicked += () => SelectedNewRegion(i);
                buttonContainer.Add(regionButtons[i]);
            }
        }

        private void SelectedNewRegion(int selectedIndex)
        {
            for (int i = 0; i < regionButtons.Length; i++)
            {
                regionButtons[i].Selected = i == selectedIndex;
            }
        }


        private void AddDataToGraph(List<HappinessData> data)
        {
            for (int i = 0; i < data.Count && i < bars.Length; i++)
            {
                bars[i].SetValue((float) data[i].LadderScore);
                bars[i].SetXLabel(data[i].CountryName);
                bars[i].IsDashed = data[i].CountryName == "Netherlands";
            }

            // Hide non used graphs
            for (int i = data.Count; i < bars.Length; i++)
            {
                bars[i].HideBar(true);
            }
        }
    }
}