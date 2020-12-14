using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public int EnemeySpeed;
    public int XMoveDirection;
    public bool facingRight = true;
    [SerializeField] GameObject _gameOverText;
    public bool _isGameOver = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection,0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection,0)* EnemeySpeed;
        if (hit.distance < 0.7f) {
            FLip();
            if (hit.collider.tag == "Player") {
                Destroy (hit.collider.gameObject);
                _isGameOver = true;
                _gameOverText.SetActive(true);

            }
        }

    if (Input.GetKeyDown(KeyCode.R) && _isGameOver)
        SceneManager.LoadScene("Level1");

    }

    void FLip(){
        if (XMoveDirection > 0){
            XMoveDirection = -1;
            FlipPlayer();
        }
        else {
            XMoveDirection = 1;
            FlipPlayer();
        }
    }  
     void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void InitiateGameOver() {
        _isGameOver = true;
        _gameOverText.SetActive(true);
    }


}
