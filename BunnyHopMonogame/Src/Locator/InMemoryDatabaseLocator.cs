using System;

namespace BunnyHopMonogame.Src.Locator {

    public static class InMemoryDatabaseLocator {

        private static InMemoryDatabase database;

        public static void Provide(InMemoryDatabase database) {
            InMemoryDatabaseLocator.Database = database;
        }

        public static InMemoryDatabase Database {
            get {
                return database;
            }
            set {
                database = value;
            }
        }

    }

}
