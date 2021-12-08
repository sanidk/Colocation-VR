using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public float _health = default;
    public float _previousHealth = default;

    [SerializeField]
    public float _energy = default;
    public float _previousEnergy = default;

    [SerializeField]
    public bool _isReady = default;
    public bool _previousIsReady = default;

    [SerializeField]
    public int _team = default; //team 1 is blue, 2 is red
    public int _previousTeam = default;

    [SerializeField]
    public bool _isServer = default;
    public bool _previousIsServer = default;

    public PlayerStatsSync _playerStatsSync;
    GameLogic gameLogic;
    public GameObject gameManager;
    GameManagerLogic gameManagerLogic;

    private Material healthShaderMat;
    private int childIndexDisplay = 0;
    private float convertedHealth;
    private float convertedHealthColor;
    public GameObject watch;

    int currentRound;
    int oldRound;

    //HUSK VI HAR UNCOMMENTET I LINIE 86
    public float hp;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        // Get a reference to the color sync component
        _playerStatsSync = GetComponent<PlayerStatsSync>();
        
        //healthShaderMat = transform.GetChild(childIndexDisplay).GetChild(childIndexDisplay).GetComponent<MeshRenderer>().material;
        healthShaderMat = watch.GetComponent<MeshRenderer>().material;
        gameLogic = gameManager.GetComponent<GameLogic>();
        gameManagerLogic = gameManager.GetComponent<GameManagerLogic>();
        

        _health = 100;
        hp = 100;
        

        //_health = 100; this works and sets _health to 100 on connection/spawn

        if (Application.platform != RuntimePlatform.Android)
        {
            //Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        convertedHealth = Remap(_health, 0, 100, 5, 0);
        healthShaderMat.SetFloat("_ConvHealth", Remap(_health, 0, 100, 0, 1));
        healthShaderMat.SetFloat("_RemovedSegments", convertedHealth);

        _health = _playerStatsSync.GetHealth();
        //if (!gameLogic._isRoundStarted && _isReady)
        //{
        //    _health = 100;
        //}

        if (!gameLogic._isRoundStarted && _isReady && _health != 100)
        {
            _playerStatsSync.SetHealth(100);
        }

        //if (gameLogic._isRoundStarted && gameLogic._roundCurrent != oldRound)
        //{
        //    _health = 100;

        //    oldRound = gameLogic._roundCurrent;

        //}

        //hp = _health;




        /*
        if (!gameManagerLogic.isServer)
        {
            //_health = _playerStatsSync.GetHealth();
            return;
        }


        _playerStatsSync.SetHealth(_health);*/

        //if (!gameManagerLogic.isServer) return;




        // If the color has changed (via the inspector), call SetColor on the color sync component.
        /*
        if (_health != _previousHealth)
        {
            _playerStatsSync.SetHealth(_health);
            _previousHealth = _health;
        }
        

        if (_energy != _previousEnergy)
        {
            _playerStatsSync.SetEnergy(_energy);
            _previousEnergy = _energy;
        }

        if (_isReady != _previousIsReady)
        {
            _playerStatsSync.SetIsReady(_isReady);
            _previousIsReady = _isReady;
        }

        if (_team != _previousTeam)
        {
            _playerStatsSync.SetTeam(_team);
            _previousTeam = _team;
        }

        if (_isServer != _previousIsServer)
        {
            _playerStatsSync.SetIsServer(_isServer);
            //gameManagerLogic.isServer = _isServer;
            _previousIsServer = _isServer;
        }*/

    }



    // Remap function tan from unity forum
    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    public void OnCollisionEnter(Collision collision) // Works. NOtice that the object needs Bullet tag AND collider AND probably both realtimeview and transform.
    {
        //if (!GetComponent<RealtimeTransform>().isOwnedLocallySelf) { return; }
        /*
        foreach (ContactPoint contact in collision.contacts) // Use contact.GetContacts() instead, No garbage
        {
            //print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            //Debug.DrawRay(contact.point, contact.normal, Color.white);
        }*/
        
        ContactPoint cp = collision.GetContact(0); // ??
        if (GetComponent<RealtimeTransform>().isOwnedLocallySelf)
        {
            if (collision.collider.CompareTag("Bullet"))
            {
                var rot = Quaternion.FromToRotation(Vector3.up, cp.normal);
                GameObject blood = Realtime.Instantiate("BloodParticle", cp.point, rot);
                GameObject hitMarkerAudio = Realtime.Instantiate("HitMarkerSound", cp.point, rot);//ownedLocallySelf?
            }
        }

        if (cp.thisCollider.name == "HeadCollider" && collision.collider.CompareTag("Bullet"))
            {
                hp -= 20;
                //_playerStatsSync.SetHealth(hp);
                _playerStatsSync.SetHealth(_health - 20);
                //Destroy(collision.collider.gameObject);
                //collision.collider.gameObject.GetComponentInParent<BulletCollision>().isActive = false;
            }
            if (cp.thisCollider.name == "TorsoCollider" && collision.collider.CompareTag("Bullet"))
            {
                
                hp -= 10;
                _playerStatsSync.SetHealth(_health - 10);
                //Realtime.Destroy(collision.collider.gameObject.GetComponent<RealtimeView>());

            }
            if (cp.thisCollider.name == "RightThighCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftThighCollider"
                && collision.collider.CompareTag("Bullet"))
            {
                hp -= 10;
                _playerStatsSync.SetHealth(_health - 10);
            }
            if (cp.thisCollider.name == "RightShinCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftShinCollider"
                && collision.collider.CompareTag("Bullet"))
            {
                hp -= 10;
                _playerStatsSync.SetHealth(_health - 10);
            }
            if (cp.thisCollider.name == "RightUpperArmCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftUpperArmCollider"
                && collision.collider.CompareTag("Bullet"))
            {
                hp -= 10;
                _playerStatsSync.SetHealth(_health - 10);
            }

            if (cp.thisCollider.name == "RightLowerArmCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftLowerArmCollider"
                && collision.collider.CompareTag("Bullet"))
            {
                hp -= 10;
                _playerStatsSync.SetHealth(_health - 10);
            }
        
    }

}