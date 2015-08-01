using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Timers;
using System.Threading;

namespace TapTitanXNA_JonryBorbe
{

    public class Hero
    {
        #region properties
        public Vector2 playerPosition;
        public Texture2D player;
        ContentManager content;
        Level level;
        public Animation idleAnimation;
        public Animation atkAnimation;
        AnimationPlayer spritePlayer;

        int recycle;
        int setry = 0;

        public int positionX;
        public int positionY;

        SpriteFont enemyHP;
        SpriteFont damageStringFont;
        public int minHP = 1;
        public int maxHP = 1;

        public float animationSpeed = 0.1f;
        public int varSprite = 3; // Fixed Sprite Number is total 3

        public int playerDamage = 1;
        public int evaDamage = 3;
        public int sayoDamage = 2;
        public int actualplayerDamage1 = 4;
        //public int damageNumber = 0;

        
        SpriteFont fontplayerDamage1;
        
        //Timer timer1 = new Timer();

       // float time1;
        //int timer;
        int s1 = 200;
        int y1 = 200;
        //int once1 = 0;

        public int printFont = 0;

        #endregion

        public Hero(ContentManager content, Level level, int varA)
        {

            this.content = content;
            this.level = level;
            this.recycle = varA;
        }

        public void test1()
        {
        }

