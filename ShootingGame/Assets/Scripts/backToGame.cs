using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class backToGame : MonoBehaviour {

    /// <summary>
    /// back to the game, so load the game scene
    /// </summary>
    public void backToGameClick()
    {
        SceneManager.LoadScene("scene1");
    }
}
