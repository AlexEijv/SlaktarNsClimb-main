using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandgunController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;
    bool cooldown = false;
    bool isReloading = false;

    [SerializeField]
    float BulletSpeed;

    [SerializeField]
    float FireRate;

    [SerializeField]
    float CurrentAmmo;

    [SerializeField]
    int MagCapacity;

    [SerializeField]
    float ReloadTime;

    [SerializeField]
    GameObject handgunObject;



    void Update()
    {
        if (!isReloading && Input.GetMouseButton(0) && CurrentAmmo > 0 && !cooldown)
        {
            FireBullet();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading && CurrentAmmo < MagCapacity)
        {
            StartCoroutine(Reload());
        }
    }

    void onReload()
    {
        Reload();
    }

    void FireBullet()
    {
        if (Input.GetMouseButton(0) && CurrentAmmo > 0 && !cooldown)
        {
            GameObject BulletClone = Instantiate(Bullet, transform.position, Quaternion.identity);
            BulletClone.SetActive(true);
            Rigidbody rb = BulletClone.GetComponent<Rigidbody>();
            rb.AddForce(Player.transform.forward * BulletSpeed);
            CurrentAmmo -= 1;
            cooldown = true;
            StartCoroutine(cooldownTimer());
            handgunObject.GetComponent<Animation>().Play();
        }

    }
    IEnumerator cooldownTimer()
    {
        yield return new WaitForSeconds(0.5f);
        cooldown = false;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        handgunObject.GetComponent<Animation>().Play("Reload");
        
        yield return new WaitForSeconds(ReloadTime);
         CurrentAmmo = Mathf.Min(MagCapacity, CurrentAmmo + (MagCapacity - CurrentAmmo));
        isReloading = false;
    }
}
