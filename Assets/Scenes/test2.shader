﻿Shader "Custom/test2"
{
    SubShader{
        Tags { "RenderType" = "Opaque" "Queue" = "Geometry+2"}

        ColorMask RGB
        Cull Front
        ZTest Always
        Stencil {
            Ref 1
            Comp equal
        }

        CGPROGRAM
        #pragma surface surf Lambert
        float4 _Color;
        struct Input {
            float4 color : COLOR;
        };
        void surf(Input IN, inout SurfaceOutput o) {
            o.Albedo = _Color.rgb;
            o.Normal = half3(0,0,-1);
            o.Alpha = 1;
        }
        ENDCG
    }
}
