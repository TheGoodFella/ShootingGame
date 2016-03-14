using UnityEngine;
using System.Collections;

public class camFollowGun : MonoBehaviour {

    public GameObject gun;
    Vector3 difference;

	// Use this for initialization
	void Start ()
    {
        difference = transform.position - gun.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = gun.transform.position + difference;
	}
}
