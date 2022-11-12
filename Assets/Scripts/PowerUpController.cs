using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public string[ ] TagList = new string[ ]{"ObrotowySwiat", "Input", "Sloik"} ;
    [SerializeField] private GameObject ArenaObject;
    private MapMovement mapMovement;

    void Start()
    {
        this.tag = TagList[Random.Range(0, 3)];
        mapMovement = ArenaObject.GetComponent<MapMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter()
    {
        switch (this.tag)
        {
            case "ObrotowySwiat":
                ObrotowySwiat();
                break;
            case "Input":
                print("Hello and good day!");
                break;
            case "Sloik":
                Input();
                break;
            default:
                Sloik();
                break;
        }
    }

        void ObrotowySwiat()
        {
            mapMovement.rotatebool = !mapMovement.rotatebool;
        }
        void Input()
        {
            
        }
        void Sloik()
        {
            
        } 
    }

