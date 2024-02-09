using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _characterController; 
    private bool _isFalling = true;
    private float _fallingSpeed = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFalling && _characterController.isGrounded)
        {
            _isFalling = false;
            _fallingSpeed = 0;
        } else if (_isFalling)
        {
            _fallingSpeed += Physics.gravity.y * Time.time;
            var velocity = _characterController.velocity;
            _characterController.Move(new Vector3(velocity.x, _fallingSpeed
                , velocity.z));
        }
        else if (!_isFalling && !_characterController.isGrounded)
        {
            _isFalling = true;
            _fallingSpeed += Physics.gravity.y * Time.time;
            var velocity = _characterController.velocity;
            _characterController.Move(new Vector3(velocity.x, _fallingSpeed
                , velocity.z));
        }
    }
}
