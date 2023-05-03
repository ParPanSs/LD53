using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipcutScene : MonoBehaviour
{
    public void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
