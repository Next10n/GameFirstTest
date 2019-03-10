using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _yMax;
    [SerializeField] float _yMin;
    [SerializeField] float _xMax;
    [SerializeField] float _xMin;
    [SerializeField] float _speed = 5;
    [SerializeField] float _tauntDistance = 5;
    [SerializeField] float _attakDistance = 4;
    [SerializeField] Transform _startTransform;
    [SerializeField] LayerMask mask;
    [SerializeField] float _TimeSleepAfterHit = 3;
    private GameObject player;
    private bool _afk = false;
    [SerializeField] float _countdownTime = 5;
    private bool _countdown = false;
    private bool _isForward;
    public Animator _enemyAnimator;
    [SerializeField] private Image HelthBar;
    [HideInInspector] public Vector2 _derection;
    //[SerializeField] float _maxVelosyty;

    private Rigidbody2D rg;
    // Use this for initialization
    void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfOutOfRange();
        if (!_afk)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < _tauntDistance) // && Vector3.Distance(transform.position, player.transform.position) > 1)
            {
                rg.velocity = new Vector2(
                    (player.transform.position.x - transform.position.x),
                    (player.transform.position.y - transform.position.y)
                    ).normalized * new Vector2(_speed * Time.deltaTime, _speed * Time.deltaTime);
                //            rg.AddForce(new Vector2(
                //(player.transform.position.x - transform.position.x),
                //(player.transform.position.y - transform.position.y)
                //).normalized * new Vector2(_speed * Time.deltaTime, _speed * Time.deltaTime));
            }
            else
            {
                 rg.velocity = _derection.normalized * new Vector2(_speed * Time.deltaTime, _speed * Time.deltaTime);

            }
        }




    }

    public void SetDerection(Vector3 dir)
    {
        _derection = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _afk = true;
            //player.GetComponent<Animator>().SetTrigger("PlayerGetHit");
            Invoke("setAfkFalse", _TimeSleepAfterHit);
        }

        if (collision.gameObject.tag == "ForeGround")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        //_enemyAnimator.SetTrigger("HitTrigger");
        if (collision.gameObject.tag == "Enemy")
        {
           //_afk = true;
        }
    }

    private void setAfkFalse()
    {
        _afk = false;
    }

    void DestroyIfOutOfRange()
    {
        if (transform.position.x > _xMax || transform.position.x < _xMin || transform.position.y > _yMax || transform.position.y < _yMin)
            Destroy(gameObject);
    }

}
