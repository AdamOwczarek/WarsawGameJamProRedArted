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
        GetComponent<ParticleSystem>().Play();
    }
    
    public void myEnd()
    {
        GetComponent<ParticleSystem>().Stop();
    }
    
    void Start()
    {
        //GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
