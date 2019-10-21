
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
            if(transform.position != target[current].position){
                Vector2 pos = Vector2.MoveTowards(transform.position,target[current].position,speed * Time.deltaTime);
                GetComponent<Rigidbody2D>().MovePosition(pos);
                //Debug.Log(current);
            }else current = (current + 1) % target.Length;
        }
}
