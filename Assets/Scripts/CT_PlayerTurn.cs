using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
    public class CT_PlayerTurn : ConditionTask
    {
        public Blackboard croupier;

        protected override bool OnCheck()
        {
            if (croupier.GetVariableValue<bool>("playerTurn")) return true;
            else return false;
        }
    }
}