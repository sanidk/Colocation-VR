using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

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

    public void OnCollisionEnter(Collision collision) // Works. NOtice that the object needs Bullet tag AND collider AND probably both realtimeview and transform.
    {
        ContactPoint cp = collision.GetContact(0);

        if(cp.thisCollider.CompareTag("Bullet") && collision.collider.CompareTag("AvatarHitbox"))
        {
            Realtime.Destroy(gameObject);
            print("RealtimeDestroy bullet on impact with avatarHitbox");
            Destroy(gameObject);
        }
    }
}
