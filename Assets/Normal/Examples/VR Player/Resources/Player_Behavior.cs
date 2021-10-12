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

    private void Awake()
    {
        //_colorSync = GetComponentInChildren<ColorSync>();
        _colorSync = meshObject.GetComponent<ColorSync>();
        _hp = GetComponent<HpFloatSync>();
        //coll = meshObject.GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        _hp.setHp(currentHp_Local); //
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp.GetHp() <= 0 && !dead) // can also just use localHP variable?
        {
            print("player ded");
            dead = true;
            _colorSync.SetColor(new Color(255,0,0));
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
        print("OnCollisionEnter-Method run");
        if (collision.collider.CompareTag("Bullet"))
        {
            //currentHp_Local -= 20;
            _hp.setHp(_hp.GetHp() - 20);
            print("HIT! HP: " + _hp.GetHp());
        }
        else if (collision.collider.CompareTag("SpawnArea") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
            print("SpawnArea collider - HP RESET");
        }
    }

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


    public void resetHp()
    {
        //currentHp_Local = 100;
        _hp.setHp(100);
        dead = false;
        _colorSync.SetColor(new Color(255,255,255));
        //gameObject.SetActive(true);
        print("Hp reset method called");
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