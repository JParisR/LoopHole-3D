Shader "TextureScrollWrapShader"
{
    Properties
    {
		_MainTex ("Texture", 2D) = "white" {}
		//_PosX ("X Position", Range(0, 1)) = 1
		//_PosY ("Y Position", Range(0, 1)) = 1
		_SpeedX ("X Speed", Range(0, 1)) = 1
		_SpeedY ("Y Speed", Range(0, 1)) = 1
		_Brightness("Brightness", Range(0, 2)) = 1
    }

    SubShader
    {
         Pass
        {
            CGPROGRAM
			#pragma vertex vert
            #pragma fragment frag

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(float4 pos : POSITION, float2 uv : TEXCOORD0)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(pos);
				o.uv = uv;
				return o;
			}

			sampler2D _MainTex;
			//float _PosX;
			//float _PosY;
			float _SpeedX;
			float _SpeedY;
			float _Brightness;

			float4 frag(v2f i) : SV_TARGET
			{
				//float x = i.uv.x + _PosX;
				//float y = i.uv.y + _PosY;
				float x = i.uv.x + _Time.w * _SpeedX;
				float y = i.uv.y + _Time.w * _SpeedY;
				float2 disp = float2(1 - abs(x % 2 - 1), 1 - abs(y % 2 - 1));
				return tex2D(_MainTex, disp)*_Brightness;
			}

            ENDCG
        }
    }

	FallBack Off
}