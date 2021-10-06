using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

    public AudioSource audioSource;
    public AudioClip fireSound;
    public AudioClip reload;
    public AudioClip noAmmo;
    public Magazine magazine;
    public XRBaseInteractor socketInteractor;

    public void AddMagazine(XRBaseInteractable interactable)
    {
        magazine = interactable.GetComponent<Magazine>();
        audioSource.PlayOneShot(reload);
    }

    public void RemoveMagazine(XRBaseInteractable interactable)
    {
        magazine = null;
        audioSource.PlayOneShot(reload);
    }

    IEnumerator VibrationDelay()
    {
        yield return new WaitForSeconds(0.15f);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.Touch);
    }

    void Start()
    {
        /*
        if (barrelLocation == null)
            barrelLocation = transform;
        
        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        socketInteractor.onSelectEntered.AddListener(AddMagazine);
        socketInteractor.onSelectExited.AddListener(RemoveMagazine);
        */
    }

    /*
    void Update()
    {
        //If you want a different input, change it here
        if (Input.GetButtonDown("Fire1"))
        {
            //Calls animation on the gun that has the relevant animation events that will fire
            gunAnimator.SetTrigger("Fire");
        }
    }*/

    public void pullTheTrigger()
    {
        //gunAnimator.SetTrigger("Fire");
        Shoot();
        /*
        if (magazine && magazine.numberOfBullets > 0)
        {
            gunAnimator.SetTrigger("Fire");
        }
        else
        {
            audioSource.PlayOneShot(noAmmo);
        }
        */
    }


    //This function creates the bullet behavior
    void Shoot()
    {
        //magazine.numberOfBullets--;
        //audioSource.PlayOneShot(fireSound);
        if (muzzleFlashPrefab)
        {
            // Make controller vibration
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.Touch);
            StartCoroutine(VibrationDelay());

            //Create the muzzle flash
            GameObject tempFlash;
            //tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
            tempFlash = Realtime.Instantiate("MuzzleFlashPrefab", barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }


        // Create a bullet and add force on it in direction of the barrel
        //Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        Realtime.Instantiate("ProjectileWithTrail", barrelLocation.position, barrelLocation.rotation, preventOwnershipTakeover: true).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        //This function creates a casing at the ejection slot
        void CasingRelease()
        {
            //Cancels function if ejection slot hasn't been set or there's no casing
            if (!casingExitLocation || !casingPrefab)
            { return; }

            //Create the casing
            GameObject tempCasing;
            tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
            //Add force on casing to push it out
            tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
            //Add torque to make casing spin in random direction
            tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

            //Destroy casing after X seconds
            Destroy(tempCasing, destroyTimer);
        }
    }
}

