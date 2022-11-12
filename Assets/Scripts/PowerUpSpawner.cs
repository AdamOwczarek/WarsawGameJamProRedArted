using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject PowerUpObject;

    void Start()
    {
        
        for (int i = 0; i < 3; i++)
        {
            Spawn();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(PowerUpObject,transform);
    }
   
}
