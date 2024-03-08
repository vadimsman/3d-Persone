using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableGranade : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var GranadeCaster = other.gameObject.GetComponent<GranadeCaster>();
        if(GranadeCaster != null)
        {
            Destroy(gameObject);
            GranadeCaster.AddGranade();
        }
    }
}
