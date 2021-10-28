using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject door;

    public float speed;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        door.transform.position += new Vector3(0, -10, 0);
    }
}
