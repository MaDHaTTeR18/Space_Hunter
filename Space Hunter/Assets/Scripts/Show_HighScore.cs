using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_HighScore : MonoBehaviour
{ 
    public Text Position1;
    public Text Position2;
    public Text Position3;
    void Start()
    {
        Position1.text = "1." + PlayerPrefs.GetInt("HighScore 1", 0).ToString();
        Position2.text = "2." + PlayerPrefs.GetInt("HighScore 2", 0).ToString();
        Position3.text = "3." + PlayerPrefs.GetInt("HighScore 3", 0).ToString();
    }
    
}
