using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapMovement : MonoBehaviour
{
    public float smooth;

    public bool rotatebool=true;

    private int rotationAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateMap();
    }

    void RotateMap()
    {
        if (rotatebool==true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rotationAngle, 0), smooth * Time.deltaTime);
        }
            
        else if (rotatebool==false)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rotationAngle+180, 0), smooth * Time.deltaTime);
        }
    }
}
