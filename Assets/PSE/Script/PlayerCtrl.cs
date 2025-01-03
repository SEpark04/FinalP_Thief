 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float v = 0;  // 수직
    private float h = 0;  // 수평

    [SerializeField] private float speed = 20;  // 이동 속도
    [SerializeField] private float rotSpeed = 50; // 회전 속도

    private Animator _animator;

    private Vector3 moveDir = new Vector3(0, 0, 0);  // 방향

    [SerializeField] private float jumpForce = 10f;  // 점프 파워
    [SerializeField] private Transform groundCheck; // 바닥 체크 위치 (캐릭터 발 아래 위치)
    [SerializeField] private float groundDistance = 0.2f; // 바닥 체크를 위한 거리
    [SerializeField] private LayerMask groundMask;  // 바닥 레이어 마스크

    private Rigidbody rb;
    private bool isGrounded;

    public float minX = -20f;
    public float maxX = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();  
    }


    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        float mappingV = v * Mathf.Sqrt(1 - (h * h) / 2);
        float mappingH = h * Mathf.Sqrt(1 - (v * v) / 2);

        _animator.SetFloat("p_V", mappingV);
        _animator.SetFloat("p_H", mappingH);

        // 이동방향 
        moveDir = (Vector3.forward * mappingV + Vector3.right * mappingH);

        // X축 제한을 위한 새로운 위치 계산
        Vector3 newPos = transform.position + moveDir * speed * Time.deltaTime;

        // X축 제한
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);

        // 캐릭터 이동
        transform.position = newPos;

        // 캐릭터 회전
        transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));

        // 캐릭터 점프 (점프시 죽음)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            //HpCtrl.instance.jumpD = true;
            //HpCtrl.instance.Hp_down(90.0f);
        }

        // 바닥 인식하는 Ray
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundMask); // 바닥에 있는지 체크

        if (!isGrounded)
        {
            _animator.SetBool("p_Jump", true);
        }
        else
        {
            _animator.SetBool("p_Jump", false);
        }

    }

}
