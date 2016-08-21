Shader "Sprites/ReColor2"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Blinking Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		_WColor("White Replacement", Color) = (1,1,1,1)
		_GColor("Grey Replacement", Color) = (1,1,1,1)
		_BColor("Black Replacement", Color) = (1,1,1,1)
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		GrabPass{}

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile _ PIXELSNAP_ON
#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
#include "UnityCG.cginc"

		struct appdata_t
	{
		float4 vertex   : POSITION;
		float4 color    : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex   : SV_POSITION;
		fixed4 color : COLOR;
		float2 texcoord  : TEXCOORD0;
		float4 uvgrab : TEXCOORD1;
	};

	fixed4 _Color;
	fixed4 _WColor;
	fixed4 _GColor;
	fixed4 _BColor;
	sampler2D _GrabTexture;

	v2f vert(appdata_t IN)
	{
		v2f OUT;
		OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
		OUT.texcoord = IN.texcoord;
		OUT.uvgrab = ComputeGrabScreenPos(OUT.vertex);
		OUT.color = IN.color * _Color;
#ifdef PIXELSNAP_ON
		OUT.vertex = UnityPixelSnap(OUT.vertex);
#endif

		return OUT;
	}

	sampler2D _MainTex;
	sampler2D _AlphaTex;

	fixed4 SampleSpriteTexture(float2 uv)
	{
		fixed4 color = tex2D(_MainTex, uv);

#if ETC1_EXTERNAL_ALPHA
		// get the color from an external texture (usecase: Alpha support for ETC1 on android)
		color.a = tex2D(_AlphaTex, uv).r;
#endif //ETC1_EXTERNAL_ALPHA

		return color;
	}

	fixed4 frag(v2f IN) : SV_Target  
	{
		fixed4 c = SampleSpriteTexture(IN.texcoord);
		fixed4 col = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(IN.uvgrab));

		c.rgb *= c.a;
		c.rgb += IN.color * IN.color.a * c.a;
		if(c.r - col.r <= .1f  && c.g - col.g <= .1f  && c.b - col.b <= .1f )
			c.rgb = (1-col.rgb) * c.rgb;
	return c;
	}
		ENDCG
	}
	}
}
