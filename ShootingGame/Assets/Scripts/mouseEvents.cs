using UnityEngine;
using System.Collections;

public class mouseEvents : MonoBehaviour {

    public ParticleSystem fireParticles;
    public GameObject gunshotAudio;
    public GameObject gun;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))  //left mouse btn
        {
            Debug.Log("Pressed mouse button left - 0");

            if (!fireParticles.isPlaying && !PauseGame.gamePaused)  //FIRE!!
            {
                Debug.Log("FIRE");
                gun.GetComponent<Animation>().Play();
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
}
