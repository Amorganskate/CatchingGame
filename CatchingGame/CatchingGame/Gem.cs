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
         
        Random random = new Random(); 
        public float randX, randY;

        //Constructor 
        public Gem(Texture2D NewTex, Vector2 newPosition)
        {
            
            speed = 4;
            texture = NewTex;
            isVisable = true;
            randX = random.Next(0,750);
            randY = random.Next(-600, -50); 

        }
        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            
            position.Y = position.Y + speed;
            if (position.Y >= 950)
                position.Y = -50;
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
            if (isVisable)
                spriteBatch.Draw(texture, position, null, Color.CornflowerBlue ); 


        }
        //Public Load
        public void LoadContent(ContentManager Content)
        {
             





        }
        

    }

    
}
