using UnityEngine;

public class Exit : MonoBehaviour
{
    /// <summary>
    /// when click on the text
    /// </summary>
    public void OnClick()
    {
        Debug.Log("closing...");
        Application.Quit();
    }
}
