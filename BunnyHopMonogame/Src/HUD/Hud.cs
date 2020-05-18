using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using BunnyHopMonogame.Src.Entities.Player;
using BunnyHopMonogame.Src.Locator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyHopMonogame.Src.HUD {

    public class Hud {

        public Rectangle box;
        public Sprite sp;

        SpriteFont font;
        SpriteFont globalFont;
        PlayerShip player;
        
        int stage;

        List<Text> options;

        public Hud(PlayerShip player, int stage) {
            sp = new Sprite("hud", 1, 1);
            box = new Rectangle(0, 0, sp.Width, sp.Height);

            this.player = player;
            this.stage = stage;

            font = ContentLocator.Content.Load<SpriteFont>("gameboy_sm");
            globalFont = ContentLocator.Content.Load<SpriteFont>("dunggeunmo"); // same name as sprite font

            options = new List<Text>();
            options.Add(new Text(Resources.Stage, new Vector2(16, 00)));
            options.Add(new Text(Resources.Bullets, new Vector2(96, 00)));
            options.Add(new Text(Resources.Life, new Vector2(16, 10)));
            options.Add(new Text(Resources.Weapon, new Vector2(96, 10)));
        }

        public void Update(GameTime gameTime) {
            box.X = (int) CameraLocator.Camera.Position.X;
        }

        public void Draw(SpriteBatch spriteBatch) {
            sp.Draw(spriteBatch, new Vector2(box.X + (box.Width / 2), box.Y + (box.Height / 2)));

            for (int i = 0; i < options.Count; i++) {
                Vector2 pos = options[i].Position;
                //spriteBatch.DrawString(globalFont, options[i].Value, new Vector2(pos.X+box.X, pos.Y+box.Y), new Color(123, 114, 99), 0f, new Vector2(0, 0), 0.05f, SpriteEffects.None, 1);
                spriteBatch.DrawString(globalFont, options[i].Value, new Vector2(pos.X + box.X, pos.Y + box.Y), new Color(123, 114, 99));
            }

            Text stageText = new Text("0" + stage.ToString(), new Vector2(50 + box.X, 02 + box.Y));
            Text bulletsText = new Text("bull", new Vector2(140 + box.X, 02 + box.Y));
            Text lifeText = new Text(LifeAsString(player.Life), new Vector2(50 + box.X, 08 + box.Y));
            Text weaponTypeText = new Text(EnumUtils.GetDescription(player.WeaponType), new Vector2(140 + box.X, 08 + box.Y));

            spriteBatch.DrawString(font, stageText.Value, stageText.Position, new Color(123, 114, 99), 0f, new Vector2(0, 0), 0.125f, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, bulletsText.Value, bulletsText.Position, new Color(123, 114, 99), 0f, new Vector2(0, 0), 0.125f, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, weaponTypeText.Value, weaponTypeText.Position, new Color(123, 114, 99), 0f, new Vector2(0, 0), 0.125f, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, lifeText.Value, lifeText.Position, new Color(123, 114, 99), 0f, new Vector2(0, 0), 0.125f, SpriteEffects.None, 1);

            Text globalText = new Text(Resources.Play, new Vector2(100, 50));
            //spriteBatch.DrawString(globalFont, arialText.Value, arialText.Position, new Color(123, 114, 99), 0f, new Vector2(0, 0), 0.05f, SpriteEffects.None, 1);
            spriteBatch.DrawString(globalFont, globalText.Value, globalText.Position, new Color(123, 114, 99));

            //spriteBatch.DrawString(font, bulletsText.Value, bulletsText.Position, new Color(123, 114, 99));
            //spriteBatch.DrawString(font, weaponTypeText.Value, weaponTypeText.Position, new Color(123, 114, 99));
            //spriteBatch.DrawString(font, stageText.Value, stageText.Position, new Color(123, 114, 99));
            //spriteBatch.DrawString(font, lifeText.Value, lifeText.Position, new Color(123, 114, 99));
        }

        private string LifeAsString(int life) {
            switch (life) {
                case 0:
                    return "";
                case 1:
                    return "<";
                case 2:
                    return "<<";
                case 3:
                    return "<<<";
                default:
                    return "";
            }
        }

    }
}