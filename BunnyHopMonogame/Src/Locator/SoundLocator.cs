using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace BunnyHopMonogame.Src.Locator {

    public class SoundLocator {

        private static List<SoundEffect> sounds;

        public static void Provide(List<SoundEffect> sounds) {
            SoundLocator.Sounds = sounds;
        }

        public static List<SoundEffect> Sounds {
            get {
                return sounds;
            }
            set {
                sounds = value;
            }
        }

    }

}
