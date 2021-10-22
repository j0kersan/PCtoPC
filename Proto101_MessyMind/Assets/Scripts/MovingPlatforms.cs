using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    //Platform Positions
    public Transform pos1, pos2, pos3;
    public Transform startPos;
    public Transform currentPos;

    //Empêcher les plateformes de bouger si le bouton est pressé mais que le personnage ne bouge pas
    public CharacterControls charaCond;

    //Quand les plateformes bougent
    public bool onTheMove;

    //Platform MoveSpeed
    public float speed;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {

        nextPos = startPos.position;

    }

    // Update is called once per frame
    void Update()
    {

        onTheMove = false;

        #region MoveCond
        //Si le joueur bouge, la plateforme bouge à sa seconde position
        if (transform.position == pos1.position && charaCond.keyRight == true || transform.position == pos1.position && charaCond.keyLeft == true)
        {
            nextPos = pos2.position;
        }

        //Si le joueur bouge, la plateforme bouge à sa troisième position
        if (transform.position == pos2.position && charaCond.keyRight == true || transform.position == pos2.position && charaCond.keyLeft == true)
        {
            nextPos = pos3.position;
        }

        //Si le joueur bouge, la plateforme bouge à sa première position
        if (transform.position == pos3.position && charaCond.keyRight == true || transform.position == pos3.position && charaCond.keyLeft == true)
        {
            nextPos = pos1.position;
        }
        #endregion


        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);


        #region PlayerMoveCond

        if(currentPos.position != pos1.position || currentPos.position != pos2.position || currentPos.position != pos3.position)
        {
            onTheMove = true;

        }

        if (currentPos.position == pos1.position || currentPos.position == pos2.position || currentPos.position == pos3.position)
                {
            onTheMove = false;

        }

        #endregion

    }
}
