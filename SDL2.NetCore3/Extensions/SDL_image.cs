using System;
using System.Runtime.InteropServices;

using SDL2.NetCore3.Internal;

namespace SDL2.NetCore3.Extensions
{
    public class SDL_image
    {
        private delegate IntPtr ImgLoadT(IntPtr file);
        private static readonly ImgLoadT s_IMG_Load = __LoadFunction<ImgLoadT>("IMG_Load");
        public static IntPtr IMG_Load(string file) => s_IMG_Load(Util.StringToHGlobalUTF8(file));
        
        private static T __LoadFunction<T>(string name)
            where T : class
        {
            if (Loader_SDL2.SdlImage == null) return null;
            try
            {
                return Loader_SDL2.SdlImage.LoadFunction<T>(name);
            }
#pragma warning disable
            catch (Exception ex)
            {
                return null;
            }
#pragma warning enable
        }
    }
}