using Godot;
using System;
using System.Collections.Generic;

public partial class Pot : Node2D
{
	private List<Card> _cards = new();
	
	public void Play(Card card)
	{
		_cards.Add(card);
		AddChild(card);
	}

	public void Clear()
	{
		
	}
	
}
