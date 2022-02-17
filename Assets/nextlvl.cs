using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextlvl : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //lade hier das zugehörige lvl
        SceneManager.LoadScene("Level2");
    }
}
