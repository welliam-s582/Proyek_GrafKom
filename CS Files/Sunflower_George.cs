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
    class Sunflower_George
    {
        private int cnt1 = 0;//timer untuk tranlasi orb matahari
        private int tmp1 = 0;// timer untuk proses reset orb
       

        private bool stop = true;

        string path_head = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_sunflower/head.obj";
        string path_mouth = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_sunflower/mouth.obj";
        string path_neck = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_sunflower/neck.obj";
        string path_body = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_sunflower/body.obj";
        string path_leaf = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_sunflower/leaf.obj";
        string path_orb = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_sunflower/orb.obj";
        string path_eye = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_sunflower/eye.obj";
        string path_kelopak = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_sunflower/kelopak.obj";

        mesh head = new mesh();
        mesh mouth = new mesh();
        mesh neck = new mesh();
        mesh body = new mesh();
        mesh leaf = new mesh();
        mesh eye = new mesh();
        mesh orb = new mesh();
        mesh kelopak = new mesh();


        public Sunflower_George()
        {

        }


        public void load() 
        {

            head.initialize(path_head);

            mouth.initialize(path_mouth);

            neck.initialize(path_neck);

            body.initialize(path_body);

            leaf.initialize(path_leaf);

            eye.initialize(path_eye);
    
            kelopak.initialize(path_kelopak);

            orb.initialize(path_orb);
          

           
        }
        public void move(Vector3 _pos)
        {

            body.translate(_pos.X, _pos.Y, _pos.Z);
            neck.translate(_pos.X, _pos.Y, _pos.Z);
            kelopak.translate(_pos.X, _pos.Y, _pos.Z);
            eye.translate(_pos.X, _pos.Y, _pos.Z);
            mouth.translate(_pos.X, _pos.Y, _pos.Z);
            leaf.translate(_pos.X, _pos.Y, _pos.Z);
            head.translate(_pos.X, _pos.Y, _pos.Z);
            orb.translate(_pos.X, _pos.Y, _pos.Z);
            orb.save();
        }

        public void Render_character(Camera _camera, Vector3 _lightPos)
        {

            if (stop == true)
            {

                //animasi orb matahari
                if (cnt1 == 50)
                {
                    orb.translate(0.0f, 0.05f, 0.0f);
                    tmp1++;
                    if (tmp1 == 4)
                    {
                        orb.reset();
                        tmp1 = 0;

                    }
                    cnt1 = 0;
                }
                else
                {
                    cnt1++;
                }
            }

            body.Render(_camera, _lightPos, new Vector3(0.0f, 1.0f, 0.0f));
            leaf.Render(_camera, _lightPos, new Vector3(0.3f, 0.6f, 0.1f));
            neck.Render(_camera, _lightPos, new Vector3(0.1f, 0.6f, 0.2f));
            kelopak.Render(_camera, _lightPos, new Vector3(1.0f, 0.9f, 0.0f));
            head.Render(_camera, _lightPos, new Vector3(0.8f, 0.4f, 0.0f));
            mouth.Render(_camera, _lightPos, new Vector3(0.0f, 0.0f, 0.0f));
            eye.Render(_camera, _lightPos, new Vector3(0.0f, 0.0f, 0.0f));         
            orb.Render(_camera, _lightPos, new Vector3(1.0f, 0.9f, 0.0f));



        }
     
    }
}
