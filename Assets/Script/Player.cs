using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction OnScore;
    public event UnityAction OnDie;

    public float jumpPower = 1;
    public float maxSpeed = 5;

    Rigidbody2D playerRigid;

    private void Awake() {
        playerRigid = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        if(Input.GetButtonDown("Jump"))
        {
            playerRigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if(playerRigid.velocity.y > maxSpeed)
        {
            playerRigid.velocity = new Vector2(0, maxSpeed);
        }
        else if(playerRigid.velocity.x < -maxSpeed)
        {
            playerRigid.velocity = new Vector2(0, -maxSpeed);
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("게임 오버");
        OnDie?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("점수 획득");
        OnScore?.Invoke();
    }
}
