using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using SDL2;

namespace AndroidGame1;

public class Game1 : Game
{
	public Game1()
	{
		GraphicsDeviceManager gdm = new GraphicsDeviceManager(this);

		// Typically you would load a config here...
		gdm.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
		gdm.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
		gdm.IsFullScreen = true;
		gdm.SynchronizeWithVerticalRetrace = true;

		IsMouseVisible = true;

		// All content loaded will be in a "Content" folder
		Content.RootDirectory = "Content";
	}

	protected override void Initialize()
	{
		/* This is a nice place to start up the engine, after
		 * loading configuration stuff in the constructor
		 */
		base.Initialize();

		Window.PointerDown += (o, e) =>
		{
			System.Console.WriteLine($"PointerDown - PointerId: {e.PointerId}, Position: {e.Position}, Button: {e.Button}");
		};
		Window.PointerMove += (o, e) =>
		{
			System.Console.WriteLine($"PointerMove - PointerId: {e.PointerId}, Position: {e.Position}, Delta: {e.Delta}");
		};
		Window.PointerUp += (o, e) =>
		{
			System.Console.WriteLine($"PointerUp - PointerId: {e.PointerId}, Position: {e.Position}");
		};
	}

	protected override void LoadContent()
	{
		base.LoadContent();
	}

	protected override void UnloadContent()
	{
		// Clean up after yourself!
		base.UnloadContent();
	}

	protected override void Update(GameTime gameTime)
	{
		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.CornflowerBlue);

		base.Draw(gameTime);
	}
}
