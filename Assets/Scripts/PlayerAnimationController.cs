using UnityEngine;

public class PlayerAnimationController : AnimationController
{

    protected Animator animator;
    protected TopDownController controller;
    protected Animator[] anim;

    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private readonly float magnituteThreshold = 0.5f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(isWalking, obj.magnitude > magnituteThreshold);
    }
}