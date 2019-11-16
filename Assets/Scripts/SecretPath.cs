using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretPath : MonoBehaviour
{
    [SerializeField] TilemapRenderer tilemapRenderer;
    [SerializeField] GameManager gameManager;

    void Update()
    {
        var shouldRenderSecretPaths =
            gameManager.StateOfPlayer == PlayerState.YOUNG;

        this.tilemapRenderer.gameObject.SetActive(shouldRenderSecretPaths);
    }
}
