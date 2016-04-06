using UnityEngine;
using UnityEngine.UI;

public class mute : MonoBehaviour
{
    /// <summary>
    /// Reproduce sounds? (yes:true/no:false)
    /// </summary>
    public bool muteSounds = false;
    public AudioSource[] audios;
    public Text muteTXT;

    void Start()
    {
        updateMute();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            muteSounds = !muteSounds;

            updateMute();
        }
    }

    void updateMute()
    {
        Debug.Log("mute sounds:" + muteSounds);

        if (muteSounds)
            muteTXT.text = "unmute (M)";
        else
            muteTXT.text = "mute (M)";

        for (int i = 0; i < audios.Length; i++)
            audios[i].mute = muteSounds;
    }
}
