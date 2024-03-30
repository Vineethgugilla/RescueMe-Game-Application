using UnityEngine;
using NUnit.Framework;

public class HeroControllerTest
{
    [Test]
    public void HeroController_Move_PlayerMovesAccordingToJoystickInput()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        HeroController heroController = gameObject.AddComponent<HeroController>();
        heroController.Joystick = new GameObject().AddComponent<FixedJoystick>();
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        heroController.moveSpeed = 5f;
        heroController.gameManager = new GameManager(); 

        // Act
        heroController.Joystick.Horizontal = 1f;
        heroController.Joystick.Vertical = 0f;
        heroController.Update(); 

        // Assert
        Assert.AreEqual(new Vector2(5f, 0f), rb.position);
    }

    [Test]
    public void HeroController_CollisionWithEnemy_DestroyPlayerAndFailLevel()
    {
        // Arrange
        GameObject heroObject = new GameObject();
        GameObject enemyObject = new GameObject();
        HeroController heroController = heroObject.AddComponent<HeroController>();
        Rigidbody2D rb = heroObject.AddComponent<Rigidbody2D>();
        heroController.gameManager = new GameManager(); 
        BoxCollider2D heroCollider = heroObject.AddComponent<BoxCollider2D>();
        BoxCollider2D enemyCollider = enemyObject.AddComponent<BoxCollider2D>();
        enemyObject.tag = "Enemy";

        // Act
        heroController.OnTriggerEnter2D(enemyCollider);

        // Assert
        Assert.IsNull(heroObject); 
        // Assert.Fail(); 
    }
}
