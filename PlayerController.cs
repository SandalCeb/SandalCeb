using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    private CharacterController controller;
    Vector3 moveDirection;

    public GameObject WinImage;
    public GameObject LoseImage;

    float Hp = 10;
    public TextMeshProUGUI HpNumber;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

   
    void Update()
    {
        if(controller.isGrounded) {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            moveDirection = transform.forward * verticalInput + transform.right *horizontalInput;

            if(Input.GetKeyDown(KeyCode.Space)){
                moveDirection.y += jumpSpeed;
            }

        }else {
            moveDirection.y -= 9.81f * Time.deltaTime;
        }
        
        controller.Move(moveDirection * moveSpeed *Time.deltaTime);

        
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    { 
        if (hit.gameObject.tag == "flag") {
            WinImage.SetActive(true);
        }
        if (hit.gameObject.tag == "Enemy"){
            Hp = Hp - Time.deltaTime;
            HpNumber.text=Mathf.Round(Hp).ToString();
            if (Hp <= 0){ 
                LoseImage.SetActive(true);
            }
        }
    }

}
