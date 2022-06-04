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
using Terraria.UI;
using Seasons.UI.Tools;

namespace Seasons.Common.Managers
{
    /// <summary>
    /// Class <c>UserInterfaceManager</c> for managing user interfaces.
    /// </summary
    public class UserInterfaceManager : ModManager
    {
        public static UserInterfaceManager Instance = new UserInterfaceManager();

        private GameTime _lastUpdatedUIGameTime;
        public GameTime LastUpdateUIGameTime
        {
            get { return _lastUpdatedUIGameTime; }
            private set { _lastUpdatedUIGameTime = value; }
        }
        // Dev tools
        internal UserInterface DevToolsUserInterface;
        internal DevToolsUI DevToolsUI;

        public override void OnLoadClient()
        {
            LoadDevToolsUI(); 
        }

        private void LoadDevToolsUI()
        {
            DevToolsUI = new DevToolsUI();
            DevToolsUI.Activate();
            DevToolsUserInterface = new UserInterface();
            DevToolsUserInterface.SetState(DevToolsUI);

            Logger.Info("Loaded DevToolsUI");
        }

        public void UpdateUI(GameTime gameTime)
        {

            if (DevToolsUI.Visible)
            {
                DevToolsUserInterface?.Update(gameTime);
            }
            LastUpdateUIGameTime = gameTime;
        }

        private void UpdateInterfaceLayers(List<GameInterfaceLayer> layers, UserInterface userInterface)
        {
            //https://github.com/tModLoader/tModLoader/wiki/Vanilla-Interface-layers-values
            int interfaceLayer = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Cursor"));
            if (interfaceLayer != -1)
            {
                layers.Insert(interfaceLayer, new LegacyGameInterfaceLayer("Player Swapper: Cursor",
                    delegate
                    {
                        if (LastUpdateUIGameTime != null && userInterface.CurrentState != null)
                            userInterface.Draw(Main.spriteBatch, LastUpdateUIGameTime);

                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        public void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            UpdateInterfaceLayers(layers, DevToolsUserInterface);
        }

    }
}
