using System;

namespace BunnyHopMonogame.Src {

    public class InMemoryDatabase {

        private int coinCount;

        public InMemoryDatabase() {
            coinCount = 0;
        }

        public void AddCoin() {
            coinCount++;
        }

        public int CoinCount {
            get {
                return coinCount;
            }
            set {
                coinCount = value;
            }
        }
    }

}
