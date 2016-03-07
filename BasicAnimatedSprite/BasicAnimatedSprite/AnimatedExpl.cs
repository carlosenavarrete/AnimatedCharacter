using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;

namespace BasicAnimatedSprite
{
    class AnimatedExpl
    {
        AnimatedSprite mega, exp;


        public void Init(ContentManager Content)
        {
            mega = new AnimatedSprite();
            mega.LoadConent(Content, "RunRight", "f", 17, .03f);
            mega.Setkeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right);


            exp = new AnimatedSprite();
            exp.LoadConent(Content, "fire", 16, .05f, 64, 64);
           

        }

        public void Update(GameTime gameTime)
        {

            exp.Setposition((mega.getrect()));

            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                exp.Update(gameTime);
            }
            else
            {
                mega.Update(gameTime);

            }


        }

        public void Draw(SpriteBatch spritebatch)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                exp.Draw(spritebatch);

            }
            else {
                mega.Draw(spritebatch);
            }
        }









    }
}
