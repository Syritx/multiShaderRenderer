using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

using System;

namespace renderer.src {

    class Camera {

        public Vector3 position = new Vector3(0,1,0), eye = new Vector3(0,0,0), up = new Vector3(0,1,0);
        float speed = 2;
        float xRotation, yRotation;

        public GameScene scene;
        Vector2 lastPosition;
        bool canRotate = false;

        public Camera(GameScene scene) {
            this.scene = scene;
            scene.UpdateFrame += Update;

            scene.MouseMove += MouseMove;
            scene.MouseDown += MouseDown;
            scene.MouseUp   += MouseUp;
        }

        public void Update(FrameEventArgs e) {
            xRotation = Clamp(xRotation, -89.9f, 89.9f);
            eye.X = (float)Math.Cos(MathHelper.DegreesToRadians(xRotation)) * (float)Math.Cos(MathHelper.DegreesToRadians(yRotation));
            eye.Y = (float)Math.Sin(MathHelper.DegreesToRadians(xRotation));
            eye.Z = (float)Math.Cos(MathHelper.DegreesToRadians(xRotation)) * (float)Math.Sin(MathHelper.DegreesToRadians(yRotation));

            eye = Vector3.Normalize(eye);

            if (scene.IsKeyDown(Keys.W)) position += eye * speed;
            else if (scene.IsKeyDown(Keys.S)) position -= eye * speed;


            Vector3 right = Vector3.Normalize(Vector3.Cross(eye, up));

            if (scene.IsKeyDown(Keys.A)) position -= right * speed;
            if (scene.IsKeyDown(Keys.D)) position += right * speed;

            Console.WriteLine(position.X + " " + position.Y + " " + position.Z); 
        }

        void MouseMove(MouseMoveEventArgs e) {
            if (canRotate)
            {
                xRotation += (lastPosition.Y - e.Y) * .5f;
                yRotation -= (lastPosition.X - e.X) * .5f;
            }
            lastPosition = new Vector2(e.X, e.Y);
        }

        void MouseDown(MouseButtonEventArgs e) {
            if (e.Button == MouseButton.Right) canRotate = true;
        }
        void MouseUp(MouseButtonEventArgs e) {
            if (e.Button == MouseButton.Right) canRotate = false;
        }

        float Clamp(float value, float min, float max) {

            if (value > max) value = max;
            if (value < min) value = min;
            return value;
        }
    }
}