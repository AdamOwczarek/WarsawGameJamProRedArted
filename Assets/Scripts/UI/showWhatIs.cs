using TMPro;
using UnityEngine;

public class showWhatIs : MonoBehaviour
{
    public AudioSource effectAudio, whatAudio, isAudio;
    public TextMeshProUGUI textBox;
    public GameObject panel; 

    private string textWhat = "WHAT";
    private string textIs = "IS";
    private float halfTime;
    private float delta;
    private float duration;
    private float flashDuration = 0.5f;
    private bool playOnHalf = true;

    // Start is called before the first frame update
    private void Start()
    {
        
        PreBigRevealLetsGoBaby(2.8f);
    }

    public void PreBigRevealLetsGoBaby(float duration)
    {
        this.duration = duration;
        delta = 0.0f;
        halfTime = duration / 2.0f;
        textBox.text = textWhat;
        effectAudio.Play();
        whatAudio.Play();
        panel.SetActive(true);
    }

    private void Update()
    {
        delta += Time.deltaTime;
        
        if (delta >= flashDuration && delta < halfTime)
        {
            panel.SetActive(false);
            textBox.text = textIs;
        }
        
        if (delta >= halfTime && playOnHalf)
        {
            playOnHalf = false;
            isAudio.Play();
            panel.SetActive(true);
        }

        if (delta > (halfTime + flashDuration))
        {
            panel.SetActive(false);
        }

        if (delta >= duration)
        {
            effectAudio.Stop();
        }
    }
}