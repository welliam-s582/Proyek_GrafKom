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
    class zombie
    {
      

        string path_head = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/head.obj";
        string path_mouth = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/mouth.obj";
        string path_body = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/body.obj";
        string path_hand = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/hand.obj";
        string path_leg = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/leg.obj";
        string path_teeth = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/teeth.obj";
        string path_eye = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/eye.obj";
        string path_shirt = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/shirt.obj";
        string path_pants = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/pants.obj";
        string path_bone = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/bone.obj";
        string path_foot = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/foot.obj";
        string path_pylon = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/pylon.obj";
        string path_bucket = "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Assets_zombie/bucket.obj";
      
        mesh mouth = new mesh();
        mesh head = new mesh();
        mesh body = new mesh();
        mesh hand = new mesh();
        mesh eye = new mesh();
        mesh teeth = new mesh();
        mesh shirt = new mesh();
        mesh pants = new mesh();
        mesh foot = new mesh();
        mesh bone = new mesh();
        mesh bucket = new mesh();
        mesh pylon = new mesh();
        mesh leg = new mesh();
    


        public zombie()
        {

        }


        public void load() 
        {

            head.initialize(path_head);
            body.initialize(path_body);
            mouth.initialize(path_mouth);
            teeth.initialize(path_teeth);
            eye.initialize(path_eye);
            hand.initialize(path_hand);
            leg.initialize(path_leg);
            bone.initialize(path_bone);
            foot.initialize(path_foot);
            shirt.initialize(path_shirt);
            pants.initialize(path_pants);
            bucket.initialize(path_bucket);
            pylon.initialize(path_pylon);

         
        }
        public void move(Vector3 _pos)
        {
            head.translate(_pos.X, _pos.Y, _pos.Z);
            body.translate(_pos.X, _pos.Y, _pos.Z);
            mouth.translate(_pos.X, _pos.Y, _pos.Z);
            eye.translate(_pos.X, _pos.Y, _pos.Z);
            teeth.translate(_pos.X, _pos.Y, _pos.Z);
            hand.translate(_pos.X, _pos.Y, _pos.Z);
            leg.translate(_pos.X, _pos.Y, _pos.Z);
            bone.translate(_pos.X, _pos.Y, _pos.Z);
            foot.translate(_pos.X, _pos.Y, _pos.Z);
            shirt.translate(_pos.X, _pos.Y, _pos.Z);
            pants.translate(_pos.X, _pos.Y, _pos.Z);
            bucket.translate(_pos.X, _pos.Y, _pos.Z); 
            pylon.translate(_pos.X, _pos.Y, _pos.Z);
        }

        public void Render_character(Camera _camera,Vector3 _lightPos, string hat = "")
        {           

            body.Render(_camera, _lightPos, new Vector3(0.4f, 0.8f, 0.2f));
            head.Render(_camera, _lightPos, new Vector3(0.4f, 0.8f, 0.2f));
            mouth.Render(_camera, _lightPos, new Vector3(0.8f, 0.0f, 0.0f));
            teeth.Render(_camera, _lightPos, new Vector3(0.94f, 1f, 0.62f));
            eye.Render(_camera, _lightPos, new Vector3(1f, 1f, 1f));
            hand.Render(_camera, _lightPos, new Vector3(0.4f, 0.8f, 0.2f));
            leg.Render(_camera, _lightPos, new Vector3(0.4f, 0.8f, 0.2f));
            foot.Render(_camera, _lightPos, new Vector3(0.5f, 0.2f, 0.0f));
            bone.Render(_camera, _lightPos, new Vector3(0.94f, 1f, 0.62f));
            shirt.Render(_camera, _lightPos, new Vector3(0.8f, 0.2f, 0.08f));
            pants.Render(_camera, _lightPos, new Vector3(0.05f, 0.22f, 0.8f));                     

            hat.ToLower();
            if (hat == "bucket")
            {
                bucket.Render(_camera, _lightPos, new Vector3(0.9f, 0.9f, 0.9f));
            }
            else if (hat == "pylon")
            {
                pylon.Render(_camera, _lightPos, new Vector3(0.8f, 0.15f, 0.02f));
            }
        }

    }
}
