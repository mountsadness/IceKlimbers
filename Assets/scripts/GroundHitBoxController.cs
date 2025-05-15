using System.Runtime.CompilerServices;
using UnityEngine;

public class GroundHitBoxController : MonoBehaviour
{
    [SerializeField] AttackControler attackController;
    [SerializeField] float AttackDuration;
    float attackStartTime;

    private void OnEnable()
    {
        attackController.isAttacking = true;
        attackStartTime = Time.time;
    }

    private void OnDisable()
    {
        attackController.isAttacking = false;
    }

    private void FixedUpdate()
    {
        if (Time.time - AttackDuration >= attackStartTime) gameObject.SetActive(false);
    }
}

