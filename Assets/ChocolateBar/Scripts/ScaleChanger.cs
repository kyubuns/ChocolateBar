using UnityEngine;

namespace ChocolateBar
{
    public class ScaleChanger : MonoBehaviour
    {
        [SerializeField] ProjectionConfig config;
        private bool down;
        private int selectingIndex;
        private const KeyCode key = KeyCode.LeftShift;
        
        Vector2 GetMousePosition() { return new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height); }
        
        public void Update()
        {
            if (Input.GetMouseButtonDown(0) && Input.GetKey(key)) MouseDown();
            if (down && Input.GetMouseButtonUp(0)) MouseUp();
            
            if (down) Drag();
        }
        
        private void MouseDown()
        {
            down = true;
            
            var min = float.MaxValue;
            var i = 0;
            var mousePos = GetMousePosition();
            foreach(var p in config.ScreenPositions)
            {
                if(Vector2.Distance(mousePos, p) < min)
                {
                    min = Vector2.Distance(mousePos, p);
                    selectingIndex = i;
                }
                i++;
            }
        }
        
        private void MouseUp()
        {
            down = false;
        }
        
        private void Drag()
        {
            config.ScreenPositions[selectingIndex] = GetMousePosition();
        }
    }
}
