using System;
using Microsoft.Xna.Framework;

namespace BunnyHopMonogame.Src.Locator {

    public static class GraphicsLocator {

        private static GraphicsDeviceManager graphics;

        public static void Provide(GraphicsDeviceManager graphics) {
            GraphicsLocator.Graphics = graphics;
        }

        public static GraphicsDeviceManager Graphics {
            get {
                return graphics;
            }
            set {
                graphics = value;
            }
        }


    }

}
