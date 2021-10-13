using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCounter : MonoBehaviour
{
    [SerializeField] Text m_count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_count.text = TurnManager.TurnCount.ToString("D10");
    }
}
