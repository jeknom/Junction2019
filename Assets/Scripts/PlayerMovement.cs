using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] VariableJoystick joystick;
    [SerializeField] float movementSpeedModifier = 0.1f;

    Rigidbody2D rigidbody2d;

    private void OnEnable()
    {
        this.rigidbody2d = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var horizontalInput = joystick.Horizontal;
        var verticalInput = joystick.Vertical;

        var nextPosition =
            this.transform.position +
            (new Vector3(horizontalInput, verticalInput) * movementSpeedModifier);

        this.rigidbody2d.MovePosition(nextPosition);
    }
}