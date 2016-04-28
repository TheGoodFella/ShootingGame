using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    /// <summary>
    /// check if pause the game and..
    /// ...check if the cursor was locked or unlocked when we press esc
    /// </summary>
    private bool isGamePaused;

    /// <summary>
    /// control the pause from external scripts, set to true for switch between pause and resume
    /// </summary>
    public static bool setPause = false;

    /// <summary>
    /// hide the pause text (resume,exit to windows, and mute text) when game starts because the ask-name-input-text is showing
    /// </summary>
    public static bool askName = true;


    /// <summary>
    /// is the game paused? [true:yes/false:no]
    /// </summary>
    public static bool gamePaused;


    public GameObject canvasPause;

	/// <summary>
    /// Use this for initialization
	/// </summary>
    void Start()
    {
        canvasPause.SetActive(false);

        //on start lock the cursor to the center of the game window and hide it
        SetCursorState(false);
    }
	
	/// <summary>
    /// Update is called once per frame
	/// </summary>
    void Update()
    {
        if (!askName)
            //if we press esc the cursor will unlock from the center of game window and it became visible if it wasn't, otherwise it again becomes locked and hidden
            if (Input.GetKeyDown(KeyCode.Escape) || setPause)
            {
                if (isGamePaused)
                {
                    SetCursorState(false);
                }
                else
                {
                    SetCursorState(true);
                }
                setPause = false;
                canvasPause.SetActive(gamePaused);
            }
    }

    /// <summary>
    /// set the state of the cursor: lock to the gamewindow and hide it if the doLock is true, otherwise unlock and show
    /// </summary>
    /// <param name="doLock">I have to lock and hide cursor?</param>
    void SetCursorState(bool doLock)
    {
        if (doLock)  //lock and hide cursor
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isGamePaused = true;
            gamePaused = false;
        }
        else  //unlock and show cursor
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isGamePaused = false;
            gamePaused = true;
        }
    }
}
