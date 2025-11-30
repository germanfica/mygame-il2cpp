using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUI;

    // Start is called before the first frame update
    void Start()
    {
        textUI.text = "Hello World";
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
