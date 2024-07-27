using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static bool hasStarted = false;
    private void Start()
    {
        if (!hasStarted)
        {
            Sounds.StartMusic("event:/Music/Menu");
            hasStarted = true;
        }
    }
    [SerializeField] CanvasGroup blackBackgrondFade;
    public void ToGame()
    {
        Sounds.StopMusic();
        StartCoroutine(FadeOut());
    }

    public void ToCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(1);
    }



    IEnumerator FadeOut()
    {
        float timeElapsed = 0;
        float lerpTime = 1f;
        while (timeElapsed < lerpTime)
        {
            blackBackgrondFade.alpha = Mathf.Lerp(0, 1, timeElapsed / lerpTime);
            timeElapsed += Time.deltaTime;
            yield return null;

        }
        blackBackgrondFade.alpha = 1;
        SceneManager.LoadScene(0);
        yield return null;


    }
}
