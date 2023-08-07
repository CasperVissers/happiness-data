using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class BarVisualElement : VisualElement
    {
        #region UXML
        public new class UxmlFactory : UxmlFactory<BarVisualElement, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private readonly UxmlFloatAttributeDescription m_Min = new() { name = "Min", defaultValue = 0f };
            private readonly UxmlFloatAttributeDescription m_Max = new() { name = "Max", defaultValue = 10f };
            private readonly UxmlFloatAttributeDescription m_Current = new() { name = "Value", defaultValue = 5f };
            private readonly UxmlBoolAttributeDescription m_IsDashed = new() { name = "Is Dashed", defaultValue = false };


            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var bar = ve as BarVisualElement;
                bar.Min = m_Min.GetValueFromBag(bag, cc);
                bar.Max = m_Max.GetValueFromBag(bag, cc);
                bar.SetValue(m_Current.GetValueFromBag(bag, cc));
                bar.IsDashed = m_IsDashed.GetValueFromBag(bag, cc);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Min value of the bar
        /// </summary>
        public float Min
        {
            get => _min;
            set
            {
                _min = value; SetValue(Value);
            }
        }
        private float _min = 0f;
        /// <summary>
        /// Max value of the bar
        /// </summary>
        public float Max
        {
            get => _max;
            set { _max = value; SetValue(Value); }
        }
        private float _max = 10f;
        /// <summary>
        /// Current displayed value of the bar
        /// </summary>
        public float Current { get; private set; }
        /// <summary>
        /// Set value of the bar
        /// </summary>
        public float Value { get; private set; } = 0f;
        public bool IsDashed { get => _isDashed; set => SetDashing(value); }
        private bool _isDashed = false;
        #endregion
        #region Actions
        public event Action Clicked;
        #endregion

        private readonly VisualElement bar;
        private readonly Label valueLabel;
        private readonly Label xLabel;

        public BarVisualElement()
        {
            // Add style sheets
            styleSheets.Add(StyleSheets.General.GetStyleSheet());
            styleSheets.Add(StyleSheets.Bar.GetStyleSheet());

            // Set parent visual element to container style.
            this.AddToClassList(StyleSheets.Bar.container);

            // Add value text
            valueLabel = new();
            valueLabel.AddToClassList(StyleSheets.General.textFont);
            valueLabel.AddToClassList(StyleSheets.General.textSize1);
            valueLabel.AddToClassList(StyleSheets.Bar.textTop);
            SetVisibilityValueLabel(false);
            this.Add(valueLabel);

            // Add bar
            bar = new();
            bar.AddToClassList(StyleSheets.Bar.bar);
            bar.RegisterCallback<MouseEnterEvent>(_ => OnHoverEnter());
            bar.RegisterCallback<MouseLeaveEvent>(_ => OnHoverExit());
            bar.RegisterCallback<MouseDownEvent>(_ => Clicked?.Invoke());
            this.Add(bar);

            // Add x-label
            xLabel = new();
            xLabel.AddToClassList(StyleSheets.General.textFont);
            xLabel.AddToClassList(StyleSheets.General.textSize1);
            xLabel.AddToClassList(StyleSheets.Bar.textBottom);
            this.Add(xLabel);

            // Set initial value
            SetValue(5);
            SetXLabel("Unknown");
        }

        public void SetValue(float value)
        {
            HideBar(false);

            this.Value = value;
            Current = Mathf.Clamp(value, Min, Max);
            float fraction = Current / Max;

            SetBarValueLabel();
            SetBarHeight();
            SetBarColor();

            void SetBarValueLabel()
            {
                valueLabel.text = value.ToString("F1");
            }
            void SetBarHeight()
            {
                bar.style.height = Length.Percent(fraction * 100);
            }
            void SetBarColor()
            {
                bar.style.backgroundColor = SO_HappinessStyle.Instance.barGradient.Evaluate(fraction);
            }
        }

        public void SetXLabel(string labelName)
        {
            xLabel.text = labelName;
        }

        private void SetDashing(bool isDashed)
        {
            _isDashed = isDashed;

            if (isDashed) bar.AddToClassList(StyleSheets.Bar.dashed);
            else bar.RemoveFromClassList(StyleSheets.Bar.dashed);
        }

        private void OnHoverEnter()
        {
            SetVisibilityValueLabel(true);
        }
        private void OnHoverExit()
        {
            SetVisibilityValueLabel(false);
        }

        private void SetVisibilityValueLabel(bool isVisable)
        {
            valueLabel.style.visibility = isVisable ? Visibility.Visible : Visibility.Hidden;
        }

        public void HideBar(bool isHidden)
        {
            this.style.display = isHidden ? DisplayStyle.None : DisplayStyle.Flex;
        }
    }
}