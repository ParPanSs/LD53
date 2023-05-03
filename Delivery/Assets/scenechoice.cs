using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechoice : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadSecondLevel()
    {
        SceneManager.LoadScene(4);
    }
}
