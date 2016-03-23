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

    public GameObject bullet_emitter;

    public float bulletSpeed = 500;

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
        if (!reloadAudioSource.isPlaying)
            reloadingTXT.SetActive(false);

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
                else if(!reloadAudioSource.isPlaying)  //fine only when the sound of reloading is not playing
                {

                    Debug.Log("gun V3: "+hammer.transform.parent.position.ToString());

                    GameObject bulletTemp = Instantiate(bulletPrefab, new Vector3(bullet_emitter.transform.position.x, bullet_emitter.transform.position.y, bullet_emitter.transform.position.z), bullet_emitter.transform.rotation) as GameObject;

                    bulletTemp.transform.Rotate(Vector3.right);

                    //bulletTemp.GetComponent<Rigidbody>().velocity = bullet_emitter.transform.forward * bulletSpeed; ;


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
