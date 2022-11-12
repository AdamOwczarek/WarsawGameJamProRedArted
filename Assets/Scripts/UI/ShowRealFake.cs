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
            textUp.text = "R E A L";
            textDown.text = "R E A L";
        }
        else
        {
            textUp.text = "F A K E";
            textDown.text = "F A K E";
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
