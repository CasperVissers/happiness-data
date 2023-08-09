using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    /// <summary>
    /// Names of the used style sheets and selectors within the project
    /// </summary>
    public static class StyleSheets 
    {
        private const string folder = "StyleSheets";
        public static class General
        {
            public const string styleSheet = "general";

            public const string textFont = "text-font";
            public const string textSize1 = "text-size1";
            public const string textSize2 = "text-size2";
            public const string textSize3 = "text-size3";

            public static StyleSheet GetStyleSheet() => StyleSheets.GetStyleSheet(styleSheet);
        }

        public static class Bar
        {
            public const string styleSheet = "bar";

            public const string container = "bar-container";
            public const string bar = "bar";
            public const string textTop = "bar-text-top";
            public const string textBottom = "bar-text-bottom";
            public const string dashed = "dashed";

            public static StyleSheet GetStyleSheet() => StyleSheets.GetStyleSheet(styleSheet);
        }

        public static class Button
        {
            public const string styleSheet = "button";

            public const string button = "button";
            public const string buttonColor = "button-color";
            public const string buttonSelectedColor = "button-selected-color";

            public static StyleSheet GetStyleSheet() => StyleSheets.GetStyleSheet(styleSheet);
        }

        public static class Stats
        {
            public const string styleSheet = "stats";

            public const string container = "container";
            public const string valueContainer = "value-container";

            public static StyleSheet GetStyleSheet() => StyleSheets.GetStyleSheet(styleSheet);
        }

        public static StyleSheet GetStyleSheet(string styleSheetName)
        {
            var style = Resources.Load<StyleSheet>($"{folder}/{styleSheetName}");
            if (style == null)
            {
                throw new System.Exception($"Cannot find style sheet {folder}/{styleSheetName} in any recources folder.");
            }
            return style;
        }
    }
}