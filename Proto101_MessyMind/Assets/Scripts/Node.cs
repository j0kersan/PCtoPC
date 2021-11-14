using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int NodeNumber;

    public TextMesh TextMeshRef;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateNode()
    {
        TextMeshRef = GetComponent<TextMesh>();
        TextMeshRef.text = NodeNumber.ToString();
    }
}
