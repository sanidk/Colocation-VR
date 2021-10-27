using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
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

     // Coroutine Variable for vibration
    IEnumerator GrenadeVibrationDelay()
        {
            yield return new WaitForSeconds(1.5f);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.Touch);
        }

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
            PlayerStats enemy = nearbyObject.GetComponent<PlayerStats>();
            Vector3 enemyPos = new Vector3(nearbyObject.transform.position.x, nearbyObject.transform.position.y, nearbyObject.transform.position.z);
            float proximity = (transform.position - enemyPos).magnitude;
            float effect = 1 - (proximity / radius);
            
            if (enemy != null) {
                // MULTIPLY BY EFFECT (enemy.GetHp() - damage * effect) WHEN HP IS EXPECTED AS FLOAT
                enemy._health = enemy._health - damage * effect;
            }
            
            if (rb != null) {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        if (this.tag == "SmokeGrenade") {
            audioSource.PlayOneShot(smokeSound);
        } else if (this.tag == "FragGrenade") {
            audioSource.PlayOneShot(explosionSound);

            // Make controller vibration
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.Touch);
            StartCoroutine(GrenadeVibrationDelay());

        } else if (this.tag == "Molotov") {
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
