using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{

    [SerializeField] GameObject[] _lives;
    int _lenght = 3;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject hp in _lives)
            hp.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveHealth()
    {
        if (_lenght > 0)
            Destroy(_lives[_lenght - 1]);
        _lenght--;
    }
}
