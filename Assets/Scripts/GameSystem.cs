using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public float resetDelay = 1f;

    public Text PlayerOneScore;
    public Text PlayerTwoScore;
    public Text winner;
    public GameObject paddle;
    public GameObject ball;
    public GameObject deathParticles;

    public static GameSystem instance = null;

    private GameObject cloneBall;

    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();
    }
	
    void Setup()
    {
        cloneBall = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
    }

    void CheckGameOver()
    {
        if(playerOneScore >= 5)
        {
            winner.text = "Player One Wins!";
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

        if (playerTwoScore >= 5)
        {
            winner.text = "Player Two Wins!";
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }
	
	void Reset() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void playerScored(int player){
        if (player == 1)
        {
            playerOneScore++;
            PlayerOneScore.text = string.Format("{0}", playerOneScore);
        }
        else
        {
            playerTwoScore++;
            PlayerTwoScore.text = string.Format("{0}", playerTwoScore);
        }

        Instantiate(deathParticles, cloneBall.transform.position, Quaternion.identity);

        Destroy(cloneBall);

        CheckGameOver();

        Invoke("SetupBall", resetDelay);
    }

    void SetupBall()
    {
        KinectManager.instance.IsFire = false;
        cloneBall = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;

    }
}
