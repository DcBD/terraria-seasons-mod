using Microsoft.Xna.Framework;
using Seasons.Common.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace Seasons.Common.Systems
{
    public class UISystem : ModSystem
    {
        public override void Load()
        {
            UserInterfaceManager.Instance.Load();
        }

        public override void UpdateUI(GameTime gameTime)
        {
            UserInterfaceManager.Instance.UpdateUI(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            UserInterfaceManager.Instance.ModifyInterfaceLayers(layers);
        }
    }
}
