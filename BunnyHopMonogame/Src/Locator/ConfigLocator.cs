using System;

namespace BunnyHopMonogame.Src.Locator {
    
	public static class ConfigLocator {

		private static Config config;

        public static void Provide(Config config) {
            ConfigLocator.Config = config;
        }

        public static Config Config {
            get {
                return config;
            }
            set {
                config = value;
            }
        }

    }

}
