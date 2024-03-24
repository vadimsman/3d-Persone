using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public UnityEngine.GameObject GameplayUI;
    public UnityEngine.GameObject WinUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectsOfType<EnemyHealth>().Length <= 0)
        {
            GameplayUI.SetActive(false);
            WinUI.SetActive(true);
            GetComponent<ReloadOnEscape>().enabled = true;
        }
    }
}
