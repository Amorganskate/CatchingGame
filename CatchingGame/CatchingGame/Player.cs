using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input ;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using System.IO.IsolatedStorage;


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

        // More Score Vars 
        HighScoreData data;
        public string HighScoresFilename = "highscores.dat";
        int PlayerScore = 0;
        string PlayerName;
        string scoreboard;

        //String for get name
        string cmdString = "Enter your player name and press Enter";
        string messageString = ""; 

        
        public Player()
        {
            texture = null;
            isColliding = false; 
            isColliding = false ;
            speed = 20;
            health = 200;
            position = new Vector2(700, 467);

        }

        public override void initialize()
        {
            //get the path of the save game
            string fullpath = "highscores.dat";
            
            //Checo to see if the save exists
            if (!File.Exists(fullpath))
            {
                //If file does not exsist, make fake one
                //create the data to save
                data = new HighScoreData(5);

                data.PlayerName[0] = "Alfred";
                data.Score[0] = 2000;

                data.PlayerName[1] = "shawn";
                data.Score[1] = 1800;

                data.PlayerName[2] = "mark";
                data.Score[2] = 1500;

                data.PlayerName[3] = "cindy";
                data.Score[3] = 1000;

                data.PlayerName[4] = "sam";
                data.Score[4] = 500;

                SaveHighScores(data, HighScoresFilename, device);






            }

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
    [Serializable]
    public struct HighScoreData
    {
        public string[] PlayerName;
        public int[] Score;

        public int Count;

        public HighScoreData (int count)
        {

            PlayerName = new string[count];
            Score = new int[count];

            Count = count;
        }
        public static void SaveHighScores(HighScoreData data, string filename, StorageDevice device)
        {
            //Get the Path of the save game
            string fullpath = ("highScores.dat");

            //Open the file, creating it if necessary
            FileStream steam = File.Open(fullpath, FileMode.OpenOrCreate);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HighScoreData));
                serializer.Serialize(steam, data);

            }
            finally
            {

                steam.Close();
            }
            

        }
        public static HighScoreData LoadHighScores(string filename)
        {
            HighScoreData data;

            //Get the path of the same game
            string fullpath = "highscores.dat";

            //Open the file
            FileStream stream = File.Open(fullpath, FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                //Read the data from the file
                XmlSerializer serializer = new XmlSerializer(typeof(HighScoreData));
                data = (HighScoreData)serializer.Deserialize(stream);


            }
            finally
            {
                stream.Close();
            }
            return (data);
        }
        private void SaveHighScores()
        {
            //Create the data to saved
            HighScoreData data = LoadHighScores(HighScoresFilename);

            int scoreIndex = -1;
            for (int i = data.Count - 1; i> -1; i--)
            {   
                if (Score.getScore() >= data.Score[i])
                {
                    scoreIndex = i;

                }
            }
            if (scoreIndex > -1)
            {
                //New high score found ... do swaps
                for (int i = data.Count - 1; i > scoreIndex; i--)
                {
                    data.PlayerName[i] = data.PlayerName[i - 1];
                    data.Score[i] = data.Score[i - 1];
                }
 
                data.PlayerName[scoreIndex] = PlayerName; //Retrieve User Name Here
                data.Score[scoreIndex] = score.getScore(); // Retrieve score here
 
                SaveHighScores(data, HighScoresFilename, device);
            }
        }
 
        /* Iterate through data if highscore is called and make the string to be saved*/
        public string makeHighScoreString()
        {
            // Create the data to save
            HighScoreData data2 = LoadHighScores(HighScoresFilename);
 
            // Create scoreBoardString
            string scoreBoardString = "Highscores:\n\n";
 
            for (int i = 0; i<5; i++) // this part was missing (5 means how many in the list/array/Counter)
            {
                        scoreBoardString = scoreBoardString + data2.PlayerName[i] + "-" + data2.Score[i] + "\n";
            }
            return scoreBoardString;
        }
        }
    }
  
}
