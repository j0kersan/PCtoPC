using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    //Platform Positions
    public List<Node> nodes = new List<Node>();


    //Empêcher les plateformes de bouger si le bouton est pressé mais que le personnage ne bouge pas
    public CharacterControls charaControls;

    /*public Transform pos1, pos2, pos3;*/
    public Transform startPos;
    public Transform currentPos;

    //public BoxCollider2D box;

    //Quand les plateformes bougent
    public bool onTheMove;

    //Platform MoveSpeed
    public float speed;

    public int nextNodeID = 0;

    public bool isReversed = false;

    Vector3 nextPos;


    // Start is called before the first frame update
    void Start()
    {
            //nextPos = startPos.position;
        MovePlatform();
    }

    void OnDrawGizmos()
    {
        foreach (var item in nodes)
        {
            Vector3 fromPosition = transform.position;
            Vector3 toPosition = item.transform.position;
            Vector3 direction = toPosition - fromPosition;

            Gizmos.color = Color.red;
            //Vector3 direction = item.transform.TransformDirection(Vector3.forward);
            Gizmos.DrawRay(transform.position, direction);
            //Debug.DrawLine(transform.position, item.transform.position);
            UpdateNodes();
        }

    }



    // Update is called once per frame
    void Update()
    {


        onTheMove = false;

        

        #region MoveCond
        /*if (charaControls.powerAct == false)
        {
            //Si le joueur bouge, la plateforme bouge à sa seconde position
            if (transform.position == pos1.position && charaControls.keyRight == true || transform.position == pos1.position && charaControls.keyLeft == true)
            {
                nextPos = pos2.position;
            }

            //Si le joueur bouge, la plateforme bouge à sa troisième position
            if (transform.position == pos2.position && charaControls.keyRight == true || transform.position == pos2.position && charaControls.keyLeft == true)
            {
                nextPos = pos3.position;
            }

            //Si le joueur bouge, la plateforme bouge à sa première position
            if (transform.position == pos3.position && charaControls.keyRight == true || transform.position == pos3.position && charaControls.keyLeft == true)
            {
                nextPos = pos1.position;
            }
        }*/
        #endregion




        /*#region PlatState

        do
        {

            box.enabled = false;
            Debug.Log("Collider disabled");
        }
        while (onTheMove == true);

        #endregion*/

        #region PlayerMoveCond

        /* if (currentPos.position != pos1.position || currentPos.position != pos2.position || currentPos.position != pos3.position)
         {

             onTheMove = true;

         }

         if (currentPos.position == pos1.position || currentPos.position == pos2.position || currentPos.position == pos3.position)
         {

             onTheMove = false;

         }*/

        #endregion

    }
    
    void UpdateNodes()
    {
        for (var i = 0; i < nodes.Count; i++)
        {
            nodes[i].NodeNumber = i;
            nodes[i].UpdateNode();
        }
    }

    public int NextNode()
    {
        if (!isReversed)
        {
            if (nextNodeID < nodes.Count - 1)
            {
                nextNodeID++;
            }
            else if (nextNodeID == nodes.Count - 1)
            {
                isReversed = true;
            }
        }

        if(isReversed)
        {
            if (nextNodeID > 0)
            {
                nextNodeID++;
            }
            else if (nextNodeID == 0)
            {
                isReversed = false;
            }
        }

        return nextNodeID;
    }

    public void MovePlatform()
    {
        //nextPos = nodes[nextNodeID].transform.position;
        NextNode();
        transform.position = Vector3.MoveTowards(transform.position, nodes[nextNodeID].transform.position, speed * Time.deltaTime);
    }
}
