﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxValue = 100;
    public Slider Healthbar;

    private float _currentValue;

    // Start is called before the first frame update
    void Start()
    {
        _currentValue = MaxValue;
        UpdateHealthBar();
    }

    // Update is called once per frame
    public void DealDamage(float damage)
    {
        _currentValue -= damage;
        if (_currentValue <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        Healthbar.value = _currentValue;
    }
}