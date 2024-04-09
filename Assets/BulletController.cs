using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float destroyDelay = 5f;

  
    void Update()
    {
        destroyDelay -= Time.deltaTime;

        if (destroyDelay <= 0f)
        {
            Destroy(gameObject); 
        }
    }
}