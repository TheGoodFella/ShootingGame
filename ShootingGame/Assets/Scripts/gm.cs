using UnityEngine;
using System.Collections;
using Ranking;

public class gm : MonoBehaviour {

    static public Player p;

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
    private int currentTargetCount;

    /// <summary>
    /// have I log "game over" already?
    /// </summary>
    private bool gameOver = false;

	void Start ()
    {        
        p = new Player("galas", 0, System.DateTime.Now, 50, targetCount);
        Debug.Log("gm started");
        Debug.Log("currentTargetCount" + p.TargetRemained);

    }

    void Update()
    {
        if(p.TargetRemained==0 && !gameOver)
        {
            gameOver = true;
            Debug.Log("game over");
        }
    }
}
