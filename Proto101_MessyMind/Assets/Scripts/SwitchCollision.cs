using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCollision : MonoBehaviour
{
    public GameObject door;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        door.transform.position += new Vector3(4, 0, 0);
    }
}
