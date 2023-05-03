using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMenu : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(0);
    }
}
