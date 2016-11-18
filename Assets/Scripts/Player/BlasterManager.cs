using UnityEngine;
using System.Collections;

public class BlasterManager : MonoBehaviour {

    public GameObject bullet;
    GameObject bulletClone;

    public bool canFire = true;
    public bool isShooting = false;


    public float fireRate;
    public float nextFire = .33f;
    public float range;
    public int maxShots;
    

    public float shotTimer = 0;
    private float shotDownTime = 1;
    public int shotCount;
    public float timestamp;
    private float shotResetTimer;



    void Start () {
	
	}
	

	void Update () {

        //Handle shooting

        if (shotCount == maxShots)
        {
            isShooting = false;
            canFire = false;
            shotTimer += 1 * Time.deltaTime;
            if (shotTimer > shotDownTime)
            {
                shotCount = 0;
                shotTimer = 0;
            }
        }
        if (shotCount < maxShots)
        {
            canFire = true;
        }


        if (Input.GetButton("Shoot") && canFire && Time.time >= timestamp)
        {
            shotTimer *= Time.deltaTime;
            Fire();
        }

    }

    void Fire()
    {
        if (shotCount < maxShots)
        {            
            isShooting = true;
            shotCount++;
            bulletClone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Destroy(bulletClone, range);
            Debug.Log("FIRE!");            
            timestamp = Time.time + nextFire;
        }

    }
}
