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

    //TXTs:
    /// <summary>
    /// current ammo text
    /// </summary>
    public GameObject ammoTXT;
    /// <summary>
    /// reload text
    /// </summary>
    public GameObject reloadTXT;
    /// <summary>
    /// reloading text
    /// </summary>
    public GameObject reloadingTXT;

    /// <summary>
    /// current available bullets
    /// </summary>
    private int bullets;

    /// <summary>
    /// max ammo per reload
    /// </summary>
    public int NAmmo = 5;

    //instead of write always reloadAudio.GetComponent<AudioSource>().Play(); I save it then I just call reloadAudioSource.Play();
    private AudioSource reloadAudioSource;
    private AudioSource gunshotAudioSource;

    void Start()
    {
        reloadAudioSource = reloadAudio.GetComponent<AudioSource>();
        gunshotAudioSource = gunshotAudio.GetComponent<AudioSource>();

        reloadingTXT.SetActive(false);
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
                else if(!reloadAudioSource.isPlaying)  //if the reload sound is playing the gun is reloading and it mustn't fire
                {
                    if (reloadingTXT.active)
                        reloadingTXT.SetActive(false);

                    bullets--;
                    setBulletsText();

                    Debug.Log("FIRE");
                    trigger.GetComponent<Animation>().Play();
                    Thread.Sleep(8);
                    gun.GetComponent<Animation>().Play();
                    Thread.Sleep(40);
                    fireParticles.Play();
                    gunshotAudioSource.Play();
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.R))  //RELOAD
        {
            reloadingTXT.SetActive(true);

            //RELOADING
            reloadAudioSource.Play();
            

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
