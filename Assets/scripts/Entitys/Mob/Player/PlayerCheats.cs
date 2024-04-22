using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheats : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    public void EnableNoClip() 
    {
        GetComponent<Collider2D>().isTrigger = !GetComponent<Collider2D>().isTrigger;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) 
        {
            EnableNoClip();
        }
    }
}
