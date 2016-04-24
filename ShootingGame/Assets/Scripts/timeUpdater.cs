using UnityEngine;

public class timeUpdater : MonoBehaviour
{
    /// <summary>
    /// set the update interval
    /// </summary>
    public float interval = 0.3f;
    /// <summary>
    /// the string after the time (mm:ss + thisString)
    /// </summary>
    public string time = "s";
    /// <summary>
    /// user for update interval
    /// </summary>
    public float next = 0.0f;
    /// <summary>
    /// effective game time (seconds), not count when game is paused, affected by eventual slow-mo
    /// </summary>
    static public float gameTime = 0.0f;

    /// <summary>
    /// the text to show the time
    /// </summary>
    public GameObject timeTXT;
    /// <summary>
    /// show also the score upper left the screen
    /// </summary>
    public GameObject scoreTXT;

    void Start()
    {
        scoreTXT.GetComponent<TextMesh>().text = "0 pt";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next)
        {
            if (!PauseGame.gamePaused)
            {
                gameTime += interval;
                timeTXT.GetComponent<TextMesh>().text =string.Format(gameTime.ToString().Split('.')[0] + " " + time);
                scoreTXT.GetComponent<TextMesh>().text = gm.p.Score + " pt";
            }
            //always update next, otherwise when the game is paused the method not works
            next += interval;
        }
    }
}
