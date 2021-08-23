Shader "Shaders/WaterTextures"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1)
        _MainTex("Texture", 2D) = "white" {}
        _Waveyness("Waveyness", Float) = 1.0
    }

        SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            float4 _Color;
            sampler2D _MainTex;
            float _Waveyness;

            struct VertexShaderInput
            {
                float4 vertex: POSITION;
                float2 uv    : TEXCOORD0;
            };

            struct VertexShaderOutput
            {
                float4 pos: SV_POSITION;
                float2 uv: TEXCOORD0;
                float4 objpos: TEXCOORD1;
            };

            VertexShaderOutput vert(VertexShaderInput v)
            {
                VertexShaderOutput o;
                v.vertex.y += sin((_Time.y + v.uv.x) * _Waveyness);
                o.uv = v.uv;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.objpos = v.vertex;
                return o;
            }

            float4 frag(VertexShaderOutput i) :SV_TARGET
            {
                float4 color = tex2D(_MainTex, i.uv);
                return color;
            }

            ENDCG
        }
    }

}
