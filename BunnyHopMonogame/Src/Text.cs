using System;
using Microsoft.Xna.Framework;

namespace BunnyHopMonogame.Src {

    public class Text {

        string value;
        Vector2 position;

        public Text(string value = "", Vector2 position = new Vector2()) {
            this.value = value;
            this.position = position;
        }

        public string Value {
            get {
                return value;
            }
            set {
                this.value = value;
            }
        }

        public Vector2 Position {
            get {
                return position;
            }
            set {
                position = value;
            }
        }


    }

}
