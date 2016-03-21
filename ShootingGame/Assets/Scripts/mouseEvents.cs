using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class mouseEvents : MonoBehaviour {

    public ParticleSystem fireParticles;
    
    //audios
    public GameObject reloadAudio;
    public GameObject gunshotAudio;

    /// <summary>
    /// hammer
    /// </summary>
    public GameObject gun;

    /// <summary>
    /// trigger
    /// </summary>
    public GameObject trigger;

    /// <summary>
    /// current ammo text
    /// </summary>
    public GameObject ammoTXT;

    /// <summary>
    /// reload text
    /// </summary>
    public GameObject reloadTXT;

    /// <summary>
    /// current available bullets
    /// </summary>
    private int bullets;

    /// <summary>
    /// max ammo per reload
    /// </summary>
    public int NAmmo = 5;

    void Start()
    {
        reloadTXT.SetActive(false);
        bullets = NAmmo;
        setBulletsText();
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))  //left mouse btn
        {
            Debug.Log("Pressed mouse button left - 0");

            if (!fireParticles.isPlaying && !PauseGame.gamePaused)  //FIRE!!
            {
                
                if (bullets <= 0)
                {
                    //NEED TO RELOAD
                    reloadTXT.SetActive(true);
                }
                else
                {
                    bullets--;
                    setBulletsText();

                    Debug.Log("FIRE");
                    trigger.GetComponent<Animation>().Play();
                    Thread.Sleep(8);
                    gun.GetComponent<Animation>().Play();
                    Thread.Sleep(40);
                    fireParticles.Play();
                    gunshotAudio.GetComponent<AudioSource>().Play();
                }
                
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
        if (Input.GetKeyDown(KeyCode.R))  //RELOAD
        {
            //RELOADING
            reloadAudio.GetComponent<AudioSource>().Play();
            reloadTXT.SetActive(false);
            bullets = NAmmo;
            setBulletsText();
        }
    }

    void setBulletsText()
    {
        ammoTXT.GetComponent<TextMesh>().text = bullets+ " ammo";
    }
}
