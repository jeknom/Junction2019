using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float destroyDuration = 1f;
    GameManager gameManager;

    void OnEnable()
    {
        this.gameManager = GameObject
            .Find("GameManager")
            .GetComponent<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("The scene is missing the GameManager GameObject!!");
        }
    }

    void OnDestroy()
    {
        this.StopAllCoroutines();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var shouldDestroyDoor =
            collision.gameObject.name == "Player" &&
            gameManager.StateOfPlayer == PlayerState.YOUNG;

        if (shouldDestroyDoor)
        {
            this.StartCoroutine(DestroyDoorRoutine());
        }
    }

    IEnumerator DestroyDoorRoutine()
    {
        yield return new WaitForSeconds(this.destroyDuration);
        Destroy(this.gameObject);
    }
}
