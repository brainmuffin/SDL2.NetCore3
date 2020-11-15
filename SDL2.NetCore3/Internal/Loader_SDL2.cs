using System;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.RuntimeInformation;
using NativeLibrary = NativeLibraryLoader.NativeLibrary;

namespace SDL2.NetCore3.Internal
{
    internal static class Loader_SDL2
    {
        private static NativeLibrary _sdl2;
        private static NativeLibrary _sdl2Mixer;
        private static NativeLibrary _sdl2Tff;
        private static NativeLibrary _sdl2Image;

        private static NativeLibrary Sdl2
        {
            get
            {
                if (_sdl2 == null)
                    _sdl2 = LoadSDL2();
                return _sdl2;
            }
        }

        internal static NativeLibrary SdlMixer
        {
            get
            {
                if (_sdl2Mixer == null)
                    _sdl2Mixer = LoadSDLMixer();
                return _sdl2Mixer;
            }
        }
        
        internal static NativeLibrary SdlTff
        {
            get
            {
                if (_sdl2Tff == null)
                    _sdl2Tff = LoadSDLTff();
                return _sdl2Tff;
            }
        }
        
        internal static NativeLibrary SdlImage
        {
            get
            {
                if (_sdl2Image == null)
                    _sdl2Image = LoadSDLImage();
                return _sdl2Image;
            }
        }

        static NativeLibrary LoadSDL2() =>
            Load(
                windows: new[] {
                    "SDL2.dll"
                },
                osx: new[] {
                    "libSDL2.dylib"
                },
                linux: new[] {
                    "libSDL2-2.0.so",
                    "libSDL2-2.0.so.0",
                    "libSDL2-2.0.so.1"
                });

        static NativeLibrary LoadSDLMixer() =>
            TryLoad(
                windows: new[] { 
                    "SDL_mixer.dll"
                },
                osx: new[] {
                    "libSDL2_mixer.dylib"
                },
                linux: new[] {
                    "libSDL2_mixer.so",
                    "libSDL2_mixer.so.0",
                    "libSDL2_mixer.so.1"
                }
            );
        
        static NativeLibrary LoadSDLTff() =>
            TryLoad(
                windows: new[] { 
                    "SDL2_ttf.dll"
                },
                osx: new[] {
                    "libSDL2_ttf.dylib",
                    "SDL2_ttf"
                },
                linux: new[] {
                    "libSDL2_ttf.so",
                    "libSDL2_ttf-2.0.so.0.14.1",
                    "libSDL2_ttf-2.0.so"
                }
            );
        
        static NativeLibrary LoadSDLImage() =>
            TryLoad(
                windows: new[] { 
                    "SDL2_image.dll"
                },
                osx: new[] {
                    "libSDL2_image.dylib",
                    "SDL2_image"
                },
                linux: new[] {
                    "libSDL2_image.so",
                    "libSDL2_image-2.0.5so",
                    "libSDL2_image-2.0.so"
                }
            );

        static NativeLibrary Load(string[] windows, string[] osx, string[] linux)
        {
            var names = linux;
            if (IsOSPlatform(OSPlatform.Windows))
                names = windows;
            else if (IsOSPlatform(OSPlatform.OSX))
                names = osx;
            return new NativeLibrary(names);
        }

        static NativeLibrary TryLoad(string[] windows, string[] osx, string[] linux)
        {
            try
            {
                return Load(windows, osx, linux);
            }
#pragma warning disable
            catch (Exception ex) { }
#pragma warning enable
            return null;
        }

        internal static T LoadFunction<T>(string name)
        {
            return Sdl2.LoadFunction<T>(name);
        }

        internal static T LoadFunction<T>(this NativeLibrary library,
            string name)
        {
            return library.LoadFunction<T>(name);
        }
    }
}