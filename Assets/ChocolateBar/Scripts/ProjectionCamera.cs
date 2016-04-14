using UnityEngine;

namespace ChocolateBar
{
    [ExecuteInEditMode]
    public class ProjectionCamera : MonoBehaviour
    {
        [SerializeField] RenderTexture targetTexture;
        [SerializeField] Material material;
        public Vector2 LeftTop = new Vector2(0.0f, 1.0f);
        public Vector2 LeftBottom = new Vector2(0.0f, 0.0f);
        public Vector2 RightBottom = new Vector2(1.0f, 0.0f);
        public Vector2 RightTop = new Vector2(1.0f, 1.0f);
        
        public void OnPostRender()
        {
            material.mainTexture = targetTexture;
            material.SetPass(0);
            
            GL.PushMatrix();
            GL.LoadOrtho();
            GL.Begin(GL.TRIANGLE_STRIP);
            
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(LeftBottom.x, LeftBottom.y, 0.0f);
            
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex3(LeftTop.x, LeftTop.y, 0.0f);
            
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex3(RightBottom.x, RightBottom.y, 0.0f);
            
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex3(RightTop.x, RightTop.y, 0.0f);
            
            GL.End();
            GL.PopMatrix();
        }
    }
}