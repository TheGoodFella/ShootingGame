using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {

    public GameObject particleSmoke;

    /// <summary>
    /// how many seconds the particles smoke must stay alive?
    /// </summary>
    public float destroyDelaySeconds = 2;

    /// <summary>
    /// destroy ball when collide with something
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "target")
            gm.p.AddScore(5);

        Destroy(Instantiate(particleSmoke, GetComponent<Transform>().position, Quaternion.identity), destroyDelaySeconds);
        Destroy(gameObject);
        //col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000.0f, col.gameObject.GetComponent<Rigidbody>().position, 5.0f);
    }
}
