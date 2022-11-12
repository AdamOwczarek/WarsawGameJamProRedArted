using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int speed = 1;
    public bool IsPlayer1 = false;

    private List<Vector3> fakes = new List<Vector3>();
    private Vector3 fakeStartPos = new Vector3();
    private bool isFake = false;
    private float fakeTime = 0;

    private void fakeStart()
    {
        isFake = true;
        fakeTime = 0;
        fakeStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void fakeConsume()
    {
        fakeTime = 0;
        isFake = false;
        transform.position = new Vector3(fakeStartPos.x, fakeStartPos.y, fakeStartPos.z);
    }

    private void fakeCancel()
    {
        fakes.Clear();
        isFake = false;
    }
    
    private Vector3 fakeMove(Vector3 move)
    {
        if (isFake)
        {
            fakes.Add(new Vector3(-move.x, -move.y, -move.z)*0.01f);
        }

        return move*0.01f;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        fakes = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFake)
        {
            fakeTime += Time.deltaTime;
            if (fakeTime > 3)
            {
                fakeCancel();
                Debug.Log("cancel");
            }
        }
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
    public bool GetSpeed()
    {
        return IsPlayer1;
    }
    public void SetSpeed(int value)
    {
        speed = value;
    }

    void GetKeyboardInputWsad()
    {
        if (!isFake && fakes.Count > 0)
        {
            float fCount = fakes.Count / 20f;
            for (int i = 0; i < fCount; i++)
            {
                transform.Translate(fakes[fakes.Count - 1]);
                fakes.RemoveAt(fakes.Count - 1);
            }
        } else
        {
            if (Input.GetKey("w"))
            {
                transform.Translate(fakeMove(new Vector3(0, 0, speed)));

            }

            if (Input.GetKey("s"))
            {
                transform.Translate(fakeMove(new Vector3(0, 0, -speed)));
            }

            if (Input.GetKey("a"))
            {
                transform.Translate(fakeMove(new Vector3(-speed, 0, 0)));
            }

            if (Input.GetKey("d"))
            {
                transform.Translate(fakeMove(new Vector3(speed, 0, 0)));
            }
        }

        if (Input.GetKeyDown("space"))
        {
            fakeConsume();
            Debug.Log("Faked a PowerUp!");
        }
        
        if (Input.GetKeyDown("f"))
        {
            fakeStart();
            Debug.Log("PowerUp!");
        }
    }
    void GetKeyboardInputArrows()
    {
        if (!isFake && fakes.Count > 0)
        {
            transform.Translate(fakes[fakes.Count-1]);
            fakes.RemoveAt(fakes.Count-1);
        }
        else
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(fakeMove(new Vector3(0, 0, speed)));
            }

            if (Input.GetKey("down"))
            {
                transform.Translate(fakeMove(new Vector3(0, 0, -speed)));
            }

            if (Input.GetKey("left"))
            {
                transform.Translate(fakeMove(new Vector3(-speed, 0, 0)));
            }

            if (Input.GetKey("right"))
            {
                transform.Translate(fakeMove(new Vector3(speed, 0, 0)));
            }
        }

        if (Input.GetKeyDown("right shift"))
        {
            fakeConsume();
            Debug.Log("Faked a PowerUp!");
        }
    }
}
