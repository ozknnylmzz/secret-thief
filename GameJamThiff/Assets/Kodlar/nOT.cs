using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class nOT : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public GameObject nottext;
    public TextMeshProUGUI text;
    public GameObject lan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void swtchof()
    {
        on.SetActive(false);
        off.SetActive(true);
        text.text = "OFF";

    }

    public void swtchn()
    {
        on.SetActive(true);
        off.SetActive(false);
        text.text = "ON";
    }
    public void langue()
    {
        lan.SetActive(true);
    }
    public void lango() 
    {
        lan.SetActive(false);
    }
   
}
