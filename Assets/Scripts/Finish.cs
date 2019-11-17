using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameManager.Instance.reset(20f, 4);
            SceneManager.LoadScene("Win");
        }    
    }
}
