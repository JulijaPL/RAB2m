using System.Collections;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        StartCoroutine(ResumeAfterDelay(3f));
    }

    IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
    }
}
