using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaw : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x -1, transform.position.y, transform.position.z);
    }
}
