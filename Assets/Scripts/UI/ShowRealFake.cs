using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class ShowRealFake : MonoBehaviour
{
    public AudioSource effect;
    public GameObject UpperPanel, DownPanel;

    private Animator animatorUp;
    private Animator animatorDown;
    private Text textUp;
    private Text textDown;

    private string textReal = "R E A L";
    private string textFake = "F A K E";
    
    // Start is called before the first frame update
    private void Start()
    {
        
        textUp = UpperPanel.transform.Find("UpperTextBox").GetComponent<Text>();
        textDown = DownPanel.transform.Find("DownTextBox").GetComponent<Text>();
        animatorUp = UpperPanel.GetComponent<Animator>();
        animatorDown = DownPanel.GetComponent<Animator>();
    }

    public void BigReveal(bool real)
    {
        effect.Play();
        if (real)
        {
            textUp.text = textReal;
            textDown.text = textReal;
        }
        else
        {
            textUp.text = textFake;
            textDown.text = textFake;
        }
        animatorUp.Play("REALFAKE_UPPER");
        animatorDown.Play("REALFAKE_DOWN");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            BigReveal(true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            BigReveal(false);
        }
    }
}
