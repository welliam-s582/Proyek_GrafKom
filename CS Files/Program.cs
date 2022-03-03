using OpenTK.Mathematics;       
using OpenTK.Windowing.Desktop; 
using System;

namespace Project2
{
    class Program
    {
        static void Main(string[] args) 
        {

            var ourWindow = new NativeWindowSettings() 
            { 
                Size = new Vector2i(800,800), 
                Title = "PvZ Demo"  
            };

            using (var win = new All(GameWindowSettings.Default, ourWindow))
            {
                win.Run();
            }

        }
    }
}
