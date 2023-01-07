using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SoundBehaviour : MonoBehaviour
{
    private TMP_Text button_Text;
    private TMP_Text[] components; 

    private int SoundState;

    private AudioSource SoundEffect;

    private void Start()
    {
        components = GetComponentsInChildren<TMP_Text>();

        foreach (TMP_Text TMPtext in components)
        {
            if (TMPtext.tag == "Sound")
            {
                button_Text = TMPtext;
            }
        }

        SoundEffect = GetComponent<AudioSource>();
        SoundState = PlayerPrefs.GetInt("sound", 0);
        SetText();
    }

    public void OnClick()
    {
        if (!SoundEffect.isPlaying && PlayerPrefs.GetInt("sound", 0) == 0)
        {
            SoundEffect.Play();
        }
        SetText();
    }

    public void SetText()
    {
        if (SoundState == 1)
        {
            button_Text.text = "Sound: off";
            SoundState = 0;
            PlayerPrefs.SetInt("sound", 0);
        }
        else
        {
            button_Text.text = "Sound: on";
            SoundState = 1;
            PlayerPrefs.SetInt("sound", 1);
        }
    }
}