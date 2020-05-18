using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace BunnyHopMonogame.Src.Locator {

    public static class ContentLocator {

        private static ContentManager content;

        public static void Provide(ContentManager content) {
            ContentLocator.Content = content;
        }

        public static ContentManager Content {
            get {
                return content;
            }
            set {
                content = value;
            }
        }

    }

}
