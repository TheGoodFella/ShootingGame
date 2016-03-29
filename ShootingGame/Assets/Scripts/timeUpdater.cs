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
    /// effective game time (seconds), not count when game is paused
    /// </summary>
    static private float gameTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next)
        {
            if (!PauseGame.gamePaused)
            {
                gameTime += interval;
                GetComponent<TextMesh>().text =string.Format(gameTime.ToString().Split('.')[0] + " " + time);
            }
            //always update next, otherwise when the game is paused the method not works
            next += interval;
        }
    }
}
