using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();          
    }
    private void DamageEnemy(Collision collision)
    {
        if (!collision.transform.root.TryGetComponent(out EnemyHealth enemyHealth)) return;
        enemyHealth.DealDamage(damage);
    }


    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
