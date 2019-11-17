﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameManager.Instance.reset();
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1,
                LoadSceneMode.Single);
        }    
    }
}
