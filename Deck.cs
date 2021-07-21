using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main(string[] args)
	{
		Deck d = new Deck();

		for (int i = 0; i < 52; i++) {
			Console.WriteLine(d.deal_one_card().toString());
		}
	}
}

class Deck
{
    private List<Card> cards = new List<Card>();
    private string[] Suits = {"Spades", "Hearts", "Clubs", "Diamonds"};
    private string[] Ranks = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven",
     "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

    public Deck() {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 13; j++) {
                cards.Add(new Card(Suits[i], Ranks[j]));
            }
        }

        shuffle();
    }

    public void shuffle() {
        List<Card> newDeck = new List<Card>();
        var rand = new Random();

        for (int i = 0; i < 52; i++) {
            int next = rand.Next(cards.Count);
            newDeck.Add(cards[next]);
            cards.RemoveAt(next);
        }

        cards = newDeck;
    }

    public Card deal_one_card() {
        if (cards.Count > 0) {
            Card copy = cards[0];
            cards.RemoveAt(0);
            return copy;
        }
        else {
            return null;
        }
    }
}

class Card
{
    private string Suit { get; set;}
    private string Rank { get; set;}

    public Card(string s, string r) {
        Suit = s;
        Rank = r;
    }

    public string toString() {
        return Rank + " of " + Suit;
    }
}
