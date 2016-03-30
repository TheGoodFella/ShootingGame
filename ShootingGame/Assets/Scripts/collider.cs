using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
        //col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000.0f, col.gameObject.GetComponent<Rigidbody>().position, 5.0f);
    }
}
