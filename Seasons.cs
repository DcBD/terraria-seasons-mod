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

namespace Seasons
{
    public class Seasons : Mod
    {
        public static readonly string ModName = $"{nameof(Seasons)}";
        public static readonly string AssetPath = $"{ModName}/Assets/";
        public static ILog PublicLogger = null;

        private UserInterface _userInterface;

        // internal SpringShaderUI SpringShaderUI;

        public override void Load()
        {

            PublicLogger = Logger;

            if (!Main.dedServ)
            {

                //Filters.Scene[$"ABCD"] =  new Filter(new SpringScreenShaderData("Default").UseColor(2f, -0.8f, -0.6f), EffectPriority.Medium);
                //Filters.Scene["Test"] = new Filter(new ScreenShaderData("FilterTest"), EffectPriority.VeryHigh);

                //Filters.Scene.Load();
                // SpringShaderUI = new SpringShaderUI();
                // SpringShaderUI.Activate();


                // _userInterface = new UserInterface();
                // _userInterface.SetState(SpringShaderUI);

                _userInterface.IsVisible = true;

                LoadClientOnly();
            }

            LoadClientOnly();
        }



        private void LoadClientOnly()
        {
            Filters.Scene[$"{ModName}:Spring"] = new Filter(new SpringScreenShaderData("FilterMiniTower").UseColor(0.1f, 0.1f, -0.1f), EffectPriority.VeryHigh);
            SkyManager.Instance[$"{ModName}:Spring"] = new SlimeSky();
        }
    }
}