using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeating : MonoBehaviour
{
    public float VerticalSize;

    private Vector2 _offSet_Up;

    private void Update()
    {
        if (transform.position.y <= -VerticalSize)
        {
            RepeatBackground();
        }
    }

    public void RepeatBackground()
    {
        _offSet_Up = new Vector2(0, VerticalSize);
        transform.position = (Vector2)transform.position + _offSet_Up;
    }
}
