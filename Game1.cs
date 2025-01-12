using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Colour = Microsoft.Xna.Framework.Color;

namespace monotest;

public class Game1 : Game
{
	public GraphicsDeviceManager graphics;
	public SpriteBatch spriteBatch;
	RenderTarget2D renderTarget;
	RenderTarget2D renderTarget2;
	SpriteFont font1;
	Texture2D spritesheet;
	Vector2 fontpos;
	Vector2 pos;
	protected int screenH = 600;
	protected int screenW = 600;
	

	public Game1()
	{
		graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content";
		IsMouseVisible = false;
		}

	protected override void Initialize()
	{
		graphics.PreferredBackBufferHeight = screenH;
		graphics.PreferredBackBufferWidth = screenW;
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

		renderTarget = new RenderTarget2D(GraphicsDevice, screenH, screenW);
		renderTarget2 = new RenderTarget2D(GraphicsDevice, screenH, screenW);
		
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        //GraphicsDevice.Clear(Colour.Black);//bg colour

		int[] origin = [48, 70];
		int[] size = [80,7];
		BoxMaker(spritesheet, renderTarget, origin, size);
		int[] test1 = [20,10];
		int[] test2 = [10,10];
		BoxMaker(spritesheet, renderTarget2, test1, test2);
		spriteBatch.Begin(samplerState: SamplerState.PointClamp);
		spriteBatch.Draw(renderTarget, Vector2.Zero, Colour.White); //AAAAAAAAAAAAAAAAAAAAAAAAA I CANT GET BOTH BOXES TO DISPLAY AT THE SAME TIME AAAAAAAAAAAAA
		
		
		
		spriteBatch.DrawString(font1, "aaaaaaa", new Vector2(100,100), Colour.White);
		
		
		
		spriteBatch.Draw(renderTarget2, Vector2.Zero, Colour.White);
		spriteBatch.End();
		
		
		base.Draw(gameTime);



    }
	RenderTarget2D BoxMaker(Texture2D Spritesheet, RenderTarget2D renderTarget, int[] Boxpos, int[] Boxsize) //make box :3
	{
		int[,] offsets = {{29,0},//Top right corner (onyl use 1st pos if 2nd is 0)
		{20,10},//Right Wall Y,X
		{29,10},//Bottom right corner Y,X
		{30,10},//Bottom Wall X,Y
		{10,19},//Left bottom corner Y,X
		{0,30},//Left wall X,Y
		{19,0}};//Top Left Corner X,Y
		
		RenderTarget2D boxrenderer;
		spritesheet = Spritesheet; //move everthing to local variables/classes
		boxrenderer = renderTarget;

		int BoxposW = Boxpos[0];
		int BoxposH = Boxpos[1]; // positioning
		Vector2 position = new Vector2(BoxposW, BoxposH);
		
		int BoxsizeW = Boxsize[0];
		int BoxsizeH = Boxsize[1]; //size
		Vector2 size = new Vector2(BoxsizeW, BoxsizeH);
		
		Vector2 scalesize = new Vector2(2,2); //box scale

		Rectangle BoxWallh = new Rectangle(1, 6, 15, 5); //all of these will need to changed if im resusing this for another project
		Rectangle BoxWallv = new Rectangle(6, 17, 5, 15);
		Rectangle BoxCornerR = new Rectangle(17, 6, 10, 10);
		Rectangle BoxCornerL = new Rectangle(22, 17, 10, 10);
		GraphicsDevice.SetRenderTarget(boxrenderer);
		//GraphicsDevice.Clear(Colour.Black);
		//TODO put box rendering code here

		spriteBatch.Begin(samplerState: SamplerState.PointClamp); //keep pixels uniform

		for (int i = 0; i < size.X; i++)
		{
			spriteBatch.Draw(spritesheet, position, BoxWallh, Colour.White, 0, Vector2.Zero, scalesize, SpriteEffects.None, 0);
			position.X++;
		}
		
		position.X = position.X + offsets[0,0];//offset 1 (move TR corner)
		spriteBatch.Draw(spritesheet, position, BoxCornerR, Colour.White, 0, Vector2.Zero, scalesize , SpriteEffects.None, 0);


		position.Y = position.Y + offsets[1,0];//offset 2 (move R wall)
		position.X = position.X + offsets[1,1];//offset 3
		for (int i = 0; i < size.Y; i++)
		{
			spriteBatch.Draw(spritesheet, position, BoxWallv, Colour.White, 0, Vector2.Zero, scalesize, SpriteEffects.None, 0);
			position.Y++;
		}

		position.Y = position.Y + offsets[2,0];//offset 4 (move BR corner)
		position.X = position.X - offsets[2,1];//offset 5
		spriteBatch.Draw(spritesheet, position, BoxCornerR, Colour.White, 0, Vector2.Zero, scalesize , SpriteEffects.FlipVertically, 0);

		position.X = position.X - offsets[3,0];
		position.Y = position.Y + offsets[3,1];
		for(int i = 0; i < size.X; i++)
		{
			spriteBatch.Draw(spritesheet, position,BoxWallh, Colour.White, 0 ,Vector2.Zero, scalesize, SpriteEffects.FlipVertically, 0);
			position.X--;
		}
		
		position.Y = position.Y - offsets[4,0];//offset 4 (move BL corner)
		position.X = position.X - offsets[4,1];//offset 5
		spriteBatch.Draw(spritesheet, position, BoxCornerL, Colour.White, 0, Vector2.Zero, scalesize, SpriteEffects.None, 0);

		position.X = position.X + offsets[5,0];
		position.Y = position.Y - offsets[5,1];
		for(int i = 0; i < size.Y; i++)
		{
			spriteBatch.Draw(spritesheet, position, BoxWallv, Colour.White, 0 ,Vector2.Zero, scalesize, SpriteEffects.FlipHorizontally, 0);
			position.Y--;
		}

		position.Y = position.Y - offsets[6,0];//offset 8 (move TL corner)
		position.X = position.X - offsets[6,1];//offset 9
		spriteBatch.Draw(spritesheet, position, BoxCornerL, Colour.White, 0, Vector2.Zero, scalesize, SpriteEffects.FlipVertically, 0);
		
		
		spriteBatch.End();
		GraphicsDevice.SetRenderTarget(null);
		renderTarget = boxrenderer;
		return renderTarget;
	}

}


