using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collision2D))]
public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Mario")
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }
}