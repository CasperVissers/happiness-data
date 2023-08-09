using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Happiness;

namespace UI
{
    public class RegionButton : Button
    {
        #region UXML
        public new class UxmlFactory : UxmlFactory<RegionButton, UxmlTraits> { }
        public new class UxmlTraits : Button.UxmlTraits
        {
            private readonly UxmlBoolAttributeDescription m_Selected = new() { name = "Selected", defaultValue = false };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var button = ve as RegionButton;
                button.Selected = m_Selected.GetValueFromBag(bag, cc);
            }
        }
        #endregion

        public RegionButton()
        {
            styleSheets.Add(StyleSheets.General.GetStyleSheet());
            styleSheets.Add(StyleSheets.Button.GetStyleSheet());

            this.AddToClassList(StyleSheets.General.textFont);
            this.AddToClassList(StyleSheets.General.textSize1);

            this.AddToClassList(StyleSheets.Button.button);
        }
        public RegionButton(HappinessData.Regions region) : this()
        {
            Region = region;
            this.text = region.ToString();
        }

        public HappinessData.Regions Region { get; private set; }

        public bool Selected { get => _selected; set { _selected = value; SetColor(); } }
        private bool _selected;

        private void SetColor()
        {
            if (Selected)
            {
                this.RemoveFromClassList(StyleSheets.Button.buttonColor);
                this.AddToClassList(StyleSheets.Button.buttonSelectedColor);
            }
            else
            {
                this.AddToClassList(StyleSheets.Button.buttonColor);
                this.RemoveFromClassList(StyleSheets.Button.buttonSelectedColor);
            }
        }
    }
}