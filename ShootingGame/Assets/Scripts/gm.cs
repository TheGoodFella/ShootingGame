using UnityEngine;
using System.Collections;
using Ranking;

public class gm : MonoBehaviour {

    public Player p;

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
    private int currentTargetCount = 0;

	void Start () {
        p = new Player();
	}
}
