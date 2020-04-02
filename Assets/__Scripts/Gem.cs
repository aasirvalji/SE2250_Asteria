using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gem : MonoBehaviour
{

    public Text countText;
    public Text winText;

    private Rigidbody _rb;
    private int _count;

    public GameObject allGemsActive;
    public GameObject orbOfAsteria;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0; //score starts at zero
        SetCountText();
        winText.text = ""; //initialize ending text

    }


    void OnTriggerEnter(Collider other) //triggered everytime player touches a gem
    {
        if (other.gameObject.CompareTag("decoy")) //test its tag, and if it matches destroy decoy
        {
            other.gameObject.SetActive(false); //then deactivate the touched game piece
           

        }

        if (other.gameObject.CompareTag("gem")) //test its tag, and if it matches pick up

        {
            other.gameObject.SetActive(false); //then deactivate the touched game piece
            _count = _count + 1; //rubies are worth 1 point
            SetCountText();
        }

        if (other.gameObject.CompareTag("orbAsteria"))
        {
            SceneManager.LoadScene("PostLevel3");
        }
    }

    void SetCountText()
    {
        countText.text =  _count.ToString() + "/4 gems obtained";
        if (_count >= 4) //if score is equal to 4, then print the win text
        {
            winText.text = "4/4 gems found! The Orb of Asteria is complete.";
            allGemsActive.SetActive(false);
            orbOfAsteria.SetActive(true);

        }

    }


}
