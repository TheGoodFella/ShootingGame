using UnityEngine;

public class mute : MonoBehaviour
{
    public bool muteBool = false;
    public AudioSource[] audios;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            muteBool = !muteBool;

            Debug.Log("muteBool:" + muteBool);

            for (int i = 0; i < audios.Length; i++)
                audios[i].mute = muteBool;
        }
    }
}
