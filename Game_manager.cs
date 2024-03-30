using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject levelFailPanel;
    public GameObject levelPassPanel;
    public int totalCollectibles;
    public int collectedCollectibles;

    private void Start()
    {
        levelFailPanel.SetActive(false);
        levelPassPanel.SetActive(false);
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        totalCollectibles = collectibles.Length;
    }

    public void CollectibleCollected()
    {
        collectedCollectibles++;

        if (collectedCollectibles == totalCollectibles)
        {
            LevelPassed();
        }
    }

    public void LevelFail()
    {
        levelFailPanel.SetActive(true);
        Time.timeScale = 0f;
        Invoke("ReloadScene", 2f); 
    }

    private void LevelPassed()
    {
        levelPassPanel.SetActive(true);
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
