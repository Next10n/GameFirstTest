using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] private float _fireCountdown = 2f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartTransform;
    private bool _fireFlag = true;
    private Rigidbody2D _myRigidBody;
    private GameObject HealthBar;
    private bool _immortal = false;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GameObject.Find("HealthBar");
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR_WIN
        _myRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, Input.GetAxis("Vertical") * _speed * Time.deltaTime);
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg));
#endif

#if UNITY_ANDROID
        _myRigidBody.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * _speed * Time.deltaTime, CrossPlatformInputManager.GetAxis("Vertical") * _speed * Time.deltaTime);
        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(CrossPlatformInputManager.GetAxis("Vertical"), CrossPlatformInputManager.GetAxis("Horizontal")) * Mathf.Rad2Deg));
#endif

#if UNITY_EDITOR_WIN
         if (Input.GetMouseButtonDown(0)) Fire();
#endif

#if UNITY_ANDROID
        if (CrossPlatformInputManager.GetButtonDown("Fire")) Fire();
#endif
        print(CrossPlatformInputManager.GetAxis("horizontal"));
    }

    void Fire()
    {
        if (_fireFlag)
        {
            Instantiate(_bullet, _bulletStartTransform.position, _bulletStartTransform.rotation);            
            _fireFlag = false;
            Invoke("setFireFlagTrue", _fireCountdown);
        }

    }

    private void setFireFlagTrue()
    {
        _fireFlag = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (_immortal)
            {

            }
            else
            {
                _immortal = true;
                GetComponent<Animator>().SetTrigger("PlayerGetHit");
                //Invoke("setAfkFalse", _TimeSleepAfterHit);
                Health hp = GetComponent<Health>();
                hp.TakeDamae(1);
                Invoke("ImmortalSetFalse", 3);
                HealthBar.GetComponent<HealthBarScript>().RemoveHealth();
            }
        }

        //_enemyAnimator.SetTrigger("HitTrigger");
    }

    void ImmortalSetFalse()
    {
        _immortal = false;
    }
}
