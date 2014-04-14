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
        public Texture2D player;
        public Vector2 position;
        public int speed; 

        //Collision Variables
        public Rectangle boundingBox;
        public bool isColliding;

        public Player()
        {
            player = null;
            isColliding = false; 
            isColliding = false ;
            speed = 5; 

        }

        public void LoadContent(ContentManager Content)
        {
            player = Content.Load<Texture2D>("MinerCart"); 


        }
    }
}
