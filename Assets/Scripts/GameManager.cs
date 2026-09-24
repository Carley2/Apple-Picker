using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public TMP_Text roundText;
    public GameObject restartButton;
    public AppleTree appleTree;

    void Start()
    {
        startPanel.SetActive(true);
        roundText.gameObject.SetActive(false);
        restartButton.SetActive(false);
    }

    public void StartGame()
    {
        startPanel.SetActive(false);

        roundText.gameObject.SetActive(true);
        roundText.text = "Round 1";

        appleTree.StartGame();
    }

    public void GameOver()
    {
        roundText.text = "Game Over";
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}