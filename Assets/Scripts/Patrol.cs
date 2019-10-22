
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public Transform[] target;
        [SerializeField]private int speed = 0;
        private int current = 0;


        void Start () {
            
        }



        void Update () {
            //Debug.Log(target.Length);
            if(transform.position != target[current].position && target != null){
                Vector3 pos = Vector3.MoveTowards(transform.position,target[current].position,speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
                //Debug.Log(current);
            }//else current = (current + 1) % target.Length;
        }

        /// <summary>
        /// OnTriggerEnter is called when the Collider other enters the trigger.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "target"){
                if(current+1 < target.Length)
                {
                    current = (current + 1);
                }
            }
        }

        public void setPatrols(Transform[] tabtarg)
        {
            target = tabtarg;
        }
}
