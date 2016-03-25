using UnityEngine;
using System.Collections;

public class aim : MonoBehaviour {
    
    private bool isAimed = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (!isAimed)
            {
                GetComponent<Animation>().Play("mainCamera");
            }
            isAimed = true;
        }
        else
        {
            if (isAimed)
            {
                isAimed = false;
                GetComponent<Animation>().Play("mainCamera-rev");

            }
        }
    }
}
