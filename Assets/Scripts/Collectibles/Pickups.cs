using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    // Start is called before the first frame update
    public enum  CollectibleType
    {
        POWERUP,
        COLLECTIBLE,
        LIVES,
        KEY,
        YOSHICOIN
    }
    public CollectibleType currentCollectible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (currentCollectible)
        {
            case CollectibleType.POWERUP:
                Debug.Log("Powerup");
                collision.GetComponent<PlayerMovement>().StartJumpForceChange();
                Destroy(gameObject);
                break;
            case CollectibleType.LIVES:
                Debug.Log("Lives");
                collision.GetComponent<PlayerMovement>().lives++;
                Destroy(gameObject);
                break;
            case CollectibleType.COLLECTIBLE:
                Debug.Log("Collectible");
                collision.GetComponent<PlayerMovement>().score++;
                Destroy(gameObject);
                break;
            case CollectibleType.YOSHICOIN:
                Debug.Log("Collectible");
                collision.GetComponent<PlayerMovement>().score++;
                Destroy(gameObject);
                break;
        }
    }
   
}
