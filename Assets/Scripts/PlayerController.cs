using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f; // Rotasyon hýzýný ayarlayabilirsiniz
    public Camera mainCamera;
    public FixedJoystick movementJoystick; // Hareket için kullanýlan joystick
    public FixedJoystick rotationJoystick; // Rotasyon için kullanýlan joystick

    private Animator animator; // Animator bileþeni

    private void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Hareket girdilerini al
        float horizontalInput = movementJoystick.Horizontal;
        float verticalInput = movementJoystick.Vertical;

        // Hareket yönünü belirle
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Hareket ediyor mu kontrol et
        bool isRunning = moveDirection.magnitude > 0.1f;

        // Animator'daki IsRunning parametresini güncelle
        if (animator != null)
        {
            animator.SetBool("IsRunning", isRunning);
        }

        // Karakteri hareket ettir
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Rotasyon girdilerini al
        float rotationHorizontal = rotationJoystick.Horizontal;
        float rotationVertical = rotationJoystick.Vertical;

        // Rotasyon joystick girdisi varsa yön deðiþtir
        if (rotationHorizontal != 0 || rotationVertical != 0)
        {
            Vector3 lookDirection = new Vector3(rotationHorizontal, 0, rotationVertical).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}