using UnityEngine;
using System.Collections;

public class mouseEvents : MonoBehaviour {

    public ParticleSystem fireParticles;

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
    }
}
