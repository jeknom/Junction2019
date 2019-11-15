using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] VariableJoystick joystick;
    [SerializeField] float movementSpeedModifier = .1f;

    void Update()
    {
        var horizontalInput = joystick.Horizontal;
        var verticalInput = joystick.Vertical;

        this.transform.position +=
            new Vector3(horizontalInput, verticalInput) * movementSpeedModifier;
    }
}
