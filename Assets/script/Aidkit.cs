
using System;
using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float healAmount = 50;
  
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }

    
    
    void Update()
    {
        
    }
}
