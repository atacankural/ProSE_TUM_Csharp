using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace A5_GroupF
{
    class Program
    {
        
        static void Main()
        {
            
            ImageContainer.threshold = 15;

            ParameterizedThreadStart del1 = new ParameterizedThreadStart(ImageContainer.Importing);
            Thread image1 = new Thread(del1);
            object path1 = "C:\\Users\\moham\\Desktop\\Assignment 5\\Ata 2\\A5_GroupF\\Filtering\\image1";
            image1.Start(path1);

            ParameterizedThreadStart del2 = new ParameterizedThreadStart(ImageContainer.Importing);
            Thread image2 = new Thread(del2);
            object path2 = "C:\\Users\\moham\\Desktop\\Assignment 5\\Ata 2\\A5_GroupF\\Filtering\\image2";
            image2.Start(path2);

            ParameterizedThreadStart del3 = new ParameterizedThreadStart(ImageContainer.Importing);
            Thread image3 = new Thread(del3);
            object path3 = "C:\\Users\\moham\\Desktop\\Assignment 5\\Ata 2\\A5_GroupF\\Filtering\\image3";
            image3.Start(path3);

            ParameterizedThreadStart del4 = new ParameterizedThreadStart(ImageContainer.Importing);
            Thread image4 = new Thread(del4);
            object path4 = "C:\\Users\\moham\\Desktop\\Assignment 5\\Ata 2\\A5_GroupF\\Filtering\\image4";
            image4.Start(path4);

            ParameterizedThreadStart del5 = new ParameterizedThreadStart(ImageContainer.Importing);
            Thread image5 = new Thread(del5);
            object path5 = "C:\\Users\\moham\\Desktop\\Assignment 5\\Ata 2\\A5_GroupF\\Filtering\\image5";
            image5.Start(path5);
        }
    }
}