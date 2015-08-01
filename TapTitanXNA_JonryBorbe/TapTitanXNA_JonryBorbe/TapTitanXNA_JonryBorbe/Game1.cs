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

namespace TapTitanXNA_JonryBorbe
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ContentManager content;

        Texture2D player;
        Texture2D bg1;
        Texture2D enemy1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 400;
            graphics.PreferredBackBufferHeight = 500;
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;

            this.content = Content;

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

            player = content.Load<Texture2D>("HeroSprites/player01");
            bg1 = content.Load<Texture2D>("Backgrounds/background");
            enemy1 = content.Load<Texture2D>("Enemies/enemy1");

            
            

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            var mouseState = Mouse.GetState();

            if(mouseState.LeftButton == ButtonState.Pressed)
            {


               // aj.X += 1;
                //aj.Y += 1;
               // aj = new Vector2(x += 100, y += 100);
                
            }

            // TODO: Add your update logic her

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //spriteBatch.Draw(bg1, new Vector2(0, 250), null, Color.White, 0.0f, Vector2.Zero, 1.275f, SpriteEffects.None, 0);

            //spriteBatch.Draw(enemy1, new Vector2(85, 95), null, Color.White, 0.0f, Vector2.Zero, 2f, SpriteEffects.None, 0);
            spriteBatch.Draw(enemy1, new Vector2(75, 225), null, Color.White, 0.0f, Vector2.Zero, 2f, SpriteEffects.None, 0);
            spriteBatch.Draw(player, new Vector2(75, 225), null, Color.White, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0);
            //spriteBatch.Draw(player, new Vector2(10.0f, 20.0f), Color.White);
            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
