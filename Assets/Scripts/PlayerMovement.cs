using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool IsPlayer1 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayer1)
        {
            GetKeyboardInputWsad();  
        }

        else
        {
            GetKeyboardInputArrows();  
        }
            
    }

    public bool GetIsPlayer1()
    {
        return IsPlayer1;
    }
    public void SetIsPlayer1(bool value)
    {
        IsPlayer1 = value;
    }

    void GetKeyboardInputWsad()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(0,1,0);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0,-1,0);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(-1,0,0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(1,0,0);
        }
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Faked a PowerUp!");
        }
    }
    void GetKeyboardInputArrows()
    {
        if (Input.GetKey("up"))
        {
            transform.Translate(0,1,0);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(0,-1,0);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(-1,0,0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(1,0,0);
        }
        if (Input.GetKeyDown("right shift"))
        {
            Debug.Log("Faked a PowerUp!");
        }
    }
}
