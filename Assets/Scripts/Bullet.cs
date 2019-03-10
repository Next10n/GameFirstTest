using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    [SerializeField] private float _speed = 10;
    [SerializeField] private float _lifeTime = 4;
    [SerializeField] private int _damage = 1;
    private GameObject player;
    private Rigidbody2D _bulletRigidBody;
    // Use this for initialization
    void Start ()
    {
        _bulletRigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");    
        transform.rotation = player.transform.rotation;
        Destroy(gameObject, _lifeTime);

        _bulletRigidBody.AddForce(transform.right * _speed);
        //_bulletRigidBody.velocity = new Vector2(player.transform.rotation.x, player.transform.rotation.y).normalized * _force;
    }
	
	// Update is called once per frame
	void Update () {

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ForeGround")
        {
            Destroy(gameObject);
        }



        if (collision.gameObject.tag == "Enemy")
        {

            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Animator>().SetTrigger("Dead");
            GameObject.Find("Score").GetComponent<UpdateScore>().AddScore(1);
            Destroy(collision.gameObject, 1);
            Destroy(gameObject);
        }
    }
}
