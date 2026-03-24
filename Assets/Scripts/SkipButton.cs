using NodeCanvas.Framework;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public Blackboard croupier;
    public void OnClick()
    {
        if (croupier.GetVariableValue<bool>("playerTurn") == true)
        {
            croupier.SetVariableValue("playerTurn", false);
        }
    }
}