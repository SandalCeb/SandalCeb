using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI Number;
    // Start is called before the first frame update
    int TimerCount = 30;

    public GameObject LoseImage;
    void Start()
    {
         InvokeRepeating("TimerFunction", 1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void TimerFunction(){
        TimerCount--;  
        Number.text=TimerCount.ToString();
        if (TimerCount <= 0){
             LoseImage.SetActive(true);
        }
     }
}
