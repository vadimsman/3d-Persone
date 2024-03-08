﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Damage = 50;
    public float MaxSize = 8;
    public float Speed = 4;
    void Start()
    {
        transform.localScale = Vector3.zero; 
    }

    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * Speed;
        if (transform.localScale.x > MaxSize)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var PlayerHealth = other.GetComponent<PlayerHealth>();
        if (PlayerHealth != null)
        {
            PlayerHealth.DealDamage(Damage);
        }

        var EnemyHealth = other.GetComponent<EnemyHealth>();
        if (EnemyHealth != null)
        {
            EnemyHealth.Value -= Damage;
            if (EnemyHealth.Value <= 0)
            {
                Destroy(EnemyHealth.gameObject);
            }
        }
    }
}
