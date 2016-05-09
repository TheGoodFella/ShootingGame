using UnityEngine;
using System.Collections;

public class creditsTime : MonoBehaviour {

    /// <summary>
    /// the fire particles emitter
    /// </summary>
    public GameObject fireEmitter;
    /// <summary>
    /// speed time scale of the render of particle system
    /// </summary>
    public float timeScale = 0.15f;

	// Use this for initialization
	void Start () {
        //apply the time scale to the particle system
        fireEmitter.GetComponent<ParticleSystem>().playbackSpeed = timeScale;
        //Time.timeScale = timeScale;
	}
	
	// Update is called once per frame
	void Update () {
        //is the particle already playing? if not, play it
	    if(!fireEmitter.GetComponent<ParticleSystem>().isPlaying)
            fireEmitter.GetComponent<ParticleSystem>().Play();
	}
}
