using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.rfilkov.kinect
{
    public class KinectScript : MonoBehaviour
    {
        [Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
        public int playerIndex = 0;

        public GameObject vaisseau1;
        public GameObject vaisseau2;

        public float smoothSpeed = 5f; // Vitesse d'interpolation (plus la valeur est grande plus le vaisseau se déplacera rapidement)

        void Update()
        {
            // Définition du type d'articulation suivi (main droite)
            KinectInterop.JointType handRight = KinectInterop.JointType.HandRight;

            // Récupération de l'instance du KinectManager
            KinectManager kinectManager = KinectManager.Instance;

            if (kinectManager && kinectManager.IsInitialized()) // Vérifie si Kinect est bien initialisé
            {
                // Vérifie si un utilisateur est détecté à l'index 0
                if (kinectManager.IsUserDetected(0))
                {
                    ulong userId = kinectManager.GetUserIdByIndex(0); // Récupère l'ID de l'utilisateur

                    // Vérifie si la main droite de l'utilisateur est suivie
                    if (kinectManager.IsJointTracked(userId, handRight))
                    {
                        Vector3 jointPos = kinectManager.GetJointPosition(userId, handRight); // Position de la main droite

                        // Active la collision et met à jour la position du vaisseau du joueur 1
                        vaisseau1.GetComponent<ScriptKatana>().collision = true;
                        //vaisseau1.transform.position = new Vector3(jointPos.x * 15, jointPos.y * 5);
                        //vaisseau1.transform.position -= new Vector3(0, 6.5f, 0); // Ajustement de la position

                        //avec un lerp
                        vaisseau1.transform.position = Vector3.Lerp(vaisseau1.transform.position, new Vector3(jointPos.x * 15, jointPos.y * 5 - 6.5f, 0), smoothSpeed * Time.deltaTime);

                    
                    }
                }

                // Vérifie si un deuxième utilisateur est détecté à l'index 1
                if (kinectManager.IsUserDetected(1))
                {
                    ulong userId = kinectManager.GetUserIdByIndex(1); // Récupère l'ID du second utilisateur

                    // Vérifie si la main droite du second utilisateur est suivie
                    if (kinectManager.IsJointTracked(userId, handRight))
                    {
                        Vector3 jointPos = kinectManager.GetJointPosition(userId, handRight); // Position de la main droite

                        // Active la collision et met à jour la position du vaisseau du joueur 2
                        vaisseau2.GetComponent<ScriptKatana>().collision = true;
                        //        vaisseau2.transform.position = new Vector3(jointPos.x * 15, jointPos.y * 5);
                        //        vaisseau2.transform.position -= new Vector3(0, 6.5f, 0); // Ajustement de la position

                        //avec un lerp
                        vaisseau2.transform.position = Vector3.Lerp(vaisseau2.transform.position, new Vector3(jointPos.x * 15, jointPos.y * 5 - 6.5f, 0), smoothSpeed * Time.deltaTime);
                    }
                }
            }
                    else
            {
                // Si Kinect n'est pas initialisé ou actif, désactiver les collisions des vaisseau
                vaisseau1.GetComponent<ScriptKatana>().collision = false;
                vaisseau2.GetComponent<ScriptKatana>().collision = false;
            }

        }
    }
}
