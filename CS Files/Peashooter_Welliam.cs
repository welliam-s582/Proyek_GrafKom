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
    class Peashooter_Welliam
    {
        private int cnt = 0; //timer untuk tranlasi peluru  
        private int tmp = 0; // timer untuk proses reset
        private bool swicth_shoot = true;

        string path_head = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_peashooter/head.obj";
        string path_mouth = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_peashooter/mouth.obj";
        string path_mouth_loop = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_peashooter/mouth_loop.obj";
        string path_hair = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_peashooter/hair.obj";
        string path_neck = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_peashooter/neck.obj";
        string path_body = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_peashooter/body.obj";
        string path_leaf = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_peashooter/leaf.obj";
        string path_eye = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_peashooter/eye.obj";
        string path_bullet = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_peashooter/bullet.obj";

        mesh head = new mesh();
        mesh mouth = new mesh();
        mesh mouth_loop = new mesh();
        mesh neck = new mesh();
        mesh body = new mesh();
        mesh leaf = new mesh();  
        mesh eye = new mesh();
        mesh hair = new mesh();
        mesh bullet = new mesh();


        public Peashooter_Welliam()
        {

        }

        public void load() 
        {

            head.initialize(path_head);

            mouth.initialize(path_mouth);

            mouth_loop.initialize(path_mouth_loop);

            neck.initialize(path_neck);

            body.initialize(path_body);

            leaf.initialize(path_leaf);

            eye.initialize(path_eye);

            hair.initialize(path_hair);

            bullet.initialize(path_bullet);
            
         
  
        }
        public void move(Vector3 _pos)
        {
            head.translate(_pos.X, _pos.Y, _pos.Z);
            body.translate(_pos.X, _pos.Y, _pos.Z);
            mouth.translate(_pos.X, _pos.Y, _pos.Z);
            mouth_loop.translate(_pos.X, _pos.Y, _pos.Z);
            neck.translate(_pos.X, _pos.Y, _pos.Z);
            eye.translate(_pos.X, _pos.Y, _pos.Z);
            hair.translate(_pos.X, _pos.Y, _pos.Z);
            bullet.translate(_pos.X, _pos.Y, _pos.Z);
            leaf.translate(_pos.X, _pos.Y, _pos.Z);
            bullet.save();
        }

        public void Render_character(Camera _camera, Vector3 _lightPos)
        {

            if (swicth_shoot == true)
            {
                //shoot bullet animation
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
            


            hair.Render(_camera, _lightPos, new Vector3 (0.0f, 0.8f, 0.4f));
            body.Render(_camera, _lightPos, new Vector3(0.0f, 1.0f, 0.0f));
            leaf.Render(_camera, _lightPos, new Vector3(0.3f, 0.6f, 0.1f));
            neck.Render(_camera, _lightPos, new Vector3(0.1f, 0.6f, 0.2f));
            head.Render(_camera, _lightPos, new Vector3(0.1f, 1.0f, 0.0f));
            eye.Render(_camera, _lightPos, new Vector3(0.0f, 0.0f, 0.0f));
            mouth.Render(_camera, _lightPos, new Vector3(0.0f, 1.0f, 0.0f));
            mouth_loop.Render(_camera, _lightPos, new Vector3(0.2f, 1.0f, 0.0f));
            if (swicth_shoot == true)
            {
                bullet.Render(_camera, _lightPos, new Vector3(0.1f, 1.0f, 0.0f));
            }
        }

    }

}
