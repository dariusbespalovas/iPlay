using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPlay
{
	public sealed class Settings
	{
		static readonly Settings _instance = new Settings();

		public static Settings Instance
		{
			get
			{
				return _instance;
			}
		}

		public Settings()
		{
			this.PlayerSettings = new PlayerSettings();
		}

		public PlayerSettings PlayerSettings { get; set; }
	}

	public class PlayerSettings
	{
		public string PlaylistFilePath { get; set; }

		public WindowSettings MainWindow { get; set; }


		public PlayerSettings()
		{
			this.PlaylistFilePath = "playlist.xml";
			this.MainWindow = new WindowSettings();
		}
	}

	public class WindowSettings
	{
		public int WindowX { get; set; }
		public int WindowY { get; set; }
	}

}




//using System.Configuration;
//using SPL.Web.SPILIS.Configuration;

//namespace SPL.Web.SPILIS
//{
//    public class Settings
//    {
//        private static bool webConfigSettingsLoaded;
//        private static SpilisConfigurationSection configurationSection;

//        public Settings()
//        {
//            LoadFromConfiguration();
//        }

//        private static void LoadFromConfiguration()
//        {
//            if (!webConfigSettingsLoaded)
//            {
//                configurationSection = (SpilisConfigurationSection)
//                                       ConfigurationManager.GetSection("spilisConfiguration") ?? new SpilisConfigurationSection();

//                webConfigSettingsLoaded = true;
//            }
//        }

//        public static SpilisConfigurationSection Configuration
//        {
//            get
//            {
//                LoadFromConfiguration();
//                return configurationSection;
//            }
//        }
//    }
//}