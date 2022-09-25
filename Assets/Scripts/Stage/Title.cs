using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            FadeManager.Instance.LoadScene("Stage1", 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            FadeManager.Instance.LoadScene("Stage7", 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            FadeManager.Instance.LoadScene("Stage6", 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            FadeManager.Instance.LoadScene("Stage21", 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            FadeManager.Instance.LoadScene("Stage10", 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            FadeManager.Instance.LoadScene("Stage9", 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            FadeManager.Instance.LoadScene("Stage8", 1.0f);
        }
    }
}
