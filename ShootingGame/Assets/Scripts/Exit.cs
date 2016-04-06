using UnityEngine;

public class Exit : MonoBehaviour
{

    public void OnClick()
    {
        Debug.Log("leaving...");
        Application.Quit();
    }

    public void OnEnter()
    {
        Debug.Log("Exit mouse enter");
    }
}
