using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    public List<MovingPlatforms> platformList = new List<MovingPlatforms>();

    public MovingPlatforms moveCond;

    public GameObject wallsDetector;

    //Quand les touches sont pressés
    public bool keyLeft;
    public bool keyRight;
    public bool powerAct;
    public bool powerUse;

    //Nombres de pas du joueurs
    public int charaStep;

    public string platform;

    // Update is called once per frame
    private void Start()
    {
        powerUse = true;
        var objects = GameObject.FindGameObjectsWithTag("Platforms");

        for(var i=0; i<objects.Length; i++)
        {
            platformList.Add(objects[i].GetComponent<MovingPlatforms>());
        }


        //platform = gameObject.tag == "platform";
    }
    void Update()
    {

        //Conditions d'utilisation des mouvements
        #region CharaMoves

        if (Input.GetKeyDown("left") && moveCond.onTheMove == false)
        {
            transform.localPosition += new Vector3(-2, 0, 0);
            keyLeft = true;
            charaStep += 1;
            PlatformMoves();
        }

        if (Input.GetKeyDown("right") && moveCond.onTheMove == false)
        {
            transform.localPosition += new Vector3(2, 0, 0);
            keyRight = true;

            charaStep += 1;
            PlatformMoves();
        }

        #endregion


        //Conditions d'utilisation des pouvoirs du personnage
        #region CharaPowers

        if (Input.GetKeyDown("f") && powerUse == true)
        {          
            StartCoroutine(powerStart());
        }

        IEnumerator powerStart()
        {
            powerAct = true;
            powerUse = false;
            charaStep = 0;
            Debug.Log("Coroutine lancé");

            yield return new WaitUntil(() => charaStep == 4);

                if (charaStep == 4)
                {
                    powerAct = false;
                    Debug.Log("Pouvoir arrété");

                yield return StartCoroutine(powerReset());
                }
            
        }

        IEnumerator powerReset()
        {
            Debug.Log("Reset en cours");
            yield return new WaitUntil(() => charaStep == 11);

            if (charaStep == 11)
            {
                powerUse = true;
                Debug.Log("Pouvoir reset");
                yield break;
            }
        }
        #endregion
    }

    void PlatformMoves()
    {
        foreach (var item in platformList)
        {

            item.MovePlatform();


        }

    }
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "platform")
         {
             Physics2D.IgnoreCollision(platform.GetComponent<Collider2D>, GetComponent<Collider2D>);
         }
     }*/

}
