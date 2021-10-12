using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{

    private HPSync _hp;

    public GameObject explosionEffect; 
    public AudioSource audioSource;

    public AudioClip smokeSound;
    public AudioClip explosionSound;
    public AudioClip molotovSound;

    private float explosionDelay = 3f;
    private float radius = 5f;
    private float force = 5000f; 
    private float proximity;
    private float effect;
    private int damage = 75;

    float countdown; 
    bool hasExploded = false; 
    public bool pinIsPulled = false;


    // Start is called before the first frame update
    void Start() {
        _hp = GetComponent<HPSync>();
        countdown = explosionDelay;   
    }

    // Update is called once per frame
    void Update() {

        // Determine if nade is set to detonate 
        if (pinIsPulled) {
        countdown -= Time.deltaTime;
        }

        // Explode on counter hitting 0 
        if (countdown <= 0f && !hasExploded) {
            Explode();
            hasExploded = true;
        }
    }

    void Explode() {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            HPSync enemy = nearbyObject.GetComponent<HPSync>();
            Transform enemyTransform = nearbyObject.GetComponent<Transform>();
            Vector3 enemyPos = new Vector3(nearbyObject.transform.position.x, nearbyObject.transform.position.y, nearbyObject.transform.position.z);
            float proximity = (transform.position - enemyPos).magnitude;
            float effect = 1 - (proximity / radius);
            
            if (enemy != null) {
                // MULTIPLY BY EFFECT (enemy.GetHp() - damage * effect) WHEN HP IS EXPECTED AS FLOAT
                enemy.setHp(enemy.GetHp() - damage);
            }
            
            if (rb != null) {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        if (this.name == "SmokeGrenade") {
            audioSource.PlayOneShot(smokeSound);
        } else if (this.name == "FragGrenade") {
            audioSource.PlayOneShot(explosionSound);
        } else if (this.name == "Molotov") {
            audioSource.PlayOneShot(molotovSound);
        }
        Destroy(gameObject, 0.5f); 
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "FloorHuge") {
            pinIsPulled = true; 
        }
    }
}
