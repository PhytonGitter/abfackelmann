using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
public void GotoLevel1Scene()
{
SceneManager.LoadScene("Level1");
}

public void GotoMenuScene()
{
SceneManager.LoadScene("menu");
}
public void OnTriggerEnter2D(Collider2D other)
{
SceneManager.LoadScene("Level2");
}
}