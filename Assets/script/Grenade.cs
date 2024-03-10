
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    public GameObject explosionPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }
    private void Explosion()
    {
        Destroy(gameObject);
        var explosion =  Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }


    void Update()
    {
        
    }
}
