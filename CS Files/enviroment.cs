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
    class environment
    {
        Lawnmower lawnmower1 = new Lawnmower();
        Lawnmower lawnmower2 = new Lawnmower();
        Lawnmower lawnmower3 = new Lawnmower();

        string path_ground = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/ground.obj";
        string path_fence = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/fence.obj";
        string path_inner_fence = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/inner_fence.obj";
        string path_leaf = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/leaf.obj";
        string path_log = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/log.obj";
        string path_atap = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/atap.obj";
        string path_body = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/body.obj";
        string path_alas = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/alas.obj";
        string path_glass_frame = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/glass_frame.obj";
        string path_glass = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/glass.obj";
        string path_door = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/door.obj";
        string path_door_knob = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/door_knob.obj";
        string path_dirt = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/dirt.obj";
        string path_road = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/road.obj";
        string path_line = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/line.obj";
        string path_gravestone = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_environment/gravestone.obj";

        mesh ground = new mesh();
        mesh fence = new mesh();
        mesh inner_fence = new mesh();
        mesh leaf= new mesh();
        mesh log = new mesh();
        mesh atap = new mesh();
        mesh body = new mesh();
        mesh glass = new mesh();
        mesh glass_frame = new mesh();
        mesh door = new mesh();
        mesh door_knob = new mesh();
        mesh alas = new mesh();
        mesh dirt = new mesh();
        mesh road = new mesh();
        mesh line = new mesh();
        mesh gravestone = new mesh();

        public environment()
        {

        }


        public void load()
        {
            ground.initialize(path_ground);

            fence.initialize(path_fence);

            inner_fence.initialize(path_inner_fence);

            leaf.initialize(path_leaf);

            log.initialize(path_log);

            atap.initialize(path_atap);

            body.initialize(path_body);

            alas.initialize(path_alas);

            glass_frame.initialize(path_glass_frame);

            glass.initialize(path_glass);

            door.initialize(path_door);

            door_knob.initialize(path_door_knob);

            dirt.initialize(path_dirt);

            gravestone.initialize(path_gravestone);

            road.initialize(path_road);

            line.initialize(path_line);

            lawnmower1.load();
            lawnmower1.move(new Vector3(-4.5f, 0.1f, -1.7f));
            lawnmower2.load();
            lawnmower2.move(new Vector3(-5.5f, 0.1f, -1.7f));
            lawnmower3.load();
            lawnmower3.move(new Vector3(-6.5f, 0.1f, -1.7f));
        }
        public void move(Vector3 _pos)
        {
            ground.translate(_pos.X, _pos.Y, _pos.Z);
            fence.translate(_pos.X, _pos.Y, _pos.Z);
            inner_fence.translate(_pos.X, _pos.Y, _pos.Z);
            leaf.translate(_pos.X, _pos.Y, _pos.Z);
            log.translate(_pos.X, _pos.Y, _pos.Z);
            atap.translate(_pos.X, _pos.Y, _pos.Z);
            body.translate(_pos.X, _pos.Y, _pos.Z);
            alas.translate(_pos.X, _pos.Y, _pos.Z);
            glass.translate(_pos.X, _pos.Y, _pos.Z);
            glass_frame.translate(_pos.X, _pos.Y, _pos.Z);
            door.translate(_pos.X, _pos.Y, _pos.Z);
            door_knob.translate(_pos.X, _pos.Y, _pos.Z);
            dirt.translate(_pos.X, _pos.Y, _pos.Z);
            road.translate(_pos.X, _pos.Y, _pos.Z);
            line.translate(_pos.X, _pos.Y, _pos.Z);
        }

        public void Render_object(Camera _camera, Vector3 _lightPos)
        {

            ground.Render(_camera, _lightPos, new Vector3 (0.02f,0.4f,0f));
            fence.Render(_camera, _lightPos, new Vector3(0.1f,0.03f,0.008f));
            inner_fence.Render(_camera, _lightPos, new Vector3(0.8f,0.2f,0.085f));
            leaf.Render(_camera, _lightPos, new Vector3(0f, 0.1f, 0f));
            log.Render(_camera, _lightPos, new Vector3(0.1f, 0.03f, 0.008f));
            atap.Render(_camera, _lightPos, new Vector3(0.8f, 0.2f, 0.085f));
            body.Render(_camera, _lightPos, new Vector3(0.8f, 0.77f, 0.5f));
            alas.Render(_camera, _lightPos, new Vector3(0.8f, 0.42f, 0f));
            glass_frame.Render(_camera, _lightPos, new Vector3(0.8f, 0.2f, 0.085f));
            glass.Render(_camera, _lightPos, new Vector3(0.23f, 0.75f, 0.8f));
            door.Render(_camera, _lightPos, new Vector3(0.1f, 0.03f, 0.008f));
            door_knob.Render(_camera, _lightPos, new Vector3(0.8f, 0.42f, 0f));
            dirt.Render(_camera, _lightPos, new Vector3(0.08f, 0.05f, 0.01f));
            road.Render(_camera, _lightPos, new Vector3(0.0f, 0.0f, 0.0f));
            line.Render(_camera, _lightPos, new Vector3(1.0f, 1.0f, 1.0f));
            gravestone.Render(_camera, _lightPos, new Vector3(0.23f, 0.23f, 0.23f));

            lawnmower1.Render_object(_camera,_lightPos);
            lawnmower2.Render_object(_camera,_lightPos);
            lawnmower3.Render_object(_camera,_lightPos);
        }
       
    }
}
