using Godot;
using System;

public partial class GameManager : Node2D
{
	[Export]
	public Hand PlayerHand;
	
	[Export]
	public Hand[] Opponents { get; set; } = new Hand[3];

	public Pot Pot;

	public override void _Ready()
	{
		Pot = GetNode<Pot>("Pot");
		
		GetViewport().SizeChanged += PositionGameElements;
		
		SetupGame();
	}

	private void PositionGameElements()
	{
		var viewport = GetViewportRect();
		
		PlayerHand.GlobalPosition = new Vector2(viewport.Size.X / 2, viewport.Size.Y - (viewport.Size.Y * 0.10f));
		
		Pot.GlobalPosition = new Vector2(viewport.Size.X / 2, viewport.Size.Y / 2);
	}

	private void SetupGame()
	{
		var deck = GD.Load<PackedScene>("res://src/Nodes/Deck.tscn").Instantiate<Deck>();
		deck.Visible = false;
		deck.CloverJacks();
		AddChild(deck);
		
		PlayerHand.AddCards(deck.Take(deck.Cards.Count / 4));
	}

	public override void _Input(InputEvent @event)
	{
	}
}
