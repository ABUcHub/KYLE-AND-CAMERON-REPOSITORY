using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touched: " + other.name);

        if (other.CompareTag("spike") && !isDead)
        {
            isDead = true;

            Debug.Log("MONKEY DIED!");

            MonkeyMovement movement =
                GetComponent<MonkeyMovement>();

            if (movement != null)
            {
                movement.enabled = false;
            }

            Invoke(nameof(RestartLevel), 1f);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}