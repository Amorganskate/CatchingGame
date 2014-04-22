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
            isVisable = false;
            randX = random.Next(0, 450);
            randY = random.Next(-500, -50); 

        }
        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            position.Y = position.Y + speed;
            if (position.Y >= 500)
                position.Y = -50;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisable)
                spriteBatch.Draw(texture, position, Color.White); 


        }
        //Public Load
        public void LoadContent(ContentManager Content)
        {
            Content.Load<Texture2D>("diamond5"); 





        }
        

    }

    
}
