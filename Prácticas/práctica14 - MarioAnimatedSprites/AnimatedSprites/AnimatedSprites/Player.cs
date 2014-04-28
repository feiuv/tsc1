using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
namespace AnimatedSprites
{
    class Player
    {
        private bool marioCaminando = false;
        private bool? marioCaminandoDerecha;
        private String ip = "148.226.81.145";
        private Game game;

        int collisionRectOffsetMarioCaminando = 5;

        // Mario
        Texture2D textureMarioCaminando;
        Point currentFrameMarioCaminando = new Point(0, 0);
        Point frameSizeMarioCaminando = new Point(52, 67);
        int timeSinceLastFrameMarioCaminando = 0;
        const int millisecondsPerFrameMarioCaminando = 30;
        Point sheetSizeMarioCaminando = new Point(3, 1);
        Vector2 positionDrawMario = new Vector2(100, 150);
        const float speedMarioCaminando = 5;

        // Mario saltando
        Texture2D textureMarioSaltando;
        Point currentFrameMarioSaltando = new Point(0, 0);
        Point frameSizeMarioSaltando = new Point(53, 66);
        int timeSinceLastFrameMarioSaltando = 0;
        const int millisecondsPerFrameMarioSaltando = 30;
        Point sheetSizeMarioSaltando = new Point(1, 1);
        const float speedMarioSaltando = 5;
        TimeSpan previousJumpTime;
        TimeSpan jumpTime;
        SoundEffect soundEffectSaltando;
        SoundEffectInstance soundEffectUpInstanceSaltando;

        Texture2D textureMarioDetenido;
        Point currentFrameMarioDetenido = new Point(0, 0);
        Point frameSizeMarioDetenido = new Point(52, 67);
        int timeSinceLastFrameMarioDetenido = 0;
        const int millisecondsPerFrameMarioDetenido = 30;
        Point sheetSizeMarioDetenido = new Point(1, 1);

        const float speedMarioDetenido = 5;

        public Player(Game game, SpriteBatch sprite)
        {
            this.game = game;
            this.sprite = sprite;

            jumpTime = TimeSpan.FromSeconds(.15f);

        }

        private SpriteBatch sprite;

