using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arga_Fåglar_2
{
    public class Game1 : Game
    {
        //medlemsvariabler
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            var display = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;

            _graphics.PreferredBackBufferWidth = display.Width;
            _graphics.PreferredBackBufferHeight = display.Height;
            _graphics.IsFullScreen = true;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameElements.currentState = GameElements.State.Menu;
            GameElements.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            GameElements.LoadContet(Content, Window);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                Exit();
            }

            switch (GameElements.currentState)
            {
                case GameElements.State.Run:
                    {
                        GameElements.currentState = GameElements.RunUpdate(Content, Window, gameTime);
                        break;
                    }
                //case GameElements.State.HighScore:
                //    {
                //        GameElements.currentState = GameElements.HighScoreUpdate();
                //        break;
                //    }
                case GameElements.State.Quit:
                    {
                        this.Exit();
                        break;
                    }
                default:
                    {
                        GameElements.currentState = GameElements.MenuUpdate(gameTime);
                        break;
                    }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            switch (GameElements.currentState)
            {
                case GameElements.State.Run:
                    {
                        GameElements.RunDraw(_spriteBatch);
                        break;
                    }
                //case GameElements.State.HighScore:
                //    {
                //        GameElements.HighScoreDraw(_spriteBatch);
                //        break;
                //    }
                case GameElements.State.Quit:
                    {
                        this.Exit();
                        break;
                    }
                default:
                    {
                        GameElements.menuDraw(_spriteBatch);
                        break;
                    }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
