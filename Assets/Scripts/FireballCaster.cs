using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball FireballPrefabs;
    public Transform FireballSourceTransform;
    public Animator Animator;
    public float Cooldown = 1f;

    private bool _isShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isShoot == false)
        {
            StartCoroutine(Shoot());
        }
    }
    public IEnumerator Shoot()
    {
        _isShoot = true;
        Animator.SetTrigger("Fireball");
        yield return new WaitForSeconds(Cooldown);
        Instantiate(FireballPrefabs, FireballSourceTransform.position, FireballSourceTransform.rotation);
        _isShoot = false;
    }
}
