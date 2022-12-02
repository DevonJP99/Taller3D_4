using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TimerPRo : MonoBehaviour
{
    [Header("Timer UI references:")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private TextMeshProUGUI uiText;
    public int Duration { get; private set; }
    private int remainDuration;
    private void Awake()
    {
        resetTimer();
    }
    private void resetTimer()
    {
        uiText.text = "00:00";
        uiFillImage.fillAmount = 0f;
        Duration = remainDuration = 0;
    }
    public TimerPRo SetDuration(int seconds)
    {
        Duration = remainDuration = seconds;
        return this;
    }
    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer()
    {
        while (remainDuration > 0)
        {
            UpdateUI(remainDuration);
            remainDuration--;
            yield return new WaitForSeconds(1f);

        }
        End();
    }
    private void UpdateUI(int seconds)
    {
        uiText.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }
    public void End()
    {
        SceneManager.LoadScene("Puntaje");
        resetTimer();
    }
    public void OnDestroy()
    {
        StopAllCoroutines();
    }
}
