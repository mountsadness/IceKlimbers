using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float  MoveDir;
    [SerializeField] float speed = 5f;

    [SerializeField] Transform RaycastOrigin;
    [SerializeField] LayerMask raycastMask;

     private void Awake()
    {
       rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocityX = MoveDir * speed;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, raycastMask);
        if (hit.transform != null) return;
        FlipEnemy();
    }

    private void OnColissionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            return;
        }
        if (!collision.gameObject.CompareTag("Bouncer")) return;
        FlipEnemy();
    }

    void FlipEnemy()
    {
        MoveDir *= -1;
        Vector3 local = transform.localScale;
        local.x *= -1;
        transform.localScale = local;
    }


}
