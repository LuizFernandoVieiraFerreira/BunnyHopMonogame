using System;
using BunnyHopMonogame.Src.States;

namespace BunnyHopMonogame.Src.Locator {

    public class StateLocator {

        private static State state;

        public static void Provide(State state) {
            StateLocator.State = state;
        }

        public static State State {
            get {
                return state;
            }
            set {
                state = value;
            }
        }

    }

}
