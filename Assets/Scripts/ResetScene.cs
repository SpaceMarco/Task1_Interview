using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetScene : MonoBehaviour
{
    public void ResetAll()
    {
        SceneManager.LoadScene(0);
    }
}
