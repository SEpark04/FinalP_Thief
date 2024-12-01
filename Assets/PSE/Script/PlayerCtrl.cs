using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float v = 0;  // ����
    private float h = 0;  // ����

    [SerializeField] private float speed = 20;  // �̵� �ӵ�
    [SerializeField] private float rotSpeed = 50; // ȸ�� �ӵ�

    private Animator _animator;

    private Vector3 moveDir = new Vector3(0, 0, 0);  // ����

    [SerializeField] private float jumpForce = 5f;  // ���� �Ŀ�
    [SerializeField] private Transform groundCheck; // �ٴ� üũ ��ġ (ĳ���� �� �Ʒ� ��ġ)
    [SerializeField] private float groundDistance = 0.2f; // �ٴ� üũ�� ���� �Ÿ�
    [SerializeField] private LayerMask groundMask;  // �ٴ� ���̾� ����ũ

    private Rigidbody rb;
    private bool isGrounded;


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

        // �̵����� 
        moveDir = (Vector3.forward * mappingV + Vector3.right * mappingH);

        // ĳ���� �̵�
        transform.Translate(moveDir * speed * Time.deltaTime, Space.Self);

        // ĳ���� ȸ��
        transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));

        // ĳ���� ����
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundMask); // �ٴڿ� �ִ��� üũ

        if (!isGrounded)
        {
            _animator.SetBool("p_Jump", true);
        }
        else
        {
            _animator.SetBool("p_Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // �ٴڿ� ���� �� Space�� ������
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

}
