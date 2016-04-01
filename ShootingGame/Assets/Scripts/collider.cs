using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {

    public GameObject particleSmoke;

    /// <summary>
    /// destroy ball when collide with something
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter(Collision col)
    {
        Instantiate(particleSmoke, GetComponent<Transform>().position, Quaternion.identity);
        Destroy(gameObject);
        //col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000.0f, col.gameObject.GetComponent<Rigidbody>().position, 5.0f);
    }
}
