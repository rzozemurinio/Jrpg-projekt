using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // nazwa sceny do za³adowania
    public string sceneToLoad;

    // gdy coœ wchodzi w trigger…
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // tylko jeœli to obiekt z tagiem "Player"
        if (collision.CompareTag("Player"))
        {
            // ³adujemy now¹ scenê
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
