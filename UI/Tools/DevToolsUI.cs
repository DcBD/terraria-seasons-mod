using Microsoft.Xna.Framework;
using Seasons.UI.Helpers;
using Terraria;
using Terraria.UI;


namespace Seasons.UI.Tools
{
    internal class DevToolsUI : UIState
    {
        public DragableUIPanel DevToolsUIPanel;
        public static bool Visible = true;

        public override void OnInitialize()
        {

            DevToolsUIPanel = DraggableUIPanelBuilder
                .Start()
                .SetTitle("Screen effect configuration")
                .SetPadding(0)
                .SetLeft(10f)
                .SetTop(10f)
                .SetWidth(400f)
                .SetHeight(300f)
                .SetBackGroundColor(73, 94, 171)
                .Build();

            //var slider = new UISliderBuilder()
            //{
            //    Width = new StyleDimension(0f, 1f),
            //    Height = new StyleDimension(15f, 0f),
            //    VAlign = 1f,
            //    FilledColor = new Color(51, 137, 255),
            //    EmptyColor = new Color(35, 43, 81),
            //    FillPercent = 0f
            //};

            var sliderR = new UISlider("R", -1000, 1000, 0.1f, On_SliderRChange) {
                MarginTop = 50f,
                MarginLeft = 10f
            };

            var sliderG = new UISlider("G", -1000, 1000, 0.1f)
            {
                MarginTop = 90f,
                MarginLeft = 10f
            };


            var sliderB = new UISlider("B", -1000, 1000, 0.1f)
            {
                MarginTop = 130f,
                MarginLeft = 10f
            };


            DevToolsUIPanel.Append(sliderR);
            DevToolsUIPanel.Append(sliderG);
            DevToolsUIPanel.Append(sliderB);

            Append(DevToolsUIPanel);
        }

        public void On_SliderRChange(float value)
        {
            Main.NewText("N" + value);
        }
    }
}
