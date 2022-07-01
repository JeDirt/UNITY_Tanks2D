using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TankController : MonoBehaviour
{

    [SerializeField]
    private float tankSpeed = 10.0f;
    public GameObject projectilePrefab;
    
    [SerializeField]
    private Transform projectileSpawnLocation;
    public float projectileMovementSpeed = 15.0f;
    
    [SerializeField, Tooltip("Projectile spawn rate, avoids spamming")]
    private float fireRate = 1.0f;

    public Animator rightTrackAnimator;
    public Animator leftTrackAnimator;
    private bool _bIsMoving = false;
    
    /** Timer for handling projectile spawn rate */
    private float _timer = 0.0f;
    
    private float _horizontalInput;
    private float _verticalInput;
    private Rigidbody2D _tankRigidbody;
    
    
    /** Engine events */
    void Start()
    {
        _tankRigidbody = GetComponent<Rigidbody2D>();
        _timer = fireRate;
    }
    private void Update()
    {
        Move();
        LaunchProjectile();
    }

    
    /** Tank functionality */
    private void Move()
    {
        
        // Handle A/D movement
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        if (_horizontalInput != 0.0f && _verticalInput == 0.0f)
        {
            transform.position += new Vector3(_horizontalInput * tankSpeed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0,0,-90 * _horizontalInput);
            _bIsMoving = true;
        }
        
        // Handle W/S movement
        _verticalInput = Input.GetAxisRaw("Vertical");
        if (_verticalInput != 0.0f && _horizontalInput == 0.0f)
        {
            transform.position += new Vector3(0, _verticalInput * tankSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0,0,90 - 90 * _verticalInput);
            _bIsMoving = true;
        }

        // Player tries to press a few buttons the same time
        if ((_horizontalInput == 0.0f && _verticalInput == 0.0f) ||
            (Mathf.Abs(_verticalInput) == 1.0f && Mathf.Abs(_horizontalInput) == 1.0f))
        {
            _bIsMoving = false;
        }
        rightTrackAnimator.SetBool("bIsMoving", _bIsMoving);
        leftTrackAnimator.SetBool("bIsMoving", _bIsMoving);

    }
    private void LaunchProjectile()
    {

        _timer += Time.deltaTime;
        if (!(_timer >= fireRate)) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var projectile = Instantiate(projectilePrefab, projectileSpawnLocation.position, transform.rotation);
            if (!projectile) return;
            _timer = 0.0f;

            var rigidBody = projectile.GetComponent<Rigidbody2D>();
            if (rigidBody)
            {
                rigidBody.velocity = projectileSpawnLocation.up * projectileMovementSpeed;
            }
        }
        
    }

    
}
