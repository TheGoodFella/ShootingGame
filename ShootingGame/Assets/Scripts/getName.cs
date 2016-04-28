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

    /// <summary>
    /// record the player name and start the game
    /// </summary>
    public void GetName()
    {
        PauseGame.askName = false;  //allows player to press ESC to pause/resume the game
        gm.p.Name = playerText.text; //record player name
        canvasInput.SetActive(false);  //hide the input textbox and the OK button
        gm.StartGame();  //start the game
    }
}
