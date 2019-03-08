using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Return : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void Return_menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
