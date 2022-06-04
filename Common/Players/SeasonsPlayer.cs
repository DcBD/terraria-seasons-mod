using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework;

namespace Seasons.Common.Players
{
    public class SeasonsPlayer : ModPlayer
    {

        public override void PostUpdate()
        {
            //Filters.Scene.Activate("WaterDistortion", default(Vector2));
            this.Player.ManageSpecialBiomeVisuals($"{SeasonsMod.ModName}:Spring", true);
            //this.Player.ManageSpecialBiomeVisuals("Solar", true);
            //Player.ManageSpecialBiomeVisuals("ABCD", true);
        }

        public override void Load()
        {


        }


        //public override void PostUpdateMiscEffects()
        //{
        //    //Filters.Scene.Activate([$"{Seasons.ModName}:Spring", this.Player.position);
        //    if(Filters.Scene.IsLoaded)
        //    {
        //        Filters.Scene.Activate("DcBDSeasons:Spring", default(Vector2));
        //        SkyManager.Instance.Activate("DcBDSeasons:Spring", default(Vector2));
        //    }

        //    //this.Player.ManageSpecialBiomeVisuals($"{Seasons.ModName}:Spring", true, this.Player.position);
        //}



        //public override void UpdateBiomeVisuals()
        //{
        //    bool usePurity = NPC.AnyNPCs(NPCType<PuritySpirit>());
        //    player.ManageSpecialBiomeVisuals("ExampleMod:PuritySpirit", usePurity);
        //    bool useVoidMonolith = voidMonolith && !usePurity && !NPC.AnyNPCs(NPCID.MoonLordCore);
        //    player.ManageSpecialBiomeVisuals("ExampleMod:MonolithVoid", useVoidMonolith, player.Center);
        //}
    }
}
