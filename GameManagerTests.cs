using UnityEngine;
using NUnit.Framework;

public class GameManagerTests
{
    [Test]
    public void CollectibleCollected_AllCollectiblesCollected_ShowsLevelPassPanel()
    {
        // Arrange
        GameObject gameManagerObject = new GameObject();
        GameManager gameManager = gameManagerObject.AddComponent<GameManager>();
        GameObject levelPassPanel = new GameObject();
        gameManager.levelPassPanel = levelPassPanel;
        gameManager.totalCollectibles = 3; 
        gameManager.collectedCollectibles = 3; 

        // Act
        gameManager.CollectibleCollected();

        // Assert
        Assert.IsTrue(levelPassPanel.activeSelf); 
    }

    [Test]
    public void LevelFail_ShowsLevelFailPanel()
    {
        // Arrange
        GameObject gameManagerObject = new GameObject();
        GameManager gameManager = gameManagerObject.AddComponent<GameManager>();
        GameObject levelFailPanel = new GameObject();
        gameManager.levelFailPanel = levelFailPanel;

        // Act
        gameManager.LevelFail();

        // Assert
        Assert.IsTrue(levelFailPanel.activeSelf); 
    }
}
