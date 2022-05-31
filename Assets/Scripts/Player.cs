using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    private int count = 0;
    public Text text_score_game;
    public Text text_score;
    public Text text_best_score;
    public GameObject panel_gameover;
    public Button btn;
    public AudioSource star, oxygen, shark;
    public Slider sl;
    private float time = 40;
    // Start is called before the first frame update
    void Start()
    {
        sl.value = time;
        text_score_game.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        sl.value = time;
        if (sl.value <= 0)
        {
            GameOver();
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    public void ClickMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Click_Rotate()
    {
        transform.eulerAngles -= new Vector3(0, 0, 45);
        if ((transform.eulerAngles.z > -136 && transform.eulerAngles.z < -134) || (transform.eulerAngles.z > 179 && transform.eulerAngles.z < 181) || (transform.eulerAngles.z < 136 && transform.eulerAngles.z > 134) || (transform.eulerAngles.z > 224 && transform.eulerAngles.z < 226))
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
            GetComponent<SpriteRenderer>().flipY = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            star.Play();
            count += 2;
            text_score_game.text = count.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Oxygen"))
        {
            oxygen.Play();
            if (40 - time >= 15f)
            {
                time += 15;
            }
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Fish"))
        {
            shark.Play();
            GameOver();
            Destroy(collision.gameObject);
        }
    }
    private void GameOver()
    {
        Time.timeScale = 0f;
        btn.interactable = false;
        panel_gameover.SetActive(true);
        text_score.text = text_score_game.text;
        if (PlayerPrefs.HasKey("score"))
        {
            if (count < PlayerPrefs.GetInt("score"))
            {
                text_best_score.text = PlayerPrefs.GetInt("score").ToString();
            }
            else
            {
                text_best_score.text = count.ToString();
                PlayerPrefs.SetInt("score", count);
                PlayerPrefs.Save();
            }
        }
        else
        {
            text_best_score.text = count.ToString();
            PlayerPrefs.SetInt("score", count);
            PlayerPrefs.Save();
        }
    }


}
