using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator claw;

    // Start is called before the first frame update
    void Start()
    {
        claw = GetComponent<Animator>();
    }

    public void OnAttack()
    {
        claw.Play("Attack");
    }
}
