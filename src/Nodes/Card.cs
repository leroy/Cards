using Godot;
using System;
using Godot.Collections;

public partial class Card : Node2D
{
	public enum CardType
	{
		Spades,
		Hearts,
		Diamonds,
		Clubs
	}

	public enum CardNumber
	{
		Ace,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King
	}
	
	private Dictionary<CardType, string> _cardTypeDict = new()
	{
		{
			CardType.Spades, "spades"
		},
		
		{
			CardType.Hearts, "hearts"
		},
		
		{
			CardType.Diamonds, "diamonds"
		},
		
		{
			CardType.Clubs, "clubs"
		}
	};

	private Dictionary<CardNumber, string> _cardNumberDict = new()
	{
		{
			CardNumber.Ace, "A"
		},
		
		{
			CardNumber.Two, "2"
		},
		
		{
			CardNumber.Three, "3"
		},
		
		{
			CardNumber.Four, "4"
		},
		
		{
			CardNumber.Five, "5"
		},
		
		{
			CardNumber.Six, "6"
		},
		
		{
			CardNumber.Seven, "7"
		},
		
		{
			CardNumber.Eight, "8"
		},
		
		{
			CardNumber.Nine, "9"
		},
		
		{
			CardNumber.Ten, "10"
		},
		
		{
			CardNumber.Jack, "J"
		},
		
		{
			CardNumber.Queen, "Q"
		},
		
		{
			CardNumber.King, "K"
		}
	};
	
	[Signal]
	public delegate void HoverEventHandler();
	
	[Signal]
	public delegate void BlurEventHandler();
	
	[Signal]
	public delegate void ClickEventHandler();

	[Export]
	public CardType Type { get; set; }
	
	[Export]
	public CardNumber Number { get; set; }
	
	private Sprite2D _sprite;
	
	private Area2D _area2D;

	private bool _hovered;

	[Export]
	public bool Hidden
	{
		get
		{
			return GetNode<Sprite2D>("CardBack").Visible;
		}
		set
		{
			GetNode<Sprite2D>("CardBack").Visible = value;
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_area2D = GetNode<Area2D>("Area2D");
		_area2D.MouseEntered += OnMouseEntered;
		_area2D.MouseExited += OnMouseExited;
		_area2D.InputEvent += (viewport, @event, shapeIdx) =>
		{
			if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
			{
				GD.Print("click");
				GetViewport().SetInputAsHandled();
				EmitSignal(nameof(Click));
			}
		};


		_sprite = GetNode<Sprite2D>("Sprite2D");
		_sprite.Texture = GD.Load<Texture2D>(SpritePath());
	}

	private void OnMouseExited()
	{
		GetViewport().SetInputAsHandled();

		GD.Print("blur");
		_hovered = false;
		
		EmitSignal(nameof(Blur));
	}

	private void OnMouseEntered()
	{
		GetViewport().SetInputAsHandled();

		GD.Print("hover!");
		_hovered = true;
		
		EmitSignal(nameof(Hover));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private string SpritePath()
	{
		var type = _cardTypeDict[Type];
		var number = _cardNumberDict[Number];

		var isNumeric = int.TryParse("123", out _);

		if (isNumeric)
		{
			number = number.PadZeros(2);
		}
		
		
		return $"res://assets/cards/card_{type}_{number}.png";
	}
	
	public int Width => _sprite.Texture.GetWidth();
	
	public int Height => _sprite.Texture.GetHeight();
}
