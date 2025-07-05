using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallController : MonoBehaviour
{
    [SerializeField] private float restartDelay = 0.5f; // Tiempo para que el sonido suene completo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Intenta reproducir el sonido del jugador
            FoxHurt audioPlayer = collision.GetComponent<FoxHurt>(); // Cambia el nombre según tu script real
            if (audioPlayer != null)
            {
                audioPlayer.PlayHurtFox();
            }

            // Reinicia la escena después de un pequeño delay
            StartCoroutine(RestartSceneAfterDelay(restartDelay));
        }
    }

    private IEnumerator RestartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
