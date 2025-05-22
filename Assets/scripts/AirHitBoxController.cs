using UnityEngine;

public class AirHitBoxController : MonoBehaviour
{
    [SerializeField] PlayerMovement movementController;
    Rigidbody2D rb;

    bool HasBroken  = false;

    private void OnEnable()
    {
        HasBroken = false;
        if (rb == null ) rb = GetComponentInParent <Rigidbody2D> ();
    }
    

    private void FixedUpdate()
    {
        if (movementController.grounded) gameObject.SetActive(false);
        if (rb.linearVelocity.y > 0) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag ("Breakable") && !HasBroken)
        {
            HasBroken |= true;
            collision.gameObject.SetActive(false);
            rb.linearVelocityY = 0;
        }



    }
}

