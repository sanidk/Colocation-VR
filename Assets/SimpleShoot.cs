using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.UIElements;
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
    public AudioClip fireSoundSingle;
    public AudioClip fireSound;
    public AudioClip reload;
    public AudioClip noAmmo;
    public Magazine magazine;
    public GameObject Mag;
    public GameObject MagLocation;
    public XRBaseInteractor socketInteractor;

    public bool isShooting = false;
    float fireSoundStart;
    public float fireSoundMinimumDuration = .11f;

    float fireTriggerStartTime;
    float fireSpeedTime = .11f;
    private Realtime _realtime;

    int previousBulletsInMag;
    public int maxBulletsInMag = 64;
    //public int bulletsInMag;

    public bool isPistol;
    public bool isRifle;

    GameObject gameManager;

    TMPro.TextMeshPro bulletsInMagTextMesh;

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

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        bulletsInMagTextMesh = GetComponentInChildren<TMPro.TextMeshPro>();
        
    }


    void Update()
    {
        //If you want a different input, change it here
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            //Calls animation on the gun that has the relevant animation events that will fire
            gunAnimator.SetTrigger("Fire");
        }
        */
        if (isPistol)
        {
            bulletsInMagTextMesh.text = GetComponent<AmmoStats>()._ammo + "/" + maxBulletsInMag;
            previousBulletsInMag = GetComponent<AmmoStats>()._ammo;
            return;
        }

        if (isShooting & GetComponent<AmmoStats>()._ammo>0)
        {
            if (!audioSource.isPlaying)
            {
                //audioSource.PlayOneShot(fireSound);
                fireSoundStart = Time.time;
            }
            if (Time.time > fireTriggerStartTime + fireSpeedTime) //.11 seem to work well through testing
            {
                Shoot();
                //bulletsInMag--;
                GetComponent<AmmoStats>()._ammo--;
                
                fireTriggerStartTime = Time.time;
            }
            

        } else if (isShooting & GetComponent<AmmoStats>()._ammo == 0){
            //play the clipping sound effect
            if (Time.time > fireTriggerStartTime + fireSpeedTime)
            {
                //audioSource.Stop();
                //audioSource.PlayOneShot(noAmmo);
                fireTriggerStartTime = Time.time;
            }
            
        } else
        {
            if (audioSource.isPlaying)
            {
                if (Time.time > fireSoundStart + fireSoundMinimumDuration)
                {
                    //audioSource.Stop();
                }
                

            }
        }

        if (GetComponent<AmmoStats>()._ammo != previousBulletsInMag)
        {
            bulletsInMagTextMesh.text = GetComponent<AmmoStats>()._ammo + "/" + maxBulletsInMag;
            previousBulletsInMag = GetComponent<AmmoStats>()._ammo;
        }
        
    }

    public void holdTheTrigger()
    {
        isShooting = true;
        //Shoot();
        //Shoot();
        //print("isholding");
    }

    public void stopTheTrigger()
    {
        isShooting = false;

    }

    public void pullTheTrigger()
    {
        //gunAnimator.SetTrigger("Fire");
        //audioSource.PlayOneShot(fireSound);
        isShooting = true;
        if (isPistol)
        {
            if (GetComponent<AmmoStats>()._ammo > 0)
            {
                Invoke("Shoot",0.1f);
                //audioSource.PlayOneShot(fireSoundSingle);
                GetComponent<AmmoStats>()._ammo--;
            }
            else
            {
                audioSource.PlayOneShot(noAmmo);
            }

        }
        //Shoot();
        

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

        // Make controller vibration
        var inputDevices = new List<UnityEngine.XR.InputDevice>(); 
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        bool triggerValue;

            foreach (var device in inputDevices)
            {
                if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
                {
                device.SendHapticImpulse(0, 1f, 0.15f);
                }
            }


        if (muzzleFlashPrefab)
        {
            
            //Create the muzzle flash
            GameObject tempFlash;
            //tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
            tempFlash = Realtime.Instantiate("MuzzleFlashPrefab", barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }


        // Create a bullet and add force on it in direction of the barrel
        //Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

            GameObject projectile = Realtime.Instantiate("ProjectileWithTrail", barrelLocation.position, barrelLocation.rotation, new Realtime.InstantiateOptions
            {
                ownedByClient = true,
                preventOwnershipTakeover = true,
                destroyWhenOwnerLeaves = false,
                destroyWhenLastClientLeaves = true,
                //useInstance = _realtime,
            });

            projectile.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        //if (GetComponent<>)
        if (!isPistol)
        {
            GameObject PistolFireAudio = Realtime.Instantiate("RifleBulletAudio", barrelLocation.position, barrelLocation.rotation);
        }
        else
        {
            GameObject RiffleFireAudio = Realtime.Instantiate("PistolBulletAudio", barrelLocation.position, barrelLocation.rotation);
        }
        

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

    void Reload()
    {
        GetComponent<AmmoStats>()._ammo = 8;
        audioSource.PlayOneShot(reload);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject != isPistol) return;
        if (collision.gameObject.CompareTag("Magazine") && Mag == null && GetComponent<AmmoStats>()._ammo < 8)
        {
            Reload();
            Mag = collision.gameObject;
            Mag.transform.position = MagLocation.transform.position;
            Realtime.Destroy(Mag);
            Mag = null;
        }

    }

}

