using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro ;
using UnityEngine.SceneManagement;

public class GameBoss : MonoBehaviour
{
    public Button restartButton;
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    private int score;
    public bool isGameActive;
    public TextMeshProUGUI scoreText;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        restartButton.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget(){
        while(isGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: "+score;

    }
    public void GameOver(){
        isGameActive=false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }
}
