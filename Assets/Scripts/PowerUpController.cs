using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private string[ ] TagList = new string[ ]{"map", "input", "swap", "jar"} ;
    [SerializeField] private GameObject ArenaObject;
    private MapMovement mapMovement;
    private int arenaBorderXPos=4;
    private int arenaBorderXNeg=-4;
    private int arenaBorderZPos=4;
    private int arenaBorderZNeg=-4;
   [SerializeField] Collider collider;
   [SerializeField] private SpriteRenderer renderer;
   [SerializeField] private Sprite mapSprite;
   [SerializeField] private Sprite inputSprite;
   [SerializeField] private Sprite jarSprite;
   [SerializeField] private Sprite swapSprite;
    void Start()
    {
        
        this.tag = TagList[Random.Range(0, TagList.Length)];
        if(this.tag == "map")
        {
            this.renderer.sprite = mapSprite;
        }
        else if (this.tag == "input")
        {
            this.renderer.sprite = inputSprite;
        }
        else if (this.tag ==  "swap")
        {
            this.renderer.sprite = swapSprite;
        }
        else if (this.tag == "jar")
        {
            this.renderer.sprite = jarSprite;
        }
    

        
        mapMovement = ArenaObject.GetComponent<MapMovement>();
        this.transform.position = new Vector3(Random.Range(arenaBorderXNeg, arenaBorderXPos), 0.4f,
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
            this.transform.position = new Vector3(Random.Range(arenaBorderXNeg, arenaBorderXPos), 0.4f,
                Random.Range(arenaBorderZNeg, arenaBorderZPos));
        }
        
    }
}

