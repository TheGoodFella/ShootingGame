using UnityEngine;
using System.Threading;

public class mouseEvents : MonoBehaviour {

    public ParticleSystem fireParticles;
    
    //audios
    public GameObject reloadAudio;
    public GameObject gunshotAudio;

    /// <summary>
    /// hammer
    /// </summary>
    public GameObject hammer;

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
    /// the prefab GameObject of the bullet, used to instantiate the bullet at runtime
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// bullet emitter (a cube in front of the gun)
    /// </summary>
    public GameObject bulletEmitter;

    /// <summary>
    /// bullet speed multiplier
    /// </summary>
    public float bulletSpeed = 500;


    /// <summary>
    /// how many seconds the bullet must stay alive? MAYBE SHOULD I REPLACE IT WITH A TRIGGER EVENT AT THE BORDER OF THE GAME MAP
    /// </summary>
    public float destroyDelaySeconds = 10f;

    /// <summary>
    /// max ammo per reload
    /// </summary>
    public int NAmmo = 5;
    /// <summary>
    /// current available bullets
    /// </summary>
    private int bullets;

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
        if (!reloadAudioSource.isPlaying)
            reloadingTXT.SetActive(false);

        if (Input.GetMouseButtonDown(0))  //left mouse btn
        {
            Debug.Log("Pressed mouse button left - 0");
            //Debug.Log("Time elapsed: " + Time.time + "seconds");

            if (!fireParticles.isPlaying && !PauseGame.gamePaused)  
            {
                
                if (bullets <= 0)
                {
                    //NEED TO RELOAD
                    reloadTXT.SetActive(true);
                }
                else if(!reloadAudioSource.isPlaying) //FIRE  //fine only when the sound of reloading is not playing
                {
                    Time.timeScale = 0.3f;
                    //instantiate a new bullet from the bullet prefab
                    GameObject bulletTemp = Instantiate(bulletPrefab, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

                    //ignore collisions between the gun, and the bullets, otherwise gun have a kind of recoil...
                    Physics.IgnoreCollision(bulletTemp.GetComponent<Collider>(), bulletEmitter.GetComponent<Collider>());
                    
                    //finally add force to the bullet (y)
                    bulletTemp.GetComponent<Rigidbody>().AddForce(bulletEmitter.GetComponent<Transform>().forward* bulletSpeed);

                    Destroy(bulletTemp, destroyDelaySeconds);

                    //decrease available bullet
                    bullets--;

                    setBulletsText();

                    Debug.Log("FIRE");
                    trigger.GetComponent<Animation>().Play();
                    Thread.Sleep(8);
                    hammer.GetComponent<Animation>().Play();
                    Thread.Sleep(40);
                    fireParticles.Play();
                    gunshotAudioSource.Play();
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.R))  //RELOAD
        {
            //show "reloading" text
            reloadingTXT.SetActive(true);

            //RELOADING
            reloadAudioSource.Play();
            
            //hide "reloading" text
            reloadTXT.SetActive(false);

            //restore current bullet (bullets) to the max bullet (ammo)
            bullets = NAmmo;
            
            setBulletsText();
        }
    }

    /// <summary>
    /// refresh current available bullet text
    /// </summary>
    void setBulletsText()
    {
        ammoTXT.GetComponent<TextMesh>().text = bullets+ " ammo";
    }
}
