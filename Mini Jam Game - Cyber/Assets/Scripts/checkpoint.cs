using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
    public string level;

    public void nextLevel() 
    {
        SceneManager.LoadScene(level);
    }
}
