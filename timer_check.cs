using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerCheck : MonoBehaviour
{
    public float waitTimeInSeconds;
    private int waitTimeInSecondsInt;
    public TextMeshProUGUI timerText;
    public GameObject collectiblesParent;
    private int remainingCollectibles;

    private void Start()
    {
        remainingCollectibles = collectiblesParent.transform.childCount;
    }

    private void Update()
    {
        if (waitTimeInSeconds > 0)
        {
            waitTimeInSeconds -= Time.deltaTime;
            waitTimeInSecondsInt = (int)waitTimeInSeconds;
            timerText.text = waitTimeInSecondsInt.ToString();
        }
        else
        {
            CheckRemainingCollectibles();
        }
    }

    private void CheckRemainingCollectibles()
    {
        remainingCollectibles = collectiblesParent.transform.childCount;
        
        if (remainingCollectibles == 0)
        {

            Debug.Log("Level Success!");
        }
        else
        {
            Debug.Log("Level Failure!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
