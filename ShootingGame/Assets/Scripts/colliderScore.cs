using System;
using UnityEngine;
using System.Collections;

public class colliderScore : MonoBehaviour {
    
    /// <summary>
    /// add score when the target it's struck by the bullet
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            gm.p.AddScore(5);
            //Debug.Log("playerName:" + gm.player.Name + "\nscore:" + gm.player.Score);

        }
        //col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000.0f, col.gameObject.GetComponent<Rigidbody>().position, 5.0f);
    }
}