        public void LoadContent()
        {
            textureMarioCaminando = game.Content.Load<Texture2D>(@"images\marioDemo");
            textureMarioSaltando = game.Content.Load<Texture2D>(@"images\mariojumping");
            textureMarioDetenido = game.Content.Load<Texture2D>(@"images\marioStatic1");
            soundEffectSaltando = game.Content.Load<SoundEffect>(@"sounds\smb_jump-small");
            soundEffectUpInstanceSaltando = soundEffectSaltando.CreateInstance();
        }
        /// <summary>
        /// MarioNormal....
        /// </summary>
        /// <param name="gameTime"></param>
        private void MarioCaminando(GameTime gameTime)
        {
            timeSinceLastFrameMarioCaminando += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrameMarioCaminando > millisecondsPerFrameMarioCaminando)
            {
                timeSinceLastFrameMarioCaminando -= millisecondsPerFrameMarioCaminando;

                ++currentFrameMarioCaminando.X;
                if (currentFrameMarioCaminando.X >= sheetSizeMarioCaminando.X)
                {
                    currentFrameMarioCaminando.X = 0;
                    ++currentFrameMarioCaminando.Y;
                    if (currentFrameMarioCaminando.Y >= sheetSizeMarioCaminando.Y)
                        currentFrameMarioCaminando.Y = 0;
                }
            }
            positionDrawMario = ValidarObjeto(positionDrawMario, frameSizeMarioCaminando);
        }
        private void MarioSaltando(GameTime gameTime)
        {
            timeSinceLastFrameMarioSaltando += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrameMarioSaltando > millisecondsPerFrameMarioSaltando)
            {
                timeSinceLastFrameMarioSaltando -= millisecondsPerFrameMarioSaltando;

                ++currentFrameMarioSaltando.X;
                if (currentFrameMarioSaltando.X >= sheetSizeMarioSaltando.X)
                {
                    currentFrameMarioSaltando.X = 0;
                    ++currentFrameMarioSaltando.Y;
                    if (currentFrameMarioSaltando.Y >= sheetSizeMarioSaltando.Y)
                        currentFrameMarioSaltando.Y = 0;
                }
            }
            positionDrawMario = ValidarObjeto(positionDrawMario, frameSizeMarioSaltando);
        }

        private void MarioDetenido(GameTime gameTime)
        {
            timeSinceLastFrameMarioDetenido += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrameMarioDetenido > millisecondsPerFrameMarioDetenido)
            {
                timeSinceLastFrameMarioDetenido -= millisecondsPerFrameMarioDetenido;

                ++currentFrameMarioDetenido.X;
                if (currentFrameMarioDetenido.X >= sheetSizeMarioDetenido.X)
                {
                    currentFrameMarioDetenido.X = 0;
                    ++currentFrameMarioDetenido.Y;
                    if (currentFrameMarioDetenido.Y >= sheetSizeMarioDetenido.Y)
                        currentFrameMarioDetenido.Y = 0;
                }
            }
            positionDrawMario = ValidarObjeto(positionDrawMario, frameSizeMarioDetenido);
        }

        bool _isJumping = false;
        bool _isJumpingDown = false;
        float _celling = 50f;
        float _positionDrawMarioYMax;

        private void MarioCaminandoSprite()
        {
            SpriteEffects effect = marioCaminandoDerecha == false ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            sprite.Draw(textureMarioCaminando, positionDrawMario,
                new Rectangle(currentFrameMarioCaminando.X * frameSizeMarioCaminando.X,
                    currentFrameMarioCaminando.Y * frameSizeMarioCaminando.Y,
                    frameSizeMarioCaminando.X,
                    frameSizeMarioCaminando.Y),
                Color.White, 0, Vector2.Zero,
               1, effect, 0);
        }

        private void MarioSaltandoSprite()
        {
            SpriteEffects effect = marioCaminandoDerecha == false ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            sprite.Draw(textureMarioSaltando, positionDrawMario,
                new Rectangle(currentFrameMarioSaltando.X * frameSizeMarioSaltando.X,
                    currentFrameMarioSaltando.Y * frameSizeMarioSaltando.Y,
                    frameSizeMarioSaltando.X,
                    frameSizeMarioSaltando.Y),
                Color.White, 0, Vector2.Zero,
               1, effect, 0);
        }

        private void MarioDetenidoSprite()
        {
            SpriteEffects effect = marioCaminandoDerecha == false ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            sprite.Draw(textureMarioDetenido, positionDrawMario,
                new Rectangle(currentFrameMarioDetenido.X * frameSizeMarioDetenido.X,
                    currentFrameMarioDetenido.Y * frameSizeMarioDetenido.Y,
                    frameSizeMarioDetenido.X,
                    frameSizeMarioDetenido.Y),
                Color.White, 0, Vector2.Zero,
               1, effect, 0);
        }


        private Vector2 ValidarObjeto(Vector2 obj, Point frameSize)
        {
            // If threerings is off the screen, move it back into the game window
            if (obj.X < 0)
                obj.X = 0;
            if (obj.Y < 0)
                obj.Y = 0;
#if WINDOWS
            if (obj.X > game.Window.ClientBounds.Width - frameSize.X)
                obj.X = game.Window.ClientBounds.Width - frameSize.X;
            if (obj.Y > game.Window.ClientBounds.Height - frameSize.Y)
                obj.Y = game.Window.ClientBounds.Height - frameSize.Y;
#else
                if (obj.X >  (graphics.GraphicsDevice.Viewport.Width-20) - frameSize.X)
                    obj.X = (graphics.GraphicsDevice.Viewport.Width-20) - frameSize.X;
                if (obj.Y > (graphics.GraphicsDevice.Viewport.Height-20) - frameSize.Y)
                    obj.Y = (graphics.GraphicsDevice.Viewport.Height-20) - frameSize.Y;
   
#endif
            return obj;
        }

        public void CaminarDerecha()
        {
            marioCaminando = true;
            marioCaminandoDerecha = false;
            positionDrawMario.X -= speedMarioCaminando;
  
        }

        public void CaminarIzquierda()
        {
            marioCaminandoDerecha = true;
            marioCaminando = true;
            positionDrawMario.X += speedMarioCaminando;
        }

        public void CaminarArriba()
        {
            marioCaminandoDerecha = true;
            marioCaminando = true;
            positionDrawMario.Y -= speedMarioCaminando;
        }

        public void CaminarAbajo()
        {
            marioCaminandoDerecha = true;
            marioCaminando = true;
            positionDrawMario.Y += speedMarioCaminando;
        }

        public void MarioDetener()
        {
            marioCaminando = false;
        }
  
        public void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                // soundEffectUpInstanceSaltando.Stop();
                if (gameTime.TotalGameTime - previousJumpTime > jumpTime)
                {

                    _isJumping = true;
                    _positionDrawMarioYMax = positionDrawMario.Y - _celling;
                    soundEffectSaltando.Play();
                    previousJumpTime = gameTime.TotalGameTime;

                }
            }
            if (_isJumping)
            {
                if (!_isJumpingDown && _positionDrawMarioYMax < positionDrawMario.Y)
                {
                    positionDrawMario.Y -= speedMarioCaminando;

                }
                else
                {
                    if (positionDrawMario.Y < (_positionDrawMarioYMax + _celling))
                    {
                        _isJumpingDown = true;
                        positionDrawMario.Y += speedMarioCaminando;
                    }
                    else
                    {
                        _isJumpingDown = false;
                        _isJumping = false;
                    }
                }
            }

            if (marioCaminando)
            {
                MarioCaminando(gameTime);
            }
            else
            {
                MarioDetenido(gameTime);
            }

        }

        public void Draw(GameTime gameTime)
        {
            if (marioCaminando && !_isJumping)
            {
                MarioCaminandoSprite();
            }
            else if (_isJumping)
            {
                MarioSaltandoSprite();
            }
            else
                MarioDetenidoSprite();
        }

    }
}
