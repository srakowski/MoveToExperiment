using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace MoveTo
{
    class Ship : GameObject
    {
        private Texture2D _shipTexture;

        public Vector2 Position { get; set; }

        public Ship(Texture2D texture, Vector2 startingPosition)
        {
            _shipTexture = texture;
            Position = startingPosition;
        }

        public void MoveTo(Vector2 target)
        {
            StartCoroutine(StepTo(target), true);
        }

        private IEnumerator StepTo(Vector2 target)
        {
            float time = 0;
            while (time < 500f)
            {
                time += _gameTime?.ElapsedGameTime.Milliseconds ?? 0;
                var t = time / 500f;
                this.Position = Vector2.SmoothStep(Position, target, t);
                yield return null;
            }
            this.Position = target;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_shipTexture, Position, Color.White);
        }
    }
}
