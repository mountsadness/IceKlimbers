using UnityEngine;

public class AirHitBoxController : MonoBehaviour
{
    [SerializeField] PlayerMovement movementController;

    private void FixedUpdate()
    {
        if (movementController.grounded) gameObject.SetActive(false);
    }
}
