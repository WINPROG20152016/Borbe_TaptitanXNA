using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
//using System.Diagnostics;

namespace TapTitanXNA_JonryBorbe
{
    public class Level
    {
        public static int windowWidth = 480;//400;
        public static int windowHeight = 800;//500;

        public int randomEnemy = 0;

        ContentManager content;
        Texture2D bg1;
        Texture2D bg2;
        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;

        Hero hero; // main char
        Hero hero1; // support 1 Sayo
        Hero hero2; // support 2 Evan
        Hero hero3; // enemy
        Hero hero4; // atkEffec


        SpriteFont clickD;
        SpriteFont enemyHP;
        public int minHP = 1;
        public int maxHP = 1;
        public int exp = 0;

        //int fontY1 = 200;

        public int damageNumber = 0;

        Button playButton;
        Button play2Button;

        Button btnClickUpgrade;
        Button btnSetUpgrade;
        Button btnSayoUpgrade;
        Button btnEvaUpgrade;

        int btn1 = 0;
        int btn2 = 0;

       // List<Hero> heroes = new List<Hero>();

        //int heroVar; 

        public Level(ContentManager content)
        {
            this.content = content;

            hero = new Hero(content, this, 0);
            hero1 = new Hero(content, this, 1);
            hero2 = new Hero(content, this, 2);
            hero3 = new Hero(content, this, 3);
            hero4 = new Hero(content, this, 4);

            //heroes.Add(hero);
            //heroes.Add(hero1);
            //heroes.Add(hero2);
        }


        public void LoadContent()
        {
            bg1 = content.Load<Texture2D>("Backgrounds/background");
            bg2 = content.Load<Texture2D>("Backgrounds/background2");
            clickD = content.Load<SpriteFont>("Font");
            enemyHP = content.Load<SpriteFont>("Font");

            playButton = new Button(content, "Buttons/buttonBored", new Vector2(125, 277));
            play2Button = new Button(content, "Buttons/buttonBored", new Vector2(46, 339));
            //play3Button = new Button(content, "Buttons/buttonBored", new Vector2(0,0));

            btnClickUpgrade = new Button(content, "Buttons/btnsClickUpgrade", new Vector2(0, windowHeight - 350));
            btnSetUpgrade = new Button(content, "Buttons/btnsSetUpgrade", new Vector2(100, windowHeight - 400));
            btnSayoUpgrade = new Button(content, "Buttons/btnsSayoUpgrade", new Vector2(200, windowHeight - 350));
            btnEvaUpgrade = new Button(content, "Buttons/btnsEvaUpgrade", new Vector2(300, windowHeight - 450));

            hero.LoadContent();//MainCharacter
            hero1.LoadContent();//Support1
            hero2.LoadContent();//support2
            hero3.LoadContent();//enemy1
            hero4.LoadContent();

            //foreach (Hero hero in heroes)
            //{
            //    hero.LoadContent();
            //}
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            //Trace.Write(mouseState + ",");

            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;


            hero.Update(gameTime);
            hero1.Update(gameTime);
            hero2.Update(gameTime);
            hero3.Update(gameTime);
            hero4.Update(gameTime);

            oldMouseState = mouseState;

            //Trace.Write(mouseX + "," + mouseY);
            if(playButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                if (btn1 == 0) { playButton = new Button(content, "Buttons/buttonTired", new Vector2(125, 277)); btn1 = 1; hero2.printFont = 1; }
                else if (btn1 == 1) { playButton = new Button(content, "Buttons/buttonBored", new Vector2(125, 277)); btn1 = 0; hero2.printFont = 0; }
                //hero1.player = content.Load<Texture2D>("HeroSprites/evaAtk");
                //hero1.idleAnimation = new Animation(hero3.player, 0.1f, false, 2);
                hero2.superAct();
            } 
            if (play2Button.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                if (btn2 == 0) { play2Button = new Button(content, "Buttons/buttonTired", new Vector2(46, 339)); btn2 = 1; hero1.printFont = 1; }
                else if (btn2 == 1) { play2Button = new Button(content, "Buttons/buttonBored", new Vector2(46, 339)); btn2 = 0; hero1.printFont = 0; }
                //hero2.player = content.Load<Texture2D>("HeroSprites/sayoAtk");
                //hero2.idleAnimation = new Animation(hero3.player, 0.1f, false, 3);
                hero1.superAct();
            }

            if (btnClickUpgrade.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                if (exp >= hero4.playerDamage) { exp -= hero4.playerDamage; hero4.playerDamage++; }
            }
            if (btnSetUpgrade.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                if (exp >= hero.actualplayerDamage1) { exp -= hero.actualplayerDamage1; hero.actualplayerDamage1++; }
            }
            if (btnSayoUpgrade.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                if (exp >= hero1.sayoDamage) { exp -= hero1.sayoDamage; hero1.sayoDamage++; }
            }
            if (btnEvaUpgrade.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                if (exp >= hero2.evaDamage) { exp -= hero2.evaDamage; hero2.evaDamage++; }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg1, new Vector2(0,0), null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);


            hero3.Draw(gameTime, spriteBatch);
            hero2.Draw(gameTime, spriteBatch);

            playButton.Draw(gameTime, spriteBatch);
            hero1.Draw(gameTime, spriteBatch);

            play2Button.Draw(gameTime, spriteBatch);
            
            hero.Draw(gameTime, spriteBatch);

            spriteBatch.Draw(bg2, new Vector2(0,0), null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);

            btnClickUpgrade.Draw(gameTime, spriteBatch);
            btnSetUpgrade.Draw(gameTime, spriteBatch);
            btnSayoUpgrade.Draw(gameTime, spriteBatch);
            btnEvaUpgrade.Draw(gameTime, spriteBatch);
            hero4.Draw(gameTime, spriteBatch); //atkEffect Sprite

            


            if (minHP <= 0) 
            {
                maxHP++; minHP = maxHP;
                if (randomEnemy == 0)
                {
                    hero3.player = content.Load<Texture2D>("Enemies/enemy1Died");
                    hero3.idleAnimation = new Animation(hero3.player, 0.1f, false, 5);
                }
                //hero3.positionX = (Level.windowWidth / 2) - ((hero3.player.Width / 5) / 2) - 25;
               // hero3.positionY = (Level.windowHeight / 2) - (hero3.player.Height / 2) - 5;
            }

            spriteBatch.DrawString(enemyHP, minHP + "/" + maxHP, new Vector2(350, 270), Color.White);
            spriteBatch.DrawString(enemyHP, "Experience: " + exp, new Vector2(0, 0), Color.White);//Experience
            

            
            //fontY1-=3;
            //spriteBatch.DrawString(clickD, "-" + hero.playerDamage + " HP", new Vector2(250, fontY1), Color.Red);

            
        }

    }
}
