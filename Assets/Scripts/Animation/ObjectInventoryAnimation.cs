using System.Collections;
using Audio;
using UnityEngine;

namespace Animation
{
    public class ObjectInventoryAnimation : MonoBehaviour
    {
        [SerializeField] private float padding;
        [SerializeField] private float timeToStay = 3;
        [SerializeField] private float duration = 1;

        private Vector3 startPos;
        private Vector3 endPos;
        private float width;
        private bool invIsToggeled;

        //TODO fix res, RectTransform
        private void Awake()
        {
            width = GetComponent<RectTransform>().rect.width * 2;
            startPos = transform.position;
            endPos = startPos - new Vector3(-width - padding, 0, 0);
        }

        public IEnumerator MoveInventory()
        {
            if (invIsToggeled == false)
            {
                AudioManager.PlaySound("ToggleInv");
                invIsToggeled = true;
                float startTime = Time.time;
                while (Time.time - startTime < duration)
                {
                    float t = (Time.time - startTime) / duration;
                    Vector3 newPos = Vector3.Lerp(startPos, endPos, t);
                    transform.position = newPos;
                    yield return new WaitForEndOfFrame();
                }

                yield return new WaitForSecondsRealtime(timeToStay);
                StartCoroutine(MoveInventoryBack());
            }
        }

        public IEnumerator MoveInventoryBack()
        {
            float startTime = Time.time;
            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;
                Vector3 newPos = Vector3.Lerp(endPos, startPos, t);
                transform.position = newPos;
                yield return new WaitForEndOfFrame();
            }

            invIsToggeled = false;
        }

        public void ToggleInv()
        {
            transform.position = endPos;
        }

        public void ToggleInvRelease()
        {
            transform.position = startPos;
        }
    }
}