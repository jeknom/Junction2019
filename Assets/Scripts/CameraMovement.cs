using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Basics")]
    [SerializeField] Transform followTarget;
    [SerializeField] float xOffset = 0f;
    [SerializeField] float yOffset = 0f;
    [SerializeField] float cameraZ = -10f;

    [Header("Follow mode")]
    [SerializeField] bool useFollowMode = false;
    [SerializeField] float followSpeedModifier = 0.05f;

    void Update()
    {
        var targetX = followTarget.position.x + xOffset;
        var targetY = followTarget.position.y + yOffset;
        var targetPosition = new Vector3(targetX, targetY, cameraZ);

        if (useFollowMode)
        {
            this.transform.position = Vector3.MoveTowards(
                this.transform.position,
                targetPosition,
                this.followSpeedModifier);
        }
        else
        {
            this.transform.position = targetPosition;
        }
    }
}
