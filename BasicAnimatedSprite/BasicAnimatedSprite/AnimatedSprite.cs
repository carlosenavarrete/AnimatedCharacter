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
    class AnimatedSprite
    {

        int frameCount;
        int currentFrame;
        ArrayList textureList;
        Rectangle pos;
        Texture2D texture;
        float timeperframe;
        float timer;
        int frameWidth, frameHeight;
        bool singleFiles;
        Keys up, down, left, right;
        int cont = 0;


        public void LoadConent(ContentManager Content,string dirName, string filename, int frames, float timeframe)
        {//multiple files
            frameCount = frames;

            textureList = new ArrayList();

            for (int k = 1; k <= frameCount; k++)
            {
                Texture2D tex;
                tex = Content.Load<Texture2D>(dirName + "/"+ filename +k.ToString("00"));

                textureList.Add(tex);

            }

            pos = new Rectangle(0, 0, ((Texture2D)textureList[0]).Width, ((Texture2D)textureList[0]).Height);

            currentFrame = 0;
            timeperframe = timeframe;
            timer = 0;

            singleFiles = false;

        }


        // single files
        public void LoadConent(ContentManager Content, string filename, int frames, float timeframe, int width, int height)
        {

            texture = Content.Load<Texture2D>(filename);
            this.frameWidth = width;
            this.frameHeight = height;

            pos = new Rectangle(0, 0, frameWidth, frameHeight);

            this.frameCount = frames;

            this.currentFrame = 0;
            this.timeperframe = timeframe;
            this.timer = 0;
            this.singleFiles = true;
        }

        public void Setposition(Rectangle posi)
        {
            this.pos = posi;

        }

        public Rectangle getrect()
        {
            return pos;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= timeperframe)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = timer - timeperframe;
            }


            if (Keyboard.GetState().IsKeyDown(up)  && pos.Y>0)
            {
                pos.Y -= 4;
                cont = 3;
            }

            if (Keyboard.GetState().IsKeyDown(down)&& pos.Y<420)
            {
                pos.Y += 4;
            }
            if (Keyboard.GetState().IsKeyDown(left)&& pos.X>0)
            {
                pos.X -= 4;
                cont = 0;
            }

            if (Keyboard.GetState().IsKeyDown(right) && pos.X<750)
            {
                pos.X += 4;
                cont = 1;
            }
          



        }


        public void Setkeys(Keys up, Keys down, Keys left, Keys right)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;

        }
      
        public void Draw(SpriteBatch spritebatch)
        {



            spritebatch.Begin();
            if (singleFiles)
            {//draw single
               
                
                    int xTex, yTex;
                    Rectangle sourceRect;

                    xTex = currentFrame * frameWidth;
                    yTex = cont* frameHeight;
                    sourceRect = new Rectangle(xTex, yTex, frameWidth, frameHeight);
                    spritebatch.Draw(texture, pos, sourceRect, Color.White);
                   
               
                
               
            }
            else
            {//draw multiple
                if (currentFrame < textureList.Count)
                {
                    Texture2D tex = (Texture2D)textureList[currentFrame];
                    spritebatch.Draw(tex, pos, Color.White);
                }
            }
            spritebatch.End();
        }

       

    }
}
