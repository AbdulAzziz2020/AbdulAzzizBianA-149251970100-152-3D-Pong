using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    { 
        player1,
        player2,
        player3,
        player4
    }

    public PlayerState choosePlayer;
    public float speed;
    public Rigidbody rb;
    public float mapWidth;

    private void FixedUpdate()
    {
        switch (choosePlayer)
        {
            case PlayerState.player1: Player1(); break;
            case PlayerState.player2: Player2(); break;
            case PlayerState.player3: Player3(); break;
            case PlayerState.player4: Player4(); break;
        }    
    }

    #region Player Controller
    void Player1()
    {
        if(Data.isEndForPlayer1)
        {
            float player1 = Input.GetAxis("Controller1") * speed * Time.deltaTime;
            Vector3 newPositionPlayer1 = rb.position + Vector3.right * player1;
            newPositionPlayer1.x = Mathf.Clamp(newPositionPlayer1.x, -mapWidth, mapWidth);
            rb.MovePosition(newPositionPlayer1);

        } else {
            transform.position = new Vector3(0, transform.position.y, -5.44f);
            transform.localScale = new Vector3(11.5f, transform.localScale.y, transform.localScale.z);
        }
        
    }

    void Player2()
    {
        if(Data.isEndForPlayer2)
        {
            float player2 = Input.GetAxis("Controller2") * speed * Time.deltaTime;
            Vector3 newPositionPlayer2 = rb.position + Vector3.forward * player2;
            newPositionPlayer2.z = Mathf.Clamp(newPositionPlayer2.z, -mapWidth, mapWidth);
            rb.MovePosition(newPositionPlayer2);
        } else {
            transform.position = new Vector3(-5.44f, transform.position.y, 0);
            transform.localScale = new Vector3(11.5f, transform.localScale.y, transform.localScale.z);
        }
        
    }

    void Player3()
    {
        if(Data.isEndForPlayer3)
        {
            float player3 = Input.GetAxis("Controller3") * speed * Time.deltaTime;
            Vector3 newPositionPlayer3 = rb.position + Vector3.right * player3;
            newPositionPlayer3.x = Mathf.Clamp(newPositionPlayer3.x, -mapWidth, mapWidth);
            rb.MovePosition(newPositionPlayer3);
        } else {
            transform.position = new Vector3(0, transform.position.y, 5.44f);
            transform.localScale = new Vector3(11.5f, transform.localScale.y, transform.localScale.z);
        }
    }

    void Player4()
    {
        if(Data.isEndForPlayer4)
        {
            float player4 = Input.GetAxis("Controller4") * speed * Time.deltaTime;
            Vector3 newPositionPlayer4 = rb.position + Vector3.forward * player4;
            newPositionPlayer4.z = Mathf.Clamp(newPositionPlayer4.z, -mapWidth, mapWidth);
            rb.MovePosition(newPositionPlayer4);
        } else {
            transform.position = new Vector3(5.44f, transform.position.y, 0);
            transform.localScale = new Vector3(11.5f, transform.localScale.y, transform.localScale.z);
        }
        
    }
    #endregion
}
