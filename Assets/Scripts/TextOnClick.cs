using TMPro;
using UnityEngine;

public class TextOnClick : MonoBehaviour
{
    public Material selected;
    public Material unselected;
    private bool selectedState;

    private void Start()
    {
        this.GetComponent<TMP_Text>().color = Color.black;
        this.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = unselected;
        selectedState = false;
    }

    public void OnClick()
    {
        if (selectedState == true)
        {
            this.GetComponent<TMP_Text>().color = Color.black;
            this.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = unselected;
            selectedState = false;
            Debug.Log(this.name + "unselected!");
        }
        else
        {
            this.GetComponent<TMP_Text>().color = Color.red;
            this.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = selected;
            selectedState = true;
            Debug.Log(this.name + "selected!");
        }
    }
}
