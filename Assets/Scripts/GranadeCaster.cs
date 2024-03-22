using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GranadeCaster : MonoBehaviour
{
    public float damage = 50;

    public int MaxGrenade;
    public int CurrentGrenade;
    public Rigidbody GrenadePrefab;
    public Transform GrenadeSourceTransform;
    public float Force = 500;
    public TMP_Text TextCurrentGrenade;

    private void Update()
    {
        if (Input.GetKey(KeyCode.G) && CurrentGrenade > 0)
        {
            CurrentGrenade -= 1;
            var grenade = Instantiate(GrenadePrefab);
            grenade.transform.position = GrenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(GrenadeSourceTransform.forward * Force);
            grenade.GetComponent<Grenade>().damage = damage;
        }
        UpdateTextCurrentGranede();
    }

    public void AddGranade()
    {
        bool GranadePick = false;
        if(CurrentGrenade < MaxGrenade && GranadePick == false)
        {
            GranadePick = true;
            CurrentGrenade += 1;
        }
    }
    
    public void UpdateTextCurrentGranede()
    {
        TextCurrentGrenade.text = CurrentGrenade.ToString();
    }
}
