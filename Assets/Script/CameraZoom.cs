using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinePaint
{

    public class CameraZoom : MonoBehaviour
    {
        private Camera myCam;

        private void Awake()
        {
            myCam = GetComponent<Camera>();
        }

        public void ZoomPerspectiveCamera(float width, float height)
        {
            float _height = 2.0f * ((width > height ? width : height + 0.5f) / 2) * Mathf.Atan(myCam.fieldOfView);

            if (_height < 5.5f)
            {
                _height = 5.5f;
            }

            transform.position = new Vector3((width - 1) / 2f, _height, myCam.transform.position.z);
        }
    }
}
