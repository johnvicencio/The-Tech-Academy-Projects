using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private List<Card> _bounty;

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player() { Name = player1Name };
            _player2 = new Player() { Name = player2Name };
            _bounty = new List<Card>();
        }

        public string Play()
        {
            Deck deck = new Deck();
            string result = deck.Deal(_player1, _player2);

            result += "<h3>Begin battle ...</h3>";
            int round = 0;
            while (_player1.Cards.Count != 0 && _player2.Cards.Count != 0)
            {
                Battle battle = new Battle();
                result += battle.PerformBattle(_player1, _player2);

                round++;
                if (round > 20)
                    break;
            }
            // Determine the winner
            result += determineWinner();
            return result;

        }

        //private Card getCard(Player player)
        //{
        //    Card card = player.Cards.ElementAt(0);
        //    player.Cards.Remove(card);
        //    _bounty.Add(card);
        //    return card;
        //}

        //private void performEvaluation(Player player1, Player player2, Card card1, Card card2)
        //{
        //    if (card1.CardValue() > card2.CardValue())
        //        player1.Cards.AddRange(_bounty);
        //    else
        //        player2.Cards.AddRange(_bounty);
        //    _bounty.Clear();
        //}


        private string determineWinner()
        {
            string result = "";
            if (_player1.Cards.Count > _player2.Cards.Count)
                result += "<br/>Player 1 wins";
            else
                result += "<br/>Player 2 wins";

            result += "<br/>Player 1:" + _player1.Cards.Count + " Player2:" + _player2.Cards.Count;
            return result;
        }


    }
}