using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    //monkey alive, monkey dead.
    private bool lifeStatus = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the monkey hits the spike he is now dead. R.I.P.
        if (other.CompareTag("spike") && !lifeStatus)
        {
            lifeStatus = true;
            MonkeyMovement movement = GetComponent<MonkeyMovement>();

            if (movement != null)
            {
                movement.enabled = false;
            }

            Invoke(nameof(RestartLevel), 1f);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}