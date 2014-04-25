using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input ;
using Microsoft.Xna.Framework.Graphics;



namespace CatchingGame
{
    class Player
    {
        //Texture for Player
        public Texture2D texture;
        //Default Position for player. 
        public Vector2 position;
        //Determines Speed of player
        public int speed, health; 

        //Collision Variables - Draws box around Player
        public Rectangle boundingBox;

        //Used to determine if object colliding with bounding box
        public bool isColliding;

        public Player()
        {
            texture = null;
            isColliding = false; 
            isColliding = false ;
            speed = 10;
            health = 200;
            position = new Vector2(700, 467);

        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Cart"); 


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, position, Color.White);


            

        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (keyState.IsKeyDown(Keys.A))
                position.X = position.X  - speed;

            if (keyState.IsKeyDown(Keys.D))
                position.X = position.X + speed;

            if (position.X <= 0)
                position.X = 0;
            if (position.X >= 800 - texture.Width)
                position.X = 800 - texture.Width;

            if (position.Y <= 0)
                position.Y = 0;
            if (position.Y >= 500 - texture.Height)
                position.Y = 500 - texture.Height; 

        }
    }
}
