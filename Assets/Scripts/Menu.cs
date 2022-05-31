using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject language_rus;
    public GameObject language_eng;
    public GameObject vibration_on;
    public GameObject vibration_off;
    public Text text_task;
     // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("vibrate"))
        {
            vibration_on.SetActive(false);
            vibration_off.SetActive(true);
        }
        else
        {
            vibration_on.SetActive(true);
            vibration_off.SetActive(false);
        }
        if (PlayerPrefs.HasKey("language"))
        {
            Translate();
            language_rus.SetActive(false);
            language_eng.SetActive(true);
        }
        else
        {
            language_rus.SetActive(true);
            language_eng.SetActive(false);
        }
    }
    private void Translate()
    {
        text_task.text = "Collect starfish to get more points. Avoid collisions with sea creatures! And, of course, don't forget about the oxygen! Bubbles will help you replenish it.";
    }
    private void Translate_rus()
    {
        text_task.text = "Собирай морские звёзды, чтобы получить больше баллов. Избегай столкновений с морскими обитателями! И, конечно же, не забывай про кислород! Пузырьки помогут тебе его восполнить.";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   public void ClickPlay(){
	SceneManager.LoadScene(1);
}
    public void PlayVibrate()
    {
        if (!PlayerPrefs.HasKey("vibrate"))
        {
            Handheld.Vibrate();
        }
    }
    public void Vibration_on()
    {
        if (!PlayerPrefs.HasKey("vibrate"))
        {
            PlayerPrefs.SetInt("vibrate", 1);
            PlayerPrefs.Save();
            vibration_on.SetActive(false);
            vibration_off.SetActive(true);
        }
    }
    public void Vibration_off()
    {
        if (PlayerPrefs.HasKey("vibrate"))
        {
            PlayerPrefs.DeleteKey("vibrate");
            Handheld.Vibrate();
            vibration_on.SetActive(true);
            vibration_off.SetActive(false);
        }
    }
    public void Language_rus()
    {
        if (!PlayerPrefs.HasKey("language"))
        {
            PlayerPrefs.SetInt("language", 1);
            PlayerPrefs.Save();
            if (!PlayerPrefs.HasKey("vibrate"))
            {
                Handheld.Vibrate();
            }
            Translate();
            language_rus.SetActive(false);
            language_eng.SetActive(true);
        }
    }
    public void Language_eng()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            PlayerPrefs.DeleteKey("language");
            if (!PlayerPrefs.HasKey("vibrate"))
            {
                Handheld.Vibrate();
            }
            Translate_rus();
            language_rus.SetActive(true);
            language_eng.SetActive(false);
        }
    }
}
