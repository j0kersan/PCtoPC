using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{

    public MovingPlatforms moveCond;

    //Quand les touches sont pressés
    public bool keyLeft;
    public bool keyRight;


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
        }

        if (Input.GetKeyDown("right") && moveCond.onTheMove == false)
        {
            transform.localPosition += new Vector3(2, 0, 0);
            keyRight = true;
        }

       

        #endregion
    }

}
