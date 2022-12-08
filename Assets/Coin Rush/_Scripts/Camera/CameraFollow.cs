using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace CoinRush.Cameras
{
    public class CameraFollow : MonoBehaviour
    {
        //! KAMERA AKTIF OLARAK CINEMACHINE UZERINDEN TAKIP EDIYOR AMA ISTENIRSE BU SCRIPT UZERINDEN DE ISLEMLER GERCEKLESTIRILEBILIR

        [Header(" SETTINGS ")]
        [SerializeField][Range(0f, 50f)] private float smoothTime;
        [SerializeField][Range(0f, 50f)] private float maxFollowSpeed;
        [SerializeField] private Vector3 followOffset;

        [Header(" ELEMENTS ")]
        [SerializeField] Transform target;
        
        private Vector3 _velocity;

        private void LateUpdate()
        {

            var moveToPosition = target.position + (target.rotation * followOffset);
            var currentPosition = Vector3.SmoothDamp(transform.position, moveToPosition, ref _velocity, smoothTime, maxFollowSpeed);
            transform.position = currentPosition;
            transform.LookAt(target, target.up);
        }
    }

}