using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play(int index)
    {
    	SceneManager.LoadScene(index);
    }
    public void Settings()
    {
    	SceneManager.LoadScene(2);
    }
    public void Devblog()
    {
    	SceneManager.LoadScene(3);
    }
    public void Credits()
    {
    	SceneManager.LoadScene(4);
    }
    public void Exit()
    {
    	Application.Quit();
    }
}
