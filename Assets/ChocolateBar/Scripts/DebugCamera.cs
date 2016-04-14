using UnityEngine;

namespace ChocolateBar
{
    [ExecuteInEditMode]
    public class DebugCamera : MonoBehaviour
    {
        [SerializeField] RenderTexture targetTexture;
        
        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            Graphics.Blit(targetTexture, destination);
        }
    }
}