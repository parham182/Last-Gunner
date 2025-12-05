using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
        transform.LookAt(player);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
