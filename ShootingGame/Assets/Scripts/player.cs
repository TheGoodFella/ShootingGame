using System;
using System.IO;
using UnityEngine;

public class player : MonoBehaviour
{
    Ranking.Players ps;
    static public Ranking.Player p = new Ranking.Player("debugPlayer", 0, DateTime.Now, 0);

    /// <summary>
    /// name of the save game xml file (Save Game Path)
    /// </summary>
    public string sgp;

    /// <summary>
    /// complete path of the save game xml file (Complete Save Game Path)
    /// </summary>
    private string csgp;

    // Use this for initialization
    void Start()
    {
        csgp = Application.dataPath + @"\" + sgp;
        ps = new Ranking.Players();

       

        if (!File.Exists(csgp))
        {
            Directory.CreateDirectory(Application.dataPath+@"\savegame");
            Debug.Log("csgp: " + csgp);
            ps.SaveXml(csgp);
        }

        Debug.Log("parsing...");
        
        //I create the list of the player obj:
        
        //I assign at the players list (plrs) the properties contained in the xml file
        ps.plrs=ps.XmlParser(@"D:\pl.xml");
        Debug.Log("parsed...");
        Debug.Log("players name:");

        //I print the player name
        for (int i = 0; i < ps.plrs.Count; i++)
            Debug.Log(ps.plrs[i].Name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    static public void AddScore(int scoreToAdd)
    {
        p.Score += scoreToAdd;
    }
}
