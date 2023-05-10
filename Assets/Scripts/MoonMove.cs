using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMove : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 10f, 500f) - 250f, transform.position.y, transform.position.z);       
    }
}
