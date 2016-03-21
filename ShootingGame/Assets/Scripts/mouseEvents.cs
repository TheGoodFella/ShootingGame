using UnityEngine;
using System.Threading;
public class mouseEvents : MonoBehaviour {

    public ParticleSystem fireParticles;
    public GameObject gunshotAudio;

    /// <summary>
    /// hammer
    /// </summary>
    public GameObject gun;

    /// <summary>
    /// trigger
    /// </summary>
    public GameObject trigger;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))  //left mouse btn
        {
            Debug.Log("Pressed mouse button left - 0");

            if (!fireParticles.isPlaying && !PauseGame.gamePaused)  //FIRE!!
            {
                Debug.Log("FIRE");
                trigger.GetComponent<Animation>().Play();
                gun.GetComponent<Animation>().Play();
                Thread.Sleep(40);
                fireParticles.Play();
                gunshotAudio.GetComponent<AudioSource>().Play();
                
            }
        }

        if (Input.GetMouseButtonDown(1))  //right mouse btn
        {
            Debug.Log("Pressed mouse button right - 1");
        }

        if (Input.GetMouseButtonDown(2))  //middle mouse btn
        {
            Debug.Log("Pressed mouse button middle - 2");
        }
    }

    void WaitForAnimation(Animation animation)
    {

    }
}
