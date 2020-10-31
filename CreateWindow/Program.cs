using System;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.RuntimeInformation;
using SDL2.NetCore3;
using static SDL2.NetCore3.SDL;
using static SDL2.NetCore3.SDL_error;
using static SDL2.NetCore3.SDL_render;
using static SDL2.NetCore3.SDL_surface;
using static SDL2.NetCore3.SDL_video;
using static SDL2.NetCore3.SDL_events;

using SDL2.NetCore3.Extensions;

namespace CreateWindow
{
    internal static class Program
    {
        static void Main()
        {
            const int width = 800;
            const int height = 600;

            if (SDL_Init(SDL_INIT_VIDEO) != 0)
                throw new Exception($"Could not init SDL: {SDL_GetError()}");
            
            var result = SDL_CreateWindowAndRenderer(width, height,
                (uint)(SDL_WindowFlags.SDL_WINDOW_SHOWN |
                       SDL_WindowFlags.SDL_WINDOW_OPENGL),
                out var window,
                out var renderer);

            if (result != 0)
                throw new Exception($"Could not initialize window: {SDL_GetError()}");
            
            SDL_RenderClear(renderer);
            
            var surface = MakeTextSurface("Hello World!!");
            
            AddSurfaceToRendererAt(surface, renderer, 0, 0);
            SDL_RenderPresent(renderer);

            WaitForWindowToBeClose();

            SDL_FreeSurface(surface);
            SDL_DestroyRenderer(renderer);
            SDL_DestroyWindow(window);
            SDL_Quit();
        }

        private static void WaitForWindowToBeClose()
        {
            var quit = false;
            var raisedEvent = new SDL_Event();

            while (!quit)
            {
                SDL_WaitEvent(ref raisedEvent);

                switch ((SDL_EventType) raisedEvent.type)
                {
                    case SDL_EventType.SDL_QUIT:
                        quit = true;
                        break;
                }
            }
        }

        private static string ArialFontFilename()
        {
            if (IsOSPlatform(OSPlatform.Windows))
                return "arial.ttf";
            else if (IsOSPlatform(OSPlatform.OSX))
                return "/Library/Fonts/Arial.ttf";
            else
                return "/usr/share/fonts/truetype/msttcorefonts/Arial.ttf";
        }

        private static IntPtr MakeTextSurface(string message)
        {
            SDL_ttf.TTF_Init();
            var font = SDL_ttf.TTF_OpenFont(ArialFontFilename(), 128);
            
            if (font == IntPtr.Zero)
                throw new Exception($"Could not initialize font: {SDL_GetError()}");
            
            var color = new SDL_pixels.SDL_Color { r = 255, g = 255, b = 255, a = 255 };
            var surface = SDL_ttf.TTF_RenderText_Solid(font,
                message, color);
            SDL_ttf.TTF_CloseFont(font);
            SDL_ttf.TTF_Quit();
            
            return surface;
        }

        private static void AddSurfaceToRendererAt(IntPtr surface, IntPtr renderer, int x, int y)
        {
            unsafe
            {
                var texture = SDL_CreateTextureFromSurface(renderer, surface);
                int texW = 0;
                int texH = 0;
                uint format = uint.MinValue;
                int access = int.MinValue;
                SDL_QueryTexture(texture, ref format, ref access, ref texW, ref texH);
                SDL_rect.SDL_Rect dstrect = new SDL_rect.SDL_Rect { x=x, y=y, w=texW, h=texH };
            
                SDL_RenderCopy(renderer, texture, null, &dstrect);
                SDL_DestroyTexture(texture);
            }
        }
    }
}