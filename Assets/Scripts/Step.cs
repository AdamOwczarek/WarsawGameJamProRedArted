using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    // Start is called before the first frame update

    public void move(Vector3 v)
    {
        transform.Translate(v);
    }

    public void myStart(Vector3 v)
    {
        transform.position = new Vector3(v.x, v.y, v.z);
        //GetComponent<ParticleSystem>().startSize = 3;
        
    }
    
    public void myEnd()
    {
        transform.Translate(new Vector3(30000, -3000, 0));
        GetComponent<ParticleSystem>().startSize = 0;
    }
    
    void Start()
    {
        GetComponent<ParticleSystem>().Play();
        //GetComponent<ParticleSystem>().startSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
