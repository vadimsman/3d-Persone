﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float damage = 50;
    public float delay = 3;
    public UnityEngine.GameObject ExplosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var Explosion = Instantiate(ExplosionPrefab);
        Explosion.transform.position = transform.position;
        Explosion.GetComponent<Explosion>().Damage = damage;
    }
}