        public void LoadContent()
        {

            /*switch (this.recycle)
            {
                case 0:
                    break;
                case 1:
                    break;
                default:
                    break;
            }*/

            if (this.recycle == 0)
            {
                player = content.Load<Texture2D>("HeroSprites/set2");//Setsuna
                idleAnimation = new Animation(player, animationSpeed, true, 3);
                positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) - 25;
                positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;

                //playerAtk = content.Load<Texture2D>("HeroSprites/set2");//Setsuna
                
                
            }
            else if (this.recycle == 1)
            {
                player = content.Load<Texture2D>("HeroSprites/support1");
                idleAnimation = new Animation(player, 0.1f, true, 3);
                positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) - 150;
                positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;
            }
            else if (this.recycle == 2)
            {
                player = content.Load<Texture2D>("HeroSprites/support2");
                idleAnimation = new Animation(player, 0.1f, true, 3);
                positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) - 60;
                positionY = (Level.windowHeight / 2) - (player.Height / 2) - 75;
            }
            else if (this.recycle == 3)
            {
                if(level.randomEnemy == 0)
                {
                    player = content.Load<Texture2D>("Enemies/enemy1");
                    idleAnimation = new Animation(player, 0.1f, true, 3);
                    positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) + 125;
                    positionY = (Level.windowHeight / 2) - (player.Height / 2) - 50;
                }
            }
            else if (this.recycle == 4)
            {
                player = content.Load<Texture2D>("HeroSprites/atkEffect");
                idleAnimation = new Animation(player, 0.1f, false, 6);
                //positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) - 25;
                //positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;
                positionX = level.mouseState.X + 1000;//((Level.windowWidth / 2) - ((player.Width / 5) / 2));
                positionY = level.mouseState.Y + 1000;//((Level.windowHeight / 2) - (player.Height / 2));
            }
            spritePlayer.PlayAnimation(idleAnimation);
            playerPosition = new Vector2((float)positionX, (float)positionY);

            enemyHP = content.Load<SpriteFont>("Font");
            damageStringFont = content.Load<SpriteFont>("Font");
            fontplayerDamage1 = content.Load<SpriteFont>("Font");
        }



        public void Update(GameTime gameTime)
        {
            

            if (level.mouseState.LeftButton == ButtonState.Pressed && level.oldMouseState.LeftButton == ButtonState.Released)
            {
                if ((this.recycle == 0)&&(idleAnimation.isLooping == true))
                {
                    player = content.Load<Texture2D>("HeroSprites/set1"); 
                    idleAnimation = new Animation(player, 0.1f, false, 9);
                    //positionX = (Level.windowWidth / 2) - ((player.Width / 9) / 2) - 25;
                    //positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;
                    //playerPosition = new Vector2((float)positionX, (float)positionY);
                    //spritePlayer.PlayAnimation(idleAnimation);
                }
                if (this.recycle == 4)
                {

                    
                    if (setry == 0) 
                    { 
                        player = content.Load<Texture2D>("HeroSprites/atkEffect");
                        idleAnimation = new Animation(player, 0.1f, false, 6); 
                        positionX = level.mouseState.X - ((player.Width / 5) / 2) + 17; //+ ((Level.windowWidth - (player.Width / 5) / 2);
                        positionY = level.mouseState.Y - ( player.Height / 2 ) - 2;
                        playerPosition = new Vector2((float)positionX, (float)positionY);
                        //Trace.Write(level.mouseState.X +","+ level.mouseState.Y);
                        level.exp++;
                        level.minHP -= playerDamage;
                        printFont = 1;
                        y1 = 250;

                    }
                    

                }
                spritePlayer.PlayAnimation(idleAnimation);
            }

            if (this.recycle == 0)
            {
                //Trace.Write(spritePlayer.rRecy + ",");
                if (this.spritePlayer.Animation.isLooping == false)
                {
                    if (this.spritePlayer.rRecy == 8)
                    {

                        this.printFont = 1;
                        player = content.Load<Texture2D>("HeroSprites/set2");
                        idleAnimation = new Animation(player, 0.1f, true, 3);
                        //positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) - 25;
                        //positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;
                        //playerPosition = new Vector2((float)positionX, (float)positionY);
                        //spritePlayer.PlayAnimation(idleAnimation);
                        
                    }
                }
            }
            if (this.recycle == 1)
            {
                if ((spritePlayer.Animation.isLooping == true) && (spritePlayer.rRecy == 1) && (printFont == 1) && (s1 <= 265))
                {
                    level.exp++;
                    level.minHP -= sayoDamage;
                    s1 = 300;
                }
            }
            if (this.recycle == 2)
            {
                if ((spritePlayer.Animation.isLooping == true) && (spritePlayer.rRecy == 2) && (printFont == 1)&&(s1 <= 172))
                {
                    level.exp++;
                    level.minHP -= evaDamage;
                    s1 = 200;
                }
            }
            if (this.recycle == 3)
            {
                if ((spritePlayer.Animation.isLooping == false) && (spritePlayer.rRecy == 4))
                {
                    if(level.randomEnemy == 0)
                    {
                        player = content.Load<Texture2D>("Enemies/enemy1");
                        idleAnimation = new Animation(player, 0.1f, true, 3);
                    }
                    
                    //positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) - 25;
                    //positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;
                    
                }
                //spritePlayer.PlayAnimation(idleAnimation);
            }



            spritePlayer.PlayAnimation(idleAnimation);
        }

        public void superAct()
        {
            if (this.recycle == 1)
            {
                if (printFont == 1)
                {
                    player = content.Load<Texture2D>("HeroSprites/sayoAtk");
                    idleAnimation = new Animation(player, 0.1f, true, 2);
                    //positionX = (Level.windowWidth / 2) - ((player.Width / 2) / 2) - 150;
                    //positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;
                    s1 = 300;
                }
                else if (printFont == 0)
                {
                    player = content.Load<Texture2D>("HeroSprites/support1");
                    idleAnimation = new Animation(player, 0.1f, true, 3);
                    //positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) - 150;
                    //positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;
                }
                //spritePlayer.PlayAnimation(idleAnimation);
            }
            if (this.recycle == 2)
            {
                if (printFont == 1)
                {
                    player = content.Load<Texture2D>("HeroSprites/evaAtk");
                    idleAnimation = new Animation(player, 0.1f, true, 3);
                    //positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) - 25;
                    //positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;
                    s1 = 200;
                }
                else if (printFont == 0)
                {
                    player = content.Load<Texture2D>("HeroSprites/support2");
                    idleAnimation = new Animation(player, 0.1f, true, 3);
                    //positionX = (Level.windowWidth / 2) - ((player.Width / 3) / 2) - 25;
                    //positionY = (Level.windowHeight / 2) - (player.Height / 2) - 5;
                }

            } 
            playerPosition = new Vector2((float)positionX, (float)positionY);
            spritePlayer.PlayAnimation(idleAnimation);

        }

        public void eHP()
        {
            if (minHP <= 0) { maxHP++; minHP = maxHP; }
        }

        public void clickD()
        {
            level.exp++;
            minHP--;
            eHP();
        }

        public void p1D()
        {
            level.exp++;
            minHP-=actualplayerDamage1;
            eHP();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player, playerPosition, null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
            //spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
            //Trace.Write(spriteBatch);

            if (this.recycle == 0)
            {
                if (this.spritePlayer.Animation.isLooping == false)
                {
                    if (this.spritePlayer.rRecy == 8)
                    {
                        //for (int i = 0; i < 10000; i++)
                        //{
                        //}
                        //System.Threading.Thread.Sleep(100);
                        this.printFont = 1;
                        s1 = 250;
                        level.exp++;
                        level.minHP -= actualplayerDamage1;
                        player = content.Load<Texture2D>("HeroSprites/set2");
                        idleAnimation = new Animation(player, 0.1f, true, 3);
                        //spritePlayer.PlayAnimation(idleAnimation);

                    }
                }
            }

            if (this.recycle == 4)
            {
                if(printFont == 1)
                {
                    y1-=5;
                    spriteBatch.DrawString(damageStringFont, "-" + playerDamage + " HP", new Vector2(350 + 25, y1 + 100), Color.Red);
                }
            }
            if ((this.recycle == 0) && (this.printFont == 1))
            {
                s1-=3;
                spriteBatch.DrawString(fontplayerDamage1, "-" + actualplayerDamage1 + " HP", new Vector2(350, s1 + 100), Color.Red);
            }
            if ((this.recycle == 1) && (this.printFont == 1))
            {
                s1 -= 5;
                spriteBatch.DrawString(damageStringFont, "-" + sayoDamage + " HP", new Vector2(320, s1 + 100), Color.Red);
            }
            if ((this.recycle == 2) && (this.printFont == 1))
            {
                s1 -= 4;
                spriteBatch.DrawString(damageStringFont, "-" + evaDamage + " HP", new Vector2(300, s1 + 100), Color.Red);
            }
        }
    }
}
