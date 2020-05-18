using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace BunnyHopMonogame.Src {

    public class Config {

        // oldWidth = 160
        // oldHeight = 144

        private int scale = 3;
        private OnOff fullscreen = OnOff.OFF;
        private OnOff vsync = OnOff.OFF;
        private int sound = 0;
        private int music = 0;
        private int virtualWidth = 176;
        private int virtualHeight = 160;

        private int topBoundry = 16;
        private int bottomBoundry = 160;
        private int leftBoundry = 0;
        private int rightBoundry = 176;

        private XmlSerializer serializer;
        private string fileName = "config";

        [Serializable]
        public struct Save {
            public int scale;
            public OnOff fullscreen;
            public OnOff vsync;
            public int sound;
            public int music;
            public int virtualWidth;
            public int virtualHeight;
        }

        public Config() {
            serializer = new XmlSerializer(typeof(Save));
        }

        void LoadFromDevice() {
            //var dataFile = Global.FileManager.GetDefaultIsolatedStorageFileStore();
            //IsolatedStorageFileStream isolatedFileStream = null;

            //if (dataFile.FileExists(fileName)){
            //    using (isolatedFileStream = dataFile.OpenFile(fileName, FileMode.Open, FileAccess.ReadWrite)) {
            //        Save saveData = (Save)serializer.Deserialize(isolatedFileStream);
            //        scale = saveData.scale;
            //        fullscreen = saveData.fullscreen;
            //        vsync = saveData.vsync;
            //        sound = saveData.sound;
            //        music = saveData.music;
            //        virtualWidth = saveData.virtualWidth;
            //        virtualHeight = saveData.virtualHeight;
            //    }

            //    dataFile.Close();
            //    isolatedFileStream.Close();
            //}
        }

        private void SaveToDevice() {
            //var dataFile = Global.FileManager.GetDefaultIsolatedStorageFileStore();
            //IsolatedStorageFileStream isolatedFileStream = null;
            ////dataFile.scale = scale;
            ////dataFile.fullscreen = fullscreen;
            ////dataFile.vsync = vsync;
            ////dataFile.sound = sound;
            ////dataFile.music = music;
            ////dataFile.virtualWidth = virtualWidth;
            ////dataFile.virtualHeight = virtualHeight;

            //Save saveData = new Save() {
            //    scale = this.scale,
            //    fullscreen = this.fullscreen,
            //    vsync = this.vsync,
            //    sound = this.sound,
            //    music = this.music,
            //    virtualWidth = this.virtualWidth,
            //    virtualHeight = this.virtualHeight
            //};

            //if (dataFile.FileExists(fileName)) {
            //    dataFile.DeleteFile(fileName);
            //}

            //using (isolatedFileStream = dataFile.CreateFile(fileName)) {
            //    isolatedFileStream.Seek(0, SeekOrigin.Begin);
            //    serializer.Serialize(isolatedFileStream, saveData);
            //    isolatedFileStream.SetLength(isolatedFileStream.Position);
            //}

            //dataFile.Close();
            //isolatedFileStream.Dispose();
        }

        public int Scale {
            get {
                return scale;
            }
            set {
                scale = value;
            }
        }

        public OnOff Fullscreen {
            get {
                return fullscreen;
            }
            set {
                fullscreen = value;
            }
        }

        public OnOff Vsync {
            get {
                return vsync;
            }
            set {
                vsync = value;
            }
        }

        public int Sound {
            get {
                return sound;
            }
            set {
                sound = value;
            }
        }

        public int Music {
            get {
                return music;
            }
            set {
                music = value;
            }
        }

        public int VirtualWidth {
            get {
                return virtualWidth;
            }
            set {
                virtualWidth = value;
            }
        }

        public int VirtualHeight {
            get {
                return virtualHeight;
            }
            set {
                virtualHeight = value;
            }
        }

        public int TopBoundry {
            get {
                return topBoundry;
            }
            set
            {
                topBoundry = value;
            }
        }

        public int BottomBoundry {
            get {
                return bottomBoundry;
            }
            set {
                bottomBoundry = value;
            }
        }

        public int LeftBoundry {
            get {
                return leftBoundry;
            }
            set {
                leftBoundry = value;
            }
        }

        public int RightBoundry {
            get {
                return rightBoundry;
            }
            set {
                rightBoundry = value;
            }
        }

    }

}
