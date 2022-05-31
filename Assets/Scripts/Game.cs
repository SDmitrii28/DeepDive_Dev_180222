using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
    public Text text_score;
    public Text text_best_score;
    public Text text_oxygen;
    public Text text_menu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.HasKey("language"))
        {
            Translate();
        }
    }
    private void Translate()
    {
        text_score.text = "SCORE";
        text_best_score.text = "BEST SCORE";
        text_oxygen.text = "oxygen";
        text_menu.text = "MENU";
    }
    public void ClickMenu()
    {
        SceneManager.LoadScene(0);
    }
}

