using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class StatsVisualElement : VisualElement
    {
        #region UXML
        public new class UxmlFactory : UxmlFactory<StatsVisualElement, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private readonly UxmlStringAttributeDescription m_PropertyName = new() { name = "Property Name", defaultValue = "Name" };
            private readonly UxmlFloatAttributeDescription m_Value = new() { name = "Value", defaultValue = 0 };
            private readonly UxmlFloatAttributeDescription m_CompareValue = new() { name = "Compare Value", defaultValue = 0 };


            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var stats = ve as StatsVisualElement;
                stats.Name = m_PropertyName.GetValueFromBag(bag, cc);
                stats.Value = m_Value.GetValueFromBag(bag, cc);
                stats.CompareToValue = m_CompareValue.GetValueFromBag(bag, cc);
            }
        }
        #endregion

        public StatsVisualElement()
        {
            styleSheets.Add(StyleSheets.General.GetStyleSheet());
            styleSheets.Add(StyleSheets.Stats.GetStyleSheet());

            this.AddToClassList(StyleSheets.Stats.container);

            statNameLabel = new Label();
            statNameLabel.text = "Name";
            statNameLabel.AddToClassList(StyleSheets.General.textFont);
            statNameLabel.AddToClassList(StyleSheets.General.textSize1);
            this.Add(statNameLabel);

            VisualElement container = new();
            container.AddToClassList(StyleSheets.Stats.valueContainer);
            this.Add(container);

            valueLabel = new Label();
            valueLabel.text = "0";
            valueLabel.AddToClassList(StyleSheets.General.textFont);
            valueLabel.AddToClassList(StyleSheets.General.textSize1);
            valueLabel.style.unityTextAlign = TextAnchor.MiddleLeft;
            container.Add(valueLabel);

            compareValueLabel = new Label();
            compareValueLabel.text = "1";
            compareValueLabel.AddToClassList(StyleSheets.General.textFont);
            compareValueLabel.AddToClassList(StyleSheets.General.textSize1);
            compareValueLabel.style.unityTextAlign = TextAnchor.MiddleRight;
            container.Add(compareValueLabel);
        }

        private readonly Label statNameLabel;
        private readonly Label valueLabel;
        private readonly Label compareValueLabel;



        public string Name { get => statNameLabel.text; set => statNameLabel.text = value; }
        public float Value { get => _value; set { _value = value; SetValues(); } }
        private float _value;
        public float CompareToValue { get => _compareToValue; set { _compareToValue = value; SetValues(); } }
        private float _compareToValue;


        private void SetValues()
        {
            valueLabel.text = _value.ToString("F3");
            SetCompareText();

        }

        private void SetCompareText()
        {
            var diff = _compareToValue - _value;
            if (diff == 0)
            {
                compareValueLabel.text = "-";
                compareValueLabel.style.color = StyleKeyword.Null;
            }
            else if (diff > 0)
            {
                compareValueLabel.text = $"▼ {diff:F3}";
                compareValueLabel.style.color = SO_HappinessStyle.Instance.barGradient.Evaluate(0);
            }
            else
            {
                compareValueLabel.text = $"▲ {Mathf.Abs(diff):F3}";
                compareValueLabel.style.color = SO_HappinessStyle.Instance.barGradient.Evaluate(1);
            }

        }
    }
}

