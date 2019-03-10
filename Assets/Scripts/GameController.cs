using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject _player;
    private int _health;
    private GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        GameOver = GameObject.Find("GameOverPanel");
        GameOver.SetActive(false);
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        _health = _player.GetComponent<Health>().GetHP();
        if (_health == 0)
        {
            GameOver.SetActive(true);
            Invoke("EndGame", 3);            
        }

    }

    void EndGame()
    {
        Application.LoadLevel(0);
    }
}
