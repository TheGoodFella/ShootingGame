using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Ranking.Players ps;
    static public Ranking.Player p = new Ranking.Player("debugPlayer", 0, DateTime.Now, 0);

    /// <summary>
    /// temp player, after game over, will added to players.plrs
    /// </summary>
    Ranking.Player ptemp;

    /// <summary>
    /// textbox for the name of the player, show at start, hide after insert
    /// </summary>
    public GameObject canvasInput;

    /// <summary>
    /// name of the save game xml file (Save Game Path)
    /// </summary>
    public string sgp;

    /// <summary>
    /// complete path of the save game xml file (Complete Save Game Path)
    /// </summary>
    private string csgp;

    /// <summary>
    /// how many targer in the area to destroy?
    /// </summary>
    public int targetCount;
    /// <summary>
    /// current target remained
    /// </summary>
    static private int currentTargetCount = 0;

    /// <summary>
    /// the score to add every time bullet hit target
    /// </summary>
    static public int scoreToAdd = 5;

    // Use this for initialization
    void Start()
    {
        currentTargetCount = targetCount;
        csgp = Application.dataPath + @"/savegame/" + sgp;
        ps = new Ranking.Players();

        canvasInput.GetComponentInChildren<Text>().text = "galas2";
        ptemp = new Ranking.Player(canvasInput.GetComponentInChildren<Text>().text, 50, DateTime.Now, 50);
        //canvasInput.SetActive(false);
        
        if (!File.Exists(csgp))
        {
            SaveXml();
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

    void SaveXml()
    {
        ps.plrs.Add(ptemp);
        Debug.Log("csgp:" + csgp);
            Directory.CreateDirectory(Application.dataPath + @"\savegame");
            Debug.Log("csgp: " + csgp);
            ps.SaveXml(csgp);
            Debug.Log("saved xml");
    }

    // Update is called once per frame
    void Update()
    {

    }

    static public void TouchTarget()
    {
        p.Score += scoreToAdd;
        if (currentTargetCount > 0)
            currentTargetCount--;
        else //the target are over, so save and exit
        { }

        /*
        TODO: add game manager script, that provides to save xml, parse xml, and stuff like that
        */
    }
}
