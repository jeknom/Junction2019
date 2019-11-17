using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretPath : MonoBehaviour
{
    [SerializeField] TilemapRenderer tilemapRenderer;
    //[SerializeField] GameManager gameManager;

    void Update()
    {
        var shouldRenderSecretPaths =
            GameManager.Instance.StateOfPlayer == PlayerState.YOUNG;

        this.tilemapRenderer.gameObject.SetActive(shouldRenderSecretPaths);
    }
}
