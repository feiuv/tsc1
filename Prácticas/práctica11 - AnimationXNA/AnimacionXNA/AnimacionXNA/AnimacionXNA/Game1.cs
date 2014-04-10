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

namespace AnimacionXNA
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Animación
        Animation playerAnimation;
        Vector2 spritePos;


        // Ball
        Texture2D textureBall;
        Point frameSizeBall = new Point(75, 75);
        Point currentFrameBall = new Point(0, 0);
        Point sheetSizeBall = new Point(6, 8);
        int timeSinceLastFrameBall = 0;
        const int millisecondsPerFrameBall = 25;
        Vector2 positionDrawBall = new Vector2(200, 300);



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerAnimation = new Animation();
            Texture2D playerTexture = Content.Load<Texture2D>("Ken");
            spritePos = new Vector2(100, 100);
            playerAnimation.Initialize(playerTexture, spritePos, 106, 110, 6, 80, Color.White, 1f, true);
         
            textureBall = Content.Load<Texture2D>(@"skullball");
         
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space)) this.Exit();

            playerAnimation.Update(gameTime);
            Ball(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin();
            playerAnimation.Draw(spriteBatch);
            BallSprite();
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        /// <summary>
        /// Explosivo
        /// </summary>
        /// <param name="gameTime"></param>
        private void Ball(GameTime gameTime)
        {
            // Verificar tiempo
            timeSinceLastFrameBall += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrameBall > millisecondsPerFrameBall)
            {
                timeSinceLastFrameBall -= millisecondsPerFrameBall;
                // Avanzar al siguiente frame
                ++currentFrameBall.X;
                if (currentFrameBall.X >= sheetSizeBall.X)
                {
                    currentFrameBall.X = 0;
                    ++currentFrameBall.Y;
                    if (currentFrameBall.Y >= sheetSizeBall.Y)
                        currentFrameBall.Y = 0;
                }
            }
        }

        private void BallSprite()
        {
            spriteBatch.Draw(textureBall, positionDrawBall,
                new Rectangle(currentFrameBall.X * frameSizeBall.X,
                    currentFrameBall.Y * frameSizeBall.Y,
                    frameSizeBall.X,
                    frameSizeBall.Y),
                Color.White, 0, Vector2.Zero,
                1, SpriteEffects.None, 0);
        }

    }
}
