using NodeCanvas.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    public class AT_DealingCards : ActionTask
    {
        public BBParameter<GameObject> player01;
        public BBParameter<GameObject> player02;
        public BBParameter<GameObject> player03;
        public BBParameter<List<int>> player01Cards;

        protected override string OnInit()
        {
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            var tempText = player01.value.GetComponentsInChildren<TMP_Text>();
            foreach (var t in tempText)
            {
                player01Cards.value.Add(int.Parse(t.text));
            }
            foreach (int c in player01Cards.value)
            {
                Debug.Log(c);
            }
            EndAction(true);
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {

        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}