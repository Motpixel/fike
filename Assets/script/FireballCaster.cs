using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform fireballSourceTransform;
    [SerializeField] private float reloadTime = 1;

    private float _timer;   
  
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _timer <= 0) 
        {
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            _timer = reloadTime;
        }
        if (_timer <= 0) return;
        _timer -= Time.deltaTime;
    }
}
