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
        
        [Fact]
        public void CreateWindowGetId()
        {
            var window = SDL_CreateWindow("", SDL_WINDOWPOS_CENTERED_MASK,
                SDL_WINDOWPOS_CENTERED_MASK, 600, 600, 0);
            
            Assert.NotEqual(IntPtr.Zero, window);

            var winId = SDL_GetWindowID(window);
            
            Assert.True(winId > 0);
            
            SDL_DestroyWindow(window);
        }
        
        [Fact]
        public void FindWindowById()
        {
            var window1 = SDL_CreateWindow("First Window", SDL_WINDOWPOS_CENTERED_MASK,
                SDL_WINDOWPOS_CENTERED_MASK, 600, 600, 0);
            
            Assert.NotEqual(IntPtr.Zero, window1);
            
            var window2 = SDL_CreateWindow("Second Window", SDL_WINDOWPOS_CENTERED_MASK,
                SDL_WINDOWPOS_CENTERED_MASK, 600, 600, 0);
            
            Assert.NotEqual(IntPtr.Zero, window2);

            var winId = SDL_GetWindowID(window1);
            var fetchedWindow = SDL_GetWindowFromID(winId);
            
            Assert.True(winId > 0);
            Assert.NotEqual(window1, window2);
            Assert.Equal(window1, fetchedWindow);
            
            SDL_DestroyWindow(window1);
            SDL_DestroyWindow(window2);
        }
    }
}