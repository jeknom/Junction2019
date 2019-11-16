using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] VariableJoystick joystick;

    [Header("Movement speed")]
    [SerializeField] float oldManMovementSpeed = .1f;
    [SerializeField] float youngManMovementSpeed = .3f;

    Rigidbody2D rigidbody2d;

    private void OnEnable()
    {
        this.rigidbody2d = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.CheatToggleCharacterAge();

        var horizontalInput = joystick.Horizontal;
        var verticalInput = joystick.Vertical;
        var movementSpeedModifier =
            this.gameManager.StateOfPlayer == PlayerState.YOUNG
                ? this.youngManMovementSpeed
                : this.oldManMovementSpeed;
        var nextPosition =
            this.transform.position +
            new Vector3(horizontalInput, verticalInput) * movementSpeedModifier;

        this.rigidbody2d.MovePosition(nextPosition);
    }

    void CheatToggleCharacterAge()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            var currentState = this.gameManager.StateOfPlayer;

            this.gameManager.StateOfPlayer = currentState == PlayerState.YOUNG
                ? PlayerState.OLD
                : PlayerState.YOUNG;
        }
    }
}