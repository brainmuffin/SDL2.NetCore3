using System;
using SDL2.NetCore3.Internal;

namespace SDL2.NetCore3
{
    public static class SDL_timer
    {
        private delegate uint SDL_GetTicks__t();

        private static SDL_GetTicks__t s_SDL_GetTicks__t = __LoadFunction<SDL_GetTicks__t>("SDL_GetTicks");

        public static uint SDL_GetTicks() => s_SDL_GetTicks__t();
        
        private delegate uint SDL_Delay__t(uint ms);

        private static SDL_Delay__t s_SDL_Delay__t = __LoadFunction<SDL_Delay__t>("SDL_Delay");

        public static void SDL_Delay(uint ms) => s_SDL_Delay__t(ms);
        private static T __LoadFunction<T>(string name) { return Loader_SDL2.LoadFunction<T>(name); }
    }
}