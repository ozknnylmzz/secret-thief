using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rest()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("bolum").ToString());
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
