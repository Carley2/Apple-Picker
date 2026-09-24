using UnityEngine;

public class Branch : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        GameObject collideWith = coll.gameObject;

        if (collideWith.CompareTag("Basket"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.GameOver();
            }

            Destroy(this.gameObject);
        }
    }
}
