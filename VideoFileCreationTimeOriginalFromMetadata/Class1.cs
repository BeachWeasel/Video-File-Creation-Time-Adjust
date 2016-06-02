using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaInfoDotNet;
using MediaInfoDotNet.Models;
// try using parallel foreach for videos passed


namespace VideoFileCreationTimeOriginalFromMetadata
{
    public class Video//FileInfo video)
    {
        public Video(FileInfo[] FI)
        {
           
            Parallel.ForEach(FI, (f) =>
             {
                 try
                 {
                     DateTime dt = new DateTime();
                     //look for encode date and time
                     try
                     {
                         MediaInfoDotNet.MediaFile mf = new MediaFile(f.FullName); 

                         dt = mf.General.encodedDate;
                     }
                     catch
                     {
                         //if encode date and time doesn't exist 
                     }


                     //if encode date and time exists compare to video's fileinfo creation date and time
                     if (dt != f.CreationTime)
                     {
                         // if different update video's fileinfo with video's encode date and time 
                        
                         DateTime ldt = new DateTime(dt.Year,dt.Month,dt.Day,dt.Hour,dt.Minute,dt.Second);
                         f.CreationTime =ldt;
                     }


                 }
                 catch
                 { }
             });

        }

        

    }
}
