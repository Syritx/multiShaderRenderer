using renderer.src.Entities;
using System.Collections.Generic;

namespace renderer.src {

    class Renderer {

        List<Renderable> renderables = new List<Renderable>();

        public void AddEntity(Renderable renderable) {
            renderables.Add(renderable);
        }

        public void RenderAll(Camera camera) {
            
            
            foreach (Renderable r in renderables)
                r.Render(camera.position, camera.eye, camera.up);
        }
    }
}