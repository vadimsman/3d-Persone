using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball FireballPrefabs;
    public Transform FireballSourceTransform;
    public Animator Animator;
    public float Damage = 10;
    public float CoolDown = 1000;
    public float CurrentCoolDown;
    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CurrentCoolDown <= 1)
        {
            CurrentCoolDown = CoolDown;
            var Fireball = Instantiate(FireballPrefabs, FireballSourceTransform.position, FireballSourceTransform.rotation);
            Fireball.Damage = Damage;
            Audio.Play();
            CurrentCoolDown = CoolDown;
        }
        CoolDownUpdate();
    }

    void CoolDownUpdate()
    {
        if (CurrentCoolDown > 0)
        {
            CurrentCoolDown -= 1;
        }
    }
}
