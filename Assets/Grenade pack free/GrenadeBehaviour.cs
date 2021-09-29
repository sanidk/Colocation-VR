using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{

    public GameObject explosionEffect; 

    public float explosionDelay = 3f;
    public float radius = 5f;
    public float force = 5000f; 

    float countdown; 
    bool hasExploded = false; 
    public bool pinIsPulled = false;



    // Start is called before the first frame update
    void Start() {
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
            if (rb != null) {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject); 
    }

    void onCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Floor") {
            pinIsPulled = true; 
        }
    }
}
