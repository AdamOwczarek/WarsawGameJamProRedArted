using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryConfition : MonoBehaviour
{
    [SerializeField] Collider collider;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject victoryPanel2;
    [SerializeField] private GameObject victoryPanel3;
    [SerializeField] private GameObject disactivate;
    public GameObject konfetti;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player1"))
        {
            victoryPanel.SetActive(true);
            victoryPanel2.SetActive(true);
            victoryPanel3.SetActive(true);
            disactivate.SetActive(false);
            konfetti.SetActive(false);
            konfetti.SetActive(true);
        }
       
        
    }
}
