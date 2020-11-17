using System;
using System.Runtime.InteropServices;
using SDL2.NetCore3;
using Xunit;

using SDL2.NetCore3.Extensions;

namespace SDL2.Tests
{
    public class ImageTests
    {
        [Fact]
        public void EmptyInit()
        {
            var result = SDL_image.IMG_Init(0);
            
            Assert.Equal(0, result);
        }
        
        [Fact]
        public void OpenImage()
        {
            var initResult = SDL_image.IMG_Init((int)SDL_image.IMG_InitFlags.IMG_INIT_PNG);
            var image = SDL_image.IMG_Load("./Hi.png");

            Assert.NotEqual(IntPtr.Zero, image);
            
            var imageSurface = Marshal.PtrToStructure<SDL_surface.SDL_Surface>(image);
            
            Assert.Equal(400, imageSurface.w);
            Assert.Equal(400, imageSurface.h);
            
            SDL_image.IMG_Quit();
        }
    }
}