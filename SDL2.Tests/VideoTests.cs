using System;
using Xunit;

using static SDL2.NetCore3.SDL_video;

namespace SDL2.Tests
{
    public class VideoTests
    {
        [Fact]
        public void CreateWindow()
        {
            var window = SDL_CreateWindow("", SDL_WINDOWPOS_CENTERED_MASK,
                SDL_WINDOWPOS_CENTERED_MASK, 600, 600, 0);
            
            Assert.NotEqual(IntPtr.Zero, window);
            
            SDL_DestroyWindow(window);
        }
        
        [Fact]
        public void CreateWindow_NoTitle()
        {
            var window = SDL_CreateWindow("", SDL_WINDOWPOS_CENTERED_MASK,
                SDL_WINDOWPOS_CENTERED_MASK, 600, 600, 0);
            
            Assert.NotEqual(IntPtr.Zero, window);
            Assert.Empty(SDL_GetWindowTitle(window));
            
            SDL_DestroyWindow(window);
        }
        
        [Fact]
        public void CreateWindow_Title()
        {
            const string windowTitle = "ThisIsATitle";
            var window = SDL_CreateWindow(windowTitle, SDL_WINDOWPOS_CENTERED_MASK,
                SDL_WINDOWPOS_CENTERED_MASK, 600, 600, 0);
            
            Assert.NotEqual(IntPtr.Zero, window);
            Assert.Equal(windowTitle,SDL_GetWindowTitle(window));
            
            SDL_DestroyWindow(window);
        }
        
        [Fact]
        public void CreateWindow_SetTitle()
        {
            const string windowTitle = "This Is A Title";
            var window = SDL_CreateWindow(windowTitle, SDL_WINDOWPOS_CENTERED_MASK,
                SDL_WINDOWPOS_CENTERED_MASK, 600, 600, 0);
            
            Assert.NotEqual(IntPtr.Zero, window);
            Assert.Equal(windowTitle,SDL_GetWindowTitle(window));

            const string anotherWindowTitle = "ThisOneIsDifferent";
            SDL_SetWindowTitle(window, anotherWindowTitle);
            
            Assert.Equal(anotherWindowTitle,SDL_GetWindowTitle(window));
            
            SDL_DestroyWindow(window);
        }
    }
}