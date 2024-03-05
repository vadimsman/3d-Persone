using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    public float Damage = 10;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireball", LifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }


    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.Value -= Damage;
            if (enemyHealth.Value <= 0)
            {
                Destroy(enemyHealth.gameObject);
            }
        }

        Destroy(gameObject);
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
