using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using renderer.src.Shaders;
using renderer.src.Etc;

namespace renderer.src.Entities {

    class Cube : Renderable {

        float[] vertices;
        int vao, vbo;

        public Cube(string VSP, string FSP, Vector3 POSITION) : base(VSP, FSP, POSITION) {

            vertices = VertexData.GenerateCube(10, POSITION);
            shader = new Shader(VSP, FSP);

            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length*sizeof(float), vertices, BufferUsageHint.StaticDraw);

            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            GL.VertexAttribPointer(
            0,
            3,
            VertexAttribPointerType.Float,
            false,
            6 * sizeof(float), 0);

            GL.VertexAttribPointer(
            1,
            3,
            VertexAttribPointerType.Float,
            false,
            6 * sizeof(float), 3 * sizeof(float));

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
        }

        public override void Render(Vector3 cameraPosition, Vector3 cameraEye, Vector3 cameraUp) {

            shader.Use();
            base.Render(cameraPosition, cameraEye, cameraUp);

            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 view = Matrix4.LookAt(cameraPosition, cameraPosition+cameraEye, cameraUp), 
                    model = Matrix4.Identity, 
                    projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(80), 1000/720, 0.01f, 2000f);

            int modelPosition = GL.GetUniformLocation(shader.program, "model"),
                viewPosition = GL.GetUniformLocation(shader.program, "view"),
                projectionPosition = GL.GetUniformLocation(shader.program, "projection");

            GL.UniformMatrix4(modelPosition, false, ref model);
            GL.UniformMatrix4(viewPosition, false, ref view);
            GL.UniformMatrix4(projectionPosition, false, ref projection);

            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length);
        }
    }
}