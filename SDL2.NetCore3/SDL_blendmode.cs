namespace SDL2.NetCore3
{
    public static class SDL_blendmode
    {
        public enum SDL_BlendMode
        {

            SDL_BLENDMODE_NONE = 0x00000000,     /**< no blending
                                              dstRGBA = srcRGBA */
            SDL_BLENDMODE_BLEND = 0x00000001,    /**< alpha blending
                                              dstRGB = (srcRGB * srcA) + (dstRGB * (1-srcA))
                                              dstA = srcA + (dstA * (1-srcA)) */
            SDL_BLENDMODE_ADD = 0x00000002,      /**< additive blending
                                              dstRGB = (srcRGB * srcA) + dstRGB
                                              dstA = dstA */
            SDL_BLENDMODE_MOD = 0x00000004       /**< color modulate
                                              dstRGB = srcRGB * dstRGB
                                              dstA = dstA */

        }
    }
}