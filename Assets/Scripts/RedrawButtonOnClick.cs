using NodeCanvas.Framework;
using UnityEngine;

public class RedrawButtonOnClick : MonoBehaviour
{
    public Blackboard playerBB;

    private void Start()
    {

    }

    public void OnClick()
    {
        playerBB.SetVariableValue("redrawClicked", true);
    }
}
