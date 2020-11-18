using System;
using Xunit;
using static SDL2.NetCore3.SDL_timer;

namespace SDL2.Tests
{
    public class TimerTests
    {
        [Fact]
        public void TwoSecondPause()
        {
            var start = DateTime.Now;

            SDL_Delay(2000);

            var end = DateTime.Now;
            var elapsed = end - start;
            
            Assert.NotEqual(start, end);
            Assert.True(elapsed.Seconds >= 2);
        }
    }
}