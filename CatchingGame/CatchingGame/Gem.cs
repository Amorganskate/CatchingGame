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
    public class Gem
    {
        public Rectangle boundingBox;
        public Texture2D texture;
        public Vector2 origin;
        public float rotationAngle; 
        public Vector2 position;
        public bool isVisable;
        public float speed;
         
        public float randX, randY;

        int redInt = 0;
        int GreenIntenstity = 0;
        int blueIntensity = 0;

        //Constructor 
        public Gem(Texture2D NewTex, Vector2 newPosition)
        {
            
            speed = 4;
            texture = NewTex;
            isVisable = true;

            // NOTE:
            // You have to assign the random value to the actual position coords, not the randX and Y vars themselves...
            // "newPosition" holds the random value created outside of this class (look in Game.cs under the LoadGems() section).
            // Hope this is what you're looking for. Happy Programming! :)
            // P.S. Also, you might want to change the gem spawning rate. It's a little too fast, unless that's how you
            // want it to be...
            // Thanks for sharing. This game looks fun!
            position.X = newPosition.X;
            position.Y = newPosition.Y; 

        }
        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            
            position.Y = position.Y + speed;
            if (position.Y >= 950)
                position.Y = -50;

            Random rand = new Random();
            {
                redInt = rand.Next(255);
                GreenIntenstity = rand.Next(255);
                blueIntensity = rand.Next(255);
                
            }
            int i = 10; 
            while (i < 10)
            {
                redInt = rand.Next(255);
                GreenIntenstity = rand.Next(255);
                blueIntensity = rand.Next(255);

            }
            //Origin for rotation

            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2; 

            //rotates Gem
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rotationAngle += elapsed;
            float circle = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % circle; 
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color ChangeColor;
            ChangeColor = new Color(redInt, blueIntensity, GreenIntenstity);

            if (isVisable)
                spriteBatch.Draw(texture, position, null, ChangeColor);

            
        }
        //Public Load
        public void LoadContent(ContentManager Content)
        {
             





        }
        

    }

    
}
