using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public void Pickup(PlayerController playerController){
        Destroy(gameObject);
    }
}
