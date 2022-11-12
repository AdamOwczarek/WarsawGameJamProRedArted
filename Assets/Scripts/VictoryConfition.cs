using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryConfition : MonoBehaviour
{
    [SerializeField] Collider collider;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player1")
        {
            Debug.Log("Player1 won");
        }
       
        
    }
}
