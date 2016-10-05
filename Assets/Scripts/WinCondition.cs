using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour {

    private static int lives = 1;
    private static Text livesText;
    public Text setLivesText;
    public int setLives;

    public void Awake() {
        livesText = setLivesText;
        lives = setLives;

        livesText.text = lives.ToString();
    }

    public static void ReachedObjective() {
        lives--;

        if (lives <= 0) {
            GameOver();
            return;
        }
        else {
            livesText.text = lives.ToString();
        }
    }

    public static void GameOver() {
        Debug.Log("Game over!");
    }
}
