using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;

    public GameObject enemyBullet;
    public Transform shootPoint;

    public float shootSpeed = 10f;
    public float timeToShoot = 1.2f;
    float originaltime;



    void Start()
    {
        originaltime = timeToShoot;
    }


    void Update()
    {
        if (detected)
        {
            enemy.LookAt(target.transform);
        }
    }

    void FixedUpdate()
    {
        if (detected)

        {
            timeToShoot -= Time.deltaTime;

            if (timeToShoot < 0)
            {
                ShootPlayer();
                timeToShoot = originaltime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            detected = true;
            target = other.gameObject;
        }
    }

    private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(enemyBullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }

}
