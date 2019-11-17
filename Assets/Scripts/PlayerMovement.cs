using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] VariableJoystick joystick;
    [SerializeField] float movementSpeedModifier = 0.1f;
    PlayerState previousState;

    Rigidbody2D rigidbody2d;
    Animator animator;

    private void OnEnable()
    {
        this.rigidbody2d = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.previousState = GameManager.Instance.StateOfPlayer;
    }

    void Update()
    {
        var horizontalInput = joystick.Horizontal;
        var verticalInput = joystick.Vertical;
        var shouldShowWalkAnimation =
            horizontalInput + verticalInput != 0;
        this.animator.SetBool("isWalking", shouldShowWalkAnimation);

        var currentState = GameManager.Instance.StateOfPlayer;

        if (currentState != previousState)
        {
            var trigger = currentState == PlayerState.OLD
                ? "triggerOld"
                : "triggerYoung";
            this.animator.SetTrigger(trigger);
            this.previousState = currentState;
        }

        var nextPosition =
            this.transform.position +
            (new Vector3(horizontalInput, verticalInput) * movementSpeedModifier);

        this.rigidbody2d.MovePosition(nextPosition);
    }
}