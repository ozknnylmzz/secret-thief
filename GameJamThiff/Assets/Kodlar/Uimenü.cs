using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Uimenü : MonoBehaviour
{
    public string sayfadı;
    public GameObject aktifet;
    public GameObject kapat;
    public bool timedursunmu;
    public bool timeacılsınmı;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void gameover() 
    {
        PlayerPrefs.GetInt("bolum");
    }

    public void go() 
    {
        SceneManager.LoadScene(sayfadı);
    }
    public void ac() 
    {
        if (timedursunmu)
        {
            Time.timeScale = 0;
        }
        aktifet.gameObject.SetActive(true);
    }
    public void kapa() 
    {
        if (timeacılsınmı)
        {
            Time.timeScale = 1;
        }
        kapat.SetActive(false);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void rest()
    {
        timeacılsınmı = true;
        kapa();
        SceneManager.LoadScene(PlayerPrefs.GetInt("bolum").ToString());
    }


}
