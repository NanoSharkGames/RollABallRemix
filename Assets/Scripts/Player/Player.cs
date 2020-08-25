using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    //TODO offload health into a Health.cs script
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;

    [SerializeField] Inventory _inventory;

    BallMotor _ballMotor;

    MeshRenderer _meshRenderer;

    Material _normalMaterial;
    [SerializeField] Material _invincibilityMaterial;

    bool isInvincible = false;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _normalMaterial = _meshRenderer.material;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if (!isInvincible)
        {
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }
        else
        {
            Debug.Log("Player has deflected hit!");
        }
    }

    public void IncreaseTreasure(int amount)
    {
        _inventory.IncreaseTreasure(amount);
        Debug.Log("Player's treasure: " + _inventory.GetTreasure());
    }

    public void Kill()
    {
        if (!isInvincible)
        {
            gameObject.SetActive(false);
            // play particles
            // play sounds
        }
        else
        {
            Debug.Log("Player has avoided death!");
        }
    }

    public void Knockback(Vector3 direction, float speed)
    {
        _ballMotor.Knockback(direction, speed);
    }

    public void ActivateInvinciblity()
    {
        _meshRenderer.material = _invincibilityMaterial;
        isInvincible = true;
    }

    public void DeactivateInvinciblity()
    {
        _meshRenderer.material = _normalMaterial;
        isInvincible = false;
    }
}