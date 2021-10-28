using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BulletCollision : MonoBehaviour
{

    float spawnTime;
    public float lifeTime = 5f;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time > spawnTime + lifeTime)
        {
            Destroy(gameObject);
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        //ContactPoint cp = collision.GetContact(0);
        if (collision.collider.name == "HeadCollider")
        {
            collision.collider.GetComponent<PlayerStats>()._health -= 40;
        }
        else if (collision.collider.name == "TorsoCollider")
        {
            collision.collider.GetComponent<PlayerStats>()._health -= 30;
        }
        else if(collision.collider.name == "LeftThighCollider" || collision.collider.name == "RightThighCollider")
        {
            collision.collider.GetComponent<PlayerStats>()._health -= 20;
        }
        else if (collision.collider.name == "LeftShinCollider" || collision.collider.name == "RightShinCollider")
        {
            collision.collider.GetComponent<PlayerStats>()._health -= 10;
        }
        else if (collision.collider.name == "LeftUpperArmCollider" || collision.collider.name == "RightUpperArmCollider")
        {
            collision.collider.GetComponent<PlayerStats>()._health -= 15;
        }
        else if (collision.collider.name == "LeftLowerArmCollider" || collision.collider.name == "RightLowerArmCollider")
        {
            collision.collider.GetComponent<PlayerStats>()._health -= 10;
        }

        /*
        if (collision.collider.CompareTag("AvatarHitbox"))
        {
            Realtime.Destroy(gameObject);

            //Destroy(gameObject);
        }*/
    }

    //Test with onTriggerEnter?
}
