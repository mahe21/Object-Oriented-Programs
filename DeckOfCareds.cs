/*namespace Objectorientedprograms
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

            // Distribute the cards among 4 players
            string[,] players = new string[4, 9];
            for (int p = 0; p < 4; p++)
            {
                for (int c = 0; c < 9; c++)
                {
                    players[p, c] = deck[p * 9 + c];
                }
            }

            // Print the cards received by each player using a 2D array
            for (int p = 0; p < 4; p++)
            {
                Console.WriteLine("Player " + (p + 1) + " received:");
                for (int c = 0; c < 9; c++)
                {
                    Console.Write(players[p, c] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}*/