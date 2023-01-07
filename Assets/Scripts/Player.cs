using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int Health;
    public float Speed;
    public float XIncrement;
    public float MinWidth, MaxWidth;

    private Animator animator;

    private Vector2 _targetPos;

    public Image[] hearts;
    public Sprite heart;

    public TMP_Text GameOver;

    private AudioSource SoundEffect;

    public void Start()
    {
        _targetPos = new Vector2(0, -7);
        animator = GetComponent<Animator>();
        GameOver.enabled = false;
        SoundEffect = GetComponent<AudioSource>();
    }

    public void FixedUpdate()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            hearts[Health].enabled = false;
            GameOver.enabled = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, _targetPos, Speed);

        if (Input.GetKey(KeyCode.D) && _targetPos.x < MaxWidth)
        {
            _targetPos = new Vector2(_targetPos.x + XIncrement, _targetPos.y);
        }
        else if (Input.GetKey(KeyCode.A) && _targetPos.x > MinWidth)
        {
            _targetPos = new Vector2(_targetPos.x - XIncrement, _targetPos.y);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Debug.Log(touch.position.x);

            if (touch.position.x > Screen.width / 2 && _targetPos.x < MaxWidth)
            {
                _targetPos = new Vector2(_targetPos.x + XIncrement, _targetPos.y);
            }
            else if (touch.position.x < Screen.width / 2 && _targetPos.x > MinWidth)
            {
                _targetPos = new Vector2(_targetPos.x - XIncrement, _targetPos.y);
            }
        }
    }

    public void GetDamage(int damage)
    {
        Health -= damage;
        animator.SetTrigger("Hit");

        if (PlayerPrefs.GetInt("sound", 0) == 1)
        {
            SoundEffect.Play();
        }

        hearts[Health].enabled = false;
    }
}