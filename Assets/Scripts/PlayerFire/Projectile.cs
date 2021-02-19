using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collision2D))]
public class Projectile : MonoBehaviour
{
    
    public float speed;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);
        
        
    }
    void OnEnable()
    {
        GameObject[] powerUpObjects = GameObject.FindGameObjectsWithTag("PowerUp");

        foreach (GameObject PowerUp in powerUpObjects)
        {
            Physics2D.IgnoreCollision(PowerUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        GameObject[] collectibleObjects = GameObject.FindGameObjectsWithTag("Collectible");

        foreach (GameObject Collectible in collectibleObjects)
        {
            Physics2D.IgnoreCollision(Collectible.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.tag != "Mario")
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
        
        
    }
    
}
