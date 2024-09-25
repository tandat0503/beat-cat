using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class DichuyenPlayer2 : MonoBehaviour
{

  
    public float tocdo;
    public TextMeshProUGUI textMeshProUGUI; // Hiển thị điểm
    public TextMeshProUGUI timeLimitText; // Hiển thị thời gian giới hạn
    private int point = 0;

    private Rigidbody2D rb;
    private Animator anim;

    private float timeSinceLastCarrot = 0f; // Thời gian từ lần nhặt cà rốt cuối
    public float timeLimit = 5f; // Thời gian giới hạn để nhặt cà rốt
    public float additionalTime = 2f; // Thời gian cộng thêm khi nhặt cà rốt

    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UpdateTimeLimitText(); // Cập nhật thời gian giới hạn ban đầu
    }

    void Update()
    {


        if (!isGameOver) // Chỉ cho phép di chuyển khi chưa thua
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * tocdo * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * tocdo * Time.deltaTime);
            }

            // Tăng thời gian từ lần nhặt cà rốt cuối
            timeSinceLastCarrot += Time.deltaTime;

            // Kiểm tra nếu thời gian vượt quá giới hạn
            if (timeSinceLastCarrot >= timeLimit)
            {
                GameOver();
            }

            UpdateTimeLimitText(); // Cập nhật hiển thị thời gian còn lại
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "CarrotSpawner2(Clone)")
        {
            point++;
            textMeshProUGUI.text = point.ToString();
            timeSinceLastCarrot = 0f; // Đặt lại thời gian khi nhặt cà rốt
            timeLimit += additionalTime; // Cộng thêm thời gian khi nhặt cà rốt
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        textMeshProUGUI.text = "Thua! Nhấn R để chơi lại."; // Hiển thị thông báo thua
    }

    private void OnGUI()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R)) // Nếu thua, nhấn R để chơi lại
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Nạp lại cảnh hiện tại
        }
    }

    private void UpdateTimeLimitText()
    {
        timeLimitText.text = "Time: " + Mathf.Ceil(timeLimit - timeSinceLastCarrot).ToString(); // Hiển thị thời gian còn lại
    }
}
