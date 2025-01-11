using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Colour = Microsoft.Xna.Framework.Color;

namespace monotest;



public class Box ()
{
	RenderTarget2D Boxrender;
	
	public static string BoxMaker(int[,] Boxpos, int[,] Boxsize, GraphicsDeviceManager graphics) //make box :3
	{
		int BoxposW = Boxpos[0,0];
		int BoxposH = Boxpos[0,1];
		int BoxsizeW = Boxsize[0,0];
		int BoxsizeH = Boxsize[0,1];
		Boxrender = new RenderTarget2D(GraphicsDevice, BoxsizeW, BoxsizeH);


		

		
		
		int w = GraphicsDevice.Viewport.Width;
		int h = GraphicsDevice.Viewport.Height;

		string output = $"{w},{h}"; //apparently i dont need to convert int to string to display ints,, huh

		Vector2 FontOrigin = font1.MeasureString(output) / 2;
		spriteBatch.DrawString(font1, output, fontpos, Colour.White, 0 , FontOrigin, 1, SpriteEffects.None, 0);
		spriteBatch.End();

		spriteBatch.Begin();//print spritesheet for debug
		spriteBatch.Draw(spritesheet, pos, Colour.White);
		spriteBatch.End();

		
		spriteBatch.Begin(samplerState: SamplerState.PointClamp);//oh god time to draw a box
		Rectangle BoxWallh = new Rectangle(5, 6, 8, 6);		 // need to make box making thingy and it'll work because
		Rectangle BoxWallv = new Rectangle(6, 21, 6, 8);	 // all the offsets are the same???????
		Rectangle BoxCorner = new Rectangle(20, 4, 30, 14);


		
		int aaaw = 220;
		int aaah = 250;
		Vector2 segx = new Vector2(aaaw, aaah);
		Vector2 scalesize = new Vector2 (3,3);
		for (int i = 0; i < 7; i++)
		{
			spriteBatch.Draw(spritesheet, segx, BoxWallh, Colour.White, 0, Vector2.Zero, scalesize, SpriteEffects.None, 0);
			segx.X++;
		}
		segx.X = segx.X + 12;//offset 1 (move TR corner)
		spriteBatch.Draw(spritesheet, segx, BoxCorner, Colour.White, 0, Vector2.Zero, scalesize , SpriteEffects.None, 0);
		
		
		segx.Y = segx.Y + 26;//offset 2 (move R wall)
		segx.X = segx.X + 12;//offset 3
		for (int i = 0; i < 131; i++)
		{
			spriteBatch.Draw(spritesheet, segx, BoxWallv, Colour.White, 0, Vector2.Zero, scalesize, SpriteEffects.None, 0);
			segx.Y++;
		}
		segx.Y = segx.Y + 4;//offset 4 (move BR corner)
		segx.X = segx.X - 12;//offset 5
		spriteBatch.Draw(spritesheet, segx, BoxCorner, Colour.White, 0, Vector2.Zero, scalesize , SpriteEffects.FlipVertically, 0);
	}





}
