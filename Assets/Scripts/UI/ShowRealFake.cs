using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class ShowRealFake : MonoBehaviour
{
    public AudioSource effectAudio, realAudio, fakeAudio;
    public GameObject UpperPanel, DownPanel;
    public GameObject particles;

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
        var particleSystemMain = particles.GetComponent<ParticleSystem>().main;
        particleSystemMain.startDelay = 0.3f;
    }

    public void BigReveal(bool real)
    {
        effectAudio.Play();
        if (real)
        {
            realAudio.Play();
            textUp.text = textReal;
            textDown.text = textReal;
        }
        else
        {
            fakeAudio.Play();
            textUp.text = textFake;
            textDown.text = textFake;
        }
        animatorUp.Play("REALFAKE_UPPER");
        animatorDown.Play("REALFAKE_DOWN");
        particles.SetActive(false);
        particles.SetActive(true);
    }
    
}
