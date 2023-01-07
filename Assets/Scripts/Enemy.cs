using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Damage;
    public float Speed;

    public void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}