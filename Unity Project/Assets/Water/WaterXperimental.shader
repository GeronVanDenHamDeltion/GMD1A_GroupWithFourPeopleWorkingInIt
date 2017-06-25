// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Water Xperimental" 
{
	Properties 
	{
		_Color ("Color", Color) = (0.25,0.6,0.75,0.5)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.85
		_Metallic ("Metallic", Range(0,1)) = 0.0

		_Normals1 ("Normal Map 1", 2D) = "bump" {}
		_Normals2 ("Normal Map 2", 2D) = "bump" {}

		_n1ScrollSpeed ("Normal 1 Scroll Speed", Vector) = (5,3,0,0)
		_n2ScrollSpeed ("Normal 2 Scroll Speed", Vector) = (8,-4,0,0)

		_Magnitude ("Distortion Magnitude", Range(0,1)) = 0.1

		_Extrusion ("Extrusion Amount", Range(-0.5,0.5)) = 0.05
		_Frequency ("Frequency", Range(0,8)) = 4.0
	}
	SubShader 
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Opaque" }
		ZWrite On Lighting Off Cull Off Fog { Mode Off } Blend One Zero
		LOD 200

		GrabPass { "_BackgroundTexture" }

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows
		#pragma vertex vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 4.0

		sampler2D _BackgroundTexture;

		sampler2D _MainTex;
		sampler2D _Normals1;
		sampler2D _Normals2;

		struct Input 
		{
			float2 uv_MainTex;
			float2 uv_Normals1;
			float2 uv_Normals2;
			float4 grabUV;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		float2 _n1ScrollSpeed;
		float2 _n2ScrollSpeed;

		float _Magnitude;

		float _Extrusion;
		float _Frequency;

		void vert (inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);

			//Animate the vertices of the mesh
			v.vertex.y += (sin(_Time.y * _Frequency + v.vertex.x * UNITY_PI) + cos(_Time.y * _Frequency + v.vertex.z * UNITY_PI)) * _Extrusion;

			float4 hpos = UnityObjectToClipPos (v.vertex);
			o.grabUV = ComputeGrabScreenPos(hpos);
		}


		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			//This section offsets the UVs of the 2 normal maps so we can create a scrolling waves animation
			float2 scrolledUVn1 = IN.uv_Normals1;

			float xScrollValue1 = _n1ScrollSpeed.x * _Time[0];
			float yScrollValue1 = _n1ScrollSpeed.y * _Time[0];

			scrolledUVn1 += float2(xScrollValue1, yScrollValue1);

			float2 scrolledUVn2 = IN.uv_Normals2;

			float xScrollValue2 = _n2ScrollSpeed.x * _Time[0];
			float yScrollValue2 = _n2ScrollSpeed.y * _Time[0];

			scrolledUVn2 += float2(xScrollValue2, yScrollValue2);

			fixed3 n1 = UnpackNormal(tex2D (_Normals1, scrolledUVn1));
			fixed3 n2 = UnpackNormal(tex2D (_Normals2, scrolledUVn2));

			//Combine normals 1 and 2
			//fixed3 n = normalize(n1+n2); // alternative version (more subtle effect)
			fixed3 n = normalize(fixed3(n1.r+n2.r, n1.g+n2.g, n1.b));

			half2 distortion = n.rg;

			//Change the UVs of the grabtexture for the refraction effect.
			IN.grabUV.xy += distortion * _Magnitude;

			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			// Refraction comes from grab texture and is colored based on transparancy of the water
			fixed4 r = tex2Dproj( _BackgroundTexture, UNITY_PROJ_COORD(IN.grabUV)) * lerp ( float4(0.9,0.95,1,1), _Color, c.a );
			// Refraction visibility is managed by alpha value
			fixed3 alb = lerp ( r.rgb, c.rgb, c.a );

			o.Albedo = alb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness; 
			o.Normal = n;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
