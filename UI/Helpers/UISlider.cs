using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Seasons.Common.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace Seasons.UI.Helpers
{
    public class UISlider : UIElement
    {
        private readonly float _min = -1f;
        private readonly float _max = 1f;
        private readonly float _step;
        private readonly Action<float> _updateValue;

        private static readonly Texture2D SliderTexture = TextureAssets.SettingsPanel.Value;
        private static readonly Texture2D BarHoverTexture = TextureAssets.ColorHighlight.Value;
        private static readonly Texture2D BarTexture = TextureAssets.ColorBar.Value;

        private readonly UIText _labelUI;
        public string LabelText { get; set; }

        private bool isHolding = false;
        private float CalculatePercentValue(Rectangle parent) => Utils.Clamp((Main.mouseX - parent.X) / (float)parent.Width, 0f, 1f);
        public float PercentValue { get; private set; }
        private float _sliderValue = 0f;
        public float SliderValue
        {
            get {
                return _sliderValue;
            }
            private set
            {
                _sliderValue = value;
                _updateValue.Invoke(value);
            }
        }

        private void SetDefaults()
        {
            // Set element size
            Width.Set(BarTexture.Width, 0);
            Height.Set(BarTexture.Height, 0);

            // Set defaults for ui label
            _labelUI.MarginLeft = Width.Pixels + 10f;
            _labelUI.MarginTop = 0;
            Append(_labelUI);
        }

        private string GeneratedLabel => $"{LabelText}: {Math.Round(SliderValue, 2)}";

        //private float CalculateSliderAdditionalOffset => value > (max / 2) ? -3f : 0; 

        public UISlider(string label, float min = 0, float max = 1, float step = 0.01f, Action<float> OnChange = null)
        {
            LabelText = label;
            _min = min;
            _max = max;
            _step = step;
            _labelUI = new UIText(GeneratedLabel, 1f);
            _updateValue = OnChange != null ? OnChange : (delegate { });

            SetDefaults();
        }


        private void DrawSlider(SpriteBatch spriteBatch, Rectangle parent)
        {
            float x = parent.X;
            float y = parent.Y;

            float textureHeight = SliderTexture.Height;

            float middleOffset = (textureHeight / 4);
            float onBarOffset = (Width.Pixels / 100) * (PercentValue * 100);

            float relativeLeftMinPositionOffset = 3f;
            float relativeRightMaxPositionOffset = -10f;

            float absolutePosX = ((float)(x + onBarOffset)).ToMinMax(x + relativeLeftMinPositionOffset, x + parent.Width + relativeRightMaxPositionOffset);

            spriteBatch.Draw(SliderTexture, new Vector2(absolutePosX, y - middleOffset), Color.White);
        }

        private void DrawBar(SpriteBatch spriteBatch, Rectangle parent)
        {
            spriteBatch.Draw(BarTexture, parent, Color.White);


            // Draw additional bar with outline to make active/hover effect.
            if (IsMouseHovering)
            {
                spriteBatch.Draw(BarHoverTexture, parent, Main.OurFavoriteColor);
            }
        }


        private void UpdateLabel()
        {
            _labelUI.SetText(GeneratedLabel);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            CalculatedStyle dimensions = GetDimensions();
            Rectangle destinationRectangle = dimensions.ToRectangle();

            // Logic for holding and moving a mouse out of bar hover area.
            if (isHolding && !Main.mouseLeft)
            {
                isHolding = false;
            }
            else if (!isHolding && Main.mouseLeft && IsMouseHovering)
            {
                isHolding = true;
            }

            // Change value logic
            if (isHolding)
            {
                float percentValue = CalculatePercentValue(destinationRectangle);

                PercentValue = percentValue;
                SliderValue = (float)Math.Round((PercentValue * (_max - _min) + _min) * (1 / _step)) * _step;
                UpdateLabel();
            }

            // Prevent using held items on slide.
            if (ContainsPoint(Main.MouseScreen))
            {
                Main.LocalPlayer.mouseInterface = true;
            }

            // Draw
            DrawBar(spriteBatch, destinationRectangle);
            DrawSlider(spriteBatch, destinationRectangle);
        }
    }
}
