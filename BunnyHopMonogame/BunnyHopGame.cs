using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BunnyHopMonogame.Src;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using BunnyHopMonogame.Src.States;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework.Audio;
using System.Globalization;
using System.Threading;

namespace BunnyHopMonogame.Desktop {

    public class BunnyHopGame : Game {    

        GraphicsDeviceManager graphics;
        RenderTarget2D renderTarget;
        SpriteBatch spriteBatch;
        Config config;
        InMemoryDatabase database;

        Stack<State> stateStack;

        KeyboardState oldKeyState;
        KeyboardState newKeyState;
        GamePadState oldGamePadState;
        GamePadState newGamePadState;

        private Camera2D camera;

        List<SoundEffect> soundEffects;

        public BunnyHopGame() {
            config = new Config();
            database = new InMemoryDatabase();
            ConfigLocator.Provide(config);
            ContentLocator.Provide(Content);
            InMemoryDatabaseLocator.Provide(database);

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = ConfigLocator.Config.VirtualWidth * ConfigLocator.Config.Scale;
            graphics.PreferredBackBufferHeight = ConfigLocator.Config.VirtualHeight * ConfigLocator.Config.Scale;
            graphics.PreferMultiSampling = false;
            graphics.ApplyChanges();
            GraphicsLocator.Provide(graphics);

            var viewportAdapter = new BoxingViewportAdapter(Window, 
                                                            GraphicsDevice, 
                                                            ConfigLocator.Config.VirtualWidth,
                                                            ConfigLocator.Config.VirtualHeight);
            camera = new Camera2D(viewportAdapter);
            CameraLocator.Provide(camera);

            soundEffects = new List<SoundEffect>();
            SoundLocator.Provide(soundEffects);

            Content.RootDirectory = "Content";
            stateStack = new Stack<State>();
            stateStack.Push(new SplashState());

            //https://docs.microsoft.com/pt-br/dotnet/api/system.globalization.cultureinfo.currentculture?view=netcore-3.1
            //CultureInfo culture = new CultureInfo("ko-KR", false); // us-EN ko-KR ja-JP
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;
            //Resources.Culture = CultureInfo.CurrentCulture;
            //Debug.Print(CultureInfo.CurrentCulture.Name);
            //Debug.Print(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            //Debug.Print(Resources.Culture.Name);
        }

        protected override void Initialize() {
            renderTarget = new RenderTarget2D(GraphicsDevice,
                                              ConfigLocator.Config.VirtualWidth,
                                              ConfigLocator.Config.VirtualHeight);
            stateStack.Peek().Create(this);

            oldKeyState = Keyboard.GetState();
            newKeyState = oldKeyState;
            oldGamePadState = GamePad.GetState(PlayerIndex.One);
            newGamePadState = oldGamePadState;

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            stateStack.Peek().LoadContent(Content);
        }

        protected override void UnloadContent() {
        }

        protected override void Update(GameTime gameTime) {
            newKeyState = Keyboard.GetState();
            newGamePadState = GamePad.GetState(PlayerIndex.One);

            if (newKeyState.IsKeyDown(Keys.Escape) ||
                GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                stateStack.Peek().QuitRequested()) {
                Exit();
            }

            stateStack.Peek().Update(gameTime);

            if (stateStack.Peek().PopRequested()) {
                stateStack.Pop();
                stateStack.Peek().Resume();
            }

            oldKeyState = newKeyState;
            oldGamePadState = newGamePadState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            // Render everything in the native resolution to a 
            // RenderTarget instead of the back buffer
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(new Color(230, 214, 156));
            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());
            stateStack.Peek().Draw(spriteBatch);
            spriteBatch.End();

            // Then render this target (your whole screen) to the back buffer
            // If you pass null to render target the GraphicsDevice will render to the backbuffer
            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            var width = graphics.IsFullScreen ? GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width : ConfigLocator.Config.VirtualWidth * ConfigLocator.Config.Scale;
            var height = graphics.IsFullScreen ? GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height : ConfigLocator.Config.VirtualHeight * ConfigLocator.Config.Scale;
            spriteBatch.Draw(renderTarget, new Rectangle(0, 0, width, height), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Push(State state) {
            stateStack.Push(state);
            stateStack.Peek().Create(this);
            stateStack.Peek().LoadContent(Content);
        }

        public void Pop() {
            stateStack.Pop();
        }

        public void SetFullscreen(bool on = false) {
            // GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width
            // GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
            var blackBarWidth = 1024;
            var backBarHeight = 768;
            var width = on ? blackBarWidth : ConfigLocator.Config.VirtualWidth * ConfigLocator.Config.Scale;
            var height = on ? backBarHeight : ConfigLocator.Config.VirtualHeight * ConfigLocator.Config.Scale;
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.IsFullScreen = on;
            graphics.ApplyChanges();
        }

        public void SetVsync(bool on = false) {

        }

    }

}

// http://community.monogame.net/t/solved-scaling-zooming-game-window/7824
// https://stackoverflow.com/questions/7602852/scaling-entire-screen-in-xna

// https://cactus.tistory.com/193