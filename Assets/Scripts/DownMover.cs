using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMover : MonoBehaviour
{
    public float Speed;
    public void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
}