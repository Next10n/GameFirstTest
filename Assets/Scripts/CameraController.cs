using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _yTop;
    [SerializeField] float _yBot;
    [SerializeField] float _xLeft;
    [SerializeField] float _xRight;
    [SerializeField] float _cameraSpeed;
    private GameObject _player;
    private Vector3 _cameraBorder;
    // Start is called before the first frame update
    void Start()
    {
        _cameraBorder = transform.position;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards( 
            transform.position, 
            new Vector3(
                _player.transform.position.x, 
                _player.transform.position.y, 
                transform.position.z), 
            _cameraSpeed * Time.deltaTime);

        CameraFixed();
    }

    private void CameraFixed()
    {
        if (transform.position.x >= _xRight) _cameraBorder.x = _xRight;
        else if (transform.position.x <= _xLeft) _cameraBorder.x = _xLeft;
        else _cameraBorder.x = transform.position.x;

        if (transform.position.y >= _yTop) _cameraBorder.y = _yTop;
        else if (transform.position.y <= _yBot) _cameraBorder.y = _yBot;
        else _cameraBorder.y = transform.position.y;

        transform.position = _cameraBorder;
    }


}
