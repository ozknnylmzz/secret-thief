using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void go()
    {
        if (PlayerPrefs.GetInt("bolum") + 1 == 4)
        {
            SceneManager.LoadScene("Menu");
        }
        else 
        {
            SceneManager.LoadScene((PlayerPrefs.GetInt("bolum") + 1).ToString());
        }
        
    }
}
