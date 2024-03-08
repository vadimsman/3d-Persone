using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxValue = 100;
    public Slider Healthbar;
    public GameObject GameplayUI;
    public GameObject GameOverScreen;
    public Animator Animator;
    public CharacterController CharacterController;

    private float _currentValue;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ReloadOnEscape>().enabled = false;
        _currentValue = MaxValue;
        UpdateHealthBar();
    }

    // Update is called once per frame
    public void DealDamage(float damage)
    {
        _currentValue -= damage;
        if (_currentValue <= 0)
        {
            PlayerisDead();
        }
        UpdateHealthBar();
    }
    public void Update()
    {
        UpdateHealthBar();
    }

    public void AddHealth(float amount)
    {
        _currentValue += amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxValue);
    }
    void UpdateHealthBar()
    {
        Healthbar.value = _currentValue;
    }

    void PlayerisDead()
    {
        Animator.SetTrigger("isDeath");
        GameplayUI.SetActive(false);
        GameOverScreen.SetActive(true);
        GetComponent<FireballCaster>().enabled = false;
        Animator.SetTrigger("isDeath");
        GetComponent<CameraRotation>().enabled = false;
        CharacterController.height = 0;
        CharacterController.radius = 0.1f;
        GetComponent<PlayerController>().IsDeath = true;
        GetComponent<ReloadOnEscape>().enabled = true;
    }
}