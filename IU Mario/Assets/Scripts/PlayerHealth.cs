using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
   public int health;
   public bool hasDied;

    void Start()
    {
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -8) {
            hasDied = true;
            Die();
        }
    }

    void Die() {
        SceneManager.LoadScene("Level1");
    }
}
