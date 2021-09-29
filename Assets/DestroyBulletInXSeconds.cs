using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletInXSeconds : MonoBehaviour
{
    float spawnTime;
    public float lifeTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime + lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
