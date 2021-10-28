using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        public GameObject karakter;
        public GameObject[] hedefler;
        Vector3 rayyonum = new Vector3();
        RaycastHit ray;
        public LayerMask layermask;
        int hedefsayisi=0;
        bool hedefmi=false;
        bool kos = false;
        Vector3 cr;
        Vector3 dr;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            
            
            agent.updateRotation = false;
	        agent.updatePosition = true;
            agent.SetDestination(hedefler[0].transform.position);
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (ray.collider.tag == "Player" && other.tag == "Player" && kos==false)
            {
                agent.SetDestination(target.position);
                agent.speed = 0.7f;
                hedefmi = true;
                kos = true;
            }
            else if (kos == true && ray.collider.tag == "Player")
            {
                agent.SetDestination(target.position);
            }
            else
            {

                hedefmi = false;
                kos = false;
                agent.speed = 0.5f;
                agent.SetDestination(hedefler[hedefsayisi].transform.position);



            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Hedef" && hedefmi==false)
            {
                if (hedefsayisi == hedefler.Length-1)
                {
                    hedefsayisi = 0;
                    agent.SetDestination(hedefler[hedefsayisi].transform.position);
                    
                }
                else 
                {
                   
                        hedefsayisi++;
                        Debug.LogError(hedefsayisi);
                        agent.SetDestination(hedefler[hedefsayisi].transform.position);
                        
                    
                    
                }
            }
        }


        private void Update()
        {

            cr =new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            dr = new Vector3(karakter.transform.position.x, karakter.transform.position.y + 1, karakter.transform.position.z);

            rayyonum = dr - cr;
            Physics.Raycast(cr, rayyonum,out ray, 1000, layermask);
            Debug.DrawLine(cr, ray.point, Color.magenta);
            

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else 
            {
                character.Move(Vector3.zero, false, false);
            }
               
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
