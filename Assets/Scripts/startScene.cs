using UnityEngine;
using UnityEngine.SceneManagement;

public class startScene : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("cat");
    }
}
