using log4net;
using Terraria;

namespace Seasons.Common.Managers
{
    /// <summary>
    /// Abstract Class <c>ModManager</c> for managing the load and unload of mod's content.
    /// </summary>
    public abstract class ModManager
    {
        protected private bool _isLoaded = false;

        protected log4net.ILog Logger = LogManager.GetLogger(SeasonsMod.ModName);
        public bool IsLoaded
        {
            get
            {
                return _isLoaded;
            }
            private set
            {
                _isLoaded = value;
            }



        }
        /// <summary>
        /// Run this method on mod load, to load manager's contents.
        /// </summary>
        public void Load()
        {
            if (IsLoaded)
            {
                return;
            }
            else
            {
                IsLoaded = true;
            }

            if(Main.dedServ)
            {
                OnLoadServer();
            } else
            {
                OnLoadClient();
            }

        }

        /// <summary>
        /// Runs only once on load.
        /// Here you can load your server side content.
        /// </summary>
        public virtual void OnLoadServer()
        {

        }

        /// <summary>
        /// Runs only once on load.
        /// Here you can load your client side content.
        /// </summary>
        public virtual void OnLoadClient()
        {

        }
    }
}
