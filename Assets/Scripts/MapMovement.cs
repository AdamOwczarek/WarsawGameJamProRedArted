using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapMovement : MonoBehaviour
{
    private float smooth = 4;

    public bool rotatebool=true;

    private int rotationAngle = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void fakeConsume()
    {
        Debug.Log("map");
        smooth = 400;
        rotatebool = !rotatebool;
    }

    // Update is called once per frame
    void Update()
    {
        smooth -= Time.deltaTime*450;
        if (smooth < 15)
        {
            smooth = 15f;
        }
        if (Input.GetKeyDown("space"))
        {
            //fakeConsume();
        }
        RotateMap();
    }

    void RotateMap()
    {
        if (rotatebool)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rotationAngle, 0), smooth * Time.deltaTime);
        }
            
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rotationAngle+180, 0), smooth * Time.deltaTime);
        }
    }
}
