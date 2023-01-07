using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerBeforeRestart : MonoBehaviour
{

    public TMP_Text GameOverText;
    public float TimeBeforeRestart;

    private AudioSource SoundEffect;

    private void Start()
    {
        SoundEffect= GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.Log(TimeBeforeRestart);
        if (GameOverText.enabled)
        {
            if (PlayerPrefs.GetInt("sound", 0) == 1)
            {
                if (!SoundEffect.isPlaying)
                {
                    SoundEffect.Play();
                }
            }
            TimeBeforeRestart -= Time.deltaTime;
        } 
        if (TimeBeforeRestart <= 0)
        {
            TimeBeforeRestart = 5;
            SceneManager.LoadScene("StartMenu");
        }
    }
}