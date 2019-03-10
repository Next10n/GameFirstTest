using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int _Health = 10;

    private void Start()
    {
        GameObject.Find("HealthBar");
    }

    private void Update()
    {

            
    }

    public void TakeDamae(int dmg)
    {
        _Health -= dmg;

        if (_Health <= 0)
            _Health = 0;

    }

    public int GetHP()
    {
        return _Health;
    }


}
