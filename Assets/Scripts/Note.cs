using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    public float speed;


    private void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
    }
}
