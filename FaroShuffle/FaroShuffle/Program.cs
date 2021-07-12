using System;
using System.Collections.Generic;
using System.Linq;

namespace FaroShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ query to generate deck of cards
            var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                               from r in Ranks().LogQuery("Rank Generation")
                               select new { Suit = s, Rank = r }).LogQuery("Starting Deck")
                               .ToArray();

            //// method syntax for same:
            //var startingDeck2 = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));

            // Display each card
            foreach (var card in startingDeck)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();

            //// Same for Deck2
            //Console.WriteLine("\nAnd now deck 2:");
            //foreach (var card in startingDeck2)
            //{
            //    Console.WriteLine(card);
            //}
            
            //// split deck
            //var top = startingDeck.Take(26);
            //var bottom = startingDeck.Skip(26);
            //// shuffle deck call
            //var shuffle = top.InterleaveSequenceWith(bottom); // calling our extension method on IEnumeratable

            //foreach (var c in shuffle)
            //{
            //    Console.WriteLine(c);
            //}

            var times = 0;
            // set shuffle var to starting deck
            var shuffle = startingDeck;

            // shuffle repeatedly, checking for original deck pattern
            do
            {
                // In shuffle
                shuffle = shuffle.Skip(26).LogQuery("Bottom Half")
                            .InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
                            .LogQuery("Shuffle").ToArray();
               
                // Out shuffle
                //shuffle = shuffle.Take(26).LogQuery("Top Half")
                //        .InterleaveSequenceWith(shuffle.Skip(26).LogQuery("Bottom Half"))
                //        .LogQuery("Shuffle").ToArray();

                foreach (var card in shuffle)
                {
                    Console.WriteLine(card);
                }

                times++;
                Console.WriteLine(times);
                Console.WriteLine();

            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }

        /// <summary>
        /// sequence to represent suits
        /// </summary>
        /// <returns>A sequence of the below strings????</returns>
        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        /// <summary>
        /// sequence to represent ranks of cards
        /// </summary>
        /// <returns></returns>
        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
    }
}
