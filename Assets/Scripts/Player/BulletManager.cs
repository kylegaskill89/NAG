using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {

    public float speed;


	void Start ()
    {
         
    }

	void Update ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
