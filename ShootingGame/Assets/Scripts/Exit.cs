using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Exit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void OnClick()
    {
        Debug.Log("Exit");
    }

    public void OnEnter()
    {
        Debug.Log("Exit mouse enter");
    }
}
