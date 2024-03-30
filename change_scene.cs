using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }
}
