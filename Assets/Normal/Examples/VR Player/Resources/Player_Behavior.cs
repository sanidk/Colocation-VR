using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Player_Behavior : MonoBehaviour
{
    public int team;
    public bool isPlayerReady;
    public float hp = 100;

    //private float currentHp_Local;
    private ColorSync _colorSync;
    private bool dead;
    //private HPSync _hp;
    private float _redAmount = 0;

    private HpFloatSync _hp; // ADD COMPONENT TO PLAYER

    public GameObject meshObject;
    Collider coll;
    //public GameObject Hitbox_Head;
    //public GameObject Hitbox_Torso;
    private float previousHp_Local;

    public GameObject textMeshObject;
    TextMesh textMesh;

    private void Awake()
    {
        //_colorSync = GetComponentInChildren<ColorSync>();
        _colorSync = meshObject.GetComponent<ColorSync>();
        _hp = GetComponent<HpFloatSync>();
        //coll = meshObject.GetComponent<CapsuleCollider>();
        textMesh = textMeshObject.GetComponent<TextMesh>();
    }

    void Start()
    {
        hp = 100;
        _hp.setHp(hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp != previousHp_Local)
        {
            _hp.setHp(hp);
            textMesh.text = "Hp: " + _hp.GetHp();
            previousHp_Local = hp;
        }

        if (hp <= 0 && !dead) // can also just use localHP variable?
        {
            print("player ded");
            dead = true;
            _colorSync.SetColor(new Color(255,0,0));
            meshObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (hp <= 25 && !dead)
        {
            _colorSync.SetColor(new Color(200, 50, 50));
        }
        else if (hp <= 50 && !dead)
        {

            _colorSync.SetColor(new Color(255, 255, 0));
        }

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
        

        ContactPoint cp = collision.GetContact(0); // ??

        if (cp.thisCollider.name == "HeadCollider" && collision.collider.CompareTag("Bullet"))
        {
            hp -= 50;
            _hp.setHp(hp);
            print("Head hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "TorsoCollider" && collision.collider.CompareTag("Bullet"))
        {
            hp -= 35;
            _hp.setHp(hp);
            print("Torso hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "RightThighCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftThighCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            hp -= 20;
            _hp.setHp(hp);
            print("Thighs hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "RightShinCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftShinCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            hp -= 10;
            _hp.setHp(hp);
            print("Shins hit hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "RightUpperArmCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftUpperArmCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            hp -= 15;
            _hp.setHp(hp);
            print("UpperArms hit, HP: " + _hp.GetHp());
        }

        if (cp.thisCollider.name == "RightLowerArmCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftLowerArmCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            hp -= 7.5f;
            _hp.setHp(hp);
            print("LowerArms HP: " + _hp.GetHp());
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
        }
        /*
        if (collision.collider.CompareTag("SpawnArea") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print(" DEAD SpawnArea collider - HP RESET");
        }*/
    }

    /*

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("SpawnArea") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("ONCOLLISIONSTAY - DEAD SpawnArea collider - HP RESET");
        }
        if (collision.collider.CompareTag("SpawnArea") && !dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("ONCOLLISIONSTAY - Not DEAD SpawnArea collider - HP RESET");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ReviveCapsule") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            //print("ONTRIGGERENTER - DEAD SpawnArea collider - HP RESET");
        }

        if (team == 1 && other.CompareTag("Spawnarea_Blue"))
        {
            isPlayerReady = true;
        }
        else if (team == 2 && other.CompareTag("Spawnarea_Red"))
        {
            isPlayerReady = true;
        }
        else
        {
            isPlayerReady = false;
        }

        /*
        Collision collision = new Collision();

        ContactPoint cp = collision.GetContact(0);

        if (cp.thisCollider.name == "HeadCollider" && other.CompareTag("Bullet"))
        {
            currentHp_Local -= 50;
            _hp.setHp(currentHp_Local);
            print("Head hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "TorsoCollider" && other.CompareTag("Bullet"))
        {
            currentHp_Local -= 35;
            _hp.setHp(currentHp_Local);
            print("Torso hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "RightThighCollider" && other.CompareTag("Bullet") || cp.thisCollider.name == "LeftThighCollider"
            && other.CompareTag("Bullet"))
        {
            currentHp_Local -= 20;
            _hp.setHp(currentHp_Local);
            print("Thighs hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "RightShinCollider" && other.CompareTag("Bullet") || cp.thisCollider.name == "LeftShinCollider"
            && other.CompareTag("Bullet"))
        {
            currentHp_Local -= 10;
            _hp.setHp(currentHp_Local);
            print("Shins hit hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "RightUpperArmCollider" && other.CompareTag("Bullet") || cp.thisCollider.name == "LeftUpperArmCollider"
            && other.CompareTag("Bullet"))
        {
            currentHp_Local -= 15;
            _hp.setHp(currentHp_Local);
            print("UpperArms hit, HP: " + _hp.GetHp());
        }

        if (cp.thisCollider.name == "RightLowerArmCollider" && other.CompareTag("Bullet") || cp.thisCollider.name == "LeftLowerArmCollider"
            && other.CompareTag("Bullet"))
        {
            currentHp_Local -= 7.5f;
            _hp.setHp(currentHp_Local);
            print("LowerArms HP: " + _hp.GetHp());
        }

        if (other.CompareTag("Bullet"))
        {
            currentHp_Local -= 2;
            _hp.setHp(currentHp_Local);
            print("DefaultIstrigger HP: " + _hp.GetHp());
        }*/


        /*
        if (other.CompareTag("SpawnArea") && !dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("ONTRIGGERENTER - Not DEAD SpawnArea collider - HP RESET");
        }*/
    }

    public void resetHp()
    {
        //currentHp_Local = 100;
        dead = false;
        hp = 100;
        _colorSync.SetColor(new Color(255,255,255));
        //gameObject.SetActive(true);
        print("Hp reset method called");
        meshObject.GetComponent<MeshRenderer>().enabled = true;
    }

    private Color updateColor()
    {
        _redAmount += 40;
        Color _color = new Color(_redAmount, 0, 0);
        return _color;
    }

    public void healthRegain()
    {
        if (_hp.GetHp() <= 100) {
            //currentHp_Local += 1; // *time.deltaTime typecast to int.
            _hp.setHp(_hp.GetHp() +1);
        }else
        {
            //gameObject.SetActive(true);
        }
    }
}
