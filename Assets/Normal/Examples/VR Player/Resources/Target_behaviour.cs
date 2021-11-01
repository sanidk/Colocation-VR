using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Target_behaviour : MonoBehaviour
{
    private Collider _playerHitbox;
    private Color _color;
    private float _redAmount = 0;
    private int currentHp_Local = 100;
    private int previousHp_Local;
    //private int hp = 100;
    // Start is called before the first frame update

    private bool dead;
    private HPSync _hp;
    TextMesh textMesh;

    private void Awake()
    {
        _playerHitbox = GetComponent<BoxCollider>();
        _color = new Color(0, 0, 0);
        _hp = GetComponent<HPSync>();
        textMesh = GetComponentInChildren<TextMesh>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp_Local != previousHp_Local)
        {
            textMesh.text = "Hp_Networked: " + _hp.GetHp() + "Hp_local: " + currentHp_Local;
            previousHp_Local = currentHp_Local;
        }
        if (_hp.GetHp() <= 0 && !dead) // can also just use localHP variable?
        {
            print("player ded");
            dead = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
            Realtime.Destroy(gameObject);
        }
        else if(_hp.GetHp() < 25 && !dead)
        {
            //_colorSync.SetColor(new Color(255, 0, 0));
        }
        
    }

    private void OnCollisionEnter(Collision collision) // Works. NOtice that the object needs Bullet tag AND collider AND probably both realtimeview and transform.
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            currentHp_Local -= 20;
            _hp.setHp(currentHp_Local);


            //trying to destroy bullets, once they hit the object.should probably be done on the bullet  prefab though.
            //collision.gameObject.GetComponent<RealtimeView>().enabled = false;
            //collision.gameObject.GetComponent<RealtimeTransform>().enabled = false;
            //Realtime.Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }
    }

    private Color updateColor()
    {
        _redAmount += 40;
        _color = new Color(_redAmount, 0, 0);
        return _color;
    }
}
