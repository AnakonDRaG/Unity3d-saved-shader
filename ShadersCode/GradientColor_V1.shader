Shader "Custom/Gradient Color" {
     Properties {
         [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
         _ColorTop ("Top Color", Color) = (1,1,1,1)
         _ColorBot ("Bot Color", Color) = (1,1,1,1)
     }

     SubShader {
         Tags {"Queue"="Background"  "IgnoreProjector"="True"}
         LOD 100

         ZWrite On

         Pass {
         CGPROGRAM
         #pragma vertex vert  
         #pragma fragment frag
         #include "UnityCG.cginc"

         fixed4 _ColorTop;
         fixed4 _ColorBot;


         struct v2f {
             float4 pos : SV_POSITION;
             float4 texcoord : TEXCOORD0;
         };

         v2f vert (appdata_full v) {
             v2f o;
             o.pos = UnityObjectToClipPos (v.vertex);
             o.texcoord = v.texcoord;
             return o;
         }

         fixed4 frag (v2f i) : COLOR {

             fixed4 c = lerp(_ColorBot, _ColorTop, i.texcoord.y / 0.999) * step(i.texcoord.y, 0.999);
             c += lerp(c, _ColorTop, (i.texcoord.y - 0.999) / (1 - 0.999)) * step(0.999, i.texcoord.y);
             c.a = 1;

             return c;
         }
         ENDCG
         }
     }
 }