using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject DeathMenu;

    public int lostLives = 0; // indicates whether player lost lives during game
    private int Lifes = 3;

    public int getHealth()
    {
        return Lifes;
    }


    //reduces Health by 1, handels player death
    public void reduceHealth()
    {
        lostLives++;
        if (Lifes == 3)
        {
            Lifes = 2;
            FindObjectOfType<AudioManager>().Play("player-hit");
            return;
        }
        else if (Lifes == 2)
        {
            Lifes = 1;
            FindObjectOfType<AudioManager>().Play("player-hit2"); //note: hit2 not hit
            return;
        }
        else if (Lifes == 1)
        {
            Lifes = 0;
            FindObjectOfType<AudioManager>().Play("player-death");
            DeathMenu.GetComponent<PlayerDeathMenu>().GameOver();
            return;
        }
    }
    
    // Add 1 live when collecting health pickups
    public void restoreHealth()
    {
        FindObjectOfType<AudioManager>().Play("garGOyleCollectHeart");
        if (Lifes < 3)
        {
            Lifes++;
        }
    }

    private void Update()
    {
        if (Lifes == 0)
        {
            Heart1.GetComponent<Renderer>().enabled = false;
            Heart2.GetComponent<Renderer>().enabled = false;
            Heart3.GetComponent<Renderer>().enabled = false;
        }
        if (Lifes == 1)
        {
            Heart1.GetComponent<Renderer>().enabled = true;
            Heart2.GetComponent<Renderer>().enabled = false;
            Heart3.GetComponent<Renderer>().enabled = false;
        }
        if (Lifes == 2)
        {
            Heart1.GetComponent<Renderer>().enabled = true;
            Heart2.GetComponent<Renderer>().enabled = true;
            Heart3.GetComponent<Renderer>().enabled = false;
        }
        if (Lifes == 3)
        {
            Heart1.GetComponent<Renderer>().enabled = true;
            Heart2.GetComponent<Renderer>().enabled = true;
            Heart3.GetComponent<Renderer>().enabled = true;
        }
    }
}
