using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{

    public Text textBox;
    // Start is called before the first frame update
    public void setText(string arg)
    {
        textBox.text = arg;
    }
    

}
