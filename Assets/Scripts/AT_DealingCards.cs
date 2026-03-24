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
        private TMP_Text[] player01CardsText;
        private TMP_Text[] player02CardsText;
        public BBParameter<List<int>> player01CardsNumberBBP;
        public BBParameter<List<int>> player02CardsNumberBBP;

        protected override string OnInit()
        {
            // Initialization of the card text arrays
            // Retrieves all `TMP_Text` components on the children of `player01BBP.value` GameObject.
            // The returned array `player01CardsText` is used as the UI targets for reading initial card text values and writing updated card numbers (see `UpdateText()`).
            player01CardsText = player01BBP.value.GetComponentsInChildren<TMP_Text>();
            foreach (var t in player01CardsText)
            {
                player01CardsNumberBBP.value.Add(int.Parse(t.text));
            }
            player02CardsText = player02BBP.value.GetComponentsInChildren<TMP_Text>();
            foreach (var t in player02CardsText)
            {
                player02CardsNumberBBP.value.Add(int.Parse(t.text));
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
            foreach (int c in player02CardsNumberBBP.value)
            {
                Debug.Log(c);
            }

            return null;
        }

        private void Dealing()
        {
            // Simulate dealing cards by assigning random values between 1 and 10 to each player's card numbers.
            for (int i = 0; i < 5; i++)
            {
                player01CardsNumberBBP.value[i] = Random.Range(1, 10);
                player02CardsNumberBBP.value[i] = Random.Range(1, 10);
            }
            Debug.Log("dealing");
        }

        private void UpdateText()
        {
            // Update the text of each card for both players based on the current values in `player01CardsNumberBBP` and `player02CardsNumberBBP`.
            for (int i = 0; i < 5; i++)
            {
                player01CardsText[i].text = player01CardsNumberBBP.value[i].ToString();
                player02CardsText[i].text = player02CardsNumberBBP.value[i].ToString();
            }
        }

        protected override void OnExecute()
        {
            // If the dealing phase is active, perform the dealing and update the card texts, then end the action.
            if (dealingPhaseBBP.value == true) dealingPhaseBBP.value = false;
            EndAction(true);
        }
    }
}