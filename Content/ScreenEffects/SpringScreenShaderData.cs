using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Shaders;

namespace Seasons.Content.ScreenEffects
{
    public class SpringScreenShaderData : ScreenShaderData
    {
        public SpringScreenShaderData(string passName)
            : base(passName)
        {
            
        }
        
        public override void Update(GameTime gameTime)
        {
            float num = 1f - Utils.SmoothStep((float)Main.worldSurface + 50f, (float)Main.rockLayer + 100f, (Main.screenPosition.Y + (float)(Main.screenHeight / 2)) / 16f);
            UseOpacity(num * 0.5f);
        }
    }
}
