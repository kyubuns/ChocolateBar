using UnityEngine;

namespace ChocolateBar
{
    [ExecuteInEditMode]
    public class ProjectionCamera : MonoBehaviour
    {
        [SerializeField] RenderTexture targetTexture;
        [SerializeField] Material material;
        [SerializeField] ProjectionConfig config;
        
        public void OnPostRender()
        {
            material.mainTexture = targetTexture;
            material.SetPass(0);
            
            GL.PushMatrix();
            GL.LoadOrtho();
            GL.Begin(GL.TRIANGLE_STRIP);
            
            for(int i=0;i<Mathf.Min(config.ScreenPositions.Count, config.TexturePositions.Count);++i)
            {
                GL.TexCoord2(config.TexturePositions[i].x, config.TexturePositions[i].y);
                GL.Vertex3(config.ScreenPositions[i].x, config.ScreenPositions[i].y, 0.0f);
            }
            
            GL.End();
            GL.PopMatrix();
        }
    }
}