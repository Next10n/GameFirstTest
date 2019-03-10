using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _yMax;
    [SerializeField] float _yMin;
    [SerializeField] float _xMax;
    [SerializeField] float _xMin;
    [SerializeField] float _spawnTime;
    [SerializeField] private GameObject _enemy;
    Vector3 spawnPosition;
    Vector3 randomDerection;
    GameObject enemy;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", _spawnTime, _spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float GenerateNumOnMaxMin(float _nMin, float _nMax, float nRand)
    {        
        if (_nMax - nRand > nRand - _nMin)
            return _nMin;
        else
            return _nMax;
    }

    void GeneratePosAndDerection()
    {
        float distX;
        float distY;
        float xRand = Random.Range(_xMin + 2, _xMax - 2);
        float yRand = Random.Range(_yMin + 2, _yMax - 2);
        distX = Distance(_xMin, _xMax, xRand);
        distY = Distance(_yMin, _yMax, yRand);
        if(distX > distY)
        {
            y = GenerateNumOnMaxMin(_yMin, _yMax, yRand);
            x = xRand;
        }

        else
        {
            x = GenerateNumOnMaxMin(_xMin, _xMax, xRand);
            y = yRand;
        }               
        
        transform.position = new Vector3(x, y, 0);
        randomDerection = spawnPosition - new Vector3(xRand, yRand, 0);
    }

    float Distance(float dMin, float dMax, float pos)
    {
        if (dMax - pos > pos - dMin)
            return  pos - dMin;
        else
            return  dMax - pos;
    }

    void Spawn()
    {
        GeneratePosAndDerection();
        enemy = Instantiate(_enemy, transform.position, transform.rotation);
        enemy.GetComponent<EnemyController>().SetDerection(randomDerection);
    }

}
