using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerCheckTests
{
    [UnityTest]
    public IEnumerator TimerCheck_CountdownToZero_LoadsScene()
    {
        GameObject gameObject = new GameObject();
        TimerCheck timerCheck = gameObject.AddComponent<TimerCheck>();
        timerCheck.WaitSec = 5f;
        timerCheck.myText = new GameObject().AddComponent<TextMeshProUGUI>();
        timerCheck.collectiblesParent = new GameObject();

        yield return new WaitForSeconds(timerCheck.WaitSec + 1f);

        Assert.IsTrue(SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByName("YourSceneName").buildIndex);
    }

    [UnityTest]
    public IEnumerator TimerCheck_CollectiblesRemaining_ReloadsScene()
    {
        GameObject gameObject = new GameObject();
        TimerCheck timerCheck = gameObject.AddComponent<TimerCheck>();
        timerCheck.WaitSec = 100f;
        timerCheck.myText = new GameObject().AddComponent<TextMeshProUGUI>();
        timerCheck.collectiblesParent = new GameObject();
        GameObject collectibleObject = new GameObject();
        collectibleObject.transform.parent = timerCheck.collectiblesParent.transform;

        timerCheck.CheckRemainingCollectibles();
        yield return null;

        Assert.IsTrue(SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByName("YourSceneName").buildIndex);
    }
}
