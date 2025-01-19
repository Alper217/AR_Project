using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f; // Rotasyon h�z�n� ayarlayabilirsiniz
    public Camera mainCamera;
    public FixedJoystick movementJoystick; // Hareket i�in kullan�lan joystick
    public FixedJoystick rotationJoystick; // Rotasyon i�in kullan�lan joystick

    private Animator animator; // Animator bile�eni

    private void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Hareket girdilerini al
        float horizontalInput = movementJoystick.Horizontal;
        float verticalInput = movementJoystick.Vertical;

        // Hareket y�n�n� belirle
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Hareket ediyor mu kontrol et
        bool isRunning = moveDirection.magnitude > 0.1f;

        // Animator'daki IsRunning parametresini g�ncelle
        if (animator != null)
        {
            animator.SetBool("IsRunning", isRunning);
        }

        // Karakteri hareket ettir
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Rotasyon girdilerini al
        float rotationHorizontal = rotationJoystick.Horizontal;
        float rotationVertical = rotationJoystick.Vertical;

        // Rotasyon joystick girdisi varsa y�n de�i�tir
        if (rotationHorizontal != 0 || rotationVertical != 0)
        {
            Vector3 lookDirection = new Vector3(rotationHorizontal, 0, rotationVertical).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}