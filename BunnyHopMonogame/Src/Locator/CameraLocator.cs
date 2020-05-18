using System;
using MonoGame.Extended;

namespace BunnyHopMonogame.Src.Locator {

    public static class CameraLocator {

        private static Camera2D camera;

        public static void Provide(Camera2D camera) {
            CameraLocator.Camera = camera;
        }

        public static Camera2D Camera {
            get {
                return camera;
            }
            set {
                camera = value;
            }
        }

    }

}
