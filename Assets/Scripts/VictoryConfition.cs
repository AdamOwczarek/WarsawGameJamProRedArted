using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryConfition : MonoBehaviour
{
    [SerializeField] Collider collider;
    [SerializeField] private GameObject victoryPanel;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player1")
        {
            victoryPanel.SetActive(true);
        }
       
        
    }
}
