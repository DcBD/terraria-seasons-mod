using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Seasons.UI.Helpers
{
    public class DraggableUIPanelBuilder
    {
        private DragableUIPanel panel;

        public static DraggableUIPanelBuilder Start()
        {
            var builder = new DraggableUIPanelBuilder();
            builder.panel = new DragableUIPanel();

            return builder;
        }
        public DragableUIPanel Build()
        {
            return panel;
        }

        public DraggableUIPanelBuilder SetWidth(float pixels, float percent = 0)
        {
            panel.Width.Set(pixels, percent);

            return this;
        }

        public DraggableUIPanelBuilder SetHeight(float pixels, float percent = 0)
        {
            panel.Height.Set(pixels, percent);

            return this;
        }

        public DraggableUIPanelBuilder SetPadding(float pixels)
        {
            panel.SetPadding(pixels);

            return this;
        }

        public DraggableUIPanelBuilder SetTop(float pixels, float percent = 0)
        {
            panel.Top.Set(pixels, percent);

            return this;
        }

        public DraggableUIPanelBuilder SetLeft(float pixels, float percent = 0)
        {
            panel.Left.Set(pixels, percent);

            return this;
        }

        public DraggableUIPanelBuilder SetBackGroundColor(int r, int g, int b)
        {
            panel.BackgroundColor = new Color(r, g, b);

            return this;
        }

        public DraggableUIPanelBuilder SetTitle(string title)
        {
            panel.WithTitle(title);


            return this;
        }



    }
}
