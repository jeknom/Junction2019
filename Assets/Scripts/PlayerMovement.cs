using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeedModifier = .1f;

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        this.transform.position +=
            new Vector3(horizontalInput, verticalInput) * movementSpeedModifier;
    }
}
