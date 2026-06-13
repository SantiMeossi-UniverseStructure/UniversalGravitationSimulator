using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public void back()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void activeCollider(bool isActive)
    {
        if(isActive == true)
        {
            UniversalVariables.collider = true;
        }
        else
        {
            UniversalVariables.collider = false;
        }
    }
    public void stopTime()
    {
        Time.timeScale = 0f;
    }
    public void timeX1()
    {
        Time.timeScale = 1f;
    }
    public void timeX0_5()
    {
        Time.timeScale = 0.5f;
    }
    public void timeX2()
    {
        Time.timeScale = 2f;
    }
}
