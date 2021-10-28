using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        public GameObject kamera;
        public GameObject karton;
        public GameObject insan;
        private Vector3 kamerapos = new Vector3();
        private Vector3 sonkamerapos = new Vector3();
        public GameObject Progress;
        public int coinsayýsý;
        public GameObject kýrmýzý;
        public GameObject yeþil;
        public GameObject kapý;
        public Sprite[] enery;
        bool kartons = false;
        public GameObject ýmageenery;
        public GameObject button;
        public GameObject gameover;
        public GameObject levelup;
        public Sprite[] ustyazýlar;
        public GameObject üstyazýimage;
        public TextMeshProUGUI coins;
        public TextMeshProUGUI gameovercoins;
        public TextMeshProUGUI Levelupnumber;
        
        [HideInInspector]
        public float Himput;
        [HideInInspector]
        public float Vinput;
        bool crouch = false;
        private void Start()
        {
            Time.timeScale = 1;
            PlayerPrefs.SetInt("bolum", int.Parse(SceneManager.GetActiveScene().name));
            Progress.GetComponent<Slider>().maxValue = coinsayýsý;
            Progress.GetComponent<Slider>().minValue = 0;
            kamerapos = kamera.transform.position - this.transform.position;
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "coins")
            {
                
                Destroy(other.gameObject);
                Progress.GetComponent<Slider>().value++;
                coins.text = Progress.GetComponent<Slider>().value.ToString() + " / " + coinsayýsý + " Coins";
                if (Progress.GetComponent<Slider>().value == 2)
                {
                    üstyazýimage.SetActive(true);
                    üstyazýimage.GetComponent<Image>().sprite = ustyazýlar[0];

                } 
                if (Progress.GetComponent<Slider>().value == 3) üstyazýimage.GetComponent<Image>().sprite = ustyazýlar[1];
                if (Progress.GetComponent<Slider>().value == 6) üstyazýimage.GetComponent<Image>().sprite = ustyazýlar[2];
                if (Progress.GetComponent<Slider>().value == coinsayýsý)
                {
                    üstyazýimage.GetComponent<Image>().sprite = ustyazýlar[3];
                    kýrmýzý.SetActive(false);
                    yeþil.SetActive(true);
                    kapý.SetActive(false);
                }
            }
            if (other.tag == "Aý")
            {
                other.gameObject.SetActive(false);
                gameovercoins.text = Progress.GetComponent<Slider>().value.ToString();
                üstyazýimage.SetActive(true);
                üstyazýimage.GetComponent<Image>().sprite = ustyazýlar[4];
                
                gameover.SetActive(true);

            }
            if (other.tag == "go")
            {
                kapý.SetActive(true);
                Levelupnumber.text = (PlayerPrefs.GetInt("bolum")+1).ToString();
                levelup.SetActive(true);
                
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag=="fakewall")
            {
               
                other.GetComponent<MeshRenderer>().enabled=true;
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;

            }
            if (other.tag == "fakewalldead")
            {
                üstyazýimage.SetActive(true);
                üstyazýimage.GetComponent<Image>().sprite = ustyazýlar[4];
                crouch = true;
                StartCoroutine(ol());
                other.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                


            }
        }
        IEnumerator ol()
        {
           
                yield return new WaitForSeconds(2);
            üstyazýimage.GetComponent<Image>().sprite = ustyazýlar[4];
            gameover.SetActive(true);
        }
        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }

        public void buttonclick()
        {
            button.GetComponent<Button>().interactable = false;
            kartons = true;
            this.tag = "karton";
            StartCoroutine(say());
            this.GetComponent<Rigidbody>().drag = 100f;
        }

        IEnumerator say() 
        {
            for (int i = 1; i < 5; i++)
            {
                
                ýmageenery.GetComponent<Image>().sprite = enery[i];
                yield return new WaitForSeconds(0.5f);
            }
            StartCoroutine(geri());

            kartons = false;
            this.tag = "Player";
            this.GetComponent<Rigidbody>().drag = 1f;
            


        }
        IEnumerator geri()
        {
         
            for (int i = 4; i > 0; i--)
            {
                
                ýmageenery.GetComponent<Image>().sprite = enery[i];
                yield return new WaitForSeconds(0.5f);
            }
            
            button.GetComponent<Button>().interactable = true;
            ýmageenery.GetComponent<Image>().sprite = enery[0];

        }
        private void LateUpdate()
        {
            
            sonkamerapos = kamerapos+this.transform.position;
            kamera.transform.position = Vector3.Lerp(kamera.transform.position, sonkamerapos, 0.1f);
           
        }
        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {

            // read inputs

            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
             
            
         
            // calculate move direction to pass to character
            if (m_Cam != null )
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                
                    m_Move = Vinput * m_CamForward + Himput * m_Cam.right;
                
            }
            else
            {
                // we use world-relative directions in the case of no main camera
              
                    m_Move = Vinput * Vector3.forward + Himput * Vector3.right;
               
               
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;

            if (kartons == true && insan.gameObject.active)
            {

                insan.SetActive(false);
                karton.SetActive(true);
               
                this.GetComponent<ThirdPersonCharacter>().enabled = false;
            }
            else if (kartons == false && karton.gameObject.active)
            {
                insan.SetActive(true);
                karton.SetActive(false);
                this.GetComponent<ThirdPersonCharacter>().enabled = true;
            }

        }
    }
}
