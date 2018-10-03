using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;

namespace Week4
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SimpleSprite background, character1, character2;

        string collisionText = "";
        SpriteFont gameFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            gameFont = Content.Load<SpriteFont>(@"Fonts\Font");

            Texture2D _bktx = Content.Load < Texture2D >("background");
            background = new SimpleSprite(_bktx, Vector2.Zero);
            Texture2D _char1 = Content.Load<Texture2D>("Down Arrow");
            character1 = new SimpleSprite(_char1, Vector2.One);
            Texture2D _char2 = Content.Load<Texture2D>("body");
            character2 = new SimpleSprite(_char2, Vector2.Zero);



            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            float speed = 5.0f;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Vector2 previousPos1 = character1.Position;
            Vector2 previousPos2 = character2.Position;
            // TODO: Add your update logic here
            if(Keyboard.GetState().IsKeyDown(Keys.A))
            { character2.Move(new Vector2(-1, 0) * speed); }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            { character2.Move(new Vector2(1, 0) * speed); }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            { character2.Move(new Vector2(0, -1) * speed); }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            { character2.Move(new Vector2(0, 1) * speed); }

            if (!GraphicsDevice.Viewport.Bounds.Contains(character2.BoundingRect))
            {
                character2.Move(previousPos2 - character2.Position);
            }
            base.Update(gameTime);


            if (character1.InCollision(character2))
            {
                collisionText = "We are in collision!";

            }
            else
                collisionText = "Not Colliding.";




        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            background.draw(spriteBatch);
            character1.draw(spriteBatch);
            character2.draw(spriteBatch);
            spriteBatch.DrawString(gameFont, collisionText, new Vector2(10, 10), Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
