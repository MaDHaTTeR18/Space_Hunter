using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject END_GAME_DISPLAY;
    public Vector3 spawnValues;
    public int hazard_Count;
    public float spawn_wait;
    public float start_wait;
    public float wave_wait;

    private int [] highscores= new int [3];
    
    public Text High_score;
    public Text Score_Text;
    private int score;

    public Text End_Game_Text;

    private bool game_Over;

    void Start()
    {
        game_Over = false;
        highscores[0] = PlayerPrefs.GetInt("HighScore 1", 0);
        highscores[1] = PlayerPrefs.GetInt("HighScore 2", 0);
        highscores[2] = PlayerPrefs.GetInt("HighScore 3", 0);
        score = 0;
        High_score.text = "High Score : " + PlayerPrefs.GetInt("HighScore 1", 0).ToString();
        
        Update_Score();
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < hazard_Count; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawn_wait);
            }
            yield return new WaitForSeconds(wave_wait);
            if (game_Over) {
                END_GAME_DISPLAY.SetActive(true);
                break;
            }
        }
    }

    public void Add_Score(int newscore) {
        score += newscore;
        Update_Score();

    }

    public void Update_Score()
    {
        Score_Text.text = "Current Score: " + score;
        if (score > PlayerPrefs.GetInt("HighScore 3", 0))
        {
            if (score > PlayerPrefs.GetInt("HighScore 2", 0))
            {
                if (score > PlayerPrefs.GetInt("HighScore 1", 0))
                {
                    PlayerPrefs.SetInt("HighScore 2", highscores[0]);
                    PlayerPrefs.SetInt("HighScore 3", highscores[1]);
                    PlayerPrefs.SetInt("HighScore 1", score);
                    High_score.text = "High Score : " + PlayerPrefs.GetInt("HighScore 1", 0).ToString();
                }
                else
                {
                    PlayerPrefs.SetInt("HighScore 2", score);
                    PlayerPrefs.SetInt("HighScore 3", highscores[1]);
                }
            }
            else {
                PlayerPrefs.SetInt("HighScore 3", score);
            }
        }
    }

    public void Game_Over()
    {
        game_Over = true;
        if (score >= PlayerPrefs.GetInt("HighScore 1", 0))
        {
            End_Game_Text.text = "Congratulations New High Score " + PlayerPrefs.GetInt("HighScore 1", 0).ToString();
        }
        else {
            End_Game_Text.text = "You LOSE ";
        }

            
    }
            
    
}
