using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float downTime = 5.5f;
    public float countdown = 2f;
    public Text countDownText;
    private int wave = 0;

    void Update() {
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = downTime;
            wave++;
        }
        countdown -= Time.deltaTime;
        countDownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave() {
        Debug.Log("Wave incoming");
        int numEnemies = wave + 1;
        for (int i = 0; i < numEnemies; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.8f);
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
