using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Hand : Node2D
{
	public List<Card> Cards { get; set; } = new List<Card>();

	private float cardMargin = 0f;
	
	public override void _Ready()
	{
	}
	
	private void UpdateHand()
	{
		var cards = GetNode<Node2D>("Cards");
		
		foreach (var card in cards.GetChildren())
		{
			card.QueueFree();
		}
		
		for (int i = 0; i < Cards.Count; i++)
		{
			var card = Cards[i];

			cards.AddChild(card);
			card.Position = new Vector2(Cards.Count / 2 * -card.Width + (i * card.Width + cardMargin), 0);
		}
	}

	public void AddCards(List<Card> cards)
	{
		Cards = Cards.Concat(cards).ToList();
		
		UpdateHand();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
