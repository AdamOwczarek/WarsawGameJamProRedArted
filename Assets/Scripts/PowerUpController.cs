using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private string[ ] TagList = new string[ ]{"map", "input", "swap", "jar"} ;
    [SerializeField] private GameObject ArenaObject;
    private MapMovement mapMovement;
    private int arenaBorderXPos=5;
    private int arenaBorderXNeg=-5;
    private int arenaBorderZPos=5;
    private int arenaBorderZNeg=-5;
   [SerializeField] Collider collider;

    void Start()
    {
        
        this.tag = TagList[Random.Range(0, TagList.Length)];
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
        Debug.Log("siema");
        Debug.Log(collider.gameObject.name);
        PlayerMovement p = collider?.gameObject?.GetComponent<PlayerMovement>();
        if (p != null && !p.isFake)
        {
            p.fakeStart(this.tag);
            this.tag = TagList[Random.Range(0, TagList.Length)];
            this.transform.position = new Vector3(Random.Range(arenaBorderXNeg, arenaBorderXPos), 0,
                Random.Range(arenaBorderZNeg, arenaBorderZPos));
        }
        
    }
}

