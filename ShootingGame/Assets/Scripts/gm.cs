using System;

public class gm {

    static public Ranking.Player player = new Ranking.Player("debugPlayer", 0, DateTime.Now, 0);

    static public void AddScore(int scoreToAdd)
    {
        player.Score += scoreToAdd;
    }
}
