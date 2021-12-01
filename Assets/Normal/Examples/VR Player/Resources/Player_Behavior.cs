using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Player_Behavior : MonoBehaviour
{
    public int team;
    public bool isPlayerReady;

    public GameObject spawnArrowNeutral;
    public GameObject spawnArrowRed;
    public GameObject spawnArrowBlue;


    public GameObject spawnAreaRedSide;
    public GameObject spawnAreaBlueSide;
    public GameObject chooseTeamObjects;

    //public float hp = 100;

    //private float currentHp_Local;
    //private ColorSync _colorSync;
    private bool dead;
    //private HPSync _hp;
    private float _redAmount = 0;

    //private HpFloatSync _hp; // ADD COMPONENT TO PLAYER
    public GameObject feedbackText;
    public TextMesh feedbackTextField;
    public GameObject meshObject;
    Collider coll;
    //public GameObject Hitbox_Head;
    //public GameObject Hitbox_Torso;
    private float previousHp_Local;

    public GameObject textMeshObject;
    TextMesh textMesh;

    PlayerStats playerStats;
    PlayerStatsSync playerStatsSync;

    Vector3 arrowStartScale;

    public GameObject skinnedMeshObject;
    public GameObject rightHand;
    public GameObject leftHand;

    public Material ghostMaterial;
    public Material defaultMaterial;

    public GameObject deadPostFX;
    public GameObject damagePostFX;
    public VignetteControl vignetteControl;

    public GameObject[] colliderObjects;
    float oldHealth = 100;

    GameObject gameManager;

    bool disableGunsOnce;

    Vector3 arrowTarget;
    private void Awake()
    {
        //_colorSync = GetComponentInChildren<ColorSync>();
        //_colorSync = meshObject.GetComponent<ColorSync>();
        //_hp = GetComponent<HpFloatSync>();
        //coll = meshObject.GetComponent<CapsuleCollider>();
        textMesh = textMeshObject.GetComponent<TextMesh>();
        playerStats = GetComponent<PlayerStats>();
        playerStatsSync = GetComponent<PlayerStatsSync>();
        skinnedMeshObject.GetComponent<SkinnedMeshRenderer>().material = defaultMaterial;
        feedbackTextField = feedbackText.GetComponent<TextMesh>();
        //deadPostFX = GameObject.Find("PostFXDead");

        deadPostFX = GameObject.Find("PostFXDead");
        damagePostFX = GameObject.Find("PostFXVignette");
        spawnAreaRedSide = GameObject.Find("SpawnAreaRedSide");
        spawnAreaBlueSide = GameObject.Find("SpawnAreaBlueSide");
        chooseTeamObjects = GameObject.Find("ChooseTeam");
        gameManager = GameObject.Find("GameManager");

        arrowStartScale = spawnArrowRed.transform.localScale;
        //arrowStartScale = spawnArrowRed.transform.localScale;

        oldHealth = playerStats._health;
    }

    void Start()
    {
        vignetteControl = damagePostFX.GetComponent<VignetteControl>();
        deadPostFX.SetActive(false);
        //hp = 100;
        //_hp.setHp(hp);
        //playerStats._health = 100;
    }



    // Update is called once per frame
    void Update()
    {
        if (GetComponent<RealtimeTransform>().isOwnedLocallySelf && dead)
        {
            //disable guns
            foreach (GameObject gun in gameManager.GetComponent<GameManagerLogic>().gunsList)
            {
                gun.SetActive(false);
            }
            disableGunsOnce = true;



        } else if (GetComponent<RealtimeTransform>().isOwnedLocallySelf && disableGunsOnce && !dead)
        {
            foreach(GameObject gun in gameManager.GetComponent<GameManagerLogic>().gunsList)
            {
                gun.SetActive(true);

            }
            disableGunsOnce = false;
        }


        //LocomotionControl(); // remember to disable for testing


        /*
        if (playerStats.hp != oldHealth)
        {
            //add directionality later maybe
            vignetteControl.vignetteIntensity = (100 - playerStats.hp) / 100 * 2;
            oldHealth = playerStats.hp;
        }
        */
        
        spawnArrowRed.SetActive(false);
        spawnArrowBlue.SetActive(false);
        spawnArrowNeutral.SetActive(false);


        if (playerStats._team == 0)
        {
            if (GetComponent<RealtimeTransform>().isOwnedLocallySelf)
            {
                TextFeedbackManager.feedbackText = "CHOOSE YOUR TEAM";
                arrowTarget = chooseTeamObjects.transform.position;
                spawnArrowNeutral.SetActive(true);
                Vector3 lookVector = arrowTarget - spawnArrowNeutral.transform.position;
                spawnArrowNeutral.transform.rotation = Quaternion.LookRotation(new Vector3(lookVector.x, 0, lookVector.z));
                spawnArrowNeutral.transform.localScale = arrowStartScale * (Mathf.Pow((Mathf.Sin(Time.time)), 2) + 1) / 2;
            }
            
        }


        //Create arrow to spawn point
        if (GetComponent<RealtimeTransform>().isOwnedLocallySelf && dead) // ADD IF EDEAD
        {
            
            
            TextFeedbackManager.feedbackText = "YOU DIED - RETURN TO SPAWN";
            if (playerStats._team == 1)
            {
                spawnArrowBlue.SetActive(true);
                arrowTarget = spawnAreaBlueSide.transform.position;
                spawnArrowBlue.transform.rotation = Quaternion.LookRotation(arrowTarget - spawnArrowBlue.transform.position);
                spawnArrowBlue.transform.localScale = arrowStartScale * (Mathf.Pow((Mathf.Sin(Time.time)), 2) + 1) / 2;
                //blue
            } else if (playerStats._team == 2)
            {
                //red
                spawnArrowRed.SetActive(true);
                arrowTarget = spawnAreaRedSide.transform.position;
                spawnArrowRed.transform.rotation = Quaternion.LookRotation(arrowTarget - spawnArrowRed.transform.position);
                spawnArrowRed.transform.localScale = arrowStartScale * (Mathf.Pow((Mathf.Sin(Time.time)), 2) + 1) / 2;
            }
            //arrow pointing towards player spawn
            

            
        } 

        if (GetComponent<RealtimeTransform>().isOwnedLocallySelf)
        {
            if (playerStats._health != oldHealth)
            {
                vignetteControl.vignetteIntensity = (100 - playerStats._health) / 100 * 2;
                oldHealth = playerStats._health;
            }
            if (skinnedMeshObject.GetComponent<SkinnedMeshRenderer>().enabled)
            {
                skinnedMeshObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }


        }



        if (playerStats._health <= 0 && !dead)//&& !skinnedMeshObject.GetComponent<SkinnedMeshRenderer>().material == ghostMaterial) // need logic to check for revive or new round
        {
            dead = true;
            skinnedMeshObject.GetComponent<SkinnedMeshRenderer>().material = ghostMaterial;

            foreach (GameObject obj in colliderObjects)
            {
                obj.SetActive(false);
            }

            if (GetComponent<RealtimeTransform>().isOwnedLocallySelf)
            {
                deadPostFX.SetActive(true);
                //rightHand.SetActive(false);
                //leftHand.SetActive(false);
            
                
            }
            

        }
        if (playerStats._health > 0 && dead)
        {
            skinnedMeshObject.GetComponent<SkinnedMeshRenderer>().material = defaultMaterial;
            dead = false;

            foreach (GameObject obj in colliderObjects)
            {
                obj.SetActive(true);
            }

            if (GetComponent<RealtimeTransform>().isOwnedLocallySelf)
            {
                deadPostFX.SetActive(false);
                //rightHand.SetActive(true);
                //leftHand.SetActive(true);
                //print("Player alive / revived");
                
                
            }
        }
            textMesh.text = "HP: " + playerStats._health; // change dis
            if (!GetComponent<RealtimeTransform>().isOwnedLocallySelf)
            {
            TextFeedbackManager.feedbackText = "";
            }

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
                if (GetComponent<RealtimeTransform>().isOwnedLocallySelf)
                {
                    other.GetComponentInParent<GameObject>().SetActive(false);
                }
                
                print("team1 chosen - Player behavior");
            }
            if (other.name == "Team2")
            {
                playerStats._team = 2;
                if (GetComponent<RealtimeTransform>().isOwnedLocallySelf)
                {
                    other.GetComponentInParent<GameObject>().SetActive(false);
                }
            //Destroy(other.GetComponentInParent<GameObject>());
            print("team2 chosen - Player behavior");
            }
        }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spawnarea_Blue"))
        {
            //GetComponent<GameModeLogic>().debugText.GetComponent<TextMesh>().text = "is ready set to true";
            playerStats._isReady = false;
            //isPlayerReady = true;
        }
        if (other.CompareTag("Spawnarea_Red"))
        {
            //GetComponent<GameModeLogic>().debugText.GetComponent<TextMesh>().text = "is ready set to true";
            playerStats._isReady = false;
            //isPlayerReady = true;
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
            else if (playerStats._team == 2 && other.CompareTag("Spawnarea_Red")) // Change to red spawnarea
            {
                //GetComponent<GameModeLogic>().debugText.GetComponent<TextMesh>().text = "is ready set to true";
                playerStats._isReady = true;
            }
            //else
            //{
            //    playerStats._isReady = false;
            //}

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

