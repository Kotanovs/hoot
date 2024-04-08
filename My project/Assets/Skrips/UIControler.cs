using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    public Text scoresDispley;
    // Start is called before the first frame update
    void Start ()
    {
        GameManager.instance.scoreEvent += ScoreChange;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
     void ScoreChange (int scores)
    {
        if (scoresDispley != null)
            scoresDispley.text = scores.ToString();
    }
    void OnDestroy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
