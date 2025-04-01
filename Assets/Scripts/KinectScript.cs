using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.rfilkov.kinect
{
    public class KinectScript : MonoBehaviour
    {
        [Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
        public int playerIndex = 0;

        public GameObject katana1;
        public GameObject katana2;

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

                        // Active la collision et met à jour la position de la katana du joueur 1
                        katana1.GetComponent<ScriptKatana>().collision = true;
                        katana1.transform.position = new Vector3(jointPos.x * 15, jointPos.y * 5);
                        katana1.transform.position -= new Vector3(0, 6.5f, 0); // Ajustement de la position
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

                        // Active la collision et met à jour la position de la katana du joueur 2
                        katana2.GetComponent<ScriptKatana>().collision = true;
                        katana2.transform.position = new Vector3(jointPos.x * 15, jointPos.y * 5);
                        katana2.transform.position -= new Vector3(0, 6.5f, 0); // Ajustement de la position
                    }
                }
            }
            else
            {
                // Si Kinect n'est pas initialisé ou actif, désactiver les collisions des katanas
                katana1.GetComponent<ScriptKatana>().collision = false;
                katana2.GetComponent<ScriptKatana>().collision = false;
            }

        }
    }
}
