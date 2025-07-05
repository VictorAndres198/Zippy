using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Nivel 2"; // Pon aquí el nombre exacto de la escena

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
