using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class ScratchTest : MonoBehaviour
    {
        public GameObject mask;
        public float time;

        WaitForSeconds WaitForSeconds;
        bool pressed;
        Coroutine drawing;

        private void Start()
        {
            pressed = false;
        }

        private void Update()
        {
          
            if(Input.GetMouseButtonDown(0))
            {
                StartLine();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                FinishLine();
            }    
        }

        public void StartLine()
        {
            WaitForSeconds = new WaitForSeconds(time);
            if (drawing != null)
            {
                StopCoroutine(drawing);
            }
            drawing = StartCoroutine(DrawLine());

        }
        public void FinishLine()
        {
            if (drawing != null)
                StopCoroutine(drawing);
        }
        IEnumerator DrawLine()
        {
            while (true)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;

                GameObject ob = Instantiate(mask, pos, Quaternion.identity);
                yield return WaitForSeconds;
            }
        }
    }
}
