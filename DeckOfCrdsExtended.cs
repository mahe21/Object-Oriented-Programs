using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objectorientedprograms
{
    class DeckOfCards
    {
        static void Main(string[] args)
        {
            // Initialize the deck of cards
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            string[] deck = new string[52];
            int i = 0;
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck[i] = rank + " of " + suit;
                    i++;
                }
            }

            // Shuffle the deck using the Fisher-Yates algorithm
            Random random = new Random();
            for (int j = deck.Length - 1; j > 0; j--)
            {
                int k = random.Next(j + 1);
                string temp = deck[j];
                deck[j] = deck[k];
                deck[k] = temp;
            }

            // Create the players and distribute the cards among them
            Player[] players = new Player[4];
            for (int p = 0; p < 4; p++)
            {
                players[p] = new Player();
                for (int c = 0; c < 9; c++)
                {
                    players[p].Deck.Enqueue(deck[p * 9 + c]);
                }
                players[p].SortByRank();
            }

            // Print the players and the cards received by each player
            Console.WriteLine("Players:");
            Queue<Player> playerQueue = new Queue<Player>(players);
            while (playerQueue.Count > 0)
            {
                Player player = playerQueue.Dequeue();
                Console.WriteLine(player);
                Console.WriteLine("Cards:");
                while (player.Deck.Count > 0)
                {
                    Console.WriteLine(player.Deck.Dequeue());
                }
                Console.WriteLine();
            }
        }
    }

    class Player
    {
        public Queue<string> Deck { get; private set; }

        public Player()
        {
            Deck = new Queue<string>();
        }

        public void SortByRank()
        {
            Queue<string> sortedDeck = new Queue<string>();
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            foreach (string rank in ranks)
            {
                foreach (string card in Deck)
                {
                    if (card.StartsWith(rank))
                    {
                        sortedDeck.Enqueue(card);
                    }
                }
            }
            Deck = sortedDeck;
        }

        public override string ToString()
        {
            return "Player: " + GetHashCode();
        }
    }
}
