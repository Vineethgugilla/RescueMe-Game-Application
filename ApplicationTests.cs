using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationTests
{
    [UnityTest]
    public IEnumerator RestartLevel_RestartsScene()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        RestartLevel restartLevel = gameObject.AddComponent<RestartLevel>();
        Scene initialScene = SceneManager.GetActiveScene();

        // Act
        restartLevel.RestartScene();
        yield return null; 

        // Assert
        Assert.AreNotEqual(initialScene, SceneManager.GetActiveScene());
    }

    [UnityTest]
    public IEnumerator QuitApplication_Quits()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        QuitApplication quitApplication = gameObject.AddComponent<QuitApplication>();

        // Act
        quitApplication.Quit();
        yield return null;
        Assert.IsFalse(Application.isPlaying);
    }
}
