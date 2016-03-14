using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

    private Vector3 offset;
    public float sensivity = 10;
    private Vector3 v3;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        v3 = new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * sensivity);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.forward * -sensivity);
    }
}
