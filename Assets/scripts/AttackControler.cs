using System;
using UnityEngine;

public class AttackControler : MonoBehaviour
{
    InputController inputs;
    PlayerMovement playerMovement;
    [SerializeField] Transform attackBoxesParent;
    [SerializeField] GameObject JumpAttackBox;
    [SerializeField] GameObject groundedAttackBox;

    public bool isAttacking;
    void Awake(){
      inputs = GetComponent<InputController>();
      playerMovement = GetComponent<PlayerMovement>(); 
    }

    void Start() { 
        JumpAttackBox.SetActive(false);
        groundedAttackBox.SetActive(false);
    }


    void OnEnable(){
        inputs.OnAttackEvent += HandleOnAttack; 
    }

    private void OnDisable(){
       inputs.OnAttackEvent -= HandleOnAttack; 
    }

    private void FixedUpdate()
    {
        if (isAttacking) return;
        {
            attackBoxesParent.localScale = inputs.moveDir > 0 ? Vector3.one : new Vector3(-1, 1, 1);
        }

    }
    private void HandleOnAttack(object sender, EventArgs e){
        if (playerMovement.grounded){
            groundedAttackBox.SetActive(true);
        }
        else
        {
            JumpAttackBox.SetActive(true);
        }
    }
} 
