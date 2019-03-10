using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    private GameObject _score;
    int _scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        _score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        _score.GetComponent<Text>().text = "SCORE: " + _scoreValue;
    }

    public void AddScore(int a)
    {
        _scoreValue += a;
    }
}
