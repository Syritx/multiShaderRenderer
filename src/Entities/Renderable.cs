using OpenTK.Mathematics;
using renderer.src.Shaders;

namespace renderer.src.Entities {

    abstract class Renderable {

        public Shader shader;        
        public Renderable(string VERTEX_SHADER_PATH, string FRAGMENT_SHADER_PATH, Vector3 POSITION) {}
        public virtual void Render(Vector3 cameraPosition , Vector3 cameraEye, Vector3 cameraUp) {}
    }
}