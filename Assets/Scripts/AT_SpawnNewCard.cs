using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class AT_SpawnNewCard : ActionTask
    {
        public BBParameter<Transform> card1Position;
        public BBParameter<int> redrawIndex;
        public GameObject prefab;

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
            temp.y = temp.y - 0.8f;
            Debug.Log("Spawning new card at position: " + temp);
            GameObject.Instantiate(prefab, temp, Quaternion.identity);
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