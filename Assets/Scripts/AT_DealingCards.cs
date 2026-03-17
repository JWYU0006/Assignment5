using NodeCanvas.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    public class AT_DealingCards : ActionTask
    {
        public BBParameter<bool> dealingPhaseBBP;
        public BBParameter<GameObject> player01BBP;
        public BBParameter<GameObject> player02BBP;
        public BBParameter<GameObject> player03BBP;
        public BBParameter<List<int>> player01CardsNumberBBP;
        private TMP_Text[] player01CardsText;

        protected override string OnInit()
        {
            player01CardsText = player01BBP.value.GetComponentsInChildren<TMP_Text>();
            foreach (var t in player01CardsText)
            {
                player01CardsNumberBBP.value.Add(int.Parse(t.text));
            }
            if (dealingPhaseBBP.value == true)
            {
                Dealing();
                UpdateText();
            }
            foreach (int c in player01CardsNumberBBP.value)
            {
                Debug.Log(c);
            }

            return null;
        }

        private void Dealing()
        {
            for (int i = 0; i < 5; i++)
            {
                player01CardsNumberBBP.value[i] = Random.Range(1, 10);
            }
            Debug.Log("dealing");
        }

        private void UpdateText()
        {
            for (int i = 0; i < 5; i++)
            {
                player01CardsText[i].text = player01CardsNumberBBP.value[i].ToString();
            }
        }

        protected override void OnExecute()
        {
            if (dealingPhaseBBP.value == true) dealingPhaseBBP.value = false;
            EndAction(true);
        }
    }
}