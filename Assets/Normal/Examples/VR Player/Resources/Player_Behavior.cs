using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Player_Behavior : MonoBehaviour
{
    private Collider _playerHitbox;
    private Color _color;
    private int currentHp_Local = 100;
    private ColorSync _colorSync;
    private bool dead;
    private HPSync _hp;
    private float _redAmount = 0;

    //public GameObject meshObject;
    //public GameObject Hitbox_Head;
    //public GameObject Hitbox_Torso;

    private void Awake()
    {
        _playerHitbox = GetComponent<BoxCollider>();
        _colorSync = GetComponent<ColorSync>();
        _color = new Color(0, 0, 0);
        _hp = GetComponent<HPSync>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_hp.GetHp() <= 0 && !dead) // can also just use localHP variable?
        {
            print("player ded");
            dead = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
            Realtime.Destroy(gameObject);
        }
        else if (_hp.GetHp() < 25 && !dead)
        {

            //meshObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            _colorSync.SetColor(new Color(255, 0, 0));
        }
        else if (_hp.GetHp() < 50 && !dead)
        {

            //meshObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            _colorSync.SetColor(new Color(255, 255, 0));
        }


    }

    void OnCollisionEnter(Collision collision) // Works. NOtice that the object needs Bullet tag AND collider AND probably both realtimeview and transform.
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            currentHp_Local -= 20;
            _hp.setHp(currentHp_Local);
            print("HIT! HP: " + _hp.GetHp());
        }
        else if (collision.collider.CompareTag("SpawnArea") && dead) // Create spawn area tag or something else to check on.
        {
            resetHp();
        }
    }


    private void resetHp()
    {
        currentHp_Local = 100;
        _hp.setHp(currentHp_Local);
        dead = false;
        _colorSync.SetColor(_color);
    }

    private Color updateColor()
    {
        _redAmount += 40;
        _color = new Color(_redAmount, 0, 0);
        return _color;
    }
}
