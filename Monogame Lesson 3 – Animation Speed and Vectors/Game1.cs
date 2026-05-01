using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Lesson_3___Animation_Speed_and_Vectors
{
    enum Screen
    {
        Intro,
        TribbleYard
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Rectangle greyTribbleRect;
        Rectangle creamTribbleRect;
        Rectangle brownTribbleRect;
        Rectangle orangeTribbleRect;

        Texture2D tribbleGreyTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleBrownTexture;
        Texture2D tribbleOrangeTexture;
        Texture2D tribbleIntroTexture;


        Vector2 tribbleGreySpeed;
        Vector2 tribbleCreamSpeed;
        Vector2 tribbleBrownSpeed;
        Vector2 tribbleOrangeSpeed;

        SoundEffect tribbleCoo;

        MouseState mouseState;

        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here




            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            this.Window.Title = "Animation Speed & Vectors";

            greyTribbleRect = new Rectangle (300, 10, 100, 100);
            tribbleGreySpeed = new Vector2(2, 2);

            creamTribbleRect = new Rectangle (400, 20, 100, 100);
            tribbleCreamSpeed = new Vector2(2, 0);

            brownTribbleRect = new Rectangle (400, 20, 100, 100);
            tribbleBrownSpeed = new Vector2(0, 2);


            orangeTribbleRect = new Rectangle(400, 20, 100, 100);
            tribbleOrangeSpeed = new Vector2(4, -3);

            screen = Screen.Intro;

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleIntroTexture = Content.Load<Texture2D>("tribble_intro");


            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;
            }

            else if (screen == Screen.TribbleYard)
            {

                greyTribbleRect.X += (int)tribbleGreySpeed.X;
                greyTribbleRect.Y += (int)tribbleGreySpeed.Y;

                if (greyTribbleRect.Right > window.Width || greyTribbleRect.Left < 0)
                {
                    tribbleGreySpeed.X *= -1;
                    tribbleCoo.Play();

                }


                if (greyTribbleRect.Bottom > window.Height || greyTribbleRect.Top < 0)
                {
                    tribbleGreySpeed.Y *= -1;
                    tribbleCoo.Play();
                }


                creamTribbleRect.X += (int)tribbleCreamSpeed.X;
                creamTribbleRect.Y += (int)tribbleCreamSpeed.Y;

                if (creamTribbleRect.Right > window.Width || creamTribbleRect.Left < 0)
                {
                    tribbleCreamSpeed.X *= -1;
                    tribbleCoo.Play();

                }


                if (creamTribbleRect.Bottom > window.Height || creamTribbleRect.Top < 0)
                {
                    tribbleCreamSpeed.Y *= -1;
                    tribbleCoo.Play();
                }

                brownTribbleRect.X += (int)tribbleBrownSpeed.X;
                brownTribbleRect.Y += (int)tribbleBrownSpeed.Y;

                if (brownTribbleRect.Right > window.Width || brownTribbleRect.Left < 0)
                {
                    tribbleBrownSpeed.X *= -1;
                    tribbleCoo.Play();

                }


                if (brownTribbleRect.Bottom > window.Height || brownTribbleRect.Top < 0)
                {
                    tribbleBrownSpeed.Y *= -1;
                    tribbleCoo.Play();
                }

                orangeTribbleRect.X += (int)tribbleOrangeSpeed.X;
                orangeTribbleRect.Y += (int)tribbleOrangeSpeed.Y;

                if (orangeTribbleRect.Right > window.Width || orangeTribbleRect.Left < 0)
                {
                    tribbleOrangeSpeed.X *= -1;
                    tribbleCoo.Play();

                }


                if (orangeTribbleRect.Bottom > window.Height || orangeTribbleRect.Top < 0)
                {
                    tribbleOrangeSpeed.Y *= -1;
                    tribbleCoo.Play();
                }


            }

            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Azure);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
           
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, window, Color.White);
            }
           
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(tribbleGreyTexture, greyTribbleRect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, creamTribbleRect, Color.White);
                _spriteBatch.Draw(tribbleBrownTexture, brownTribbleRect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, orangeTribbleRect, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
