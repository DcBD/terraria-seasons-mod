using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Seasons.Content.ScreenEffects;
using System.IO;
using log4net;

namespace Seasons.Content.SceneEffects
{
    public class SpringSceneEffect : ModSceneEffect
    {

        public override bool IsSceneEffectActive(Player player)
        {

            return true;
        }

        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Corrupt;

        public override void SpecialVisuals(Player player)
        {
            //Filters.Scene["DcBDSeasons:Spring"].Activate(player.position);
            //Filters.Scene["DcBDSeasons:Spring"].Load();
            //Filters.Scene["DcBDSeasons:Spring"].Apply();

            if (Main.ScreenShaderRef.Value.CurrentTechnique.Passes != null)
            {
                foreach (var pass in Main.ScreenShaderRef.Value.CurrentTechnique.Passes)
                {

                    //SeasonsMod.PublicLogger.InfoFormat(pass.Name);
                }

            }


            //filter.Apply();
            //player.ManageSpecialBiomeVisuals("ABCDs", true, player.position);
            //Filters.Scene.Activate();
        }
    }
}
