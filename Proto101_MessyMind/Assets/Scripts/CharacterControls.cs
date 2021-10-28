using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{

    public MovingPlatforms moveCond;

    //Quand les touches sont pressés
    public bool keyLeft;
    public bool keyRight;
    public bool powerAct;

    public int charaStep;

    // Update is called once per frame
    void Update()
    {

        keyRight = false;
        keyLeft = false;

        
        #region CharaMoves

        if (Input.GetKeyDown("left") && moveCond.onTheMove == false)
        {
            transform.localPosition += new Vector3(-2, 0, 0);
            keyLeft = true;
            charaStep += 1;
        }

        if (Input.GetKeyDown("right") && moveCond.onTheMove == false)
        {
            transform.localPosition += new Vector3(2, 0, 0);
            keyRight = true;

            charaStep += 1;
        }



        #endregion

        #region CharaPowers

        if (Input.GetKeyDown("f"))
        {          
            StartCoroutine(powerStart());
        }

        IEnumerator powerStart()
        {
            powerAct = true;
            charaStep = 0;
            Debug.Log("Coroutine lancé");

            yield return new WaitUntil(() => charaStep == 4);

                if (charaStep == 4)
                {
                    powerAct = false;
                    Debug.Log("Pouvoir arrété");
                    yield break;
                }

            Debug.Log("Stop Coroutine");
            
        }
        #endregion
    }

}
