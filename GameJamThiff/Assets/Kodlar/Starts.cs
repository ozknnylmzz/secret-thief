using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
    public GameObject settings;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sett()
    {
        settings.SetActive(true);
    }
    public void str()
    {
        SceneManager.LoadScene("1");
    }
    public void close()
    {
        settings.SetActive(false);
    }
}
