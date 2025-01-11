using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Colour = Microsoft.Xna.Framework.Color;

namespace monotest;

public class Game1 : Game
{
	private GraphicsDeviceManager graphics;

	private SpriteBatch spriteBatch;
	SpriteFont font1;
	Texture2D spritesheet;
	Vector2 fontpos;
	Vector2 pos;


	public Game1()
	{
		graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content";
		IsMouseVisible = false;
	}

	protected override void Initialize()
	{
		graphics.PreferredBackBufferHeight = 600;
		graphics.PreferredBackBufferWidth = 600;
		graphics.ApplyChanges();
		base.Initialize();
	}

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

		font1 = Content.Load<SpriteFont>("font");//font loading
		Viewport viewport = graphics.GraphicsDevice.Viewport;
		fontpos = new Vector2(40, 10);

		spritesheet = Content.Load<Texture2D>("spritesheet");//spritesheet load
		pos = new Vector2(10, 100);

    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Colour.Black);//bg colour

		spriteBatch.Begin();//get screen resolution and print it
		
		Box.BoxMaker(, , graphics)
		
		
		
		
		
		
		spriteBatch.End();
		base.Draw(gameTime);



    }

	

}
