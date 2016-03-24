using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
