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
    class Lawnmower
    {

        string path_wheels = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_lawnmower/wheels.obj";
        string path_tangkai = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_lawnmower/tangkai.obj";
        string path_body = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_lawnmower/body.obj";

        mesh tangkai = new mesh();
        mesh wheels = new mesh();
        mesh body = new mesh();
       
        public Lawnmower()
        {

        }


        public void load()
        {
            body.initialize(path_body);

            tangkai.initialize(path_tangkai);

            wheels.initialize(path_wheels);

        }

        public void move(Vector3 _pos)
        {
         
            body.translate(_pos.X, _pos.Y, _pos.Z);
            tangkai.translate(_pos.X, _pos.Y, _pos.Z);
            wheels.translate(_pos.X, _pos.Y, _pos.Z);
        }

        public void Render_object(Camera _camera,  Vector3 _lightPos)
        {
            tangkai.Render(_camera, _lightPos, new Vector3(1f,1f,1f));
            body.Render(_camera, _lightPos, new Vector3(0.8f,0f,0f));
            wheels.Render(_camera, _lightPos, new Vector3(0f,0f,0f));
        }

    }
}
