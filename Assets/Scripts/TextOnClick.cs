using NodeCanvas.Framework;
using TMPro;
using UnityEngine;

public class TextOnClick : MonoBehaviour
{
    public Material selected;
    public Material unselected;
    public bool selectedState;
    public Blackboard croupier;

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
            croupier.SetVariableValue("redrawIndex", -1);
        }
        else
        {
            this.GetComponent<TMP_Text>().color = Color.red;
            this.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = selected;
            selectedState = true;
            Debug.Log(this.name + "selected!");
            croupier.SetVariableValue("redrawIndex", int.Parse(this.name));
        }
    }
}
