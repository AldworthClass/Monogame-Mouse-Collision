using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Mouse_Collision
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        MouseState mouseState;
        MouseState previousMouseState;
        Vector2 mouseLocation;

        Texture2D crosshairTexture;
        Rectangle crosshairRect;

        Texture2D targetTexture;
        Rectangle targetRect;

        Texture2D targetColorTexture;
        Rectangle targetColorRect;

        SpriteFont statusFont;
        string status;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
             IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            crosshairTexture = Content.Load<Texture2D>("crosshair");
            crosshairRect = new Rectangle(0, 0, 40, 40);

            targetColorTexture = Content.Load<Texture2D>("target_color");
            targetColorRect = new Rectangle(550, 140, 200, 200);

            targetTexture = Content.Load<Texture2D>("targetSquare");
            targetRect = new Rectangle(300, 140, 200, 200);

            statusFont = Content.Load<SpriteFont>("StatusFont");
            status = "Nothing";
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            crosshairRect.Location = mouseState.Position;
            crosshairRect.Offset(-20, -20);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (targetRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
            {
                status = "Hit";
            }
            else if(mouseState.LeftButton == ButtonState.Pressed)
            {
                status = "Missed";
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(statusFont, status, new Vector2(10, _graphics.PreferredBackBufferHeight - 40), Color.Black);
            _spriteBatch.Draw(targetTexture, targetRect, Color.White);
            _spriteBatch.Draw(crosshairTexture, crosshairRect, Color.White);
            _spriteBatch.Draw(targetColorTexture, targetColorRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
