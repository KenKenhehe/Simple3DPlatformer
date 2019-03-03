using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour {
    public Camera gameCamera;
    public PlayerController player;
    public Text gameOverText;
    public Text winText;
	// Use this for initialization
	void Start () {
        gameOverText.enabled = false;
        winText.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (player != null)
        {
            gameCamera.transform.position = new Vector3(
                Mathf.Lerp(gameCamera.transform.position.x, player.transform.position.x, Time.deltaTime * 2),
                Mathf.Lerp(gameCamera.transform.position.y, player.transform.position.y, Time.deltaTime * 2),
                gameCamera.transform.position.z
                );
            if(player.GetComponent<Rigidbody>().useGravity == false)
            {
                winText.enabled = true;
                winText.text = "You Win! press R to play again";
                if (Input.GetKeyDown(KeyCode.R))
                    Restart();
            }
            
        }
        else if(player == null)
        {
            gameOverText.enabled = true;
            gameOverText.text = "Game over! press R to restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }
      
	}

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
