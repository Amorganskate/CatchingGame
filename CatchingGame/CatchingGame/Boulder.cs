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
    class Boulder
    {
        public Rectangle boundingBox;
        public Texture2D texture;
        public Vector2 posistion;
        public Vector2 origin;
        public float rotateAngle;
        public int speed;

        public bool isVisable;
        Random random = new Random();
        public float randX, randY; 

        public Boulder(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            posistion = newPosition;
            speed = 6;
            randX = random.Next(0, 750);
            randY = random.Next(-600, -50);
            isVisable = true; 


        }

        public void LoadContent(ContentManager Content)
        { }

        public void update (GameTime gameTime)
        {
            //Set Bounding Box
            boundingBox = new Rectangle((int)posistion.X, (int)posistion.Y, 80, 64);

            //Rotation
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;

            //Update Movement
            posistion.Y = posistion.Y + speed;
            if (posistion.Y >= 950)
                posistion.Y = -50;

            //rotate Asteriod 
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rotateAngle += elapsed;
            float circle = MathHelper.Pi * 2;
            rotateAngle = rotateAngle % circle;

            



        }
        public void draw(SpriteBatch spriteBatch)
        {
            if (isVisable)
                spriteBatch.Draw(texture, posistion, null, Color.White);


        }


    }


    
}
