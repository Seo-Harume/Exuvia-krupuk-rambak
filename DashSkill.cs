using System.Collections;
using UnityEngine;

public class DashSkill : MonoBehaviour
{
    [Header("Dash Settings")]
    [Tooltip("Dash speed multiplier")]
    public float DashSpeed = 10.0f;
    [Tooltip("Duration of the dash in seconds")]
    public float DashDuration = 0.2f;
    [Tooltip("Cooldown time between dashes in seconds")]
    public float DashCooldown = 1.0f;

    private bool _isDashing;
    private float _dashTimeRemaining;
    private float _dashCooldownRemaining;

    private Vector3 _dashDirection;
    private CharacterController _characterController;
    private StarterAssets.StarterAssetsInputs _input;
    private GameObject _mainCamera;

    private void Start()
    {
        // Dapatkan referensi komponen yang diperlukan
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<StarterAssets.StarterAssetsInputs>();
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        HandleDash();
    }

    private void HandleDash()
    {
        // Jika sedang dalam dash, jalankan logika dash
        if (_isDashing)
        {
            _dashTimeRemaining -= Time.deltaTime;

            if (_dashTimeRemaining <= 0)
            {
                _isDashing = false;
                _dashCooldownRemaining = DashCooldown; // Aktifkan cooldown setelah dash selesai
            }

            _characterController.Move(_dashDirection * DashSpeed * Time.deltaTime);
            return;
        }

        // Jika tidak sedang dash, kurangi cooldown jika ada
        if (_dashCooldownRemaining > 0)
        {
            _dashCooldownRemaining -= Time.deltaTime;
        }

        // Hanya aktifkan dash jika _input.dash adalah true, cooldown habis, dan ada input gerakan
        if (_input.dash && _dashCooldownRemaining <= 0 && _input.move != Vector2.zero)
        {
            StartDash();
        }
        else
        {
            // Pastikan dash dinonaktifkan jika pemain tidak menekan input
            _input.dash = false;
        }
    }

    private void StartDash()
    {
        // Arah dash berdasarkan input (jika ada input gerakan)
        Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

        if (inputDirection == Vector3.zero)
        {
            Debug.LogWarning("No movement input detected. Dash will not activate.");
            return;
        }

        _isDashing = true;
        _dashTimeRemaining = DashDuration;

        // Orientasi dash mengikuti kamera
        _dashDirection = Quaternion.Euler(0.0f, _mainCamera.transform.eulerAngles.y, 0.0f) * inputDirection;

        // Debugging
        Debug.Log($"Dash started in direction: {_dashDirection}");
    }
}
