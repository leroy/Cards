using Godot;
using System;
using System.Collections.Generic;
using Cards.Extensions;

public partial class Deck : Node2D
{
	public List<Card> Cards { get; set; } = new List<Card>();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void UpdateDeck()
	{
		var sprites = GetNode<Node2D>("Sprites");
		
		foreach (var child in sprites.GetChildren())
		{
			child.QueueFree();
		}
		
		for (int i = 0; i < Cards.Count / 4; i++)
		{
			var sprite = new Sprite2D();
			
			sprite.Texture = GD.Load<Texture2D>("res://assets/cards/card_back.png");
			sprite.Position = new Vector2(0, i * 2);
			sprite.TextureFilter = TextureFilterEnum.Nearest;
			
			sprites.AddChild(sprite);
		}
	}

	public Deck AddCard(Card.CardType type, Card.CardNumber number)
	{
		var card = GD.Load<PackedScene>("res://src/Nodes/Card.tscn").Instantiate<Card>();

		card.Type = type;
		card.Number = number;

		Cards.Add(card);

		return this;
	}
	
	public void CloverJacks()
	{
		AddCard(Card.CardType.Clubs, Card.CardNumber.Ace);
		AddCard(Card.CardType.Clubs, Card.CardNumber.Jack);
		AddCard(Card.CardType.Clubs, Card.CardNumber.Queen);
		AddCard(Card.CardType.Clubs, Card.CardNumber.King);
		AddCard(Card.CardType.Clubs, Card.CardNumber.Seven);
		AddCard(Card.CardType.Clubs, Card.CardNumber.Eight);
		AddCard(Card.CardType.Clubs, Card.CardNumber.Nine);
		AddCard(Card.CardType.Clubs, Card.CardNumber.Ten);
		
		AddCard(Card.CardType.Diamonds, Card.CardNumber.Ace);
		AddCard(Card.CardType.Diamonds, Card.CardNumber.Jack);
		AddCard(Card.CardType.Diamonds, Card.CardNumber.Queen);
		AddCard(Card.CardType.Diamonds, Card.CardNumber.King);
		AddCard(Card.CardType.Diamonds, Card.CardNumber.Seven);
		AddCard(Card.CardType.Diamonds, Card.CardNumber.Eight);
		AddCard(Card.CardType.Diamonds, Card.CardNumber.Nine);
		AddCard(Card.CardType.Diamonds, Card.CardNumber.Ten);
		
		AddCard(Card.CardType.Hearts, Card.CardNumber.Ace);
		AddCard(Card.CardType.Hearts, Card.CardNumber.Jack);
		AddCard(Card.CardType.Hearts, Card.CardNumber.Queen);
		AddCard(Card.CardType.Hearts, Card.CardNumber.King);
		AddCard(Card.CardType.Hearts, Card.CardNumber.Seven);
		AddCard(Card.CardType.Hearts, Card.CardNumber.Eight);
		AddCard(Card.CardType.Hearts, Card.CardNumber.Nine);
		AddCard(Card.CardType.Hearts, Card.CardNumber.Ten);
		
		AddCard(Card.CardType.Spades, Card.CardNumber.Ace);
		AddCard(Card.CardType.Spades, Card.CardNumber.Jack);
		AddCard(Card.CardType.Spades, Card.CardNumber.Queen);
		AddCard(Card.CardType.Spades, Card.CardNumber.King);
		AddCard(Card.CardType.Spades, Card.CardNumber.Seven);
		AddCard(Card.CardType.Spades, Card.CardNumber.Eight);
		AddCard(Card.CardType.Spades, Card.CardNumber.Nine);
		AddCard(Card.CardType.Spades, Card.CardNumber.Ten);

		Cards.Shuffle();
		
		UpdateDeck();
	}

	public List<Card> Take(int number = 1)
	{
		var cards = Cards.GetRange(0, number);
		Cards.RemoveRange(0, number);

		UpdateDeck();
		
		return cards;
	}
}
