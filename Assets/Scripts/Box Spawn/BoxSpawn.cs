using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public Pickups[] pickuplist;
    
    public void StartBoxSpawn()
    {
        
        Instantiate(pickuplist[Random.Range(0, pickuplist.Length )].gameObject, transform.position, Quaternion.identity);
        
    }
    
}
