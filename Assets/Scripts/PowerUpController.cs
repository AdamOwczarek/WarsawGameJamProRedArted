using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public string[ ] TagList = new string[ ]{"ObrotowySwiat", "Input", "Sloik"} ;
    [SerializeField] private GameObject ArenaObject;
    private MapMovement mapMovement;
    private int arenaBorderXPos=5;
    private int arenaBorderXNeg=-5;
    private int arenaBorderZPos=5;
    private int arenaBorderZNeg=-5;
   [SerializeField] Collider collider;

    void Start()
    {
        
        this.tag = TagList[Random.Range(0, 3)];
        mapMovement = ArenaObject.GetComponent<MapMovement>();
        this.transform.position = new Vector3(Random.Range(arenaBorderXNeg, arenaBorderXPos), 0,
            Random.Range(arenaBorderZNeg, arenaBorderZPos));

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider collider)
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
        this.tag = TagList[Random.Range(0, 3)];
        this.transform.position = new Vector3(Random.Range(arenaBorderXNeg, arenaBorderXPos), 0,
            Random.Range(arenaBorderZNeg, arenaBorderZPos));
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

