using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM1 : MonoBehaviour
{
    public float WalkSpeed, RunSpeed, JumpSpeed;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask Ground;

    private bool IsGrounded;
}
