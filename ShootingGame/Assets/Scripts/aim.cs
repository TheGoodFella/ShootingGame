using UnityEngine;
using System.Collections;

public class aim : MonoBehaviour {
    

    /// <summary>
    /// is it aimed?
    /// </summary>
    private bool isAimed = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            
            if (!isAimed) //if is not aimed yet, do it by playing the animation
                GetComponent<Animation>().Play("mainCamera");

            //tells that is aimed
            isAimed = true;
        }
        else
        {
            //if is aimed, set the boolean false and start the animation reversed (from the aiming position to normal)
            if (isAimed)
            {
                isAimed = false;
                GetComponent<Animation>().Play("mainCamera-rev");
            }
        }
    }
}
