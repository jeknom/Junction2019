using UnityEngine;

public class Door : MonoBehaviour
{
    GameManager gameManager;

    private void OnEnable()
    {
        this.gameManager = GameObject
            .Find("GameManager")
            .GetComponent<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("The scene is missing the GameManager GameObject!!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var shouldDestroyDoor =
            collision.gameObject.name == "Player" &&
            gameManager.StateOfPlayer == PlayerState.YOUNG;

        if (shouldDestroyDoor)
        {
            Destroy(this.gameObject);
        }
    }
}
