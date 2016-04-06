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

    /// <summary>
    /// when cursor enter the text area
    /// </summary>
    public void OnEnter()
    {
        //Debug.Log("Mouse enter on exit");
    }

    /// <summary>
    /// when cursor exit the text area
    /// </summary>
    public void OnExit()
    {
        //Debug.Log("Mouse leaving on exit");
    }
}
