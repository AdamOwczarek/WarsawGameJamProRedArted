using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryConfition1 : MonoBehaviour
{
    [SerializeField] Collider collider;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player2")
        {
            Debug.Log("Player2 won");
        }
       
        
    }
}
