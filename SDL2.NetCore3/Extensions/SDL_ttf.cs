using System;

using SDL2.NetCore3.Internal;

namespace SDL2.NetCore3.Extensions
{
    public static class SDL_ttf
    {
        public static string TTF_GetError() => SDL_error.SDL_GetError();
        private delegate void TTF_Linked_Version__t();
        private static TTF_Linked_Version__t s_TTF_Linked_Version__t = __LoadFunction<TTF_Linked_Version__t>("TTF_Linked_Version");
        public static void TTF_Linked_Version() => s_TTF_Linked_Version__t();
        
        private delegate void TTF_Init__t();
        private static TTF_Init__t s_TTF_Init__t = __LoadFunction<TTF_Init__t>("TTF_Init");
        public static void TTF_Init() => s_TTF_Init__t();
        
        private delegate void TTF_Quit__t();
        private static TTF_Quit__t s_TTF_Quit__t = __LoadFunction<TTF_Quit__t>("TTF_Quit");
        public static void TTF_Quit() => s_TTF_Quit__t();
        
        private delegate IntPtr TTF_OpenFont_IntPtr_int__t(IntPtr file, int size);
        private static TTF_OpenFont_IntPtr_int__t s_TTF_OpenFont_IntPtr_int__t = __LoadFunction<TTF_OpenFont_IntPtr_int__t>("TTF_OpenFont");
        public static IntPtr TTF_OpenFont(string file, int size) => s_TTF_OpenFont_IntPtr_int__t(Util.StringToHGlobalUTF8(file), size);

        private delegate void TTF_CloseFont_IntPtr__t(IntPtr font);
        private static TTF_CloseFont_IntPtr__t s_TTF_CloseFont_IntPtr__t = __LoadFunction<TTF_CloseFont_IntPtr__t>("TTF_CloseFont");
        public static void TTF_CloseFont(IntPtr font) => s_TTF_CloseFont_IntPtr__t(font);

        private delegate IntPtr TTF_RenderText_Solid_IntPtr_IntPtr_color__t(IntPtr font, IntPtr text,
            SDL_pixels.SDL_Color color);
        private static TTF_RenderText_Solid_IntPtr_IntPtr_color__t s_TTF_RenderText_Solid_IntPtr_IntPtr_color__t =
            __LoadFunction<TTF_RenderText_Solid_IntPtr_IntPtr_color__t>("TTF_RenderText_Solid");
        public static IntPtr TTF_RenderText_Solid(IntPtr font, string text, SDL_pixels.SDL_Color foreground) => s_TTF_RenderText_Solid_IntPtr_IntPtr_color__t(font, Util.StringToHGlobalUTF8(text), foreground);
        
        private static T __LoadFunction<T>(string name)
            where T : class
        {
            if (Loader_SDL2.SdlTff == null) return null;
            try
            {
                return Loader_SDL2.SdlTff.LoadFunction<T>(name);
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