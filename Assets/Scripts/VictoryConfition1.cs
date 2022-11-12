using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryConfition1 : MonoBehaviour
{
    [SerializeField] Collider collider;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject victoryPanel2;
    [SerializeField] private GameObject victoryPanel3;
    [SerializeField] private GameObject disactivate;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player2"))
        {
            victoryPanel.SetActive(true);
            victoryPanel2.SetActive(true);
            victoryPanel3.SetActive(true);
            disactivate.SetActive(false);
        }
       
        
    }
}
