using UnityEngine;

public class MoovingEnemy : MonoBehaviour
{

    public Transform[] path_Points;
    public float speed_Enemy;
    public Vector3[] _new_Position;
    public int Damage;

    private int current_Position;

    private void Start()
    {
        _new_Position = NewPositionByPath(path_Points);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _new_Position[current_Position], speed_Enemy * Time.deltaTime);

        if (Vector3.Distance(transform.position, _new_Position[current_Position]) < 0.2f)
        {
            current_Position++;
        }

        if (Vector3.Distance(transform.position, _new_Position[_new_Position.Length - 1]) < 0.2f)
        {
            Destroy(gameObject);
        }
    }

    Vector3[] NewPositionByPath(Transform[] pathPos)
    {
        Vector3[] pathPositions = new Vector3[pathPos.Length];
        for (int i = 0; i < path_Points.Length; i++)
        {
            pathPositions[i] = pathPos[i].position;
        }
        return pathPositions;
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