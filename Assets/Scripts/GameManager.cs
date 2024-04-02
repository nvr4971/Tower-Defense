using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    [Header("UI References")]
    public GameObject completeLevelUI;
    public GameObject gameOverUI;

    [Header("Next Level Var")]
    public string nextLevel = "Level2";
    public int levelToUnlock = 2;

    [Header("Scene Fader")]
    public SceneFader sceneFader;

    private void Start()
    {
        gameIsOver = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            EndGame();
        }

        if (gameIsOver)
        {
            return;
        }
        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
