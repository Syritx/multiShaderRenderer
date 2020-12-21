using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

using renderer.src.Entities;
using renderer.src.Etc;

namespace renderer.src {

    class GameScene : GameWindow {

        public Renderer renderer;
        Camera camera;

        public GameScene(GameWindowSettings GWS, NativeWindowSettings NWS) : base(GWS, NWS) {
            Run();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            renderer.RenderAll(camera);
            SwapBuffers();
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0,0,0,1);
            camera = new Camera(this);
            renderer = new Renderer();

            renderer.AddEntity(new Cube("src/Shaders/GLSL/Cube/cubeVertexShader.glsl", "src/Shaders/GLSL/Cube/cubeFragmentShader.glsl", new Vector3(0,0,1)));
            renderer.AddEntity(new Pyramid("src/Shaders/GLSL/Cube/cubeVertexShader.glsl", "src/Shaders/GLSL/Cube/cubeFragmentShader.glsl", new Vector3(0,0,-10)));
        }
    }
}