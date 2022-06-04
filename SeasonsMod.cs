using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Seasons.Content.ScreenEffects;
using Terraria.GameContent.Skies;
using Microsoft.Xna.Framework;
using log4net;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Graphics;
// using Seasons.UI.Tools;
using Terraria.UI;
using Seasons.Common.Managers;

namespace Seasons
{
    public class SeasonsMod : Mod
    {
        public static readonly string ModName = $"{nameof(SeasonsMod)}";


        public override void Load()
        {
           

            LoadClientOnly(); // Stay for now
        }

        private void LoadClientOnly()
        {
            Filters.Scene[$"{ModName}:Spring"] = new Filter(new SpringScreenShaderData("FilterMiniTower").UseColor(1f, 0.1f, -100f), EffectPriority.VeryHigh);
            SkyManager.Instance[$"{ModName}:Spring"] = new SlimeSky();
        }
    }
}