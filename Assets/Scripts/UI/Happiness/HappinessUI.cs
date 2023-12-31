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
        [SerializeField]
        private string netherlandsButtonName = "buttonNetherlands";

        private BarVisualElement[] bars;
        private RegionButton[] regionButtons;
        private RegionButton netherlandsButton;
        private HappinessStatsVisualElement happinessStats;

        public HappinessData.Regions SelectedRegion { get; private set; }

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            AddBarGraphs(root);
            InitNetherlandsButton(root);
            InitHappinessStats(root);
            AddRegionButtons(root);
        }

        private void AddBarGraphs(VisualElement root)
        {
            var barGraph = root.Q<VisualElement>(barGraphName);

            bars = new BarVisualElement[numberOfBars];
            for (int i = 0; i < bars.Length; i++)
            {
                var index = i;
                bars[i] = new();
                bars[i].Clicked += () => SetSelectedBar(index);
                barGraph.Add(bars[i]);
            }
        }

        private void AddRegionButtons(VisualElement root)
        {
            var buttonContainer = root.Q<VisualElement>(buttonsName);

            regionButtons = new RegionButton[(int) HappinessData.Regions.Count];
            for (int i = 0; i < regionButtons.Length; i++)
            {
                var index = i; // create new variable for SelectedNewRegionMethod
                regionButtons[i] = new RegionButton((HappinessData.Regions) i);
                regionButtons[i].clicked += () => SelectedNewRegion(index);
                buttonContainer.Add(regionButtons[i]);
            }
            SelectedNewRegion(0);
        }

        private void InitHappinessStats(VisualElement root)
        {
            happinessStats = root.Q<HappinessStatsVisualElement>();
            happinessStats.SetComparetoStats(HappinessAnalyzer.GetCountryData(HappinessAnalyzer.NETHERLANDS));
        }

        private void InitNetherlandsButton(VisualElement root)
        {
            netherlandsButton = root.Q<RegionButton>(netherlandsButtonName);
            netherlandsButton.clicked += () => { netherlandsButton.Selected = !netherlandsButton.Selected; GetData(); };
        }

        private void HideNetherlandsButton(bool isHidden)
        {
            netherlandsButton.visible = isHidden;
        }


        private void SelectedNewRegion(int selectedIndex)
        {
            for (int i = 0; i < regionButtons.Length; i++)
            {
                regionButtons[i].Selected = i == selectedIndex;
            }
            SelectedRegion = (HappinessData.Regions) selectedIndex;
            GetData();
        }

        private void GetData()
        {
            AddDataToGraph(HappinessAnalyzer.GetHappiestCountriesByRegion(SelectedRegion,
                           netherlandsButton.Selected).ToList());

            HideNetherlandsButton(!HappinessAnalyzer.RegionIncludesTheNetherlands(SelectedRegion));
        }

        private void AddDataToGraph(List<HappinessData> data)
        {
            for (int i = 0; i < data.Count && i < bars.Length; i++)
            {
                bars[i].SetValue((float) data[i].LadderScore);
                bars[i].XLabel = data[i].CountryName;
                bars[i].IsDashed = data[i].CountryName == "Netherlands";
            }

            // Hide non used graphs
            for (int i = data.Count; i < bars.Length; i++)
            {
                bars[i].HideBar(true);
            }

            SetSelectedBar(0);
        }

        private void SetSelectedBar(int index)
        {
            for (int i = 0; i < bars.Length; i++)
            {
                bars[i].Selected = i == index;
            }
            SetCompareData(bars[index].XLabel);

            void SetCompareData(string countryName)
            {
                happinessStats.SetData(HappinessAnalyzer.GetCountryData(countryName));
            }
        }
    }
}