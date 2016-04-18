using System;
using System.Collections.Generic;

/*
 * TODO: SAVE THE SCORES TO AN XML FILE
 * */

namespace Ranking
{
    public class Player
    {
        #region properties
        /// <summary>
        /// name of the player, or nickname
        /// </summary>
        public string Name { get;  set; }
        /// <summary>
        /// the final score
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// when was the score achieved?
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// time spent in the run
        /// </summary>
        public int TimeSpent { get; set; }
        #endregion

        public Player() { }

        public Player(string name,int score, DateTime date, int timeSpent)
        {
            Name = name;
            Score = score;
            Date = date;
            TimeSpent = timeSpent;
        }
    }

    public class Players : List<Player>
    {
        public bool AddPlayer(string name, int score, DateTime date, int timeSpent)
        {
            Add(new Player(name, score, date, timeSpent));
            return true;
        }
    }
}
