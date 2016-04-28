using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getName : MonoBehaviour {

    public Text playerText;

    public GameObject canvasInput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetName()
    {
        gm.p.Name = playerText.text;
        canvasInput.SetActive(false);
        gm.StartGame();
    }
}
