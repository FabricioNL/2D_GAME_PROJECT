using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AjudaScript : MonoBehaviour
{

    public GameObject main;
    public GameObject other;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        // Insira aqui o código que será executado quando o botão for clicado
        main.SetActive(false);
        other.SetActive(true);
    }
}
