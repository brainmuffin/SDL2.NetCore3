using System.Runtime.InteropServices;
using SDL_bool = System.Int32;

namespace SDL2.NetCore3
{
    public static class SDL_rect
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Point
        {

            public int x;
            public int y;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Rect
        {

            public int x, y;
            public int w, h;

        }

        private delegate SDL_bool SDL_HasIntersection_SDL_Rect_SDL_Rect_t(ref SDL_Rect A, ref SDL_Rect B);

        private static SDL_HasIntersection_SDL_Rect_SDL_Rect_t s_SDL_HasIntersection_SDL_Rect_SDL_Rect_t = __LoadFunction<SDL_HasIntersection_SDL_Rect_SDL_Rect_t>("SDL_HasIntersection");

        public static SDL_bool SDL_HasIntersection(ref SDL_Rect A, ref SDL_Rect B) => s_SDL_HasIntersection_SDL_Rect_SDL_Rect_t(ref A, ref B);

        private delegate SDL_bool SDL_IntersectRect_SDL_Rect_SDL_Rect_SDL_Rect_t(ref SDL_Rect A, ref SDL_Rect B, ref SDL_Rect result);

        private static SDL_IntersectRect_SDL_Rect_SDL_Rect_SDL_Rect_t s_SDL_IntersectRect_SDL_Rect_SDL_Rect_SDL_Rect_t = __LoadFunction<SDL_IntersectRect_SDL_Rect_SDL_Rect_SDL_Rect_t>("SDL_IntersectRect");

        public static SDL_bool SDL_IntersectRect(ref SDL_Rect A, ref SDL_Rect B, ref SDL_Rect result) => s_SDL_IntersectRect_SDL_Rect_SDL_Rect_SDL_Rect_t(ref A, ref B, ref result);

        private delegate void SDL_UnionRect_SDL_Rect_SDL_Rect_SDL_Rect_t(ref SDL_Rect A, ref SDL_Rect B, ref SDL_Rect result);

        private static SDL_UnionRect_SDL_Rect_SDL_Rect_SDL_Rect_t s_SDL_UnionRect_SDL_Rect_SDL_Rect_SDL_Rect_t = __LoadFunction<SDL_UnionRect_SDL_Rect_SDL_Rect_SDL_Rect_t>("SDL_UnionRect");

        public static void SDL_UnionRect(ref SDL_Rect A, ref SDL_Rect B, ref SDL_Rect result) => s_SDL_UnionRect_SDL_Rect_SDL_Rect_SDL_Rect_t(ref A, ref B, ref result);

        private delegate SDL_bool SDL_EnclosePoints_SDL_Point_int_SDL_Rect_SDL_Rect_t(ref SDL_Point points, int count, ref SDL_Rect clip, ref SDL_Rect result);

        private static SDL_EnclosePoints_SDL_Point_int_SDL_Rect_SDL_Rect_t s_SDL_EnclosePoints_SDL_Point_int_SDL_Rect_SDL_Rect_t = __LoadFunction<SDL_EnclosePoints_SDL_Point_int_SDL_Rect_SDL_Rect_t>("SDL_EnclosePoints");

        public static SDL_bool SDL_EnclosePoints(ref SDL_Point points, int count, ref SDL_Rect clip, ref SDL_Rect result) => s_SDL_EnclosePoints_SDL_Point_int_SDL_Rect_SDL_Rect_t(ref points, count, ref clip, ref result);

        private delegate SDL_bool SDL_IntersectRectAndLine_SDL_Rect_int_int_int_int_t(ref SDL_Rect rect, ref int X1, ref int Y1, ref int X2, ref int Y2);

        private static SDL_IntersectRectAndLine_SDL_Rect_int_int_int_int_t s_SDL_IntersectRectAndLine_SDL_Rect_int_int_int_int_t = __LoadFunction<SDL_IntersectRectAndLine_SDL_Rect_int_int_int_int_t>("SDL_IntersectRectAndLine");

        public static SDL_bool SDL_IntersectRectAndLine(ref SDL_Rect rect, ref int X1, ref int Y1, ref int X2, ref int Y2) => s_SDL_IntersectRectAndLine_SDL_Rect_int_int_int_int_t(ref rect, ref X1, ref Y1, ref X2, ref Y2);
        private static T __LoadFunction<T>(string name) { return Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}