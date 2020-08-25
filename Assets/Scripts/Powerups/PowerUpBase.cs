using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    private Player player;

    [SerializeField] float _powerUpDuration = 10f;

    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;

    Collider _collider;
    Renderer _renderer;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            PowerUp(player);

            // Spawn particles & SFX because we need to disable object
            Feedback();

            _collider.enabled = false;
            _renderer.enabled = false;

            StartCoroutine(PowerUpTimer(_powerUpDuration));
        }
    }

    private void Feedback()
    {
        // Particles
        if (_collectParticles != null)
        {
            _collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);
        }

        // Audio. TODO - consider object pooling for performance
        if (_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }

    private IEnumerator PowerUpTimer(float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            yield return new WaitForSeconds(1f);

            elapsedTime += 1;
        }

        PowerDown(player);

        gameObject.SetActive(false);
    }
}
