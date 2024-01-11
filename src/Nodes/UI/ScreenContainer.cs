using Godot;
using System;

public partial class ScreenContainer : Control
{
	[Export] public SubViewport Viewport;

	[Export] public float Scale = 1.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Resize();
	}

	private void Resize()
	{
		var viewport = GetViewportRect();
		
		Viewport.Size2DOverride = new Vector2I((int) (viewport.Size.X / Scale), (int) (viewport.Size.Y / Scale));
		Viewport.Size2DOverrideStretch = true;
		
		Viewport.HandleInputLocally = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
