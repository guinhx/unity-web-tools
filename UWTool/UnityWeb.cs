namespace UWTool;

public class UnityWeb
{
    const string BrotliHeader = "UnityWeb Compressed Content (brotli)";
    
    public static bool HasUnityMarker(byte[] e)
    {

        if (e.Length == 0)
            return false;

        var r = (1 & e[0]) != 0 ? (14 & e[0]) != 0 ? 4 : 7 : 1;
        var n = e[0] & ((1 << r) - 1);
        var o = 1 + ((int)(Math.Log(BrotliHeader.Length - 1) / Math.Log(2)) >> 3);
        var commentOffset = (r + 1 + 2 + 1 + 2 + (o << 3) + 7) >> 3;

        if (n == 17 || commentOffset > e.Length)
            return false;

        var a = n + (6 + (o << 4) + ((BrotliHeader.Length - 1) << 6) << r);

        for (var i = 0; i < commentOffset; i++, a >>= 8)
        {
            if (e[i] != (byte)(a & 0xff))
                return false;
        }

        var comment = System.Text.Encoding.UTF8.GetString(e, commentOffset, BrotliHeader.Length);
        return comment == BrotliHeader;
    }
}