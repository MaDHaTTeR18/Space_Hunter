using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_by_Contact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject Player_explosion;
    public int scoreValue;

    private Game_Controller gamecontroller;
   
    private void Start()
    {
        GameObject gamecontrollerobject = GameObject.FindWithTag("GameController");
        if(gamecontrollerobject!=null)
        {
            gamecontroller = gamecontrollerobject.GetComponent<Game_Controller>();
        }
        if (gamecontroller == null)
        {
            Debug.Log("Cannot find script");
        }
    }

    void OnTriggerEnter(Collider other)
    {   if (other.CompareTag ( "Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player"){
            Instantiate(Player_explosion, other.transform.position, other.transform.rotation);
            gamecontroller.Game_Over();
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
        gamecontroller.Add_Score(scoreValue);
    }
}
