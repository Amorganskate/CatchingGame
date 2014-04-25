using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CatchingGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        public enum State
        {
            Menu, 
            playing,
            Gameover


        }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player P = new Player();
        public Texture2D menuImage;
        Random random = new Random();
        List<Gem> gemList = new List<Gem>();
        HUD hud = new HUD(); 
        public int score; 

        //First state 
        State gameState = State.Menu;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); 
            //graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 500;
            this.Window.Title = "Catching Game";
            graphics.ApplyChanges();
            this.Window.Title = "Catching Game";
            menuImage = null;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            P.LoadContent(Content);
            hud.LoadContent(Content); 
            menuImage = Content.Load<Texture2D>("GameMenu");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case State.playing:
                    {
                        P.Update(gameTime);
                        foreach (Gem G in gemList)
                        {
                            if (G.boundingBox.Intersects(P.boundingBox))
                            {
                                G.isVisable = false;
                                hud.playerscore += 50;
                            }
                            G.Update(gameTime);
                            
                        }
                        LoadGems(); 
                        break;
                    }
                case State.Menu:
                    {
                        KeyboardState keyState = Keyboard.GetState();

                        if (keyState.IsKeyDown (Keys.Enter))
                        {
                            gameState =  State.playing;
                        }
                        break;
                    }
                case State.Gameover:
                    {
                        KeyboardState keystate = Keyboard.GetState();

                        if (keystate.IsKeyDown(Keys.Escape))
                        {
                            P.position = new Vector2(700, 467);
                            gemList.Clear();
                            hud.playerscore = 0; 
                            gameState = State.Menu;
                            

                        }

                        break;
                    }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(); 
            GraphicsDevice.Clear(Color.CornflowerBlue);
            P.Draw(spriteBatch);

            switch (gameState)
            {
                case State.playing:
                    {
                        hud.Draw(spriteBatch); 
                        foreach (Gem G in gemList)
                        {
                            G.Draw(spriteBatch); 
                        }
                        break;
                    }
                case State.Menu:
                    {
                        spriteBatch.Draw(menuImage, new Vector2(0, 0), Color.White );
                        break;
                    }
                case State.Gameover:
                    {
                        
                        break;
                    }
            }
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void LoadGems()
        {
            int randX = random.Next(0, 750);
            int randY = random.Next(-600, -50);
            

            if (gemList.Count < 5)
            {
                gemList.Add( new Gem(Content.Load<Texture2D>("diamond5"), new Vector2 (randX,randY )));

            }

            for (int i=0; i< gemList .Count; i++)
            {
                if (!gemList[i].isVisable)
                {
                    gemList.RemoveAt(i);
                    i--;
                }
            }
        }



        
    }
}
