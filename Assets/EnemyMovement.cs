using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 Position;
    private float speed = 5;

    void Start()
    {
        float randomX = Random.Range(-5f, 5f);
        float randomZ = Random.Range(-5f, 5f);

        Position = new Vector3(randomX, 0f, randomZ);
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, Position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Position) < 1f)
        {
            float randomX = Random.Range(-5f, 5f);
            float randomZ = Random.Range(-5f, 5f);

            Position = new Vector3(randomX, 0f, randomZ);
        }
    }
}
