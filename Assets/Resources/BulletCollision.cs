using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BulletCollision : MonoBehaviour
{

    public bool hasAuthority = false;

    private GameObject GameManager;

    float spawnTime;
    public float lifeTime = 5f;

    void Start()
    {
        spawnTime = Time.time;
        //GameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (!hasAuthority) return;
        if (Time.time > spawnTime + lifeTime)
        {
            Destroy(gameObject);
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (!hasAuthority) return;
        print("OnCollisionEnter On bullet");
        //ContactPoint cp = collision.GetContact(0);
        /*if (collision.collider.name == "HeadCollider")
        {
            print("Head collider hit");
            collision.collider.gameObject.GetComponentInParent<PlayerStats>()._health -= 40;
            //Realtime.Destroy(gameObject);
            Destroy(gameObject);
        }*/
        if (collision.collider.name == "TorsoCollider")
        {
            print("Torso collider hit");
            collision.collider.gameObject.GetComponentInParent<PlayerStats>()._health -= 10;
            //collision.collider.gameObject.GetComponentInParent<PlayerStatsSync>().DeductHealth(15);
            //Realtime.Destroy(gameObject);
            //Destroy(gameObject);
            //Realtime.Destroy(gameObject);
        }/*
        else if(collision.collider.name == "LeftThighCollider" || collision.collider.name == "RightThighCollider")
        {
            collision.collider.gameObject.GetComponentInParent<PlayerStats>()._health -= 5;
            //Realtime.Destroy(gameObject);
            Destroy(gameObject);
        }
        else if (collision.collider.name == "LeftShinCollider" || collision.collider.name == "RightShinCollider")
        {
            collision.collider.gameObject.GetComponentInParent<PlayerStats>()._health -= 5;
            //Realtime.Destroy(gameObject);
            Destroy(gameObject);
        }
        else if (collision.collider.name == "LeftUpperArmCollider" || collision.collider.name == "RightUpperArmCollider")
        {
            collision.collider.gameObject.GetComponentInParent<PlayerStats>()._health -= 15;
            //Realtime.Destroy(gameObject);
            Destroy(gameObject);
        }
        else if (collision.collider.name == "LeftLowerArmCollider" || collision.collider.name == "RightLowerArmCollider")
        {
            collision.collider.gameObject.GetComponentInParent<PlayerStats>()._health -= 10;
            //Realtime.Destroy(gameObject);
            Destroy(gameObject);
        }
        /*
        if (collision.collider.CompareTag("AvatarHitbox"))
        {
            Realtime.Destroy(gameObject);

            //Destroy(gameObject);
        }
        */
    }

    //Test with onTriggerEnter?
}
