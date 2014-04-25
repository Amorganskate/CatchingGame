using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CatchingGame
{
    class HUD
    {
        public Rectangle healthRectangle;
        public Texture2D healthTex;
        public int playerscore, healthbarHeight, healthbarWidth,health;
        public SpriteFont playerScoreFont;
        public Vector2 playerScorePos, healthbarPosition;
        public bool showHUD;
        Player P; 


        public HUD()
        {
            playerscore = 0;
            showHUD = true;
            healthbarHeight = 25;

            playerScoreFont = null;
            playerScorePos = new Vector2(700/ 2, 10);
            healthbarPosition = new Vector2(50, 50);
            health = 200;
            healthTex = null; 



        }
        public void LoadContent(ContentManager Content)
        {
            playerScoreFont = Content.Load<SpriteFont>("MyFont");
            healthTex = Content.Load<Texture2D>("healthbar"); 


        }
        public void Update(GameTime gameTime)
        {
            healthRectangle = new Rectangle((int)healthbarPosition.X, (int)healthbarPosition.Y, P.health, healthbarHeight);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (showHUD)
                spriteBatch.DrawString(playerScoreFont, "Score - " + playerscore, playerScorePos, Color.Red);
            spriteBatch.Draw(healthTex, healthRectangle, Color.White);
        }


    }


}
