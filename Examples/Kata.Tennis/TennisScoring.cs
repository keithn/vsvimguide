using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Xunit;

namespace Kata.Tennis
{
    public class TennisScoring
    {
        private readonly TennisGame _tennisGame;

        public TennisScoring()
        {
            _tennisGame = new TennisGame();
        }

        [Theory]
        [InlineData(0, 0, "Love All")]
        [InlineData(1, 0, "Fifteen Love")]
        [InlineData(1, 1, "Fifteen All")]
        [InlineData(2, 1, "Thirty Fifteen")]
        [InlineData(2, 2, "Thirty All")]
        [InlineData(3, 2, "Forty Thirty")]
        [InlineData(3, 3, "Deuce")]
        [InlineData(4, 3, "Advantage Player One")]
        [InlineData(5, 3, "Player One Wins")]
        [InlineData(3, 5, "Player Two Wins")]
        [InlineData(4, 4, "Deuce")]
        [InlineData(4, 5, "Advantage Player Two")]
        [InlineData(4, 6, "Player Two Wins")]
        public void Score(int first, int second, string score)
        {
            Enumerable.Range(0, first).ToList().ForEach(n => _tennisGame.Scores(TennisPlayer.One));
            Enumerable.Range(0, second).ToList().ForEach(n => _tennisGame.Scores(TennisPlayer.Two));
            Assert.Equal(score, _tennisGame.Score);
        }
    }

    public class TennisGame
    {
        private (TennisScore one, TennisScore two) _scores = (TennisScore.Love, TennisScore.Love);

        public void Scores(TennisPlayer player) => _scores =
            player == TennisPlayer.One ? IncrementScore(_scores) : Flip(IncrementScore(Flip(_scores)));

        private (TennisScore, TennisScore) Flip((TennisScore one, TennisScore two) scores) => (scores.two, scores.one);

        private (TennisScore, TennisScore) IncrementScore( (TennisScore currentPlayer, TennisScore otherPlayer ) scores)
        {
            if (scores.otherPlayer == TennisScore.Advantage && scores.currentPlayer == TennisScore.Forty) scores.otherPlayer--;
            else scores.currentPlayer++;
            return scores;
        }

        public string Score
        {
            get
            {
                var scores = _scores;
                if (scores.two == TennisScore.Wins) return $"Player Two Wins";
                if (scores.one == TennisScore.Wins) return $"Player One Wins";
                if (scores.two == TennisScore.Advantage) return $"Advantage Player Two";
                if (scores.one == TennisScore.Advantage) return $"Advantage Player One";
                if (scores.one == scores.two && scores.one == TennisScore.Forty) return "Deuce";
                if (scores.one == scores.two) return $"{scores.one} All";
                return $"{scores.one} {scores.two}";
            }
        }
    }

    public enum TennisPlayer
    {
        One,
        Two
    }

    public enum TennisScore
    {
        Love,
        Fifteen,
        Thirty,
        Forty,
        Advantage,
        Wins
    }
}