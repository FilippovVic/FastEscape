using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public TMP_Text text;
    public int score;

    public void Update()
    {
        text.SetText("Score\n" + score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            text.SetText("Score\n" + score++);
            Destroy(collision.gameObject);
        }
    }
}