using System;
using System.Collections.Generic;
using System.Text;
using LearnOpenTK.Common;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using System.IO;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Project2
{ 
    class mesh
    {
  
        protected List<Vector3> vertices = new List<Vector3>(); 
        protected List<Vector3> texture = new List<Vector3>();
        protected List<Vector3> normals = new List<Vector3>();
        protected List<float> _combine = new List<float>();
        private float[] _realVertices;
        protected List<uint> indeces = new List<uint>();
        protected List<uint> indeces_n = new List<uint>();

        protected int _VBO;
        protected int _VAO;
        protected int _VAO_lamp;
        protected int _EBO;

        private Shader _lightingShader;
        private Shader _lampShader;

        protected Matrix4 _transform; 
        protected Matrix4 _transform_tmp;

      
    
        public mesh() 
        {}

        public void set_transform()
        {
            _transform = Matrix4.Identity;             
        }

        public void set_VAO()
        {     
            _VAO = GL.GenVertexArray();
            GL.BindVertexArray(_VAO);
        }
        public void set_VAO_lamp()
        {
            _VAO_lamp = GL.GenVertexArray();
            GL.BindVertexArray(_VAO_lamp);
        }
        public void set_VBO()
        {
            combine();
            _VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, _realVertices.Length * sizeof(float), _realVertices, BufferUsageHint.StaticDraw);
        }

        public void enable_vertex()
        {

            var vertexLocation = _lightingShader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);


            var normalLocation = _lightingShader.GetAttribLocation("aNormal"); //karena ada normalisasi, jadi buat baru...jika tidak ada normalisasi, bisa dihapus
            GL.EnableVertexAttribArray(normalLocation);
            GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));


            //var texCoordLocation = _lightingShader.GetAttribLocation("aTexCoords");
            //GL.EnableVertexAttribArray(texCoordLocation);
            //GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 0, 6 * sizeof(float));

        }

        public void set_EBO()
        {
            _EBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indeces.Count * sizeof(uint), indeces.ToArray(), BufferUsageHint.StaticDraw) ;

        }

        public void set_shader()
        {
            _lightingShader = new Shader("D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Project2/Shaders/shader.vert", "D:/Visual Studio source/Computer Graphic/Tugas_Project_GrafKom_klmpk34/Project2/Shaders/lighting.frag");
            enable_vertex();
        }
        public void set_shader_lamp()
        {
            _lampShader = new Shader("D:/Visual Studio source/CG10/CG10/Shaders/shader.vert", "D:/Visual Studio source/CG10/CG10/Shaders/shader.frag");

            var vertexLocation = _lampShader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);        
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);

        }
       

        public void initialize(string p1)
        {
            set_transform();
            LoadObjFile(p1);
            set_VBO();
            set_VAO();
            set_shader();
        }

        public void Render(Camera _camera, Vector3 _lightPos, Vector3 _color)
        {
            GL.BindVertexArray(_VAO);
            _lightingShader.Use();
         
            _lightingShader.SetMatrix4("transform", _transform);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", _color);
            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);


            GL.DrawArrays(PrimitiveType.Triangles, 0, _realVertices.Length);
        }
        
        public void Render_lamp(Camera _camera, Vector3 _lightPos, Vector3 _color)
        {
            GL.BindVertexArray(_VAO);
            _lightingShader.Use();

            _lightingShader.SetMatrix4("transform", _transform);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", _color);
            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 0.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);


            GL.BindVertexArray(_VAO_lamp);
            _lampShader.Use();

            Matrix4 lampMatrix = Matrix4.CreateScale(2f); 
            lampMatrix = lampMatrix * Matrix4.CreateTranslation(_lightPos);

            _lampShader.SetMatrix4("transform", lampMatrix);
            _lampShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lampShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, _realVertices.Length);

        }
        private void combine()
        {
            int n = 0;
            int cnt = 0;
            foreach (int i in indeces)
            {
                
                n = (int)indeces_n[cnt];

                _combine.Add(vertices[i].X);
                _combine.Add(vertices[i].Y);
                _combine.Add(vertices[i].Z);
                _combine.Add(normals[n].X);
                _combine.Add(normals[n].Y);
                _combine.Add(normals[n].Z);

                cnt++;
            }
            _realVertices = _combine.ToArray();
        }

        public void save()
        {
            _transform_tmp = _transform;
        }
        public void reset()
        {
            _transform = _transform_tmp;
        }

        public void rotate(float dr) 
        {
            _transform = _transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(dr));

        }
        public void scale(float r) 
        {
            _transform = _transform * Matrix4.CreateScale(r);
        }

        public void translate(float dx, float dy, float dz)
        {
            _transform = _transform * Matrix4.CreateTranslation(dx, dy, dz); 

        }

     

        public void LoadObjFile(string path)
        {
            
            if (!File.Exists(path))
            {     
                throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                  
                    List<string> words = new List<string>(streamReader.ReadLine().ToLower().Split(' '));
                 
                    words.RemoveAll(s => s == string.Empty);
                  
                    if (words.Count == 0)
                    {
                        continue;
                    }
                          
                    string type = words[0];
                    words.RemoveAt(0);

                    switch (type)
                    {
                       
                        case "v":
                            vertices.Add(new Vector3(float.Parse(words[0]) / 10, float.Parse(words[1]) / 10, float.Parse(words[2]) / 10));
                            break;

                        case "vt":
                            texture.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]),
                                                            words.Count < 3 ? 0 : float.Parse(words[2])));
                            break;

                        case "vn":
                            normals.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]), float.Parse(words[2])));
                            break;
       
                        case "f":
                            foreach (string w in words)
                            {
                                if (w.Length == 0)
                                    continue;

                                string[] comps = w.Split('/');

                                indeces.Add(uint.Parse(comps[0]) - 1);
                                indeces_n.Add(uint.Parse(comps[2]) - 1);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}
