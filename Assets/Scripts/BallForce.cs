using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallForce : MonoBehaviour
{
    private Rigidbody rb;
    private int score = 0;

    public int force = 5;
    public Text scoreText;
    public GameObject winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(h, 0, v) * force);
    }

    // 碰撞检测
    // Prefebs/Food/Box Collider/ Is Trigger 不选中会触发
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Food") {
            Destroy(collision.collider.gameObject);
        }
    }

    // 触发检测 没有物理碰撞效果
    // Prefebs/Food/Box Collider/ Is Trigger 选中会触发
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Food")
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            Destroy(collider.gameObject);
            if (score == 7)
            {
                winText.SetActive(true);
            }
        }   
    }
}
