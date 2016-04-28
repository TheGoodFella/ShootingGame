using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ranking;
using System.IO;

public class gm : MonoBehaviour {

    static public Player p;

    /// <summary>
    /// textbox for the name of the player, show at start, hide after insert
    /// </summary>
    public GameObject canvasInput;

    /// <summary>
    /// name of the save game xml file (Save Game Name)
    /// </summary>
    public string sgn;

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
    private int currentTargetCount;

    /// <summary>
    /// have I log "game over" already?
    /// </summary>
    private bool gameOver = false;

	void Start ()
    {
        //PauseGame.setPause = true;
        //canvasInput.SetActive(false);
        //canvasInput.SetActive(true);
        //canvasInput.GetComponentInChildren<Text>().text = "fuck";

        p = new Player("temp", 0, System.DateTime.Now, 50, targetCount);
        Debug.Log("gm started");
        Debug.Log("currentTargetCount" + p.TargetRemained);

    }

    void Update()
    {
        if(p.TargetRemained==0 && !gameOver)
        {
            gameOver = true;
            Debug.Log("game over");
            GameOver();
        }
    }

    void GameOver()
    {
        Players ps = new Players();
        csgp = Application.dataPath + @"/savegame/" + sgn;
        if (File.Exists(csgp))
        {
            //ps.plrs.Add(new Player("galas", 100, System.DateTime.Now, 30, 5));
            //ps.plrs.Add(new Player("dan", 200, System.DateTime.Now, 40, 5));
            //ps.SaveXml(@"D:\pl.xml");
            //ps.plrs = ps.XmlParser(@"D:\pl.xml");
            //ps.SaveXml(@"D:\pl2.xml");
            ps.plrs = ps.XmlParser(csgp);
            ps.plrs.Add(p);
            ps.SaveXml(csgp);
        }
        else
        {
            ps.plrs.Add(p);
            ps.SaveXml(csgp);
        }
    }

    public void SetName()
    {
        p.Name = canvasInput.GetComponentInChildren<Text>().text;
    }


    public static void StartGame()
    {
        Debug.Log("player name: " + p.Name);
        PauseGame.setPause = true; //change pause state to paused to resumed
    }
}
