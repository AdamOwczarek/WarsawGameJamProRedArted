using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject stepPref;
    private GameObject step;
    
    private float speed2 = 0.003f;
    private int speed = 1;
    public bool IsPlayer1 = false;

    public GameObject secondPlayer;
    public GameObject realfake;
    public GameObject map;

    private string[] powerups = { "input", "map", "swap", "jar"};
    private string powerupKey = "";

    private bool faked = false;
    private List<Vector3> fakes = new List<Vector3>();
    private Vector3 fakeStartPos = new Vector3();
    public bool isFake = false;
    private bool isFakeControl = false;
    public float fakeTime = 0;
    public void fakeStart(string key)
    {
        faked = false;
        Debug.Log(key);
        powerupKey = key;
        secondPlayer.GetComponent<PlayerMovement>().powerupKey = key;
        
        isFake = true;
        secondPlayer.GetComponent<PlayerMovement>().isFake = true;
        
        isFakeControl = true;
        secondPlayer.GetComponent<PlayerMovement>().isFakeControl = false;
        
        fakeTime = 0;
        secondPlayer.GetComponent<PlayerMovement>().fakeTime = 0;
        
        if (key == "input" || key == "jar")
        {
            fakeStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            secondPlayer.GetComponent<PlayerMovement>().fakeStartPos = new Vector3(secondPlayer.transform.position.x, secondPlayer.transform.position.y, secondPlayer.transform.position.z);
        }

        if (key == "swap")
        {
            fakeStartPos = new Vector3(secondPlayer.transform.position.x, secondPlayer.transform.position.y, secondPlayer.transform.position.z);
            secondPlayer.GetComponent<PlayerMovement>().fakeStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        
        if (key == "input")
        {
            step.GetComponent<Step>().myStart(transform.position);
        }
        
        if (key == "swap")
        {
            step.GetComponent<Step>().myStart(secondPlayer.GetComponent<PlayerMovement>().transform.position);
        }
        
    }

    private void fakeConsume2()
    {
        if (isFake && isFakeControl)
        {
            faked = true;
            secondPlayer.GetComponent<PlayerMovement>().faked = true;
        }
    }
    private void fakeConsume()
    {
        fakeTime = 0;
        secondPlayer.GetComponent<PlayerMovement>().fakeTime = 0;
        
        isFake = false;
        secondPlayer.GetComponent<PlayerMovement>().isFake = false;
        
        isFakeControl = true;
        secondPlayer.GetComponent<PlayerMovement>().isFakeControl = false;

        if (powerupKey == "input" || powerupKey == "jar" || powerupKey == "swap")
        {
            transform.position = new Vector3(fakeStartPos.x, fakeStartPos.y, fakeStartPos.z);
            secondPlayer.GetComponent<PlayerMovement>().transform.position = new Vector3(secondPlayer.GetComponent<PlayerMovement>().fakeStartPos.x, secondPlayer.GetComponent<PlayerMovement>().fakeStartPos.y, secondPlayer.GetComponent<PlayerMovement>().fakeStartPos.z);
        }

        Debug.Log("isFakeControl " + isFakeControl);
        if (powerupKey == "map" && isFakeControl)
        {
            map.GetComponent<MapMovement>().fakeConsume();
        }
        
        
        faked = true;
        secondPlayer.GetComponent<PlayerMovement>().faked = true;
    }

    private void fakeCancel()
    {
        powerupKey = "";
        secondPlayer.GetComponent<PlayerMovement>().powerupKey = "";
        fakes.Clear();
        secondPlayer.GetComponent<PlayerMovement>().fakes.Clear();
        isFake = false;
        secondPlayer.GetComponent<PlayerMovement>().isFake = false;
        isFakeControl = false;
        secondPlayer.GetComponent<PlayerMovement>().isFakeControl = false;
        
        faked = false;
        secondPlayer.GetComponent<PlayerMovement>().faked = false;
    }
    
    private Vector3 fakeMove(Vector3 move)
    {
        if (isFake)
        {
            int side = 1;
            if (isFakeControl)
            {
                
            }
            if (powerupKey == "input")
            {
                
                Debug.Log(step == null);
                step.GetComponent<Step>().move(new Vector3(move.z, -move.y, -move.x)*speed2*speed);
            }
        
            if (powerupKey == "swap")
            {
                Debug.Log(step == null);
                step.GetComponent<Step>().move(new Vector3(-move.z, -move.y, move.x)*speed2*speed);
            }
            fakes.Add(new Vector3(-move.x, -move.y, -move.z)*speed2);
        }

        return move*speed2;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        fakes = new List<Vector3>();
        step = Instantiate(stepPref);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFake)
        {
            fakeTime += Time.deltaTime;
            if (fakeTime > 3)
            {
                if (faked)
                {
                    if (IsPlayer1 || true)
                    {
                        realfake.GetComponent<ShowRealFake>().BigReveal(true);
                    }
                    
                    fakeConsume();
                }
                else
                {
                    if (IsPlayer1 || true)
                    {
                        realfake.GetComponent<ShowRealFake>().BigReveal(false);
                    }
                    fakeCancel();
                }
                Debug.Log("cancel");
            }
        }
        if (!isFake && fakes.Count > 0)
        {
            step.GetComponent<Step>().myEnd();
            if (powerupKey == "input")
            {
                float fCount = fakes.Count / 30f;
                for (int i = 0; i < fCount; i++)
                {
                    transform.Translate(fakes[fakes.Count - 1]);
                    fakes.RemoveAt(fakes.Count - 1);
                    if (fakes.Count == 4)
                    {
                        //step.GetComponent<Step>().myEnd();
                    }
                }
            }
            else if (powerupKey == "swap")
            {
                float fCount = fakes.Count / 30f;
                for (int i = 0; i < fCount; i++)
                {
                    transform.Translate(-fakes[fakes.Count - 1]);
                    fakes.RemoveAt(fakes.Count - 1);
                    if (fakes.Count == 4)
                    {
                        //step.GetComponent<Step>().myEnd();
                    }
                }
            }
            else
            {
                fakes.Clear();
            }

        }
        else
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
        
            
    }

    void GetKeyboardInputWsad()
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

        if (Input.GetKeyDown("space"))
        {
            fakeConsume2();
            Debug.Log("Faked a PowerUp!");
        }
        
        if (Input.GetKeyDown("f"))
        {
            //fakeStart(powerups[(int)Random.Range(0, powerups.Length)]);
            Debug.Log("PowerUp!");
        }
    }
    void GetKeyboardInputArrows()
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
        
        if (Input.GetKeyDown("f"))
        {
            fakeStart(powerups[(int)Random.Range(0, powerups.Length)]);
            Debug.Log("PowerUp!");
        }

        if (Input.GetKeyDown("right shift"))
        {
            fakeConsume2();
            Debug.Log("Faked a PowerUp!");
        }
    }
}
