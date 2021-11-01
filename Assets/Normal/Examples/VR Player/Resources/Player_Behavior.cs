using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Player_Behavior : MonoBehaviour
{
    public int team;
    public bool isPlayerReady;
    //public float hp = 100;

    //private float currentHp_Local;
    //private ColorSync _colorSync;
    private bool dead;
    //private HPSync _hp;
    private float _redAmount = 0;

    //private HpFloatSync _hp; // ADD COMPONENT TO PLAYER

    public GameObject meshObject;
    Collider coll;
    //public GameObject Hitbox_Head;
    //public GameObject Hitbox_Torso;
    private float previousHp_Local;

    public GameObject textMeshObject;
    TextMesh textMesh;

    PlayerStats playerStats;
    PlayerStatsSync playerStatsSync;

    private void Awake()
    {
        //_colorSync = GetComponentInChildren<ColorSync>();
        //_colorSync = meshObject.GetComponent<ColorSync>();
        //_hp = GetComponent<HpFloatSync>();
        //coll = meshObject.GetComponent<CapsuleCollider>();
        textMesh = textMeshObject.GetComponent<TextMesh>();
        playerStats = GetComponent<PlayerStats>();
        playerStatsSync = GetComponent<PlayerStatsSync>();
    }

    void Start()
    {
        //hp = 100;
        //_hp.setHp(hp);
        //playerStats._health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (playerStats._health <= 0 && !dead) // can also just use localHP variable?
        {
            print("player ded");
            dead = true;
        }
        else if (playerStats._health <= 25 && !dead)
        {
            // _colorSync.SetColor(new Color(200, 50, 50));
        }
        else if (playerStats._health <= 50 && !dead)
        {
        
        }
        */
        textMesh.text = "HP: " + playerStats._health; // change dis

    }

    public void OnCollisionEnter(Collision collision) // Works. NOtice that the object needs Bullet tag AND collider AND probably both realtimeview and transform.
    {
        /*
        foreach (ContactPoint contact in collision.contacts) // Use contact.GetContacts() instead, No garbage
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            //Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        */
        /*
        ContactPoint cp = collision.GetContact(0); // ??
        
        if (cp.thisCollider.name == "HeadCollider" && collision.collider.CompareTag("Bullet"))
        {
            //hp -= 50;
            //_hp.setHp(_hp.GetHp() - 50);
            playerStats._health = playerStats._health - 50;
            //print("Head hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "TorsoCollider" && collision.collider.CompareTag("Bullet"))
        {
            //hp -= 35;
            //_hp.setHp(_hp.GetHp() - 35);
            //print("Torso hit, HP: " + _hp.GetHp());
            playerStats._health = playerStats._health - 10;
            //Destroy(collision.collider.gameObject.GetComponentInParent<GameObject>());
        }
        
        if (cp.thisCollider.name == "RightThighCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftThighCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            //hp -= 20;
            //_hp.setHp(_hp.GetHp() - 20);
            //print("Thighs hit, HP: " + _hp.GetHp());
            playerStats._health = playerStats._health - 20;
        }
        if (cp.thisCollider.name == "RightShinCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftShinCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            //hp -= 10;
            //_hp.setHp(_hp.GetHp() - 10);
            //print("Shins hit hit, HP: " + _hp.GetHp());
            playerStats._health = playerStats._health - 10;
        }
        if (cp.thisCollider.name == "RightUpperArmCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftUpperArmCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            //hp -= 15;
            //_hp.setHp(_hp.GetHp() - 15);
            //print("UpperArms hit, HP: " + _hp.GetHp());
            playerStats._health = playerStats._health - 15;
        }

        if (cp.thisCollider.name == "RightLowerArmCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftLowerArmCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            //hp -= 7.5f;
            //_hp.setHp(_hp.GetHp() - 7.5f);
            //print("LowerArms HP: " + _hp.GetHp());
            playerStats._health = playerStats._health - 7.5f;
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            //collision.gameObject.SetActive(false);
            Realtime.Destroy(collision.collider.gameObject);
        }*/
        /*
        if (collision.collider.CompareTag("SpawnArea") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print(" DEAD SpawnArea collider - HP RESET");
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ReviveCapsule") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            //print("ONTRIGGERENTER - DEAD SpawnArea collider - HP RESET");
        }

        if (other.name == "Team1")
        {
            playerStats._team = 1;
            print("team1 chosen - Player behavior");
        }
        if (other.name == "Team2")
        {
            playerStats._team = 2;
            print("team2 chosen - Player behavior");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (playerStats._team == 1 && other.CompareTag("Spawnarea_Blue"))
        {
            //GetComponent<GameModeLogic>().debugText.GetComponent<TextMesh>().text = "is ready set to true";
            playerStats._isReady = true;
            //isPlayerReady = true;
        }
        else if (playerStats._team == 2 && other.CompareTag("Spawnarea_Blue")) // Change to red spawnarea
        {
            //GetComponent<GameModeLogic>().debugText.GetComponent<TextMesh>().text = "is ready set to true";
            playerStats._isReady = true;
        }
        /*
        else
        {
            playerStats._isReady = false;
        }*/

    }
    public void resetHp()
    {
        //currentHp_Local = 100;
        dead = false;
        //hp = 100;
        playerStats._health = 100;
        //_colorSync.SetColor(new Color(255,255,255));
        //gameObject.SetActive(true);
        print("Hp reset method called");
        meshObject.GetComponent<MeshRenderer>().enabled = true;
    }
    /*
    private Color updateColor()
    {
        _redAmount += 40;
        Color _color = new Color(_redAmount, 0, 0);
        return _color;
    }
    */
    /*
    public void healthRegain()
    {
        if (_hp.GetHp() <= 100) {
            //currentHp_Local += 1; // *time.deltaTime typecast to int.
            _hp.setHp(_hp.GetHp() +1);
        }else
        {
            //gameObject.SetActive(true);
        }
    }*/
}

