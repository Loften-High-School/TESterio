using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ItemRandomizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int randomnumber;
    public string petname;
    public TextMeshProUGUI text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        randomnumber = Random.Range(0, 12);
        if (randomnumber == 0)
        {
            petname = "josh";
        }
        if (randomnumber == 1)
        {
            petname = "cutie";
        }
        if (randomnumber == 2)
        {
            petname = "cayden";
        }
        if (randomnumber == 3)
        {
            petname = "eggo";
        }
        if (randomnumber == 4)
        {
            petname = "Olovai";
        }
        if(randomnumber == 5)
        {
            petname = "lov";
        }
        if(randomnumber == 6)
        {
            petname = "thingy";
        }
        if(randomnumber == 7)
        {
            petname = "Chimera";
        }
        if (randomnumber == 8)
        {
            petname = "Homer";
        }
        if (randomnumber == 9)
        {
            petname = "Doug";
        }
        if (randomnumber == 10)
        {
            petname = "spooky";
        }
        if (randomnumber == 11)
        {
            petname = "Jimothy";
        }
        if (randomnumber == 12)
        {
            petname = "Fluffy";
        }
        text.text = petname;
    }
}
