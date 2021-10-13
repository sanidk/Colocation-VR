using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Player_Behavior : MonoBehaviour
{
    private int currentHp_Local = 100;
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
        _hp.setHp(currentHp_Local);
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp.GetHp() != previousHp_Local)
        {
            textMesh.text = "Hp: " + _hp.GetHp();
            previousHp_Local = _hp.GetHp();
        }

        if (_hp.GetHp() <= 0 && !dead) // can also just use localHP variable?
        {
            print("player ded");
            dead = true;
            _colorSync.SetColor(new Color(255,0,0));
            meshObject.GetComponent<MeshRenderer>().enabled = false;
            //gameObject.SetActive(false);
            //Destroy(gameObject);
            //Realtime.Destroy(gameObject);
        }
        else if (_hp.GetHp() <= 25 && !dead)
        {

            //meshObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            _colorSync.SetColor(new Color(200, 50, 50));
        }
        else if (_hp.GetHp() <= 50 && !dead)
        {

            //meshObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            _colorSync.SetColor(new Color(255, 255, 0));
        }

    }

    public void OnCollisionEnter(Collision collision) // Works. NOtice that the object needs Bullet tag AND collider AND probably both realtimeview and transform.
    {
        
        foreach (ContactPoint contact in collision.contacts) // Use contact.GetContacts() instead, No garbage
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            //Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        

        ContactPoint cp = collision.GetContact(0);

        if (cp.thisCollider.name == "HeadCollider" && collision.collider.CompareTag("Bullet"))
        {
            _hp.setHp(_hp.GetHp() - 50);
            print("Head hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "TorsoCollider" && collision.collider.CompareTag("Bullet"))
        {
            _hp.setHp(_hp.GetHp() - 35);
            print("Torso hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "RightThighCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftThighCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            _hp.setHp(_hp.GetHp() - 20);
            print("Thighs hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "RightShinCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftShinCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            _hp.setHp(_hp.GetHp() - 10);
            print("Shins hit hit, HP: " + _hp.GetHp());
        }
        if (cp.thisCollider.name == "RightUpperArmCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftUpperArmCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            _hp.setHp(_hp.GetHp() - 15);
            print("UpperArms hit, HP: " + _hp.GetHp());
        }

        if (cp.thisCollider.name == "RightLowerArmCollider" && collision.collider.CompareTag("Bullet") || cp.thisCollider.name == "LeftLowerArmCollider"
            && collision.collider.CompareTag("Bullet"))
        {
            _hp.setHp(_hp.GetHp() - 7.5f);
            print("LowerArms HP: " + _hp.GetHp());
        }
        /*
        if (collision.collider.CompareTag("Bullet"))
        {
            //currentHp_Local -= 20;
            _hp.setHp(_hp.GetHp() - 20);
            print("HIT! HP: " + _hp.GetHp());
        }
        */
        if (collision.collider.CompareTag("SpawnArea") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print(" DEAD SpawnArea collider - HP RESET");
        }
        if (collision.collider.CompareTag("SpawnArea") && !dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("Not DEAD SpawnArea collider - HP RESET");
        }
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
        if (other.CompareTag("SpawnArea") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("ONTRIGGERENTER - DEAD SpawnArea collider - HP RESET");
        }
        if (other.CompareTag("SpawnArea") && !dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("ONTRIGGERENTER - Not DEAD SpawnArea collider - HP RESET");
        }
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SpawnArea") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("ONTRIGGERENTERSTAY - DEAD SpawnArea collider - HP RESET");
        }
        if (other.CompareTag("SpawnArea") && !dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("ONTRIGGERENTERSTAY - Not DEAD SpawnArea collider - HP RESET");
        }
    }*/


    /*
    public void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter-Method run");
        if (other.CompareTag("Bullet"))
        {
            //currentHp_Local -= 20;
            _hp.setHp(_hp.GetHp() - 20);
            print("HIT! HP: " + _hp.GetHp());
        }
        else if (other.CompareTag("SpawnArea") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("SpawnArea collider - HP RESET");
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "SpawnArea" && !dead)
        {
            healthRegain();
            print("SpawnAreaStay method");
        }
    }
    */


    public void resetHp()
    {
        //currentHp_Local = 100;
        dead = false;
        _hp.setHp(100);
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
