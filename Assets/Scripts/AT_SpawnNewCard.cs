using NodeCanvas.Framework;
using System.Collections;
using TMPro;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class AT_SpawnNewCard : ActionTask
    {
        public BBParameter<Transform> card1Position;
        public BBParameter<int> redrawIndex;
        public GameObject prefab;
        public Transform canvas;
        private GameObject spawnedCard;
        private Vector3 chosenCardPosition;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            var temp = card1Position.value.position;
            temp.x = temp.x + 0.5f * (redrawIndex.value - 1);
            chosenCardPosition = temp;
            temp.y = temp.y + 5;
            card1Position.value.position = temp;
            Debug.Log("Spawning new card at position: " + card1Position.value.position);
            spawnedCard = GameObject.Instantiate(prefab, temp, Quaternion.identity);
            spawnedCard.transform.SetParent(canvas);
            StartCoroutine(SpawnAnimation(spawnedCard));
            EndAction(true);
        }

        private IEnumerator SpawnAnimation(GameObject spawnedCard)
        {
            while (Vector3.Distance(spawnedCard.transform.position, chosenCardPosition) != 0)
            {
                spawnedCard.transform.position = Vector3.Lerp(spawnedCard.transform.position, chosenCardPosition, Time.deltaTime * 5);
                yield return null;
            }
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