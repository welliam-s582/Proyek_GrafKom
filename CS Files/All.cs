using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using LearnOpenTK.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Project2
{
    class All : GameWindow
    {
        string path_sun = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/sun.obj";
        mesh sun = new mesh();

        //Inisialisasi Peashooter
        Peashooter_Welliam peashooter = new Peashooter_Welliam();

        //Inisialisasi Sunflower
        Sunflower_George sunflower = new Sunflower_George();

        //Inisialisasi Mushroom
        Scaredy_shroom_Iverson scaredy_shroom = new Scaredy_shroom_Iverson();

        //Inisialisasi zombie
        zombie _zombie1 = new zombie();
        zombie _zombie2 = new zombie();
        zombie _zombie3 = new zombie();

        //Inisialisasi Environment
        environment _environment = new environment();
        environment _environment2 = new environment();
        environment _environment3 = new environment();
     
        private Camera _camera;
        private Vector3 _lightPos = new Vector3(0f, 6.0f, -10.0f);
        public All(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            GL.ClearColor(0.1f, 0.9f, 1.0f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            sun.initialize(path_sun);
            sun.set_VAO_lamp();
            sun.set_shader_lamp();

            //environment
            _environment.load();
            _environment.move(new Vector3(0f, 0f, 0f));
            _environment2.load();
            _environment2.move(new Vector3(-6.5f, 0f, 0f));
            _environment3.load();
            _environment3.move(new Vector3(6.5f, 0f, 0f));

            //Sunflower
            sunflower.load();
            sunflower.move(new Vector3(0.0f, 0.0f, -0.7f));

            //Mushroom
            scaredy_shroom.load();
            scaredy_shroom.move(new Vector3(0f, 0f, 0f));

            //Peashooter
            peashooter.load();
            peashooter.move(new Vector3(0f, 0f, 0f));

            //zombie
            _zombie1.load();
            _zombie1.move(new Vector3(-9.6f, 0.2f, 2f));
            _zombie2.load();
            _zombie2.move(new Vector3(-8.8f, 0.2f, 3.5f));
            _zombie3.load();
            _zombie3.move(new Vector3(-11f, 0.2f, 2.7f));

            var _cameraPosInit = new Vector3(0f, 6f,-9f);
            _camera = new Camera(_cameraPosInit, (float)Size.X / (float)Size.Y);
      
            base.OnLoad();
        }


        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            sun.Render_lamp(_camera, _lightPos, new Vector3 (0f,0f,0f));

            //Sunflower
            sunflower.Render_character(_camera, _lightPos);

            //Mushroom
            scaredy_shroom.Render_character(_camera, _lightPos);

            //Peashooter
            peashooter.Render_character(_camera, _lightPos);

            //zombie
            _zombie1.Render_character(_camera, _lightPos);
            _zombie2.Render_character(_camera, _lightPos, "bucket");
            _zombie3.Render_character(_camera, _lightPos, "pylon");

            //environment
            _environment.Render_object(_camera, _lightPos);
            _environment2.Render_object(_camera, _lightPos);
            _environment3.Render_object(_camera, _lightPos);
            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            const float cameraSpeed = 1.5f;

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                this.Close();
            }

            //menggerakan camera ke depan dan ke belakang (zoom in dan zoom out)
            if (KeyboardState.IsKeyDown(Keys.I))
            {
                _camera.Fov += 0.05f;
            }
            if (KeyboardState.IsKeyDown(Keys.O))
            {
                _camera.Fov -= 0.05f;
            }


            //menggerakan camera agar bisa melihat ke kiri,kanan,atas dan bawah berdasarkan sumbu x dan y (kita melihat)
            if (KeyboardState.IsKeyDown(Keys.T)) // liat ke keatas
            {
                _camera.Pitch += 0.2f;
            }
            if (KeyboardState.IsKeyDown(Keys.G))// liat ke kebawah
            {
                _camera.Pitch -= 0.2f;
            }
            if (KeyboardState.IsKeyDown(Keys.F))// liat ke kekiri
            {
                _camera.Yaw -= 0.2f;
            }
            if (KeyboardState.IsKeyDown(Keys.H))// liat ke kekanan
            {
                _camera.Yaw += 0.2f;
            }


            //menggerakan camera secara bebas (kita bergerak)
            if (KeyboardState.IsKeyDown(Keys.W)) // ke depan
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.S))// ke belakang
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.A))// ke kiri
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.D))// ke kanan
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.Space))// ke atas
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.LeftControl))// ke bawah
            {
                if (_camera.Position.Y > 0.2f)
                {
                    _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
                }
               
            }

            //untuk mengubah posisi lampu berdasarkan sumbu Z
            if (KeyboardState.IsKeyDown(Keys.Z))
            {
                _lightPos.Z += 0.1f;
            }
            if (KeyboardState.IsKeyDown(Keys.X))
            {
                _lightPos.Z -= 0.1f;
            }

            if (!IsFocused)
            {
                return;
            }

            //menggerakan camera agar bisa melihat ke kiri,kanan,atas dan bawah DENGAN MOUSE
            //const float mouse_sensitivity = 0.1f;
            //if (_first_move == true)
            //{
            //    _last_mouse_pos = new Vector2(MousePosition.X, MousePosition.Y);
            //    _first_move = false;
            //}
            //else
            //{
            //    var deltaX = MousePosition.X - _last_mouse_pos.X;
            //    var deltaY = MousePosition.Y - _last_mouse_pos.Y;

            //    _last_mouse_pos = new Vector2(MousePosition.X, MousePosition.Y);

            //    _camera.Yaw += deltaX * mouse_sensitivity;
            //    _camera.Pitch -= deltaY * mouse_sensitivity;
            //}




            base.OnUpdateFrame(args);
        }
    }

}
