using UnityEngine;
using System.Collections;

public class mouseEvents : MonoBehaviour {

    public ParticleSystem fireParticles;

    /// <summary>
    /// check if the cursor was locked or unlocked when we press esc
    /// </summary>
    private bool isCursorLocked;

    void Start()
    {
        //on start lock the cursor to the center of the game window and hide it
        SetCursorState(true);
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
            isCursorLocked = true;
        }
        else  //unlock and show cursor
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isCursorLocked = false;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))  //left mouse btn
        {
            Debug.Log("Pressed mouse button left - 0");

            if (!fireParticles.isPlaying)
                fireParticles.Play();
        }

        if (Input.GetMouseButtonDown(1))  //right mouse btn
        {
            Debug.Log("Pressed mouse button right - 1");
        }

        if (Input.GetMouseButtonDown(2))  //middle mouse btn
        {
            Debug.Log("Pressed mouse button middle - 2");
        }

        //if we press esc the cursor will unlock from the center of game window and it became visible if it wasn't, otherwise it again becomes locked and hidden
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isCursorLocked)
                SetCursorState(false);
            else
                SetCursorState(true);
        }
    }
}
