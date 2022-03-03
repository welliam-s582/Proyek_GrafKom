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
    class Scaredy_shroom_Iverson
    {
        private int cnt = 0; //timer untuk proses tranlasi peluru
        private int tmp = 0; // timer untuk proses reset   
        private bool swicth = true;

        string path_head = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_mushroom/head.obj";
        string path_mouth = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_mushroom/mouth.obj";
        string path_mouth_loop = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_mushroom/mouth_loop.obj";
        string path_body = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_mushroom/body.obj";
        string path_eye = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_mushroom/eye.obj";       
        string path_eyebrow = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_mushroom/eyebrow.obj";
        string path_bullet = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_mushroom/bullet.obj";

        mesh head = new mesh();
        mesh mouth = new mesh();
        mesh mouth_loop = new mesh();
        mesh body = new mesh();
        mesh eye = new mesh();
        mesh eyebrow = new mesh();
        mesh bullet = new mesh();


        public Scaredy_shroom_Iverson()
        {

        }

        public void load() //untuk set vbo,vao,ebo,shader,dan load object nya
        {

            head.initialize(path_head);

            mouth.initialize(path_mouth);

            mouth_loop.initialize(path_mouth_loop);

            body.initialize(path_body);

            eye.initialize(path_eye);

            eyebrow.initialize(path_eyebrow);

            bullet.initialize(path_bullet);

           
   
        }
        public void move(Vector3 _pos)
        {

            body.translate(_pos.X, _pos.Y, _pos.Z);
            mouth.translate(_pos.X, _pos.Y, _pos.Z);
            mouth_loop.translate(_pos.X, _pos.Y, _pos.Z);
            eye.translate(_pos.X, _pos.Y, _pos.Z);
            eyebrow.translate(_pos.X, _pos.Y, _pos.Z);
            head.translate(_pos.X, _pos.Y, _pos.Z);
            bullet.translate(_pos.X, _pos.Y, _pos.Z);
            bullet.save();
        }

        public void Render_character(Camera _camera, Vector3 _lightPos)
        {

            //animasi tembak peluru
            if (swicth == true)
            {
                if (cnt == 29)
                {
                    bullet.translate(0.0f, 0.0f, -0.1f);
                    tmp++;
                    if (tmp == 20)
                    {

                        bullet.reset();
                        tmp = 0;

                    }
                    cnt = 0;
                }
                else
                {
                    cnt++;
                }

         
            }


            head.Render(_camera, _lightPos, new Vector3 (0.3f, 0.0f, 0.5f));
            body.Render(_camera, _lightPos, new Vector3(0.9f, 1.0f, 0.8f));
            eyebrow.Render(_camera, _lightPos, new Vector3(0.0f, 0.0f, 0.0f));
            mouth.Render(_camera, _lightPos, new Vector3(0.9f, 0.9f, 0.8f));
            mouth_loop.Render(_camera, _lightPos, new Vector3(0.9f, 0.9f, 0.8f));
            eye.Render(_camera, _lightPos, new Vector3(0.0f, 0.0f, 0.0f));
            bullet.Render(_camera, _lightPos, new Vector3(0.3f, 0.0f, 0.5f));

        }
    }
}
