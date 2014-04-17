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
        public int speed; 

        //Collision Variables - Draws box around Player
        public Rectangle boundingBox;

        //Used to determine if object colliding with bounding box
        public bool isColliding;

        public Player()
        {
            texture = null;
            isColliding = false; 
            isColliding = false ;
            speed = 5;

            position = new Vector2(400, 400);

        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("MinerCart"); 


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, position, Color.White);


            

        }
    }
}
