using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public void PlayerInteract()
    {
        Inventory.main.hasKey = true;

        Destroy(gameObject);
    }
}
