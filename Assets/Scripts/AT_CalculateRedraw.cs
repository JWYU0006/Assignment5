using NodeCanvas.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class AT_CalculateRedraw : ActionTask
    {
        public Blackboard croupier;
        public BBParameter<List<int>> cards;
        private int expectedDrawValue;
        public BBParameter<GameObject> player02BBP;
        private TMP_Text[] player02CardsText;

        protected override string OnInit()
        {
            cards.value = croupier.GetVariableValue<List<int>>("player02Cards");
            // Calculate the expected value of drawing a card from the deck. Assuming the deck has cards with values from 1 to 9,
            // the expected value is the average of these values - 5.
            expectedDrawValue = (1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9) / 9;

            player02CardsText = player02BBP.value.GetComponentsInChildren<TMP_Text>();
            return null;
        }

        protected override void OnExecute()
        {
            Debug.Log("Calculating redraw for player 2");
            int sum = 0;
            foreach (var card in cards.value)
            {
                sum += card;
            }
            // Calculate how many points the player is away from 30, positive if they are under 30, negative if they are over 30.
            int difference = 30 - sum;

            if (difference == 0)
            {
                Debug.Log("Player has exactly 30 points");
                EndAction(true);
            }
            Debug.Log($"Player has {sum} total points and {difference} points difference");

            for (int i = 0; i < cards.value.Count; i++)
            {
                // Calculate the expected change in points if the player redraws. expected draw value minus card value is the change in points of redraw.
                int expectedChange = expectedDrawValue - cards.value[i];

                // If the expected change is positive and the difference is positive, or if the expected change is negative and the difference is negative, then redraw is favorable.
                if (expectedChange < 0 && difference < 0 || expectedChange > 0 && difference > 0)
                {
                    Debug.Log($"redraw card {i}: {cards.value[i]}");
                    cards.value[i] = Random.Range(1, 10); // Simulate drawing a new card from the deck with values from 1 to 9.
                    Debug.Log($"new card {i}: {cards.value[i]}");

                    player02CardsText[i].text = cards.value[i].ToString();
                    EndAction(true);
                }
            }

            EndAction(true);
        }
    }
}