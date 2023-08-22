using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public void GotoStudy()
    {
        SceneManager.LoadScene("Studypage");
    }
    public void GotoSleep()
    {
        SceneManager.LoadScene("Sleeppage");
    }
    public void GotoRelax()
    {
        SceneManager.LoadScene("Relaxpage");
    }
    public void GotoMeal()
    {
        SceneManager.LoadScene("Mealpage");
    }
}
