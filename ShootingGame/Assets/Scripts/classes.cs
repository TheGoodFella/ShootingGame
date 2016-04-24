using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;

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
        public string Name { get; set; }
        /// <summary>
        /// the final score
        /// </summary>
        public int score;
        public int Score
        {
            get { return score; }
            set { score = value; TargetRemained--; }
        }
        /// <summary>
        /// when was the score achieved?
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// time spent in the run
        /// </summary>
        public int TimeSpent { get; set; }

        /// <summary>
        /// how many target is remained?
        /// </summary>
        public int TargetRemained { get; set; }
        #endregion

        public Player() { }

        public Player(string name, int score, DateTime date, int timeSpent, int targetRemained)
        {
            Name = name;
            Score = score;
            Date = date;
            TimeSpent = timeSpent;
            TargetRemained = targetRemained;
        }

        public void AddScore(int scoreToAdd)
        {
            Score += scoreToAdd;
        }

        public bool SaveXml(string path)
        {

            StreamWriter sw = new StreamWriter(path);
            XmlSerializer xml = new XmlSerializer(typeof(Player));

            xml.Serialize(sw, this);
            sw.Close();

            return true;
        }
    }

    public class Players
    {
        public List<Player> plrs = new List<Player>();

        public bool AddPlayer(string name, int score, DateTime date, int timeSpent, int targetRemained)
        {
            plrs.Add(new Player(name, score, date, timeSpent, targetRemained));
            return true;
        }

        public void SaveXml(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            XmlSerializer xs = new XmlSerializer(typeof(List<Player>));
            xs.Serialize(sw, plrs);
            sw.Close();
        }

        public List<Player> XmlParser(string path)
        {
            List<Player> p = new List<Player>();
            StreamReader sr = new StreamReader(path);
            XmlSerializer xml = new XmlSerializer(typeof(List<Player>));

            p = (List<Player>)xml.Deserialize(sr);

            sr.Close();

            return p;

        }
    }
}
