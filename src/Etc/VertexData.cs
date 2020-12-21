
using OpenTK.Mathematics;

namespace renderer.src.Etc {

    class VertexData {

        public static float[] GenerateCube(float size, Vector3 position) {

            return new float[] {
                -size+position.X, -size+position.Y, -size+position.Z, 1, 0, 0,
                 size+position.X, -size+position.Y, -size+position.Z, 1, 0, 0,
                 size+position.X,  size+position.Y, -size+position.Z, 1, 0, 0,
                -size+position.X, -size+position.Y, -size+position.Z, 1, 0, 0,
                 size+position.X,  size+position.Y, -size+position.Z, 1, 0, 0,
                -size+position.X,  size+position.Y, -size+position.Z, 1, 0, 0,

                -size+position.X, -size+position.Y,  size+position.Z, 1, 1, 0,
                 size+position.X, -size+position.Y,  size+position.Z, 1, 1, 0,
                 size+position.X,  size+position.Y,  size+position.Z, 1, 1, 0,
                -size+position.X, -size+position.Y,  size+position.Z, 1, 1, 0,
                 size+position.X,  size+position.Y,  size+position.Z, 1, 1, 0,
                -size+position.X,  size+position.Y,  size+position.Z, 1, 1, 0,

                -size+position.X,  size+position.Y,  size+position.Z, 0, 1, 0,
                -size+position.X,  size+position.Y, -size+position.Z, 0, 1, 0,
                 size+position.X,  size+position.Y, -size+position.Z, 0, 1, 0,
                -size+position.X,  size+position.Y,  size+position.Z, 0, 1, 0,
                 size+position.X,  size+position.Y,  size+position.Z, 0, 1, 0,
                 size+position.X,  size+position.Y, -size+position.Z, 0, 1, 0,

                -size+position.X, -size+position.Y,  size+position.Z, 0, 0, 1,
                -size+position.X, -size+position.Y, -size+position.Z, 0, 0, 1,
                 size+position.X, -size+position.Y, -size+position.Z, 0, 0, 1,
                -size+position.X, -size+position.Y,  size+position.Z, 0, 0, 1,
                 size+position.X, -size+position.Y,  size+position.Z, 0, 0, 1,
                 size+position.X, -size+position.Y, -size+position.Z, 0, 0, 1,

                -size+position.X,  size+position.Y,  -size+position.Z, 1, 1, 1,
                -size+position.X, -size+position.Y,  -size+position.Z, 1, 1, 1,
                -size+position.X, -size+position.Y,   size+position.Z, 1, 1, 1,
                -size+position.X,  size+position.Y,  -size+position.Z, 1, 1, 1,
                -size+position.X,  size+position.Y,   size+position.Z, 1, 1, 1,
                -size+position.X, -size+position.Y,   size+position.Z, 1, 1, 1,

                 size+position.X,  size+position.Y,  -size+position.Z, 1, .5f, 0,
                 size+position.X, -size+position.Y,  -size+position.Z, 1, .5f, 0,
                 size+position.X, -size+position.Y,   size+position.Z, 1, .5f, 0,
                 size+position.X,  size+position.Y,  -size+position.Z, 1, .5f, 0,
                 size+position.X,  size+position.Y,   size+position.Z, 1, .5f, 0,
                 size+position.X, -size+position.Y,   size+position.Z, 1, .5f, 0,
            };
        }
    }
}