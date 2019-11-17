using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (SceneManager.GetActiveScene().name == "Level 2")
            {
                GameManager.Instance.reset(10f, 3);
                SceneManager.LoadScene("StartOver");
            }
            else
            {
                GameManager.Instance.reset(20f, 4);
                SceneManager.LoadScene("Win");
            }
        }
    }
}
